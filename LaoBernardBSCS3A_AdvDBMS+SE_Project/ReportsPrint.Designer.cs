namespace LaoBernardBSCS3A_AdvDBMS_SE_Project
{
    partial class frmReportsPrint
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportsPrint));
            this.lblDescription = new System.Windows.Forms.Label();
            this.cmbQuarter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstRecords = new System.Windows.Forms.ListView();
            this.clLRN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clFullname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tmSetter = new System.Windows.Forms.Timer(this.components);
            this.btnPrintGrade = new System.Windows.Forms.Button();
            this.btnPrintLMS = new System.Windows.Forms.Button();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.gpbQuarterInfo = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbMonths = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAttendance = new System.Windows.Forms.Button();
            this.gpbQuarterInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(13, 13);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(134, 19);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Class Description : ";
            // 
            // cmbQuarter
            // 
            this.cmbQuarter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuarter.FormattingEnabled = true;
            this.cmbQuarter.Items.AddRange(new object[] {
            "1st",
            "2nd",
            "3rd",
            "4th"});
            this.cmbQuarter.Location = new System.Drawing.Point(90, 47);
            this.cmbQuarter.Name = "cmbQuarter";
            this.cmbQuarter.Size = new System.Drawing.Size(77, 27);
            this.cmbQuarter.TabIndex = 1;
            this.cmbQuarter.SelectedIndexChanged += new System.EventHandler(this.cmbQuarter_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Quarter : ";
            // 
            // lstRecords
            // 
            this.lstRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstRecords.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clLRN,
            this.clFullname});
            this.lstRecords.FullRowSelect = true;
            this.lstRecords.GridLines = true;
            this.lstRecords.Location = new System.Drawing.Point(12, 121);
            this.lstRecords.Name = "lstRecords";
            this.lstRecords.Size = new System.Drawing.Size(903, 311);
            this.lstRecords.TabIndex = 3;
            this.lstRecords.UseCompatibleStateImageBehavior = false;
            this.lstRecords.View = System.Windows.Forms.View.Details;
            // 
            // clLRN
            // 
            this.clLRN.Text = "LRN";
            this.clLRN.Width = 120;
            // 
            // clFullname
            // 
            this.clFullname.Text = "Fullname";
            this.clFullname.Width = 300;
            // 
            // tmSetter
            // 
            this.tmSetter.Enabled = true;
            this.tmSetter.Tick += new System.EventHandler(this.tmSetter_Tick);
            // 
            // btnPrintGrade
            // 
            this.btnPrintGrade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintGrade.Location = new System.Drawing.Point(777, 438);
            this.btnPrintGrade.Name = "btnPrintGrade";
            this.btnPrintGrade.Size = new System.Drawing.Size(138, 33);
            this.btnPrintGrade.TabIndex = 4;
            this.btnPrintGrade.Text = "Print Grades";
            this.btnPrintGrade.UseVisualStyleBackColor = true;
            this.btnPrintGrade.Click += new System.EventHandler(this.btnPrintGrade_Click);
            // 
            // btnPrintLMS
            // 
            this.btnPrintLMS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintLMS.Location = new System.Drawing.Point(633, 438);
            this.btnPrintLMS.Name = "btnPrintLMS";
            this.btnPrintLMS.Size = new System.Drawing.Size(138, 33);
            this.btnPrintLMS.TabIndex = 5;
            this.btnPrintLMS.Text = "Print LMS";
            this.btnPrintLMS.UseVisualStyleBackColor = true;
            this.btnPrintLMS.Click += new System.EventHandler(this.btnPrintLMS_Click);
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpFrom.CustomFormat = "MMMM dd, yyyy";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(187, 47);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(167, 27);
            this.dtpFrom.TabIndex = 12;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(13, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(502, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "Note : Please Specify Quarter Date Span for accurate computation of Attendance";
            // 
            // dtpTo
            // 
            this.dtpTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpTo.CustomFormat = "MMMM dd, yyyy";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(394, 47);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(167, 27);
            this.dtpTo.TabIndex = 13;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(360, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 19);
            this.label3.TabIndex = 14;
            this.label3.Text = "TO";
            // 
            // gpbQuarterInfo
            // 
            this.gpbQuarterInfo.Controls.Add(this.dtpFrom);
            this.gpbQuarterInfo.Controls.Add(this.label3);
            this.gpbQuarterInfo.Controls.Add(this.cmbQuarter);
            this.gpbQuarterInfo.Controls.Add(this.dtpTo);
            this.gpbQuarterInfo.Controls.Add(this.label1);
            this.gpbQuarterInfo.Controls.Add(this.label2);
            this.gpbQuarterInfo.Location = new System.Drawing.Point(12, 35);
            this.gpbQuarterInfo.Name = "gpbQuarterInfo";
            this.gpbQuarterInfo.Size = new System.Drawing.Size(579, 80);
            this.gpbQuarterInfo.TabIndex = 15;
            this.gpbQuarterInfo.TabStop = false;
            this.gpbQuarterInfo.Text = "Grade Details";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(597, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(704, 18);
            this.label4.TabIndex = 16;
            this.label4.Text = "Note : this computation is based in your user settings. This might not match tota" +
    "lly with the printed DepEd format";
            // 
            // cmbMonths
            // 
            this.cmbMonths.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbMonths.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonths.FormattingEnabled = true;
            this.cmbMonths.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cmbMonths.Location = new System.Drawing.Point(235, 442);
            this.cmbMonths.Name = "cmbMonths";
            this.cmbMonths.Size = new System.Drawing.Size(99, 27);
            this.cmbMonths.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 445);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(216, 19);
            this.label5.TabIndex = 18;
            this.label5.Text = "Month(for Attendance Report) : ";
            // 
            // btnAttendance
            // 
            this.btnAttendance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAttendance.Location = new System.Drawing.Point(340, 438);
            this.btnAttendance.Name = "btnAttendance";
            this.btnAttendance.Size = new System.Drawing.Size(153, 33);
            this.btnAttendance.TabIndex = 19;
            this.btnAttendance.Text = "Print Attendance";
            this.btnAttendance.UseVisualStyleBackColor = true;
            this.btnAttendance.Click += new System.EventHandler(this.btnAttendance_Click);
            // 
            // frmReportsPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(927, 473);
            this.Controls.Add(this.btnAttendance);
            this.Controls.Add(this.cmbMonths);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gpbQuarterInfo);
            this.Controls.Add(this.btnPrintLMS);
            this.Controls.Add(this.btnPrintGrade);
            this.Controls.Add(this.lstRecords);
            this.Controls.Add(this.lblDescription);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReportsPrint";
            this.Text = "My Records";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReportsPrint_FormClosing);
            this.Load += new System.EventHandler(this.frmReportsPrint_Load);
            this.gpbQuarterInfo.ResumeLayout(false);
            this.gpbQuarterInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.ComboBox cmbQuarter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lstRecords;
        private System.Windows.Forms.ColumnHeader clLRN;
        private System.Windows.Forms.ColumnHeader clFullname;
        private System.Windows.Forms.Timer tmSetter;
        private System.Windows.Forms.Button btnPrintGrade;
        private System.Windows.Forms.Button btnPrintLMS;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gpbQuarterInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbMonths;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAttendance;
    }
}