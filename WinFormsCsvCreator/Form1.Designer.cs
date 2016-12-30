namespace WinFormsCsvCreator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox_file_path = new System.Windows.Forms.TextBox();
            this.button_open = new System.Windows.Forms.Button();
            this.button_xls_to_list = new System.Windows.Forms.Button();
            this.listBox_first = new System.Windows.Forms.ListBox();
            this.listBox_second = new System.Windows.Forms.ListBox();
            this.listBox_db = new System.Windows.Forms.ListBox();
            this.listBox_xls = new System.Windows.Forms.ListBox();
            this.button_from_list_to_exel = new System.Windows.Forms.Button();
            this.button_from_list_to_db = new System.Windows.Forms.Button();
            this.button_from_db_to_list = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_tables = new System.Windows.Forms.ComboBox();
            this.button_create_ctl = new System.Windows.Forms.Button();
            this.textBox_file_name = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputFileNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pathToResultFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_path_to_dir = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_input_file = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_file_path
            // 
            this.textBox_file_path.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_file_path.Location = new System.Drawing.Point(126, 59);
            this.textBox_file_path.Name = "textBox_file_path";
            this.textBox_file_path.ReadOnly = true;
            this.textBox_file_path.Size = new System.Drawing.Size(492, 26);
            this.textBox_file_path.TabIndex = 0;
            // 
            // button_open
            // 
            this.button_open.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_open.Location = new System.Drawing.Point(646, 57);
            this.button_open.Name = "button_open";
            this.button_open.Size = new System.Drawing.Size(151, 32);
            this.button_open.TabIndex = 1;
            this.button_open.Text = "Open";
            this.button_open.UseVisualStyleBackColor = true;
            this.button_open.Click += new System.EventHandler(this.button_open_Click);
            // 
            // button_xls_to_list
            // 
            this.button_xls_to_list.Enabled = false;
            this.button_xls_to_list.Location = new System.Drawing.Point(416, 172);
            this.button_xls_to_list.Name = "button_xls_to_list";
            this.button_xls_to_list.Size = new System.Drawing.Size(31, 125);
            this.button_xls_to_list.TabIndex = 3;
            this.button_xls_to_list.Text = "->";
            this.button_xls_to_list.UseVisualStyleBackColor = true;
            this.button_xls_to_list.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox_first
            // 
            this.listBox_first.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_first.FormattingEnabled = true;
            this.listBox_first.Location = new System.Drawing.Point(462, 114);
            this.listBox_first.Name = "listBox_first";
            this.listBox_first.Size = new System.Drawing.Size(156, 394);
            this.listBox_first.TabIndex = 5;
            this.listBox_first.SelectedIndexChanged += new System.EventHandler(this.listBox_first_SelectedIndexChanged);
            // 
            // listBox_second
            // 
            this.listBox_second.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_second.FormattingEnabled = true;
            this.listBox_second.Location = new System.Drawing.Point(646, 114);
            this.listBox_second.Name = "listBox_second";
            this.listBox_second.Size = new System.Drawing.Size(151, 394);
            this.listBox_second.TabIndex = 6;
            this.listBox_second.SelectedIndexChanged += new System.EventHandler(this.listBox_second_SelectedIndexChanged);
            // 
            // listBox_db
            // 
            this.listBox_db.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_db.FormattingEnabled = true;
            this.listBox_db.Location = new System.Drawing.Point(863, 114);
            this.listBox_db.Name = "listBox_db";
            this.listBox_db.Size = new System.Drawing.Size(239, 394);
            this.listBox_db.TabIndex = 7;
            this.listBox_db.SelectedIndexChanged += new System.EventHandler(this.listBox_db_SelectedIndexChanged);
            // 
            // listBox_xls
            // 
            this.listBox_xls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox_xls.FormattingEnabled = true;
            this.listBox_xls.HorizontalScrollbar = true;
            this.listBox_xls.Location = new System.Drawing.Point(36, 114);
            this.listBox_xls.Name = "listBox_xls";
            this.listBox_xls.Size = new System.Drawing.Size(361, 394);
            this.listBox_xls.TabIndex = 10;
            this.listBox_xls.SelectedIndexChanged += new System.EventHandler(this.listBox_xls_SelectedIndexChanged);
            // 
            // button_from_list_to_exel
            // 
            this.button_from_list_to_exel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_from_list_to_exel.Enabled = false;
            this.button_from_list_to_exel.Location = new System.Drawing.Point(416, 334);
            this.button_from_list_to_exel.Name = "button_from_list_to_exel";
            this.button_from_list_to_exel.Size = new System.Drawing.Size(31, 125);
            this.button_from_list_to_exel.TabIndex = 11;
            this.button_from_list_to_exel.Text = "<-";
            this.button_from_list_to_exel.UseVisualStyleBackColor = true;
            this.button_from_list_to_exel.Click += new System.EventHandler(this.button_from_list_to_exel_Click);
            // 
            // button_from_list_to_db
            // 
            this.button_from_list_to_db.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_from_list_to_db.Enabled = false;
            this.button_from_list_to_db.Location = new System.Drawing.Point(814, 355);
            this.button_from_list_to_db.Name = "button_from_list_to_db";
            this.button_from_list_to_db.Size = new System.Drawing.Size(31, 125);
            this.button_from_list_to_db.TabIndex = 13;
            this.button_from_list_to_db.Text = "->";
            this.button_from_list_to_db.UseVisualStyleBackColor = true;
            this.button_from_list_to_db.Click += new System.EventHandler(this.button_from_list_to_db_Click);
            // 
            // button_from_db_to_list
            // 
            this.button_from_db_to_list.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_from_db_to_list.Enabled = false;
            this.button_from_db_to_list.Location = new System.Drawing.Point(814, 172);
            this.button_from_db_to_list.Name = "button_from_db_to_list";
            this.button_from_db_to_list.Size = new System.Drawing.Size(31, 125);
            this.button_from_db_to_list.TabIndex = 12;
            this.button_from_db_to_list.Text = "<-";
            this.button_from_db_to_list.UseVisualStyleBackColor = true;
            this.button_from_db_to_list.Click += new System.EventHandler(this.button_from_db_to_list_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(32, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Path to file:";
            // 
            // comboBox_tables
            // 
            this.comboBox_tables.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_tables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_tables.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_tables.FormattingEnabled = true;
            this.comboBox_tables.Location = new System.Drawing.Point(863, 61);
            this.comboBox_tables.Name = "comboBox_tables";
            this.comboBox_tables.Size = new System.Drawing.Size(239, 28);
            this.comboBox_tables.TabIndex = 15;
            this.comboBox_tables.SelectedIndexChanged += new System.EventHandler(this.comboBox_tables_SelectedIndexChanged);
            // 
            // button_create_ctl
            // 
            this.button_create_ctl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_create_ctl.Enabled = false;
            this.button_create_ctl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_create_ctl.Location = new System.Drawing.Point(863, 533);
            this.button_create_ctl.Name = "button_create_ctl";
            this.button_create_ctl.Size = new System.Drawing.Size(239, 36);
            this.button_create_ctl.TabIndex = 16;
            this.button_create_ctl.Text = "Create control";
            this.button_create_ctl.UseVisualStyleBackColor = true;
            this.button_create_ctl.Click += new System.EventHandler(this.button_create_ctl_Click);
            // 
            // textBox_file_name
            // 
            this.textBox_file_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox_file_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_file_name.Location = new System.Drawing.Point(711, 683);
            this.textBox_file_name.Name = "textBox_file_name";
            this.textBox_file_name.Size = new System.Drawing.Size(110, 26);
            this.textBox_file_name.TabIndex = 17;
            this.textBox_file_name.Text = "imp.csv";
            this.textBox_file_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(36, 693);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(361, 26);
            this.textBox1.TabIndex = 18;
            this.textBox1.Text = "imp.csv";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1143, 29);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inputFileNameToolStripMenuItem,
            this.pathToResultFileToolStripMenuItem});
            this.настройкиToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(78, 25);
            this.настройкиToolStripMenuItem.Text = "Settings";
            // 
            // inputFileNameToolStripMenuItem
            // 
            this.inputFileNameToolStripMenuItem.Name = "inputFileNameToolStripMenuItem";
            this.inputFileNameToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.inputFileNameToolStripMenuItem.Text = "Input file name";
            this.inputFileNameToolStripMenuItem.Click += new System.EventHandler(this.inputFileNameToolStripMenuItem_Click);
            // 
            // pathToResultFileToolStripMenuItem
            // 
            this.pathToResultFileToolStripMenuItem.Name = "pathToResultFileToolStripMenuItem";
            this.pathToResultFileToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.pathToResultFileToolStripMenuItem.Text = "Path to result file";
            this.pathToResultFileToolStripMenuItem.Click += new System.EventHandler(this.pathToResultFileToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(64, 25);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel_path_to_dir,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel_input_file,
            this.toolStripStatusLabel4});
            this.statusStrip1.Location = new System.Drawing.Point(0, 585);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1143, 22);
            this.statusStrip1.TabIndex = 23;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(99, 17);
            this.toolStripStatusLabel1.Text = "Path to result file:";
            // 
            // toolStripStatusLabel_path_to_dir
            // 
            this.toolStripStatusLabel_path_to_dir.Name = "toolStripStatusLabel_path_to_dir";
            this.toolStripStatusLabel_path_to_dir.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(90, 17);
            this.toolStripStatusLabel3.Text = "Input file name:";
            // 
            // toolStripStatusLabel_input_file
            // 
            this.toolStripStatusLabel_input_file.Name = "toolStripStatusLabel_input_file";
            this.toolStripStatusLabel_input_file.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel4.Text = "|";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 607);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox_file_name);
            this.Controls.Add(this.button_create_ctl);
            this.Controls.Add(this.comboBox_tables);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_from_list_to_db);
            this.Controls.Add(this.button_from_db_to_list);
            this.Controls.Add(this.button_from_list_to_exel);
            this.Controls.Add(this.listBox_xls);
            this.Controls.Add(this.listBox_db);
            this.Controls.Add(this.listBox_second);
            this.Controls.Add(this.listBox_first);
            this.Controls.Add(this.button_xls_to_list);
            this.Controls.Add(this.button_open);
            this.Controls.Add(this.textBox_file_path);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control creator";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_file_path;
        private System.Windows.Forms.Button button_open;
        private System.Windows.Forms.Button button_xls_to_list;
        private System.Windows.Forms.ListBox listBox_first;
        private System.Windows.Forms.ListBox listBox_second;
        private System.Windows.Forms.ListBox listBox_db;
        private System.Windows.Forms.ListBox listBox_xls;
        private System.Windows.Forms.Button button_from_list_to_exel;
        private System.Windows.Forms.Button button_from_list_to_db;
        private System.Windows.Forms.Button button_from_db_to_list;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_tables;
        private System.Windows.Forms.Button button_create_ctl;
        private System.Windows.Forms.TextBox textBox_file_name;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inputFileNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pathToResultFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_path_to_dir;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_input_file;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
    }
}

