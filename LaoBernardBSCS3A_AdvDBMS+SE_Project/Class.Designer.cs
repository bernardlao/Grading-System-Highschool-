namespace LaoBernardBSCS3A_AdvDBMS_SE_Project
{
    partial class frmClass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClass));
            this.cmbSubject = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbYearSec = new System.Windows.Forms.ComboBox();
            this.gpbSchoolyear = new System.Windows.Forms.GroupBox();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbFilterBy = new System.Windows.Forms.ComboBox();
            this.lstStudents = new System.Windows.Forms.ListView();
            this.clLrn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clFullname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gpbTime = new System.Windows.Forms.GroupBox();
            this.dtpTTo = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpTFrom = new System.Windows.Forms.DateTimePicker();
            this.gpbSchoolMonth = new System.Windows.Forms.GroupBox();
            this.dtpMonthEnd = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpMonthStart = new System.Windows.Forms.DateTimePicker();
            this.gpbSchoolyear.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gpbTime.SuspendLayout();
            this.gpbSchoolMonth.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbSubject
            // 
            this.cmbSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubject.FormattingEnabled = true;
            this.cmbSubject.Location = new System.Drawing.Point(142, 12);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.Size = new System.Drawing.Size(271, 27);
            this.cmbSubject.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Subjects : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Year && Section : ";
            // 
            // cmbYearSec
            // 
            this.cmbYearSec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYearSec.FormattingEnabled = true;
            this.cmbYearSec.Location = new System.Drawing.Point(142, 45);
            this.cmbYearSec.Name = "cmbYearSec";
            this.cmbYearSec.Size = new System.Drawing.Size(271, 27);
            this.cmbYearSec.TabIndex = 2;
            // 
            // gpbSchoolyear
            // 
            this.gpbSchoolyear.Controls.Add(this.dtpTo);
            this.gpbSchoolyear.Controls.Add(this.label4);
            this.gpbSchoolyear.Controls.Add(this.label3);
            this.gpbSchoolyear.Controls.Add(this.dtpFrom);
            this.gpbSchoolyear.Location = new System.Drawing.Point(461, 1);
            this.gpbSchoolyear.Name = "gpbSchoolyear";
            this.gpbSchoolyear.Size = new System.Drawing.Size(344, 57);
            this.gpbSchoolyear.TabIndex = 4;
            this.gpbSchoolyear.TabStop = false;
            this.gpbSchoolyear.Text = "School Year";
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "yyyy";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(242, 24);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.ShowUpDown = true;
            this.dtpTo.Size = new System.Drawing.Size(64, 27);
            this.dtpTo.TabIndex = 6;
            this.dtpTo.TabStop = false;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(195, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 19);
            this.label4.TabIndex = 10;
            this.label4.Text = "To :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "From :";
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "yyyy";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(92, 24);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.ShowUpDown = true;
            this.dtpFrom.Size = new System.Drawing.Size(64, 27);
            this.dtpFrom.TabIndex = 5;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtSearch);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cmbFilterBy);
            this.groupBox2.Controls.Add(this.lstStudents);
            this.groupBox2.Location = new System.Drawing.Point(12, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(793, 460);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Students";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(643, 427);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 27);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(341, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 19);
            this.label6.TabIndex = 6;
            this.label6.Text = "Search :";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(417, 32);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(144, 27);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(567, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Filter By :";
            // 
            // cmbFilterBy
            // 
            this.cmbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterBy.FormattingEnabled = true;
            this.cmbFilterBy.Location = new System.Drawing.Point(643, 32);
            this.cmbFilterBy.Name = "cmbFilterBy";
            this.cmbFilterBy.Size = new System.Drawing.Size(133, 27);
            this.cmbFilterBy.TabIndex = 1;
            // 
            // lstStudents
            // 
            this.lstStudents.CheckBoxes = true;
            this.lstStudents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clLrn,
            this.clFullname});
            this.lstStudents.FullRowSelect = true;
            this.lstStudents.GridLines = true;
            this.lstStudents.Location = new System.Drawing.Point(16, 65);
            this.lstStudents.Name = "lstStudents";
            this.lstStudents.Size = new System.Drawing.Size(760, 360);
            this.lstStudents.TabIndex = 3;
            this.lstStudents.UseCompatibleStateImageBehavior = false;
            this.lstStudents.View = System.Windows.Forms.View.Details;
            this.lstStudents.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lstStudents_ItemChecked);
            // 
            // clLrn
            // 
            this.clLrn.Text = "LRN Number";
            this.clLrn.Width = 150;
            // 
            // clFullname
            // 
            this.clFullname.Text = "Fullname";
            this.clFullname.Width = 500;
            // 
            // gpbTime
            // 
            this.gpbTime.Controls.Add(this.dtpTTo);
            this.gpbTime.Controls.Add(this.label7);
            this.gpbTime.Controls.Add(this.label8);
            this.gpbTime.Controls.Add(this.dtpTFrom);
            this.gpbTime.Location = new System.Drawing.Point(12, 78);
            this.gpbTime.Name = "gpbTime";
            this.gpbTime.Size = new System.Drawing.Size(401, 57);
            this.gpbTime.TabIndex = 3;
            this.gpbTime.TabStop = false;
            this.gpbTime.Text = "Time";
            // 
            // dtpTTo
            // 
            this.dtpTTo.CustomFormat = "hh:mm tt";
            this.dtpTTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTTo.Location = new System.Drawing.Point(277, 18);
            this.dtpTTo.Name = "dtpTTo";
            this.dtpTTo.ShowUpDown = true;
            this.dtpTTo.Size = new System.Drawing.Size(89, 27);
            this.dtpTTo.TabIndex = 4;
            this.dtpTTo.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(230, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 19);
            this.label7.TabIndex = 10;
            this.label7.Text = "End :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(51, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 19);
            this.label8.TabIndex = 9;
            this.label8.Text = "Start : ";
            // 
            // dtpTFrom
            // 
            this.dtpTFrom.CustomFormat = "hh:mm tt";
            this.dtpTFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTFrom.Location = new System.Drawing.Point(106, 18);
            this.dtpTFrom.Name = "dtpTFrom";
            this.dtpTFrom.ShowUpDown = true;
            this.dtpTFrom.Size = new System.Drawing.Size(88, 27);
            this.dtpTFrom.TabIndex = 3;
            this.dtpTFrom.ValueChanged += new System.EventHandler(this.dtpTFrom_ValueChanged);
            // 
            // gpbSchoolMonth
            // 
            this.gpbSchoolMonth.Controls.Add(this.dtpMonthEnd);
            this.gpbSchoolMonth.Controls.Add(this.label9);
            this.gpbSchoolMonth.Controls.Add(this.label10);
            this.gpbSchoolMonth.Controls.Add(this.dtpMonthStart);
            this.gpbSchoolMonth.Location = new System.Drawing.Point(461, 68);
            this.gpbSchoolMonth.Name = "gpbSchoolMonth";
            this.gpbSchoolMonth.Size = new System.Drawing.Size(344, 67);
            this.gpbSchoolMonth.TabIndex = 5;
            this.gpbSchoolMonth.TabStop = false;
            this.gpbSchoolMonth.Text = "School Month Duration";
            // 
            // dtpMonthEnd
            // 
            this.dtpMonthEnd.CustomFormat = "MMMM";
            this.dtpMonthEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMonthEnd.Location = new System.Drawing.Point(219, 28);
            this.dtpMonthEnd.Name = "dtpMonthEnd";
            this.dtpMonthEnd.Size = new System.Drawing.Size(87, 27);
            this.dtpMonthEnd.TabIndex = 8;
            this.dtpMonthEnd.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(172, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 19);
            this.label9.TabIndex = 10;
            this.label9.Text = "End :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 19);
            this.label10.TabIndex = 9;
            this.label10.Text = "Start :";
            // 
            // dtpMonthStart
            // 
            this.dtpMonthStart.CustomFormat = "MMMM";
            this.dtpMonthStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMonthStart.Location = new System.Drawing.Point(56, 28);
            this.dtpMonthStart.Name = "dtpMonthStart";
            this.dtpMonthStart.Size = new System.Drawing.Size(100, 27);
            this.dtpMonthStart.TabIndex = 7;
            this.dtpMonthStart.ValueChanged += new System.EventHandler(this.dtpMonthStart_ValueChanged);
            // 
            // frmClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(817, 602);
            this.Controls.Add(this.gpbSchoolMonth);
            this.Controls.Add(this.gpbTime);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gpbSchoolyear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbYearSec);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbSubject);
            this.Font = new System.Drawing.Font("Calibri", 12F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmClass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Class Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmClass_FormClosing);
            this.Load += new System.EventHandler(this.frmClass_Load);
            this.gpbSchoolyear.ResumeLayout(false);
            this.gpbSchoolyear.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gpbTime.ResumeLayout(false);
            this.gpbTime.PerformLayout();
            this.gpbSchoolMonth.ResumeLayout(false);
            this.gpbSchoolMonth.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSubject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbYearSec;
        private System.Windows.Forms.GroupBox gpbSchoolyear;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lstStudents;
        private System.Windows.Forms.ColumnHeader clLrn;
        private System.Windows.Forms.ColumnHeader clFullname;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbFilterBy;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gpbTime;
        private System.Windows.Forms.DateTimePicker dtpTTo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpTFrom;
        private System.Windows.Forms.GroupBox gpbSchoolMonth;
        private System.Windows.Forms.DateTimePicker dtpMonthEnd;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpMonthStart;
    }
}