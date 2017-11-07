namespace LaoBernardBSCS3A_AdvDBMS_SE_Project
{
    partial class frmGradeSheet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGradeSheet));
            this.lblClassName = new System.Windows.Forms.Label();
            this.tcGrading = new System.Windows.Forms.TabControl();
            this.tpFirst = new System.Windows.Forms.TabPage();
            this.dgvFirst = new System.Windows.Forms.DataGridView();
            this.tpSecond = new System.Windows.Forms.TabPage();
            this.dgvSecond = new System.Windows.Forms.DataGridView();
            this.tpThird = new System.Windows.Forms.TabPage();
            this.dgvThird = new System.Windows.Forms.DataGridView();
            this.tpFourth = new System.Windows.Forms.TabPage();
            this.dgvFourth = new System.Windows.Forms.DataGridView();
            this.tmSetter = new System.Windows.Forms.Timer(this.components);
            this.cmsFirst = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuAddCol = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDeleteCol = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tcGrading.SuspendLayout();
            this.tpFirst.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFirst)).BeginInit();
            this.tpSecond.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSecond)).BeginInit();
            this.tpThird.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThird)).BeginInit();
            this.tpFourth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFourth)).BeginInit();
            this.cmsFirst.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblClassName
            // 
            this.lblClassName.AutoSize = true;
            this.lblClassName.Location = new System.Drawing.Point(12, 9);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(134, 19);
            this.lblClassName.TabIndex = 0;
            this.lblClassName.Text = "Class Description : ";
            // 
            // tcGrading
            // 
            this.tcGrading.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcGrading.Controls.Add(this.tpFirst);
            this.tcGrading.Controls.Add(this.tpSecond);
            this.tcGrading.Controls.Add(this.tpThird);
            this.tcGrading.Controls.Add(this.tpFourth);
            this.tcGrading.Location = new System.Drawing.Point(16, 31);
            this.tcGrading.Name = "tcGrading";
            this.tcGrading.SelectedIndex = 0;
            this.tcGrading.Size = new System.Drawing.Size(997, 452);
            this.tcGrading.TabIndex = 1;
            // 
            // tpFirst
            // 
            this.tpFirst.Controls.Add(this.dgvFirst);
            this.tpFirst.Location = new System.Drawing.Point(4, 28);
            this.tpFirst.Name = "tpFirst";
            this.tpFirst.Padding = new System.Windows.Forms.Padding(3);
            this.tpFirst.Size = new System.Drawing.Size(989, 420);
            this.tpFirst.TabIndex = 0;
            this.tpFirst.Text = "1st Quarter";
            this.tpFirst.UseVisualStyleBackColor = true;
            // 
            // dgvFirst
            // 
            this.dgvFirst.AllowUserToAddRows = false;
            this.dgvFirst.AllowUserToDeleteRows = false;
            this.dgvFirst.AllowUserToResizeColumns = false;
            this.dgvFirst.AllowUserToResizeRows = false;
            this.dgvFirst.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvFirst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFirst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFirst.Location = new System.Drawing.Point(3, 3);
            this.dgvFirst.Name = "dgvFirst";
            this.dgvFirst.Size = new System.Drawing.Size(983, 414);
            this.dgvFirst.TabIndex = 0;
            this.dgvFirst.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvFirst_CellBeginEdit);
            this.dgvFirst.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFirst_CellEndEdit);
            this.dgvFirst.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFirst_CellMouseEnter);
            this.dgvFirst.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvFirst_EditingControlShowing);
            // 
            // tpSecond
            // 
            this.tpSecond.Controls.Add(this.dgvSecond);
            this.tpSecond.Location = new System.Drawing.Point(4, 28);
            this.tpSecond.Name = "tpSecond";
            this.tpSecond.Padding = new System.Windows.Forms.Padding(3);
            this.tpSecond.Size = new System.Drawing.Size(989, 420);
            this.tpSecond.TabIndex = 1;
            this.tpSecond.Text = "2nd Quarter";
            this.tpSecond.UseVisualStyleBackColor = true;
            // 
            // dgvSecond
            // 
            this.dgvSecond.AllowUserToAddRows = false;
            this.dgvSecond.AllowUserToDeleteRows = false;
            this.dgvSecond.AllowUserToResizeColumns = false;
            this.dgvSecond.AllowUserToResizeRows = false;
            this.dgvSecond.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSecond.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSecond.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSecond.Location = new System.Drawing.Point(3, 3);
            this.dgvSecond.Name = "dgvSecond";
            this.dgvSecond.Size = new System.Drawing.Size(983, 414);
            this.dgvSecond.TabIndex = 1;
            this.dgvSecond.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvFirst_CellBeginEdit);
            this.dgvSecond.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFirst_CellEndEdit);
            this.dgvSecond.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFirst_CellMouseEnter);
            this.dgvSecond.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvFirst_EditingControlShowing);
            // 
            // tpThird
            // 
            this.tpThird.Controls.Add(this.dgvThird);
            this.tpThird.Location = new System.Drawing.Point(4, 28);
            this.tpThird.Name = "tpThird";
            this.tpThird.Padding = new System.Windows.Forms.Padding(3);
            this.tpThird.Size = new System.Drawing.Size(989, 420);
            this.tpThird.TabIndex = 2;
            this.tpThird.Text = "3rd Quarter";
            this.tpThird.UseVisualStyleBackColor = true;
            // 
            // dgvThird
            // 
            this.dgvThird.AllowUserToAddRows = false;
            this.dgvThird.AllowUserToDeleteRows = false;
            this.dgvThird.AllowUserToResizeColumns = false;
            this.dgvThird.AllowUserToResizeRows = false;
            this.dgvThird.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvThird.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThird.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThird.Location = new System.Drawing.Point(3, 3);
            this.dgvThird.Name = "dgvThird";
            this.dgvThird.Size = new System.Drawing.Size(983, 414);
            this.dgvThird.TabIndex = 1;
            this.dgvThird.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvFirst_CellBeginEdit);
            this.dgvThird.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFirst_CellEndEdit);
            this.dgvThird.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFirst_CellMouseEnter);
            this.dgvThird.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvFirst_EditingControlShowing);
            // 
            // tpFourth
            // 
            this.tpFourth.Controls.Add(this.dgvFourth);
            this.tpFourth.Location = new System.Drawing.Point(4, 28);
            this.tpFourth.Name = "tpFourth";
            this.tpFourth.Padding = new System.Windows.Forms.Padding(3);
            this.tpFourth.Size = new System.Drawing.Size(989, 420);
            this.tpFourth.TabIndex = 3;
            this.tpFourth.Text = "4th Quarter";
            this.tpFourth.UseVisualStyleBackColor = true;
            // 
            // dgvFourth
            // 
            this.dgvFourth.AllowUserToAddRows = false;
            this.dgvFourth.AllowUserToDeleteRows = false;
            this.dgvFourth.AllowUserToResizeColumns = false;
            this.dgvFourth.AllowUserToResizeRows = false;
            this.dgvFourth.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvFourth.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFourth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFourth.Location = new System.Drawing.Point(3, 3);
            this.dgvFourth.Name = "dgvFourth";
            this.dgvFourth.Size = new System.Drawing.Size(983, 414);
            this.dgvFourth.TabIndex = 1;
            this.dgvFourth.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvFirst_CellBeginEdit);
            this.dgvFourth.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFirst_CellEndEdit);
            this.dgvFourth.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFirst_CellMouseEnter);
            this.dgvFourth.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvFirst_EditingControlShowing);
            // 
            // tmSetter
            // 
            this.tmSetter.Enabled = true;
            this.tmSetter.Tick += new System.EventHandler(this.tmSetter_Tick);
            // 
            // cmsFirst
            // 
            this.cmsFirst.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddCol,
            this.menuDeleteCol});
            this.cmsFirst.Name = "cmsFirst";
            this.cmsFirst.Size = new System.Drawing.Size(154, 48);
            // 
            // menuAddCol
            // 
            this.menuAddCol.Name = "menuAddCol";
            this.menuAddCol.Size = new System.Drawing.Size(153, 22);
            this.menuAddCol.Text = "Add Column";
            this.menuAddCol.Click += new System.EventHandler(this.menuAddCol_Click);
            // 
            // menuDeleteCol
            // 
            this.menuDeleteCol.Name = "menuDeleteCol";
            this.menuDeleteCol.Size = new System.Drawing.Size(153, 22);
            this.menuDeleteCol.Text = "Delete Column";
            this.menuDeleteCol.Click += new System.EventHandler(this.menuDeleteCol_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(934, 485);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 29);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 490);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Search :";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSearch.Location = new System.Drawing.Point(85, 487);
            this.txtSearch.MaxLength = 12;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(195, 27);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // cmbFilter
            // 
            this.cmbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Items.AddRange(new object[] {
            "LRN",
            "Fullname"});
            this.cmbFilter.Location = new System.Drawing.Point(307, 487);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(121, 27);
            this.cmbFilter.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(581, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(432, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "Note : Total Items that has \'%\' is Graded by Percent not per Items";
            // 
            // frmGradeSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1025, 521);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbFilter);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tcGrading);
            this.Controls.Add(this.lblClassName);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGradeSheet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grade Sheet";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGradeSheet_FormClosing);
            this.Load += new System.EventHandler(this.frmGradeSheet_Load);
            this.tcGrading.ResumeLayout(false);
            this.tpFirst.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFirst)).EndInit();
            this.tpSecond.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSecond)).EndInit();
            this.tpThird.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThird)).EndInit();
            this.tpFourth.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFourth)).EndInit();
            this.cmsFirst.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblClassName;
        private System.Windows.Forms.TabControl tcGrading;
        private System.Windows.Forms.TabPage tpFirst;
        private System.Windows.Forms.DataGridView dgvFirst;
        private System.Windows.Forms.TabPage tpSecond;
        private System.Windows.Forms.TabPage tpThird;
        private System.Windows.Forms.TabPage tpFourth;
        private System.Windows.Forms.Timer tmSetter;
        private System.Windows.Forms.ContextMenuStrip cmsFirst;
        private System.Windows.Forms.ToolStripMenuItem menuAddCol;
        private System.Windows.Forms.ToolStripMenuItem menuDeleteCol;
        private System.Windows.Forms.DataGridView dgvSecond;
        private System.Windows.Forms.DataGridView dgvThird;
        private System.Windows.Forms.DataGridView dgvFourth;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.Label label2;
    }
}