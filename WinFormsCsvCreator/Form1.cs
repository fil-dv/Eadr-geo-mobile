using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsCsvCreator
{
    public partial class Form1 : Form
    {
        string _path;
        int _columnCount;
        List<XlsData> _listStr = new List<XlsData>();

        public Form1()
        {
            InitializeComponent();
            //this.TopMost = true;
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;
        }

        private void button_open_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.DefaultExt = ".xls";
            openfile.Filter = "Excel Files| *.xlsx; *.xls";

            var browsefile = openfile.ShowDialog();

            if (browsefile == DialogResult.OK)
            {
                _path = openfile.FileName;
                textBox_file_path.Text = _path; 

                Action action = () =>
                {
                    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                    //????????? Why so many parameters???
                    //Microsoft.Office.Interop.Excel.Workbook excelBook = excelApp.Workbooks.Open(_path, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    Microsoft.Office.Interop.Excel.Workbook excelBook = excelApp.Workbooks.Open(_path);
                    Microsoft.Office.Interop.Excel.Worksheet excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelBook.Worksheets.get_Item(1); ;
                    Microsoft.Office.Interop.Excel.Range excelRange = excelSheet.UsedRange;
                    _columnCount = excelRange.Columns.Count;

                    string strCellData = "";
                    double douCellData;
                    int rowCnt = 0;
                    int colCnt = 0;

                    int countToName = 0; // will use to create new name of collun if sach name is exist already

                    _listStr.Capacity = _columnCount;

                    for (colCnt = 1; colCnt <= _columnCount; colCnt++)
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
                        _listStr.Add(xd);
                    }

                    /////
                    int countOfRows = 3;
                    //countOfRows = excelRange.Rows.Count;
                    /////

                    if (excelRange.Rows.Count < countOfRows) countOfRows = excelRange.Rows.Count;

                    for (rowCnt = 2; rowCnt <= countOfRows; rowCnt++)
                    {
                        for (colCnt = 1; colCnt <= excelRange.Columns.Count; colCnt++)
                        {
                            XlsData xd = _listStr.Where<XlsData>(n => n.Number == colCnt).First();
                            try
                            {
                                strCellData = (string)(excelRange.Cells[rowCnt, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2;                                
                            }
                            catch (Exception)
                            {
                                douCellData = (excelRange.Cells[rowCnt, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2;
                                strCellData = strCellData + "_" + (++countToName).ToString();                               
                            }
                            xd.ListStr.Add(strCellData);
                        }                        
                    }

                    FillXslListBox();

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
            }
        }

        void FillXslListBox()
        {
            foreach (var item in _listStr)
            {
                listBox_xls.Items.Add(String.Format("{0}) {1}", item.Number, item.ToString()));
            }
        }

        private void listBox_xls_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
                
                string curStr = listBox_xls.SelectedItem.ToString();
                string[] arr = curStr.Split(')');
                int index = Convert.ToInt32(arr[0]);
                XlsData item = _listStr.Where<XlsData>(c => c.Number == index).First();
                _listStr.Remove(item);
                listBox_xls.Items.Clear();
                FillXslListBox();
                listBox_first.Items.Add(curStr);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                throw;
            }
        }
    }
}
