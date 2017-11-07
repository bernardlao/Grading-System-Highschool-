namespace LaoBernardBSCS3A_AdvDBMS_SE_Project
{
    partial class frmCriteria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCriteria));
            this.pnlPerformance = new System.Windows.Forms.Panel();
            this.btnMinusPerformance = new System.Windows.Forms.Button();
            this.btnPlusPerformance = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPercentage = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnMinusWrittenWorks = new System.Windows.Forms.Button();
            this.btnPlusWrittenWorks = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlWritten = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.btnMinusPeriodicals = new System.Windows.Forms.Button();
            this.btnPlusPeriodicals = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlPeriodicals = new System.Windows.Forms.Panel();
            this.doCancel = new System.Windows.Forms.Timer(this.components);
            this.lblTotalPerformance = new System.Windows.Forms.Label();
            this.lblTotalWritten = new System.Windows.Forms.Label();
            this.lblTotalPeriodicals = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlPerformance
            // 
            this.pnlPerformance.AutoScroll = true;
            this.pnlPerformance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPerformance.Location = new System.Drawing.Point(12, 49);
            this.pnlPerformance.Name = "pnlPerformance";
            this.pnlPerformance.Size = new System.Drawing.Size(294, 395);
            this.pnlPerformance.TabIndex = 0;
            // 
            // btnMinusPerformance
            // 
            this.btnMinusPerformance.Location = new System.Drawing.Point(279, 3);
            this.btnMinusPerformance.Name = "btnMinusPerformance";
            this.btnMinusPerformance.Size = new System.Drawing.Size(27, 27);
            this.btnMinusPerformance.TabIndex = 1;
            this.btnMinusPerformance.Text = "-";
            this.btnMinusPerformance.UseVisualStyleBackColor = true;
            this.btnMinusPerformance.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // btnPlusPerformance
            // 
            this.btnPlusPerformance.Location = new System.Drawing.Point(253, 3);
            this.btnPlusPerformance.Name = "btnPlusPerformance";
            this.btnPlusPerformance.Size = new System.Drawing.Size(27, 27);
            this.btnPlusPerformance.TabIndex = 0;
            this.btnPlusPerformance.Text = "+";
            this.btnPlusPerformance.UseVisualStyleBackColor = true;
            this.btnPlusPerformance.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Criteria Name";
            // 
            // lblPercentage
            // 
            this.lblPercentage.AutoSize = true;
            this.lblPercentage.Location = new System.Drawing.Point(191, 27);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Size = new System.Drawing.Size(82, 19);
            this.lblPercentage.TabIndex = 2;
            this.lblPercentage.Text = "Percentage";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(455, 474);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Performance 40%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(342, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 23);
            this.label3.TabIndex = 10;
            this.label3.Text = "Written Works 40%";
            // 
            // btnMinusWrittenWorks
            // 
            this.btnMinusWrittenWorks.Location = new System.Drawing.Point(613, 3);
            this.btnMinusWrittenWorks.Name = "btnMinusWrittenWorks";
            this.btnMinusWrittenWorks.Size = new System.Drawing.Size(27, 27);
            this.btnMinusWrittenWorks.TabIndex = 7;
            this.btnMinusWrittenWorks.Text = "-";
            this.btnMinusWrittenWorks.UseVisualStyleBackColor = true;
            this.btnMinusWrittenWorks.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // btnPlusWrittenWorks
            // 
            this.btnPlusWrittenWorks.Location = new System.Drawing.Point(587, 3);
            this.btnPlusWrittenWorks.Name = "btnPlusWrittenWorks";
            this.btnPlusWrittenWorks.Size = new System.Drawing.Size(27, 27);
            this.btnPlusWrittenWorks.TabIndex = 5;
            this.btnPlusWrittenWorks.Text = "+";
            this.btnPlusWrittenWorks.UseVisualStyleBackColor = true;
            this.btnPlusWrittenWorks.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(525, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "Percentage";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(342, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Criteria Name";
            // 
            // pnlWritten
            // 
            this.pnlWritten.AutoScroll = true;
            this.pnlWritten.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlWritten.Location = new System.Drawing.Point(346, 49);
            this.pnlWritten.Name = "pnlWritten";
            this.pnlWritten.Size = new System.Drawing.Size(294, 395);
            this.pnlWritten.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(672, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 23);
            this.label6.TabIndex = 16;
            this.label6.Text = "Periodicals 20%";
            // 
            // btnMinusPeriodicals
            // 
            this.btnMinusPeriodicals.Location = new System.Drawing.Point(943, 3);
            this.btnMinusPeriodicals.Name = "btnMinusPeriodicals";
            this.btnMinusPeriodicals.Size = new System.Drawing.Size(27, 27);
            this.btnMinusPeriodicals.TabIndex = 13;
            this.btnMinusPeriodicals.Text = "-";
            this.btnMinusPeriodicals.UseVisualStyleBackColor = true;
            this.btnMinusPeriodicals.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // btnPlusPeriodicals
            // 
            this.btnPlusPeriodicals.Location = new System.Drawing.Point(917, 3);
            this.btnPlusPeriodicals.Name = "btnPlusPeriodicals";
            this.btnPlusPeriodicals.Size = new System.Drawing.Size(27, 27);
            this.btnPlusPeriodicals.TabIndex = 11;
            this.btnPlusPeriodicals.Text = "+";
            this.btnPlusPeriodicals.UseVisualStyleBackColor = true;
            this.btnPlusPeriodicals.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(855, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 19);
            this.label7.TabIndex = 15;
            this.label7.Text = "Percentage";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(672, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 19);
            this.label8.TabIndex = 14;
            this.label8.Text = "Criteria Name";
            // 
            // pnlPeriodicals
            // 
            this.pnlPeriodicals.AutoScroll = true;
            this.pnlPeriodicals.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPeriodicals.Location = new System.Drawing.Point(676, 49);
            this.pnlPeriodicals.Name = "pnlPeriodicals";
            this.pnlPeriodicals.Size = new System.Drawing.Size(294, 395);
            this.pnlPeriodicals.TabIndex = 12;
            // 
            // doCancel
            // 
            this.doCancel.Enabled = true;
            this.doCancel.Tick += new System.EventHandler(this.doCancel_Tick);
            // 
            // lblTotalPerformance
            // 
            this.lblTotalPerformance.AutoSize = true;
            this.lblTotalPerformance.Location = new System.Drawing.Point(220, 447);
            this.lblTotalPerformance.Name = "lblTotalPerformance";
            this.lblTotalPerformance.Size = new System.Drawing.Size(53, 19);
            this.lblTotalPerformance.TabIndex = 17;
            this.lblTotalPerformance.Text = "Total : ";
            // 
            // lblTotalWritten
            // 
            this.lblTotalWritten.AutoSize = true;
            this.lblTotalWritten.Location = new System.Drawing.Point(554, 447);
            this.lblTotalWritten.Name = "lblTotalWritten";
            this.lblTotalWritten.Size = new System.Drawing.Size(53, 19);
            this.lblTotalWritten.TabIndex = 18;
            this.lblTotalWritten.Text = "Total : ";
            // 
            // lblTotalPeriodicals
            // 
            this.lblTotalPeriodicals.AutoSize = true;
            this.lblTotalPeriodicals.Location = new System.Drawing.Point(884, 447);
            this.lblTotalPeriodicals.Name = "lblTotalPeriodicals";
            this.lblTotalPeriodicals.Size = new System.Drawing.Size(53, 19);
            this.lblTotalPeriodicals.TabIndex = 19;
            this.lblTotalPeriodicals.Text = "Total : ";
            // 
            // frmCriteria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(983, 513);
            this.Controls.Add(this.lblTotalPeriodicals);
            this.Controls.Add(this.lblTotalWritten);
            this.Controls.Add(this.lblTotalPerformance);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnMinusPeriodicals);
            this.Controls.Add(this.btnPlusPeriodicals);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pnlPeriodicals);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnMinusWrittenWorks);
            this.Controls.Add(this.btnPlusWrittenWorks);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pnlWritten);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnMinusPerformance);
            this.Controls.Add(this.btnPlusPerformance);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblPercentage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlPerformance);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCriteria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Criteria";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCriteria_FormClosing);
            this.Load += new System.EventHandler(this.frmCriteria_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlPerformance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPercentage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnMinusPerformance;
        private System.Windows.Forms.Button btnPlusPerformance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnMinusWrittenWorks;
        private System.Windows.Forms.Button btnPlusWrittenWorks;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlWritten;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnMinusPeriodicals;
        private System.Windows.Forms.Button btnPlusPeriodicals;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel pnlPeriodicals;
        private System.Windows.Forms.Timer doCancel;
        private System.Windows.Forms.Label lblTotalPerformance;
        private System.Windows.Forms.Label lblTotalWritten;
        private System.Windows.Forms.Label lblTotalPeriodicals;
    }
}