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
        const string _tableName = "DIMA_IMP";
        string _pathToFolder = "";
        string _renamedPath = ""; // @"d:\!!!\Renamed";
        string _restructedPath = "";  //@"d:\!!!\Restructed";

        List<string> _addList = new List<string>();
        List<string> _pathList = new List<string>();
        List<InsertValues> _listValuesToDB = new List<InsertValues>();

        public Form1()
        {
            InitializeComponent();
            button_start.Enabled = false;
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
            _renamedPath = _pathToFolder.Substring(0, _pathToFolder.LastIndexOf('\\'));
            _renamedPath = _renamedPath + @"\Renamed"; 
            if (!Directory.Exists(_renamedPath))
            {
                Directory.CreateDirectory(_renamedPath);
            }
            else
            {
                DirectoryInfo di = new DirectoryInfo(_renamedPath);
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
                string newFileName = _renamedPath + '\\' + GetDirNames() + file.Name;
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
                string sql = "delete from " + _tableName;
                connect.DoCommand(sql);

                QueryBuilder qb = new QueryBuilder(QueryType.Insert);
                foreach (var item in _listValuesToDB)
                {
                    sql = qb.BuildInsert(_tableName, item);
                    connect.DoCommand(sql);
                }
                MessageBox.Show(String.Format("Записи залиты в таблицу {0} ({1} шт.)", _tableName, _listValuesToDB.Count.ToString()));
                DefaultSettings();        
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void DefaultSettings()
        {
            textBox_path.Text = "";
            button_start.Enabled = false;
            button_rename.Enabled = false;
        }

        private void button_rename_Click(object sender, EventArgs e)
        {
            PathPreparer();
            RemoveThumbs();
            MessageBox.Show("Готово!");
            button_start.Enabled = true;
        }

        void GetDogovorIdList()
        {
            _restructedPath = _pathToFolder.Substring(0, _pathToFolder.LastIndexOf('\\'));
            _restructedPath = _restructedPath + @"\Restructed";

            DirectoryInfo dirInfo = new DirectoryInfo(_renamedPath);
            Regex rgx = new Regex(@"\d{9}");
            List<string> matchList = new List<string>();
            foreach (FileInfo file in dirInfo.GetFiles())
            {
                if (rgx.IsMatch(file.Name))
                {
                    Match match = rgx.Match(file.Name);
                    string matchStr = match.Value;
                    if (!matchList.Contains(matchStr))
                    {
                        matchList.Add(matchStr);
                    }
                }
            }
            CreateNewFolders(matchList);
        }

        void CreateNewFolders(List<string> list)
        {
            foreach (var item in list)
            {
                if (!Directory.Exists(_restructedPath + "\\" + item))
                {
                    Directory.CreateDirectory(_restructedPath + "\\" + item);
                }
            }
            FileMover();
        }

        void FileMover()
        {
            int count = 0;
            DirectoryInfo dirInfo = new DirectoryInfo(_renamedPath);            
            foreach (FileInfo file in dirInfo.GetFiles())
            {
                string soursPath = file.FullName;                
                Regex rgx = new Regex(@"\d{9}");
                if (rgx.IsMatch(file.Name))
                {
                    Match match = rgx.Match(file.Name);
                    string matchStr = match.Value;
                    string cutFileName = file.Name.Substring(file.Name.LastIndexOf('#')).TrimStart(new char[] { '#', ' '});
                    string destPath = _restructedPath + "\\" + matchStr + "\\" + cutFileName;
                    while (File.Exists(destPath))
                    {
                        string bit = "_";
                        cutFileName = bit + cutFileName;
                        destPath = _restructedPath + "\\" + matchStr + "\\" + cutFileName;
                        bit = bit  +  "_";
                        count++;
                    }
                    InsertValues insertValue = new InsertValues();
                    insertValue.Dogovor_ID = matchStr;
                    insertValue.comment1 = matchStr + "\\" + cutFileName;
                    _listValuesToDB.Add(insertValue);
                    File.Move(soursPath, destPath);
                }
            }
            MessageBox.Show(String.Format("Количество дублей имен файлов = {0}", count.ToString()));
        }

        void RemoveThumbs()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(_renamedPath);
            Regex rgx = new Regex(@"Thumbs");
            foreach (FileInfo file in dirInfo.GetFiles())
            {
                bool isThumbs = rgx.IsMatch(file.Name);
                if (file.Extension == ".db"  && isThumbs)
                {
                    file.Delete();
                }               
            }
            GetDogovorIdList();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
