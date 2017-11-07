using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using DevExpress.XtraReports.UI;
using MyClassCollection;

namespace LaoBernardBSCS3A_AdvDBMS_SE_Project
{
    public partial class AttendanceSheet : DevExpress.XtraReports.UI.XtraReport
    {
        MySQLDBUtilities db = new MySQLDBUtilities();
        List<Attendance> attendance;
        int page = 0;
        int totalDays = 0;
        string monthString;
        private bool preventPageHeader = false;

        public AttendanceSheet()
        {
            InitializeComponent();
            attendance = new List<Attendance>();
        }
        public void PrepareData(int month, List<StudentInClass> studs,string[] sy)
        {
            if (studs.Count < 37)
                preventPageHeader = true;
            string ids = "";
            foreach (StudentInClass s in studs)
                ids += s.classID + ",";
            ids = ids.Remove(ids.Length - 1);
            DataTable dt = db.SelectTable("SELECT * FROM tblattendance WHERE MONTH(attendancedate) = " + month  + " AND classid IN(" + ids + ");");
            foreach (DataRow r in dt.Rows)
            {
                Attendance a = new Attendance(r["attendanceid"].ToString(), r["isPresent"].ToString(), r["classid"].ToString(),r["attendancedate"].ToString());
                attendance.Add(a);
            }
            SetDays(month,sy);
            List<StudentInClass> males = studs.Where(s => s.gender.Equals("Male")).Select(s => s).ToList();
            SetTable(tblMale, males);
            tblFemale.LocationF = new PointF(tblFemale.LocationF.X, tblMale.LocationF.Y + tblMale.SizeF.Height);
            List<StudentInClass> females = studs.Where(s => s.gender.Equals("Female")).Select(s => s).ToList();
            SetTable(tblFemale, females);
            DoOverall();
            pnlFooter.LocationF = new PointF(pnlFooter.LocationF.X, tblFemale.LocationF.Y + tblFemale.SizeF.Height + 10);
            SetHeaders();
        }
        private void SetDays(int month, string[] schoolYear)
        {
            string year = "";
            int maxDay = 0;
            if (month > 5)
                year = schoolYear[0];
            else
                year = schoolYear[1];
            maxDay = DateTime.DaysInMonth(Convert.ToInt32(year), month);
            monthString = Convert.ToDateTime(month.ToString() + "/1/" + year).ToString("MMMM");
            int counter = 1;
            for (int i = 1; i <= maxDay; i++)
            {
                DateTime d = Convert.ToDateTime((month.ToString() + "/" + i + "/" + year).ToString());
                if (d.DayOfWeek != DayOfWeek.Saturday && d.DayOfWeek != DayOfWeek.Sunday)
                {
                    tblNumber.Rows[0].Cells[counter].Text = i.ToString();
                    tblDays.Rows[0].Cells[counter].Text = d.DayOfWeek.ToString().Substring(0, 3).ToUpper();
                    tblNumber2.Rows[0].Cells[counter].Text = i.ToString();
                    tblDays2.Rows[0].Cells[counter].Text = d.DayOfWeek.ToString().Substring(0, 3).ToUpper();
                    totalDays++;
                    counter++;
                }
            }
        }
        private void SetTable(XRTable tbl, List<StudentInClass> sin)
        {
            int rowCount = sin.Count;
            for (int i = 0; i < rowCount; i++)
            {
                tbl.Rows[i].Cells[0].Text = (i + 1).ToString();
                tbl.InsertRowBelow(tbl.Rows[i]);
            }
            for(int i = 0; i < sin.Count; i++)
            {
                int absCount = 0;
                StudentInClass s = sin[i];
                tbl.Rows[i].Cells[1].Text = s.fullname;
                List<Attendance> perStudent = attendance.Where(a => a.ClassID.Equals(s.classID) && a.IsPresent == false).Select(a => a).ToList();
                foreach (Attendance a in perStudent)
                {
                    for (int j = 0; j < tblNumber.Rows[0].Cells.Count; j++)
                    {
                        if (a.AttendanceDate.Day.ToString().Equals(tblNumber.Rows[0].Cells[j].Text))
                        {
                            tbl.Rows[i].Cells[j + 2].Text = "X";
                        }
                    }
                }
                tbl.Rows[i].Cells[27].Text = perStudent.Count.ToString();
                tbl.Rows[i].Cells[28].Text = "0";
            }
            int lastRow = tbl.Rows.Count - 1;
            tbl.Rows[lastRow].Cells[0].SizeF = new SizeF(0, tbl.Rows[lastRow].Cells[0].SizeF.Height);
            tbl.Rows[lastRow].Cells[1].Text = (tbl.Name.Equals("tblMale") ? "MALE | " : "FEMALE | ") + "Total Per Day";
            int totalAbsences = 0;
            for (int i = 2; i < 27; i++)
            {
                if (!tblNumber.Rows[0].Cells[i - 2].Text.Equals(""))
                {
                    int presentCount = 0;
                    for (int j = 0; j < tbl.Rows.Count - 1; j++)
                    {
                        if (tbl.Rows[j].Cells[i].Text.Equals(""))
                            presentCount++;
                    }
                    tbl.Rows[lastRow].Cells[i].Text = presentCount.ToString();
                }
            }
            for (int i = 0; i < tbl.Rows.Count - 1; i++)
            {
                totalAbsences += Convert.ToInt32(tbl.Rows[i].Cells[27].Text);
            }
            tbl.Rows[lastRow].Cells[27].Text = totalAbsences.ToString();
            tbl.Rows[lastRow].Cells[28].Text = "0";
            tbl.Rows[lastRow].Font = new Font("Arial",7, FontStyle.Bold);
        }
        private void DoOverall()
        {
            tblFemale.InsertRowBelow(tblFemale.Rows[tblFemale.Rows.Count - 1]);
            tblFemale.Rows[tblFemale.Rows.Count - 1].Font = new Font("Arial", 7, FontStyle.Bold);
            int femaleCount = tblFemale.Rows.Count - 2;
            int maleCount = tblMale.Rows.Count - 1;
            tblFemale.Rows[femaleCount + 1].Cells[1].Text = "Combined TOTAL PER DAY";
            for (int i = 2; i < 28; i++)
            {
                if (!tblMale.Rows[maleCount].Cells[i].Text.Equals(""))
                {
                    int male = Convert.ToInt32(tblMale.Rows[maleCount].Cells[i].Text);
                    int female = Convert.ToInt32(tblFemale.Rows[femaleCount].Cells[i].Text);
                    int totalAbs = male + female;
                    tblFemale.Rows[femaleCount + 1].Cells[i].Text = totalAbs.ToString();
                }
            }
            tblFemale.Rows[femaleCount + 1].Cells[28].Text = "0"; 
        }
        private void SetHeaders()
        {
            DataTable dt = db.SelectTable("SELECT * FROM tbluser u INNER JOIN tblschool sc ON u.userid=sc.userid WHERE u.userid = " + frmLogin.userid);
            if (dt != null)
            {
                if (dt.Rows.Count != 0)
                {
                    DataRow r = dt.Rows[0];
                    DataRow rc = db.SelectTable("SELECT * FROM tblclass c INNER JOIN tblyearsection y ON c.yearsecid = y.yearsecid WHERE classSignature='" +
                        frmReportsPrint.classSignature + "' LIMIT 1").Rows[0];
                    lblGrade.Text = rc["year"].ToString();
                    lblMonth.Text = monthString.ToUpper();
                    lblMonthTable.Text += monthString.ToUpper();
                    lblNoOfDays.Text += totalDays.ToString();
                    lblSchoolHead.Text = r["schoolhead"].ToString();
                    lblSchoolID.Text = r["schoolid"].ToString();
                    lblSchoolName.Text = r["schoolname"].ToString();
                    lblSchoolYear.Text = rc["schoolyear"].ToString();
                    lblSection.Text = rc["sectionname"].ToString();
                    lblTeacher.Text = r["userfullname"].ToString();
                    this.ShowPreviewDialog();
                }
                else
                    MessageBox.Show("Please set School information in the settings first.");
            }
            else
                MessageBox.Show("Please set School information in the settings first.");
        }
        private void PageHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (preventPageHeader)
                e.Cancel = true;
            else
            {
                page++;
                if (page == 1 || page > 2) { e.Cancel = true; }
            }
        }
    }
}
