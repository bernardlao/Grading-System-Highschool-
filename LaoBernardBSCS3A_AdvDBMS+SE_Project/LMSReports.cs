using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using MyClassCollection;

namespace LaoBernardBSCS3A_AdvDBMS_SE_Project
{
    public partial class LMSReports : DevExpress.XtraReports.UI.XtraReport
    {
        MySQLDBUtilities db = new MySQLDBUtilities();
        public LMSReports()
        {
            InitializeComponent();
        }
        public void PrepareData(List<StudentInClass> scs)
        {
            int max = 25;
            List<StudentInClass> males = scs.Where(s => s.gender.Equals("Male")).OrderBy(s=>s.fullname).Select(s => s).ToList();
            if (males.Count > 25)
                max = males.Count;
            for (int i = 0; i < max; i++)
            {
                tblMale.InsertRowBelow(tblMale.Rows[i]);
            }
            for (int i = 1; i < tblMale.Rows.Count; i++)
            {
                tblMale.Rows[i].Cells[0].Text = (i).ToString();
                tblMale.Rows[i].Cells[1].Text = ((i - 1)< males.Count?males[i-1].fullname:"");
            }
            max =25;
            //FEMALE
            List<StudentInClass> females = scs.Where(s => s.gender.Equals("Female")).OrderBy(s => s.fullname).Select(s => s).ToList();
            tblFemale.LocationF = new PointF(tblFemale.LocationF.X, tblMale.LocationF.Y + tblMale.SizeF.Height + 20);
            if (females.Count > 25)
                max = females.Count;
            for (int i = 0; i < max + 3; i++)
            {
                tblFemale.InsertRowBelow(tblFemale.Rows[i]);
            }
            for (int i = 1; i < tblFemale.Rows.Count; i++)
            {
                tblFemale.Rows[i].Cells[0].Text = (i).ToString();
                tblFemale.Rows[i].Cells[1].Text = ((i - 1) < females.Count ? females[i - 1].fullname : "");
            }
            for (int i = tblFemale.Rows.Count - 3; i < tblFemale.Rows.Count; i++)
            {
                tblFemale.Rows[i].Cells[0].Text = "";
                tblFemale.Rows[i].Cells[1].TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            }
            tblFemale.Rows[tblFemale.Rows.Count - 3].Cells[1].Text = "NO. OF STUDENTS PASSED";
            tblFemale.Rows[tblFemale.Rows.Count - 2].Cells[1].Text = "NO. OF STUDENTS PRESENT";
            tblFemale.Rows[tblFemale.Rows.Count - 1].Cells[1].Text = "MASTERY LEVEL";
            SetHeader();
        }
        private void SetHeader()
        {
            DataTable dt = db.SelectTable("SELECT * FROM tbluser u INNER JOIN tblschool sc ON u.userid=sc.userid WHERE u.userid = " + frmLogin.userid);
            if (dt != null)
            {
                if (dt.Rows.Count != 0)
                {
                    DataRow r = dt.Rows[0];
                    lblDepartment.Text = r["usermajor"].ToString().ToUpper() + " DEPARTMENT";
                    lblTeacher.Text += (r["usergender"].ToString().Equals("Male") ? "Mr. " + r["userfullname"].ToString() :
                        "Ms. " + r["userfullname"].ToString());
                    DataRow rc = db.SelectTable("SELECT * FROM tblclass c INNER JOIN tblyearsection y ON c.yearsecid = y.yearsecid WHERE classSignature='" +
                        frmReportsPrint.classSignature + "' LIMIT 1").Rows[0];
                    lblGradeAndSection.Text += "  GRADE " + rc["year"].ToString() + " - " + rc["sectionname"].ToString().ToUpper();
                    lblAddress.Text = r["schooladdress"].ToString();
                    lblSchoolName.Text = r["schoolname"].ToString();
                    this.ShowPreviewDialog();
                }
                else
                    MessageBox.Show("Please set School information in the settings first.");
            }
            else
                MessageBox.Show("Please set School information in the settings first.");
            
        }
    }
}
