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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScanDocsToDb
{
    public partial class Form1 : Form
    {
        string _pathToFolder = "";
        string _destPath = "";

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
            _destPath = _destPath + @"\Structured"; 
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
            FileRenamer(dirInfo);  
                     
            foreach (DirectoryInfo dir in dirInfo.GetDirectories())
            {
                DirectoryInspector(dir);
            }
        }

        void FileRenamer(DirectoryInfo dirInfo)
        {            
            foreach (FileInfo file in dirInfo.GetFiles())
            {
                string parrentDirName = file.DirectoryName.Substring(file.DirectoryName.LastIndexOf('\\') + 1);
                string ext = file.Extension;
                string FileNameNoExt = file.FullName.Substring(0, file.FullName.LastIndexOf('.'));
                string newFileName = FileNameNoExt + "#" + parrentDirName + "#" + ext;
                File.Move(file.FullName, newFileName);
            }
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
            MessageBox.Show("Files renamed!");
        }
    }
}
