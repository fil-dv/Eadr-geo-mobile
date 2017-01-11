using DbLayer;
using DbLayer.Models.Insert;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
        bool _isReadyOpenFile = false;
        bool _isReadyStoragePath = false;

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
            if (textBox_path.Text.Length > 0 )
            {
                _isReadyOpenFile = true;
                if (_isReadyStoragePath)
                {
                    button_rename.Enabled = true;
                }
                else
                {
                    button_start.Enabled = false;
                    button_rename.Enabled = false;
                }
            }
            else
            {                
                _isReadyOpenFile = false;
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
            //int count = 0;
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
                        string bit = "__|__";
                        cutFileName = bit + cutFileName;
                        destPath = _restructedPath + "\\" + matchStr + "\\" + cutFileName;
                        bit = bit + bit;
                       //count++;
                    }              

                    File.Move(soursPath, destPath);
                }
            }
            //MessageBox.Show(String.Format("Количество дублей имен файлов = {0}", count.ToString()));
            DeleteDoubleFiles();
        }

        //byte[] GetFileCheckSum(string filename)
        //{
        //    using (var md5 = MD5.Create())
        //    {
        //        using (var stream = File.OpenRead(filename))
        //        {
        //            return md5.ComputeHash(stream);
        //        }
        //    }
        //}

        void DeleteDoubleFiles()
        {
            int counter = 0;
            DirectoryInfo di = new DirectoryInfo(_restructedPath);
            foreach (DirectoryInfo dirInfo in di.GetDirectories())
            {
                foreach (FileInfo file in dirInfo.GetFiles())
                {
                    if (file.Name.Substring(0, 1) == "_")
                    {
                        CheckDoubles(dirInfo, file, ref counter);
                    }
                }
            }
            int res = counter;
           // ReplaceUkrSymbols();
            InitDataForDB();
        }

        //string Translit(string str)
        //{
        //    string[] lat_up = { "A", "B", "V", "G", "D", "E", "Yo", "Zh", "Z", "I", "Y", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "F", "Kh", "Ts", "Ch", "Sh", "Shch", "\"", "Y", "'", "E", "Yu", "Ya" };
        //    string[] lat_low = { "a", "b", "v", "g", "d", "e", "yo", "zh", "z", "i", "y", "k", "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "kh", "ts", "ch", "sh", "shch", "\"", "y", "'", "e", "yu", "ya" };
        //    string[] rus_up = { "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я" };
        //    string[] rus_low = { "а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я"};
        //    for (int i = 0; i <= 32; i++)
        //    {
        //        str = str.Replace(rus_up[i], lat_up[i]);
        //        str = str.Replace(rus_low[i], lat_low[i]);
        //        str = str.Replace('і', '_');
        //        str = str.Replace('І', '_');
        //        str = str.Replace('ї', '_');
        //        str = str.Replace('Ї', '_');
        //        str = str.Replace('є', '_');
        //        str = str.Replace('Є', '_');
        //        str = str.Replace(' ', '_');
        //        str = str.Replace(',', '_');
        //        str = str.Replace('\'', '_');                
        //    }
        //    return str;
        //}

        //void ReplaceUkrSymbols()
        //{
        //    DirectoryInfo di = new DirectoryInfo(_restructedPath);
        //    foreach (DirectoryInfo dirInfo in di.GetDirectories())
        //    {
        //        foreach (FileInfo file in dirInfo.GetFiles())
        //        {
        //            string translitStr = Translit(file.Name);
        //            File.Move(file.FullName, dirInfo.FullName + '\\' + translitStr);
        //        }
        //    }
        //}

        void InitDataForDB()
        {
            int counter = 0;
            DirectoryInfo di = new DirectoryInfo(_restructedPath);
            int counterAsFileName = 0;
            string ext = "";
            foreach (DirectoryInfo dirInfo in di.GetDirectories())
            {
                foreach (FileInfo file in dirInfo.GetFiles())
                {
                    ext = file.Extension;
                    InsertValues insertValue = new InsertValues();
                    insertValue.Dogovor_ID = dirInfo.Name;
                    insertValue.comment1 = file.Name;
                    insertValue.comment2 = textBox1.Text + "/" + dirInfo.Name + "/" + (++counterAsFileName) + ext; 
                    insertValue.comment3 = counterAsFileName + ext;
                    insertValue.comment4 = file.Length;
                    _listValuesToDB.Add(insertValue);
                    counter++;

                    string newName = counterAsFileName + ext;
                    File.Move(file.FullName, dirInfo.FullName + '\\' + newName);
                }
            }
            int stop = counter;
        }
        
        void CheckDoubles(DirectoryInfo dirInfo, FileInfo currentFile, ref int counter)
        {
            foreach (var item in dirInfo.GetFiles())
            {
                if (item.FullName != currentFile.FullName)
                {
                    if (item.Length == currentFile.Length)
                    {
                        File.Delete(currentFile.FullName);
                        counter++;                     
                    }
                }
            }
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (Char.IsNumber(textBox1.Text[textBox1.Text.Length - 1]))
            {
                _isReadyStoragePath = true;
                if (_isReadyOpenFile)
                {
                    button_rename.Enabled = true;
                }
                else
                {
                    button_rename.Enabled = false;
                }                   
            }
            else
            {
                button_rename.Enabled = false;
                _isReadyStoragePath = false;
            }
        }
    }
}
