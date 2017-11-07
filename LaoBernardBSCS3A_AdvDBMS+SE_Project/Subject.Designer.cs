namespace LaoBernardBSCS3A_AdvDBMS_SE_Project
{
    partial class frmSubject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSubject));
            this.label1 = new System.Windows.Forms.Label();
            this.txtSubjectName = new System.Windows.Forms.TextBox();
            this.lstSubject = new System.Windows.Forms.ListView();
            this.clid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clSubjectName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.optAZ = new System.Windows.Forms.RadioButton();
            this.optZA = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Subject Name";
            // 
            // txtSubjectName
            // 
            this.txtSubjectName.Location = new System.Drawing.Point(146, 30);
            this.txtSubjectName.Name = "txtSubjectName";
            this.txtSubjectName.Size = new System.Drawing.Size(190, 27);
            this.txtSubjectName.TabIndex = 1;
            this.txtSubjectName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSubjectName_KeyDown);
            // 
            // lstSubject
            // 
            this.lstSubject.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clid,
            this.clSubjectName});
            this.lstSubject.FullRowSelect = true;
            this.lstSubject.Location = new System.Drawing.Point(37, 109);
            this.lstSubject.Name = "lstSubject";
            this.lstSubject.Size = new System.Drawing.Size(299, 306);
            this.lstSubject.TabIndex = 2;
            this.lstSubject.UseCompatibleStateImageBehavior = false;
            this.lstSubject.View = System.Windows.Forms.View.Details;
            this.lstSubject.DoubleClick += new System.EventHandler(this.lstSubject_DoubleClick);
            // 
            // clid
            // 
            this.clid.Text = "SubjectID";
            this.clid.Width = 0;
            // 
            // clSubjectName
            // 
            this.clSubjectName.Text = "Subject Name";
            this.clSubjectName.Width = 260;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(37, 423);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Note : Double-click an item to edit";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(206, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Note : Hit Enter to Save";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Order by :";
            // 
            // optAZ
            // 
            this.optAZ.AutoSize = true;
            this.optAZ.Checked = true;
            this.optAZ.Location = new System.Drawing.Point(112, 85);
            this.optAZ.Name = "optAZ";
            this.optAZ.Size = new System.Drawing.Size(57, 23);
            this.optAZ.TabIndex = 6;
            this.optAZ.TabStop = true;
            this.optAZ.Text = "A - Z";
            this.optAZ.UseVisualStyleBackColor = true;
            this.optAZ.CheckedChanged += new System.EventHandler(this.optZA_CheckedChanged);
            // 
            // optZA
            // 
            this.optZA.AutoSize = true;
            this.optZA.Location = new System.Drawing.Point(175, 85);
            this.optZA.Name = "optZA";
            this.optZA.Size = new System.Drawing.Size(57, 23);
            this.optZA.TabIndex = 7;
            this.optZA.Text = "Z - A";
            this.optZA.UseVisualStyleBackColor = true;
            this.optZA.CheckedChanged += new System.EventHandler(this.optZA_CheckedChanged);
            // 
            // frmSubject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(378, 454);
            this.Controls.Add(this.optZA);
            this.Controls.Add(this.optAZ);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstSubject);
            this.Controls.Add(this.txtSubjectName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSubject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Subject Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSubject_FormClosing);
            this.Load += new System.EventHandler(this.frmSubject_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSubjectName;
        private System.Windows.Forms.ListView lstSubject;
        private System.Windows.Forms.ColumnHeader clid;
        private System.Windows.Forms.ColumnHeader clSubjectName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton optAZ;
        private System.Windows.Forms.RadioButton optZA;
    }
}