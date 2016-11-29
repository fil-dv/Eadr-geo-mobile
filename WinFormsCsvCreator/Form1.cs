using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsCsvCreator
{
    public partial class Form1 : Form
    {
        string _pathToXlsFile;
        string _pathToResultFile;
        int _columnCount;
        List<XlsData> _listXlsStr = new List<XlsData>();
        List<string> _startDbList = new List<string>();


        public Form1()
        {
            InitializeComponent();
            listBox_xls.Sorted = true;
            _pathToResultFile = @"x:\upd\Control Creator\";



            //this.TopMost = true;
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;
            InitTableColumns();
        }

        void InitTableColumns()
        {
            List<string> fileList = FilesList();
            List<string> tableNameList = new List<string>();
            foreach (var item in fileList)
            {
                string[] arr = item.Split('\\');
                string path = arr[arr.Length - 1];
                string name = path.Substring(0, path.Length - 4);
                tableNameList.Add(name);
            }
            InitComboBox(tableNameList);
            InitListBoxDB(comboBox_tables.SelectedItem.ToString());
        }

        void InitListBoxDB(string nableName)
        {
            listBox_db.Items.Clear();
            TableColumns table = new TableColumns(nableName);
            // table.ListTable.Sort((col1, col2) => col1.Str.CompareTo(col2.Str)); // Sorting
            foreach (var item in table.ListTable)
            {
                _startDbList.Add(item.Str);
                listBox_db.Items.Add(item);
                listBox_db.Enabled = false;
            }
        }

        void InitComboBox(List<string> nameList)
        {
            foreach (var item in nameList)
            {
                comboBox_tables.Items.Add(item);
            }
            //if (File.Exists(@"..\..\TableColumns\import_clnt_example.txt"))
            //{}
            if (nameList.Contains("import_clnt_example"))
            {
                comboBox_tables.SelectedItem = "import_clnt_example";
            }

        }

        string GetPathToDefaultDir()
        {
            return @"x:\upd\Control Creator\";
        }

        List<string> FilesList()
        {
            string pathToDefaultDir = GetPathToDefaultDir();
            return Directory.GetFiles(@"..\..\TableColumns\").ToList();  // path to files directory             
        }

        private void button_open_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.DefaultExt = ".xls";
            openfile.Filter = "Excel Files| *.xlsx; *.xls";

            var browsefile = openfile.ShowDialog();

            if (browsefile == DialogResult.OK)
            {
                _pathToXlsFile = openfile.FileName;
                textBox_file_path.Text = _pathToXlsFile;

                Action action = () =>
                {
                    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                    //????????? Why so many parameters???
                    //Microsoft.Office.Interop.Excel.Workbook excelBook = excelApp.Workbooks.Open(_path, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    Microsoft.Office.Interop.Excel.Workbook excelBook = excelApp.Workbooks.Open(_pathToXlsFile);
                    Microsoft.Office.Interop.Excel.Worksheet excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelBook.Worksheets.get_Item(1); ;
                    Microsoft.Office.Interop.Excel.Range excelRange = excelSheet.UsedRange;
                    _columnCount = excelRange.Columns.Count;

                    string strCellData = "";
                    double douCellData;
                    int rowCnt = 0;
                    // int colCnt = 0;

                    int countToName = 0; // will use to create new name of collun if sach name is exist already

                    _listXlsStr.Capacity = _columnCount;

                    for (int colCnt = 1; colCnt <= _columnCount; colCnt++)
                    {
                        string strColumn = "";
                        XlsData xd = new XlsData();
                        xd.Number = colCnt;
                        try
                        {
                            strColumn = (string)(excelRange.Cells[1, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2;
                        }
                        catch (DuplicateNameException)
                        {
                            strColumn = strColumn + "_" + (++countToName).ToString();
                        }
                        xd.ListStr.Add(strColumn);
                        _listXlsStr.Add(xd);
                    }

                    /////
                    int countOfRows = 3;
                    //countOfRows = excelRange.Rows.Count;
                    /////

                    if (excelRange.Rows.Count < countOfRows) countOfRows = excelRange.Rows.Count;

                    for (rowCnt = 2; rowCnt <= countOfRows; rowCnt++)
                    {
                        for (int colCnt = 1; colCnt <= excelRange.Columns.Count; colCnt++)
                        {
                            XlsData xd = _listXlsStr.Where<XlsData>(n => n.Number == colCnt).First();
                            try
                            {
                                Type type = (excelRange.Cells[rowCnt, colCnt] as Microsoft.Office.Interop.Excel.Range).Value.GetType();
                                if (type == typeof(DateTime))
                                {
                                    strCellData = (excelRange.Cells[rowCnt, colCnt] as Microsoft.Office.Interop.Excel.Range).Value.ToString("dd.MM.yyyy");
                                }
                                else
                                {
                                    strCellData = (string)(excelRange.Cells[rowCnt, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2;
                                }
                            }
                            catch (Exception)
                            {
                                var item = (excelRange.Cells[rowCnt, colCnt] as Microsoft.Office.Interop.Excel.Range).Value;
                                if (item != null)
                                {
                                    douCellData = (excelRange.Cells[rowCnt, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2;
                                    strCellData = douCellData.ToString();
                                }
                                else
                                {
                                    strCellData = "";
                                }
                            }
                            xd.ListStr.Add(strCellData);
                        }
                    }

                    FillListBox(listBox_xls);

                    try
                    {
                        excelBook.Close(true, null, null);
                        excelApp.Quit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        throw;
                    }
                };
                Invoke(action);
                listBox_db.Enabled = true;
            }
        }

        void FillListBox(ListBox lb)
        {
            foreach (var item in _listXlsStr)
            {
                if (item.Number < 10)
                {
                    lb.Items.Add(String.Format("0{0}) {1}", item.Number, item.ToString()));
                }
                //else if (item.Number >= 10 && item.Number < 100)
                //{
                //    lb.Items.Add(String.Format("0{0}) {1}", item.Number, item.ToString()));
                //}
            }
        }

        private void listBox_xls_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (listBox_xls.SelectedItem != null)
                {
                    button_xls_to_list.Enabled = true;
                }
                else
                {
                    button_xls_to_list.Enabled = false;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                throw;
            }
        }

        private void comboBox_tables_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (listBox_xls.Items.Count > 0)
            //{
            //    comboBox_tables.Enabled = true;
            //}
            //else
            //{
            //    comboBox_tables.Enabled = false;
            //}
            InitListBoxDB(comboBox_tables.SelectedItem.ToString());
        }

        int GetSelectedItemIndex(string str)
        {
            try
            {
                string[] arr = str.Split(')');
                int index = Convert.ToInt32(arr[0]);
                return index;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendXlsItem(listBox_xls, listBox_first);

            //string curStr = listBox_xls.SelectedItem.ToString();
            //int index = GetSelectedItemIndex(curStr);
            //XlsData item = _listStr.Where<XlsData>(c => c.Number == index).First();
            //_listStr.Remove(item);
            //listBox_xls.Items.Clear();
            //FillXslListBox();
            //listBox_first.Items.Add(curStr);
            //button_xls_to_list.Enabled = false;
            button_xls_to_list.Enabled = false;
        }

        void SendXlsItem(ListBox sender, ListBox receiver)
        {
            string curStr = sender.SelectedItem.ToString();
            //int ourIndex = GetSelectedItemIndex(curStr);
            //XlsData item = _listXlsStr.Where<XlsData>(c => c.Number == ourIndex).First();
            int index = sender.SelectedIndex;
            sender.Items.RemoveAt(index);
            //sender.Items.Clear();
            //FillListBox(sender);
            receiver.Items.Add(curStr);
            //SortListBox(receiver);
            //receiver.Sorted = true; // ((col1, col2) => col1.Str.CompareTo(col2.Str)); // Sorting

            if (listBox_first.Items.Count == listBox_second.Items.Count)
            {
                button_create_ctl.Enabled = true;
            }
            else
            {
                button_create_ctl.Enabled = false;
            }

        }

        //void SortListBox(ListBox lb)
        //{
        //    List<object> q = new List<object>();
        //    foreach (object o in lb.Items)
        //    { 
        //        q.Add(o);
        //    }
        //    q.Sort((col1, col2) => col1.ToString().CompareTo(col2.ToString()));
        //    lb.Items.Clear();
        //    foreach (object o in q)
        //    {
        //        lb.Items.Add(o);
        //    }        
        //}




        private void listBox_first_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_first.SelectedItem != null)
            {
                button_from_list_to_exel.Enabled = true;
            }
            else
            {
                button_from_list_to_exel.Enabled = false;
            }
        }

        private void button_from_list_to_exel_Click(object sender, EventArgs e)
        {
            if (listBox_first.SelectedItem != null)
            {
                SendXlsItem(listBox_first, listBox_xls);
                button_from_list_to_exel.Enabled = false;
            }
        }

        private void listBox_db_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_db.SelectedItem != null)
            {
                button_from_db_to_list.Enabled = true;
            }
            else
            {
                button_from_db_to_list.Enabled = false;
            }
        }

        private void button_from_db_to_list_Click(object sender, EventArgs e)
        {
            SendXlsItem(listBox_db, listBox_second);
            button_from_db_to_list.Enabled = false;
        }

        private void listBox_second_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_second.SelectedItem != null)
            {
                button_from_list_to_db.Enabled = true;
            }
            else
            {
                button_from_list_to_db.Enabled = false;
            }

        }

        private void button_from_list_to_db_Click(object sender, EventArgs e)
        {
            SendXlsItem(listBox_second, listBox_db);
            button_from_db_to_list.Enabled = false;
        }

        private void button_create_ctl_Click(object sender, EventArgs e)
        {
            StringBuilder builder = CreateHead();

            List<string> resultList = new List<string>();
            int index;
            foreach (var item in listBox_first.Items)
            {
                index = GetSelectedItemIndex(item.ToString());
                //resultList.Add(_startDbList[index-1]);
                builder.Append(_startDbList[index - 1]);
                builder.Append(",\n");
            }
            builder.Append("\n)");
            string resultString = builder.ToString();


        }

        void CreateResultFile()
        {

        }

        StringBuilder CreateHead()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(@"LOAD DATA
INFILE '");
            builder.Append(textBox_file_name.Text);
            builder.Append(@"'
REPLACE
INTO TABLE ");
            builder.Append(comboBox_tables.Text);
            builder.Append(@"
FIELDS TERMINATED BY ';'
TRAILING NULLCOLS
(");
            return builder;
        }

        private void inputFileNameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pathToResultFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog opendir = new FolderBrowserDialog();

            var browsefile = opendir.ShowDialog();

            if (browsefile == DialogResult.OK)
            {
                _pathToResultFile = opendir.SelectedPath;
            }
        }
    }
}
