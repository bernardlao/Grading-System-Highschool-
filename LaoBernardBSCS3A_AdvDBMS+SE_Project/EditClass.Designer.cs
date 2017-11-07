namespace LaoBernardBSCS3A_AdvDBMS_SE_Project
{
    partial class frmEditClass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditClass));
            this.lstClasses = new System.Windows.Forms.ListView();
            this.clSignature = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clSubject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clYearAndSec = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clSched = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clSY = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstClasses
            // 
            this.lstClasses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clSignature,
            this.clSubject,
            this.clYearAndSec,
            this.clSched,
            this.clSY});
            this.lstClasses.FullRowSelect = true;
            this.lstClasses.GridLines = true;
            this.lstClasses.Location = new System.Drawing.Point(12, 31);
            this.lstClasses.Name = "lstClasses";
            this.lstClasses.Size = new System.Drawing.Size(732, 394);
            this.lstClasses.TabIndex = 0;
            this.lstClasses.UseCompatibleStateImageBehavior = false;
            this.lstClasses.View = System.Windows.Forms.View.Details;
            this.lstClasses.Click += new System.EventHandler(this.lstClasses_Click);
            this.lstClasses.DoubleClick += new System.EventHandler(this.lstClasses_DoubleClick);
            // 
            // clSignature
            // 
            this.clSignature.Width = 0;
            // 
            // clSubject
            // 
            this.clSubject.Text = "Subject";
            this.clSubject.Width = 200;
            // 
            // clYearAndSec
            // 
            this.clYearAndSec.Text = "Year & Section";
            this.clYearAndSec.Width = 180;
            // 
            // clSched
            // 
            this.clSched.Text = "Schedule";
            this.clSched.Width = 180;
            // 
            // clSY
            // 
            this.clSY.Text = "School Year";
            this.clSY.Width = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select a Class :";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(326, 431);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(104, 37);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // frmEditClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(756, 472);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstClasses);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditClass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Class Selection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEditClass_FormClosing);
            this.Load += new System.EventHandler(this.frmEditClass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstClasses;
        private System.Windows.Forms.ColumnHeader clSubject;
        private System.Windows.Forms.ColumnHeader clYearAndSec;
        private System.Windows.Forms.ColumnHeader clSY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader clSignature;
        private System.Windows.Forms.ColumnHeader clSched;
        public System.Windows.Forms.Button btnSelect;
    }
}