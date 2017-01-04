using DbLayer;
using DbLayer.Models.Insert;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScanDocsToDb
{
    public partial class Form1 : Form
    {
        string _pathToFolder = "";
        string _destPath = "";
        List<string> _addList = new List<string>();
        List<string> _pathList = new List<string>();

        public Form1()
        {
            InitializeComponent();
            //button_start.Enabled = false;
            button_rename.Enabled = false;
        }

        private void button_open_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                var browsefile = fbd.ShowDialog();

                if (browsefile == DialogResult.OK)
                {
                    _pathToFolder = fbd.SelectedPath;
                    textBox_path.Text = _pathToFolder;
                }
            }
        }

        private void textBox_path_TextChanged(object sender, EventArgs e)
        {
            if (textBox_path.Text.Length > 0)
            {
                button_start.Enabled = true;
                button_rename.Enabled = true;
            }
            else
            {
                button_start.Enabled = false;
                button_rename.Enabled = false;
            }
        }

        void PathPreparer()
        {
            _destPath = _pathToFolder.Substring(0, _pathToFolder.LastIndexOf('\\'));
            _destPath = _destPath + @"\Renamed"; 
            if (!Directory.Exists(_destPath))
            {
                Directory.CreateDirectory(_destPath);
            }
            else
            {
                DirectoryInfo di = new DirectoryInfo(_destPath);
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
            }
            DirectoryInfo dirInf = new DirectoryInfo(_pathToFolder);
            DirectoryInspector(dirInf);
        }

        void DirectoryInspector(DirectoryInfo dirInfo)
        {
            _pathList.Add(dirInfo.FullName);
            FileRenamer(dirInfo);

            if (Directory.Exists(dirInfo.FullName))
            {
                foreach (DirectoryInfo dir in dirInfo.GetDirectories())
                {
                    DirectoryInspector(dir);
                }
            }
        }


        void FileRenamer(DirectoryInfo dirInfo)
        {
            _addList.Add(dirInfo.Name);

            foreach (FileInfo file in dirInfo.GetFiles())
            {
                string newFileName = _destPath + '\\' + GetDirNames() + file.Name;
                File.Move(file.FullName, newFileName);               
            }

            if (dirInfo.GetFiles().Length < 1 && dirInfo.GetDirectories().Length < 1) // если папка пустая
            {               
                DelEmptyDirs();
            }
        }

        void DelEmptyDirs()
        {
            for(int i = _pathList.Count - 1; i>=0; --i)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(_pathList[i]);
                if (Directory.Exists(dirInfo.FullName))
                {
                    if (dirInfo.GetFiles().Length < 1 && dirInfo.GetDirectories().Length < 1) // если папка пустая
                    {
                        Directory.Delete(dirInfo.FullName);
                        for (int j = _addList.Count - 1; j >= 0; --j)
                        {
                            if (_addList[j] == dirInfo.Name)
                            {
                                _addList.RemoveAt(j);
                                break;
                            }
                        }
                        _pathList.RemoveAt(i);
                    }
                }               
            }            
        }

        string GetDirNames()
        {
            string res = "";
            foreach (var item in _addList)
            {
                res = res + item + " # ";
            }
            return res;
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            OraConnect connect = new OraConnect();
            try
            {
                connect.OpenConnect();
                //string sql = "select p.dogovor_id from suvd.projects p where p.business_n = 1532569";
                string sql = "delete from dima_imp";
                //connect.DoCommand(sql);

                QueryBuilder qb = new QueryBuilder(QueryType.Insert);
                sql = qb.BuildInsert("DIMA_IMP", new InsertValues { comment1 = "111", comment2 = "222", comment3= "333", inn = 444});
                connect.DoCommand(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_rename_Click(object sender, EventArgs e)
        {
            PathPreparer();
            RemoveThumbs();
            MessageBox.Show("Files renamed!");
        }

        void RemoveThumbs()
        {
            int i = 0;
            DirectoryInfo dirInfo = new DirectoryInfo(_destPath);
            Regex rgx = new Regex(@"Thumbs");
            foreach (FileInfo file in dirInfo.GetFiles())
            {
                bool isThumbs = rgx.IsMatch(file.Name);
                if (file.Extension == ".db"  && isThumbs)
                {
                    file.Delete();
                    i++;
                }               
            }
        }
    }
}
