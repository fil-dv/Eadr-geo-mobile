using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsCsvCreator
{
    public class TableColumns
    {
        List<TableItem> _listTable;
        int _counter;
        public List<TableItem> ListTable { get { return _listTable; } set { _listTable = value; } }

        public TableColumns()
        {
            _listTable = new List<TableItem>();
            _counter = 0;
            InitList();
        }

        void InitList()
        {
            if (File.Exists(@"..\..\TableColumns\import_clnt_example.txt"))
            {
                _listTable.Clear();
                string str = File.ReadAllText(@"..\..\TableColumns\import_clnt_example.txt");
                string[] arr = str.Split(',');
                foreach (var item in arr)
                {
                    _listTable.Add(new TableItem { Number = (++_counter), Str = item });
                }
            }
            else
            {
                MessageBox.Show(@"Верните файл на место! TableColumns\import_clnt_example.txt");
            }
        }        
    }

    public class TableItem
    {
        public int Number { get; set; }
        public string Str { get; set; }

        public override string ToString()
        {
            return Str;
        }
    }
}
