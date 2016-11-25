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
            this.button1 = new System.Windows.Forms.Button();
            this.listBox_first = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox_db = new System.Windows.Forms.ListBox();
            this.listBox_xls = new System.Windows.Forms.ListBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_tables = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBox_file_path
            // 
            this.textBox_file_path.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_file_path.Location = new System.Drawing.Point(126, 30);
            this.textBox_file_path.Name = "textBox_file_path";
            this.textBox_file_path.ReadOnly = true;
            this.textBox_file_path.Size = new System.Drawing.Size(475, 26);
            this.textBox_file_path.TabIndex = 0;
            // 
            // button_open
            // 
            this.button_open.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_open.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_open.Location = new System.Drawing.Point(612, 28);
            this.button_open.Name = "button_open";
            this.button_open.Size = new System.Drawing.Size(96, 30);
            this.button_open.TabIndex = 1;
            this.button_open.Text = "Open";
            this.button_open.UseVisualStyleBackColor = true;
            this.button_open.Click += new System.EventHandler(this.button_open_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(416, 105);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 125);
            this.button1.TabIndex = 3;
            this.button1.Text = "->";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // listBox_first
            // 
            this.listBox_first.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox_first.FormattingEnabled = true;
            this.listBox_first.Location = new System.Drawing.Point(462, 72);
            this.listBox_first.Name = "listBox_first";
            this.listBox_first.Size = new System.Drawing.Size(120, 407);
            this.listBox_first.TabIndex = 5;
            // 
            // listBox2
            // 
            this.listBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(588, 72);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(120, 407);
            this.listBox2.TabIndex = 6;
            // 
            // listBox_db
            // 
            this.listBox_db.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_db.FormattingEnabled = true;
            this.listBox_db.Location = new System.Drawing.Point(772, 72);
            this.listBox_db.Name = "listBox_db";
            this.listBox_db.Size = new System.Drawing.Size(239, 407);
            this.listBox_db.TabIndex = 7;
            // 
            // listBox_xls
            // 
            this.listBox_xls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox_xls.FormattingEnabled = true;
            this.listBox_xls.Location = new System.Drawing.Point(36, 72);
            this.listBox_xls.Name = "listBox_xls";
            this.listBox_xls.Size = new System.Drawing.Size(361, 407);
            this.listBox_xls.TabIndex = 10;
            this.listBox_xls.SelectedIndexChanged += new System.EventHandler(this.listBox_xls_SelectedIndexChanged);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button5.Location = new System.Drawing.Point(416, 273);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(31, 125);
            this.button5.TabIndex = 11;
            this.button5.Text = "<-";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.Location = new System.Drawing.Point(723, 273);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(31, 125);
            this.button6.TabIndex = 13;
            this.button6.Text = "->";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.Location = new System.Drawing.Point(723, 105);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(31, 125);
            this.button7.TabIndex = 12;
            this.button7.Text = "<-";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(32, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Path to file:";
            // 
            // comboBox_tables
            // 
            this.comboBox_tables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_tables.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_tables.FormattingEnabled = true;
            this.comboBox_tables.Location = new System.Drawing.Point(772, 28);
            this.comboBox_tables.Name = "comboBox_tables";
            this.comboBox_tables.Size = new System.Drawing.Size(239, 28);
            this.comboBox_tables.TabIndex = 15;
            this.comboBox_tables.SelectedIndexChanged += new System.EventHandler(this.comboBox_tables_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 525);
            this.Controls.Add(this.comboBox_tables);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.listBox_xls);
            this.Controls.Add(this.listBox_db);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox_first);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_open);
            this.Controls.Add(this.textBox_file_path);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Control creator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_file_path;
        private System.Windows.Forms.Button button_open;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox_first;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox_db;
        private System.Windows.Forms.ListBox listBox_xls;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_tables;
    }
}

