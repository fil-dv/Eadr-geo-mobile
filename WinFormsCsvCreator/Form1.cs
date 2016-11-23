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
                // string[] arr = _path.Split('\\');
                textBox_file_path.Text = _path; // arr[(arr.Length - 1)];


                //Dispatcher.BeginInvoke(new ThreadStart(delegate
                //{
                //    dispatcherTimer.Start();
                //}));

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

                    DataTable dt = new DataTable();

                    for (colCnt = 1; colCnt <= _columnCount; colCnt++)
                    {
                        string strColumn = "";
                        strColumn = (string)(excelRange.Cells[1, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2;
                        try
                        {
                            dt.Columns.Add(strColumn, typeof(string));
                        }
                        catch (DuplicateNameException)
                        {
                            strColumn = strColumn + "_" + (++countToName).ToString();
                            dt.Columns.Add(strColumn, typeof(string));
                        }
                    }

                    /////
                    int countOfRows = 3;
                    //countOfRows = excelRange.Rows.Count;
                    /////

                    if (excelRange.Rows.Count < countOfRows) countOfRows = excelRange.Rows.Count;

                    for (rowCnt = 2; rowCnt <= countOfRows; rowCnt++)
                    {
                        string strData = "";
                        for (colCnt = 1; colCnt <= excelRange.Columns.Count; colCnt++)
                        {
                            try
                            {
                                strCellData = (string)(excelRange.Cells[rowCnt, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2;
                                //if(strCellData == "")
                                strData += strCellData + "|";
                            }
                            catch (Exception)
                            {
                                douCellData = (excelRange.Cells[rowCnt, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2;
                                strData += douCellData.ToString() + "|";
                            }
                        }
                        strData = strData.Remove(strData.Length - 1, 1);
                        dt.Rows.Add(strData.Split('|'));
                    }

                    dtGrid.DataSource = dt.DefaultView;
                    //var cols = dtGrid.Columns;
                    //List<DataGridLength> widts = new List<DataGridLength>();
                    //foreach (var item in cols)
                    //{
                    //    widts.Add(item.Width);

                    //}


                    //dtGrid.Columns.Add();
                    //dtGrid.Items.Add(new DataItem { Column1 = "b.1", Column2 = "b.2", Column3 = "b.3", Column4 = "b.4" });

                    try
                    {
                        excelBook.Close(true, null, null);
                        excelApp.Quit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        //throw;
                    }

                    //_isAnalyzing = false;
                    //dispatcherTimer.Stop();
                    //btnOpen.Content = "Select excel file";

                };
                Invoke(action);

                List<string> strList = new List<string>();
                strList.Add("111");
                strList.Add("222");

                List<ComboBox> comboList = new List<ComboBox>();

                for (int i = 0; i < _columnCount; ++i)
                {
                    ComboBox combo = new ComboBox();
                    foreach (var item in strList)
                    {
                        combo.Items.Add(item);
                    }
                    comboList.Add(combo);
                }

            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
