namespace LaoBernardBSCS3A_AdvDBMS_SE_Project
{
    partial class frmStudent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStudent));
            this.label1 = new System.Windows.Forms.Label();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.txtMName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.dtpBday = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLRN = new System.Windows.Forms.TextBox();
            this.gpbStudentList = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lstStudents = new System.Windows.Forms.ListView();
            this.clLRN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clFullname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clBirthday = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clGender = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gpbStudentList.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Last Name :";
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(141, 30);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(189, 27);
            this.txtLName.TabIndex = 1;
            this.txtLName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMName_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "First Name :";
            // 
            // txtFName
            // 
            this.txtFName.Location = new System.Drawing.Point(141, 72);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(189, 27);
            this.txtFName.TabIndex = 3;
            this.txtFName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMName_KeyPress);
            // 
            // txtMName
            // 
            this.txtMName.Location = new System.Drawing.Point(141, 115);
            this.txtMName.Name = "txtMName";
            this.txtMName.Size = new System.Drawing.Size(189, 27);
            this.txtMName.TabIndex = 5;
            this.txtMName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMName_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Middle Name :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(385, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Birthday :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(385, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "Gender :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 19);
            this.label6.TabIndex = 8;
            this.label6.Text = "Address :";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(141, 160);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(189, 69);
            this.txtAddress.TabIndex = 9;
            // 
            // cmbGender
            // 
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cmbGender.Location = new System.Drawing.Point(463, 30);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(121, 27);
            this.cmbGender.TabIndex = 10;
            // 
            // dtpBday
            // 
            this.dtpBday.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBday.Location = new System.Drawing.Point(463, 72);
            this.dtpBday.Name = "dtpBday";
            this.dtpBday.Size = new System.Drawing.Size(120, 27);
            this.dtpBday.TabIndex = 11;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(444, 197);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(139, 32);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(385, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 19);
            this.label7.TabIndex = 13;
            this.label7.Text = "LRN  :";
            // 
            // txtLRN
            // 
            this.txtLRN.Location = new System.Drawing.Point(463, 115);
            this.txtLRN.MaxLength = 12;
            this.txtLRN.Name = "txtLRN";
            this.txtLRN.Size = new System.Drawing.Size(121, 27);
            this.txtLRN.TabIndex = 14;
            this.txtLRN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLRN4_KeyPress);
            // 
            // gpbStudentList
            // 
            this.gpbStudentList.Controls.Add(this.btnSearch);
            this.gpbStudentList.Controls.Add(this.txtSearch);
            this.gpbStudentList.Controls.Add(this.label9);
            this.gpbStudentList.Controls.Add(this.label8);
            this.gpbStudentList.Controls.Add(this.lstStudents);
            this.gpbStudentList.Location = new System.Drawing.Point(12, 235);
            this.gpbStudentList.Name = "gpbStudentList";
            this.gpbStudentList.Size = new System.Drawing.Size(632, 376);
            this.gpbStudentList.TabIndex = 19;
            this.gpbStudentList.TabStop = false;
            this.gpbStudentList.Text = "Student List";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(480, 29);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(139, 28);
            this.btnSearch.TabIndex = 28;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(285, 29);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(189, 27);
            this.txtSearch.TabIndex = 27;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLRN4_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(166, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 19);
            this.label9.TabIndex = 26;
            this.label9.Text = "Search by LRN : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(16, 354);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(192, 15);
            this.label8.TabIndex = 25;
            this.label8.Text = "Note : Double-click an item to edit";
            // 
            // lstStudents
            // 
            this.lstStudents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clLRN,
            this.clFullname,
            this.clBirthday,
            this.clGender});
            this.lstStudents.FullRowSelect = true;
            this.lstStudents.GridLines = true;
            this.lstStudents.Location = new System.Drawing.Point(20, 62);
            this.lstStudents.Name = "lstStudents";
            this.lstStudents.Size = new System.Drawing.Size(599, 289);
            this.lstStudents.TabIndex = 24;
            this.lstStudents.UseCompatibleStateImageBehavior = false;
            this.lstStudents.View = System.Windows.Forms.View.Details;
            this.lstStudents.DoubleClick += new System.EventHandler(this.lstStudents_DoubleClick);
            // 
            // clLRN
            // 
            this.clLRN.Text = "LRN #";
            this.clLRN.Width = 130;
            // 
            // clFullname
            // 
            this.clFullname.Text = "Fullname";
            this.clFullname.Width = 240;
            // 
            // clBirthday
            // 
            this.clBirthday.Text = "Birth Date";
            this.clBirthday.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clBirthday.Width = 120;
            // 
            // clGender
            // 
            this.clGender.Text = "Gender";
            this.clGender.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clGender.Width = 80;
            // 
            // frmStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(656, 618);
            this.Controls.Add(this.gpbStudentList);
            this.Controls.Add(this.txtLRN);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpBday);
            this.Controls.Add(this.cmbGender);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmStudent_FormClosing);
            this.Load += new System.EventHandler(this.frmStudent_Load);
            this.gpbStudentList.ResumeLayout(false);
            this.gpbStudentList.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.TextBox txtMName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.DateTimePicker dtpBday;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtLRN;
        private System.Windows.Forms.GroupBox gpbStudentList;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView lstStudents;
        private System.Windows.Forms.ColumnHeader clLRN;
        private System.Windows.Forms.ColumnHeader clFullname;
        private System.Windows.Forms.ColumnHeader clBirthday;
        private System.Windows.Forms.ColumnHeader clGender;
    }
}