namespace LaoBernardBSCS3A_AdvDBMS_SE_Project
{
    partial class frmAttendance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAttendance));
            this.lblClassDescription = new System.Windows.Forms.Label();
            this.lstAttendance = new System.Windows.Forms.ListView();
            this.LRN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fullname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gender = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.classid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tmSetter = new System.Windows.Forms.Timer(this.components);
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpSpecifiedDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblClassDescription
            // 
            this.lblClassDescription.Location = new System.Drawing.Point(13, 13);
            this.lblClassDescription.Name = "lblClassDescription";
            this.lblClassDescription.Size = new System.Drawing.Size(653, 51);
            this.lblClassDescription.TabIndex = 0;
            this.lblClassDescription.Text = "Class Description : ";
            // 
            // lstAttendance
            // 
            this.lstAttendance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAttendance.CheckBoxes = true;
            this.lstAttendance.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LRN,
            this.fullname,
            this.gender,
            this.classid});
            this.lstAttendance.FullRowSelect = true;
            this.lstAttendance.GridLines = true;
            this.lstAttendance.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstAttendance.Location = new System.Drawing.Point(12, 106);
            this.lstAttendance.Name = "lstAttendance";
            this.lstAttendance.ShowItemToolTips = true;
            this.lstAttendance.Size = new System.Drawing.Size(654, 479);
            this.lstAttendance.TabIndex = 1;
            this.lstAttendance.UseCompatibleStateImageBehavior = false;
            this.lstAttendance.View = System.Windows.Forms.View.Details;
            this.lstAttendance.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lstGrades_ItemChecked);
            // 
            // LRN
            // 
            this.LRN.Text = "LRN";
            this.LRN.Width = 150;
            // 
            // fullname
            // 
            this.fullname.Text = "Fullname";
            this.fullname.Width = 300;
            // 
            // gender
            // 
            this.gender.Text = "Gender";
            this.gender.Width = 80;
            // 
            // classid
            // 
            this.classid.Width = 0;
            // 
            // tmSetter
            // 
            this.tmSetter.Enabled = true;
            this.tmSetter.Tick += new System.EventHandler(this.tmSetter_Tick);
            // 
            // cmbFilter
            // 
            this.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Items.AddRange(new object[] {
            "LRN",
            "Fullname"});
            this.cmbFilter.Location = new System.Drawing.Point(270, 73);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(91, 27);
            this.cmbFilter.TabIndex = 8;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(69, 73);
            this.txtSearch.MaxLength = 12;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(195, 27);
            this.txtSearch.TabIndex = 7;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Search :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(388, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "Specific Date : ";
            // 
            // dtpSpecifiedDate
            // 
            this.dtpSpecifiedDate.CustomFormat = "MMMM dd, yyyy";
            this.dtpSpecifiedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSpecifiedDate.Location = new System.Drawing.Point(499, 70);
            this.dtpSpecifiedDate.Name = "dtpSpecifiedDate";
            this.dtpSpecifiedDate.Size = new System.Drawing.Size(167, 27);
            this.dtpSpecifiedDate.TabIndex = 10;
            this.dtpSpecifiedDate.ValueChanged += new System.EventHandler(this.dtpSpecifiedDate_ValueChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(591, 37);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 27);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(678, 597);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpSpecifiedDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbFilter);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstAttendance);
            this.Controls.Add(this.lblClassDescription);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAttendance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check Attendance";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAttendance_FormClosing);
            this.Load += new System.EventHandler(this.Attendance_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblClassDescription;
        private System.Windows.Forms.ListView lstAttendance;
        private System.Windows.Forms.ColumnHeader LRN;
        private System.Windows.Forms.ColumnHeader fullname;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader gender;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpSpecifiedDate;
        private System.Windows.Forms.ColumnHeader classid;
        private System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Timer tmSetter;
    }
}