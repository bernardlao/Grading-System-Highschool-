namespace LaoBernardBSCS3A_AdvDBMS_SE_Project
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mnsHeader = new System.Windows.Forms.MenuStrip();
            this.menuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSchoolInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEditCriteria = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSubject = new System.Windows.Forms.ToolStripMenuItem();
            this.menuYS = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClass = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddClass = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEditClass = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGrade = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAttendance = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCheckAttendance = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCheckAbsences = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRecords = new System.Windows.Forms.ToolStripMenuItem();
            this.tmFilterAccess = new System.Windows.Forms.Timer(this.components);
            this.menuDeleteClass = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnsHeader
            // 
            this.mnsHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.mnsHeader.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnsHeader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSettings,
            this.menuSubject,
            this.menuYS,
            this.menuStudent,
            this.menuClass,
            this.menuGrade,
            this.menuAttendance,
            this.menuRecords});
            this.mnsHeader.Location = new System.Drawing.Point(0, 0);
            this.mnsHeader.Name = "mnsHeader";
            this.mnsHeader.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.mnsHeader.Size = new System.Drawing.Size(1172, 29);
            this.mnsHeader.TabIndex = 1;
            this.mnsHeader.Text = "menuStrip1";
            // 
            // menuSettings
            // 
            this.menuSettings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.menuSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSchoolInfo,
            this.menuChangePassword,
            this.menuEditCriteria,
            this.menuLogout});
            this.menuSettings.Image = ((System.Drawing.Image)(resources.GetObject("menuSettings.Image")));
            this.menuSettings.Name = "menuSettings";
            this.menuSettings.Size = new System.Drawing.Size(89, 23);
            this.menuSettings.Text = "Settings";
            // 
            // menuSchoolInfo
            // 
            this.menuSchoolInfo.Image = ((System.Drawing.Image)(resources.GetObject("menuSchoolInfo.Image")));
            this.menuSchoolInfo.Name = "menuSchoolInfo";
            this.menuSchoolInfo.Size = new System.Drawing.Size(223, 24);
            this.menuSchoolInfo.Text = "Set School Information";
            this.menuSchoolInfo.Click += new System.EventHandler(this.menuSchoolInfo_Click);
            // 
            // menuChangePassword
            // 
            this.menuChangePassword.Image = ((System.Drawing.Image)(resources.GetObject("menuChangePassword.Image")));
            this.menuChangePassword.Name = "menuChangePassword";
            this.menuChangePassword.Size = new System.Drawing.Size(223, 24);
            this.menuChangePassword.Text = "Change User Settings";
            this.menuChangePassword.Click += new System.EventHandler(this.menuChangePassword_Click);
            // 
            // menuEditCriteria
            // 
            this.menuEditCriteria.Image = ((System.Drawing.Image)(resources.GetObject("menuEditCriteria.Image")));
            this.menuEditCriteria.Name = "menuEditCriteria";
            this.menuEditCriteria.Size = new System.Drawing.Size(223, 24);
            this.menuEditCriteria.Text = "Edit your Criteria";
            this.menuEditCriteria.Click += new System.EventHandler(this.menuEditCriteria_Click);
            // 
            // menuLogout
            // 
            this.menuLogout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.menuLogout.Image = ((System.Drawing.Image)(resources.GetObject("menuLogout.Image")));
            this.menuLogout.Name = "menuLogout";
            this.menuLogout.Size = new System.Drawing.Size(223, 24);
            this.menuLogout.Text = "Logout";
            this.menuLogout.Click += new System.EventHandler(this.menuLogout_Click);
            // 
            // menuSubject
            // 
            this.menuSubject.Image = ((System.Drawing.Image)(resources.GetObject("menuSubject.Image")));
            this.menuSubject.Name = "menuSubject";
            this.menuSubject.Size = new System.Drawing.Size(115, 23);
            this.menuSubject.Text = "My Subjects";
            this.menuSubject.Click += new System.EventHandler(this.menuSubject_Click_1);
            // 
            // menuYS
            // 
            this.menuYS.Image = ((System.Drawing.Image)(resources.GetObject("menuYS.Image")));
            this.menuYS.Name = "menuYS";
            this.menuYS.Size = new System.Drawing.Size(185, 23);
            this.menuYS.Text = "My Grade&&Section List";
            this.menuYS.Click += new System.EventHandler(this.menuYS_Click);
            // 
            // menuStudent
            // 
            this.menuStudent.Image = ((System.Drawing.Image)(resources.GetObject("menuStudent.Image")));
            this.menuStudent.Name = "menuStudent";
            this.menuStudent.Size = new System.Drawing.Size(110, 23);
            this.menuStudent.Text = "My Student";
            this.menuStudent.Click += new System.EventHandler(this.menuStudent_Click);
            // 
            // menuClass
            // 
            this.menuClass.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddClass,
            this.menuEditClass,
            this.menuDeleteClass});
            this.menuClass.Image = ((System.Drawing.Image)(resources.GetObject("menuClass.Image")));
            this.menuClass.Name = "menuClass";
            this.menuClass.Size = new System.Drawing.Size(96, 23);
            this.menuClass.Text = "My Class";
            // 
            // menuAddClass
            // 
            this.menuAddClass.Image = ((System.Drawing.Image)(resources.GetObject("menuAddClass.Image")));
            this.menuAddClass.Name = "menuAddClass";
            this.menuAddClass.Size = new System.Drawing.Size(172, 24);
            this.menuAddClass.Text = "Add a Class";
            this.menuAddClass.Click += new System.EventHandler(this.menuAddClass_Click);
            // 
            // menuEditClass
            // 
            this.menuEditClass.Image = ((System.Drawing.Image)(resources.GetObject("menuEditClass.Image")));
            this.menuEditClass.Name = "menuEditClass";
            this.menuEditClass.Size = new System.Drawing.Size(172, 24);
            this.menuEditClass.Text = "Edit a Class";
            this.menuEditClass.Click += new System.EventHandler(this.menuEditClass_Click);
            // 
            // menuGrade
            // 
            this.menuGrade.Image = ((System.Drawing.Image)(resources.GetObject("menuGrade.Image")));
            this.menuGrade.Name = "menuGrade";
            this.menuGrade.Size = new System.Drawing.Size(140, 23);
            this.menuGrade.Text = "My Grade Sheet";
            this.menuGrade.Click += new System.EventHandler(this.menuGrade_Click);
            // 
            // menuAttendance
            // 
            this.menuAttendance.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCheckAttendance,
            this.menuCheckAbsences});
            this.menuAttendance.Image = ((System.Drawing.Image)(resources.GetObject("menuAttendance.Image")));
            this.menuAttendance.Name = "menuAttendance";
            this.menuAttendance.Size = new System.Drawing.Size(135, 23);
            this.menuAttendance.Text = "My Attendance";
            // 
            // menuCheckAttendance
            // 
            this.menuCheckAttendance.Image = ((System.Drawing.Image)(resources.GetObject("menuCheckAttendance.Image")));
            this.menuCheckAttendance.Name = "menuCheckAttendance";
            this.menuCheckAttendance.Size = new System.Drawing.Size(195, 24);
            this.menuCheckAttendance.Text = "Check Attendance";
            this.menuCheckAttendance.Click += new System.EventHandler(this.menuAttendance_Click);
            // 
            // menuCheckAbsences
            // 
            this.menuCheckAbsences.Image = ((System.Drawing.Image)(resources.GetObject("menuCheckAbsences.Image")));
            this.menuCheckAbsences.Name = "menuCheckAbsences";
            this.menuCheckAbsences.Size = new System.Drawing.Size(195, 24);
            this.menuCheckAbsences.Text = "Check Absences";
            this.menuCheckAbsences.Click += new System.EventHandler(this.menuCheckAbsences_Click);
            // 
            // menuRecords
            // 
            this.menuRecords.Image = ((System.Drawing.Image)(resources.GetObject("menuRecords.Image")));
            this.menuRecords.Name = "menuRecords";
            this.menuRecords.Size = new System.Drawing.Size(113, 23);
            this.menuRecords.Text = "My Records";
            this.menuRecords.Click += new System.EventHandler(this.menuRecords_Click);
            // 
            // tmFilterAccess
            // 
            this.tmFilterAccess.Enabled = true;
            this.tmFilterAccess.Tick += new System.EventHandler(this.tmFilterAccess_Tick);
            // 
            // menuDeleteClass
            // 
            this.menuDeleteClass.Image = ((System.Drawing.Image)(resources.GetObject("menuDeleteClass.Image")));
            this.menuDeleteClass.Name = "menuDeleteClass";
            this.menuDeleteClass.Size = new System.Drawing.Size(172, 24);
            this.menuDeleteClass.Text = "Delete a Class";
            this.menuDeleteClass.Click += new System.EventHandler(this.menuDeleteClass_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1172, 655);
            this.ControlBox = false;
            this.Controls.Add(this.mnsHeader);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnsHeader;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My Grade Records";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.mnsHeader.ResumeLayout(false);
            this.mnsHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.MenuStrip mnsHeader;
        private System.Windows.Forms.Timer tmFilterAccess;
        private System.Windows.Forms.ToolStripMenuItem menuSettings;
        private System.Windows.Forms.ToolStripMenuItem menuLogout;
        private System.Windows.Forms.ToolStripMenuItem menuChangePassword;
        private System.Windows.Forms.ToolStripMenuItem menuEditCriteria;
        private System.Windows.Forms.ToolStripMenuItem menuSubject;
        private System.Windows.Forms.ToolStripMenuItem menuYS;
        private System.Windows.Forms.ToolStripMenuItem menuStudent;
        private System.Windows.Forms.ToolStripMenuItem menuClass;
        private System.Windows.Forms.ToolStripMenuItem menuAddClass;
        private System.Windows.Forms.ToolStripMenuItem menuEditClass;
        private System.Windows.Forms.ToolStripMenuItem menuGrade;
        private System.Windows.Forms.ToolStripMenuItem menuAttendance;
        private System.Windows.Forms.ToolStripMenuItem menuCheckAttendance;
        private System.Windows.Forms.ToolStripMenuItem menuCheckAbsences;
        private System.Windows.Forms.ToolStripMenuItem menuRecords;
        private System.Windows.Forms.ToolStripMenuItem menuSchoolInfo;
        private System.Windows.Forms.ToolStripMenuItem menuDeleteClass;

    }
}



