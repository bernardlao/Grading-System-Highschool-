namespace LaoBernardBSCS3A_AdvDBMS_SE_Project
{
    partial class frmYearAndSection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmYearAndSection));
            this.label1 = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.txtSecName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSecNum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lstRecords = new System.Windows.Forms.ListView();
            this.clid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clyear = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clSecNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clSectionName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.optDESC = new System.Windows.Forms.RadioButton();
            this.optASC = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Grade";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(134, 16);
            this.txtYear.MaxLength = 2;
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(174, 27);
            this.txtYear.TabIndex = 1;
            this.txtYear.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSecName_KeyDown);
            this.txtYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSecNum_KeyPress);
            // 
            // txtSecName
            // 
            this.txtSecName.Location = new System.Drawing.Point(134, 99);
            this.txtSecName.Name = "txtSecName";
            this.txtSecName.Size = new System.Drawing.Size(174, 27);
            this.txtSecName.TabIndex = 5;
            this.txtSecName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSecName_KeyDown);
            this.txtSecName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSecName_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Section  Name";
            // 
            // txtSecNum
            // 
            this.txtSecNum.Location = new System.Drawing.Point(134, 57);
            this.txtSecNum.MaxLength = 2;
            this.txtSecNum.Name = "txtSecNum";
            this.txtSecNum.Size = new System.Drawing.Size(174, 27);
            this.txtSecNum.TabIndex = 3;
            this.txtSecNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSecName_KeyDown);
            this.txtSecNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSecNum_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Section #";
            // 
            // lstRecords
            // 
            this.lstRecords.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clid,
            this.clyear,
            this.clSecNo,
            this.clSectionName});
            this.lstRecords.FullRowSelect = true;
            this.lstRecords.GridLines = true;
            this.lstRecords.Location = new System.Drawing.Point(12, 170);
            this.lstRecords.Name = "lstRecords";
            this.lstRecords.Size = new System.Drawing.Size(296, 298);
            this.lstRecords.TabIndex = 8;
            this.lstRecords.UseCompatibleStateImageBehavior = false;
            this.lstRecords.View = System.Windows.Forms.View.Details;
            this.lstRecords.DoubleClick += new System.EventHandler(this.lstRecords_DoubleClick);
            // 
            // clid
            // 
            this.clid.Width = 0;
            // 
            // clyear
            // 
            this.clyear.Text = "Year";
            this.clyear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // clSecNo
            // 
            this.clSecNo.Text = "Sec #";
            this.clSecNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // clSectionName
            // 
            this.clSectionName.Text = "Section Name";
            this.clSectionName.Width = 150;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(12, 475);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "Note : Double-click to Edit Details";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(177, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "Note : Hit Enter to Save";
            // 
            // optDESC
            // 
            this.optDESC.AutoSize = true;
            this.optDESC.Location = new System.Drawing.Point(180, 146);
            this.optDESC.Name = "optDESC";
            this.optDESC.Size = new System.Drawing.Size(103, 23);
            this.optDESC.TabIndex = 7;
            this.optDESC.Text = "Descending";
            this.optDESC.UseVisualStyleBackColor = true;
            this.optDESC.CheckedChanged += new System.EventHandler(this.optDESC_CheckedChanged);
            // 
            // optASC
            // 
            this.optASC.AutoSize = true;
            this.optASC.Checked = true;
            this.optASC.Location = new System.Drawing.Point(91, 146);
            this.optASC.Name = "optASC";
            this.optASC.Size = new System.Drawing.Size(94, 23);
            this.optASC.TabIndex = 6;
            this.optASC.TabStop = true;
            this.optASC.Text = "Ascending";
            this.optASC.UseVisualStyleBackColor = true;
            this.optASC.CheckedChanged += new System.EventHandler(this.optDESC_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 19);
            this.label6.TabIndex = 11;
            this.label6.Text = "Order by :";
            // 
            // frmYearAndSection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(320, 494);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.optDESC);
            this.Controls.Add(this.optASC);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstRecords);
            this.Controls.Add(this.txtSecNum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSecName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmYearAndSection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grade and Section Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmYearAndSection_FormClosing);
            this.Load += new System.EventHandler(this.frmYearAndSection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.TextBox txtSecName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSecNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lstRecords;
        private System.Windows.Forms.ColumnHeader clid;
        private System.Windows.Forms.ColumnHeader clyear;
        private System.Windows.Forms.ColumnHeader clSecNo;
        private System.Windows.Forms.ColumnHeader clSectionName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton optDESC;
        private System.Windows.Forms.RadioButton optASC;
        private System.Windows.Forms.Label label6;
    }
}