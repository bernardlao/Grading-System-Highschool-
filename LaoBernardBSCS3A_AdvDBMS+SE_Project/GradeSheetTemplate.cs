using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraReports.UI;
using MyClassCollection;

namespace LaoBernardBSCS3A_AdvDBMS_SE_Project
{
    public partial class GradeSheetTemplate : DevExpress.XtraReports.UI.XtraReport
    {
        MySQLDBUtilities db = new MySQLDBUtilities();
        List<Attendance> attendees = new List<Attendance>();
        private int studentCount;
        //private string maxDays;
        public GradeSheetTemplate()
        {
            InitializeComponent();
            PopulateAttendance();
        }
        private void PopulateAttendance()
        {
            DataTable dt = db.SelectTable("SELECT * FROM tblattendance WHERE classid IN(" + frmReportsPrint.cIDs +
                ") AND attendancedate BETWEEN '" + frmReportsPrint.from.ToString("yyyy-MM-dd") + "' AND '" +
                frmReportsPrint.to.ToString("yyyy-MM-dd") + "';");
            foreach (DataRow r in dt.Rows)
            {
                Attendance a = new Attendance(r["attendanceid"].ToString(), r["isPresent"].ToString(), r["classid"].ToString());
                attendees.Add(a);
            }
            /*int max = 0;
            string[] ids = frmReportsPrint.cIDs.Split(',');
            foreach (string i in ids)
            {
                List<Attendance> totalPerStudent = attendees.Where(s => s.ClassID.Equals(i)).Select(s => s).ToList();
                if (totalPerStudent.Count > max)
                    max = totalPerStudent.Count;
            }
            maxDays = max.ToString();*/
        }
        public void PrepareData(List<StudentInClass> sts, List<Grade> gs,List<Criteria> crits,string quarter)
        {
            studentCount = sts.Count;
            gs = gs.Where(s => s.Quarter.Equals(quarter)).Select(s => s).ToList();
            int max = 25;

            List<StudentInClass> males = sts.Where(s => s.gender.Equals("Male")).OrderBy(s=>s.fullname).Select(s => s).ToList();
            if (males.Count > 25)
                max = males.Count;
            for (int i = 1; i < max; i++)
            {
                tblMale.InsertRowBelow(tblMale.Rows[i]);
            }
            for (int i = 1; i <= max; i++)
            {
                tblMale.Rows[i].Cells[0].Text = i.ToString();
                tblMale.Rows[i].Cells[1].Text = ((i - 1) < males.Count ? males[i - 1].fullname : "");
            }
            ImplementGradesForMales(males, gs, crits);
            XRPageBreak br = new XRPageBreak();
            br.LocationF = new PointF(40, tblMale.LocationF.Y + tblMale.SizeF.Height);
            this.Bands[BandKind.Detail].Controls.Add(br);

            tblFemale.LocationF = new PointF(tblFemale.LocationF.X, tblMale.LocationF.Y + tblMale.SizeF.Height + 30);
            max = 25;
            List<StudentInClass> females = sts.Where(s => s.gender.Equals("Female")).OrderBy(s => s.fullname).Select(s => s).ToList();
            tblFemale.LocationF = new PointF(tblFemale.LocationF.X, tblMale.LocationF.Y + tblMale.SizeF.Height + 20);
            if (females.Count > 25)
                max = females.Count;
            for (int i = 1; i < max; i++)
            {
                tblFemale.InsertRowBelow(tblFemale.Rows[i]);
            }
            for (int i = 1; i <= max; i++)
            {
                tblFemale.Rows[i].Cells[0].Text = i.ToString();
                tblFemale.Rows[i].Cells[1].Text = ((i - 1) < females.Count ? females[i - 1].fullname : "");
            }
            tblFemale.InsertRowBelow(tblFemale.Rows[max]);
            ImplementGradesForFemales(females,gs,crits);
            SetHeader();
        }
        private void ImplementGradesForMales(List<StudentInClass> males, List<Grade> gs, List<Criteria> cs)
        {
            List<Criteria> wWorks = cs.Where(s => s.CriteriaType.Equals("WrittenWorks")).Select(s => s).ToList();
            //row1 col2-12 12total
            List<Criteria> performance = cs.Where(s => s.CriteriaType.Equals("Performance")).Select(s => s).ToList();
            //15-25 25total
            List<Criteria> periodicals = cs.Where(s => s.CriteriaType.Equals("Periodicals")).Select(s => s).ToList();
            //exam 28
            int col = 2;
            for (int i = 0; i < males.Count; i++)
            {
                foreach (Criteria c in wWorks)
                {
                    List<Grade> perStudent = GetGradesPerCriteriaPerStudent(males[i].classID, gs, c.CriteriaID);
                    foreach (Grade g in perStudent)
                    {
                        if (i == 0)
                        {
                            tblHighest.Rows[1].Cells[col].Text = g.TotalItems.ToString();
                            tblMale.Rows[0].Cells[col].Text = GenerateHeader(c.CriteriaName);
                        }
                        tblMale.Rows[i + 1].Cells[col].Text = g.RawScore.ToString();
                        col++;
                    }
                    double totalHi = 0;
                    if (i == 0)
                    {
                        for (int j = 2; j < 12; j++)
                            totalHi += Convert.ToDouble((!tblHighest.Rows[1].Cells[j].Text.Equals("") ? tblHighest.Rows[1].Cells[j].Text : "0"));
                        tblHighest.Rows[1].Cells[12].Text = totalHi.ToString();
                    }
                    
                }
                double total = 0;
                for (int j = 2; j < 12; j++)
                    total += Convert.ToDouble((!tblMale.Rows[i + 1].Cells[j].Text.Equals("") ? tblMale.Rows[i+1].Cells[j].Text : "0"));
                tblMale.Rows[i + 1].Cells[12].Text = total.ToString();
                double ps = (total / Convert.ToDouble(tblHighest.Rows[1].Cells[12].Text)) * 100;
                tblMale.Rows[i + 1].Cells[13].Text = Math.Round(ps, 2).ToString();
                tblMale.Rows[i + 1].Cells[14].Text = Math.Round((ps * 0.40), 2).ToString();

                col = 15;
                foreach (Criteria c in performance)
                {
                    if (!c.CriteriaName.Equals("Attendance"))
                    {
                        List<Grade> perStudent = GetGradesPerCriteriaPerStudent(males[i].classID, gs, c.CriteriaID);
                        foreach (Grade g in perStudent)
                        {
                            if (i == 0)
                            {
                                tblHighest.Rows[1].Cells[col].Text = "100%";
                                tblMale.Rows[i].Cells[col].Text = GenerateHeader(c.CriteriaName);
                            }
                            tblMale.Rows[i + 1].Cells[col].Text = g.RawScore.ToString();
                            col++;
                        }
                        tblHighest.Rows[1].Cells[25].Text = "100%";
                    }
                    
                }
                int index = 0;
                for (int j = 15; j < 25; j++)
                {
                    if (tblMale.Rows[i + 1].Cells[j].Text.Equals(""))
                    {
                        index = j;
                        break;
                    }
                }
                tblHighest.Rows[1].Cells[index].Text = "100%";
                tblMale.Rows[i + 1].Cells[index].Text = GetAttendanceGrade(males[i].classID);
                tblMale.Rows[0].Cells[index].Text = "Att";
                total = 0;
                double count = 0;
                for (int j = 15; j < 25; j++)
                {
                    if (!tblMale.Rows[i + 1].Cells[j].Text.Equals(""))
                    {
                        total += Convert.ToDouble((!tblMale.Rows[i + 1].Cells[j].Text.Equals("") ? tblMale.Rows[i + 1].Cells[j].Text : "0"));
                        count++;
                    }
                }
                 ps = Math.Round((total / count), 2);
                 tblMale.Rows[i + 1].Cells[25].Text = ps.ToString();
                tblMale.Rows[i + 1].Cells[26].Text = ps.ToString();
                tblMale.Rows[i + 1].Cells[27].Text = Math.Round(ps * 0.40, 2).ToString();

                List<Grade> perStudentExam = GetGradesPerCriteriaPerStudent(males[i].classID, gs, periodicals[0].CriteriaID);
                tblHighest.Rows[1].Cells[28].Text = perStudentExam[0].TotalItems.ToString();
                tblMale.Rows[i + 1].Cells[28].Text = perStudentExam[0].RawScore.ToString();
                ps = Math.Round(( perStudentExam[0].RawScore/ Convert.ToDouble(tblHighest.Rows[1].Cells[28].Text)) * 100, 2);
                tblMale.Rows[i + 1].Cells[29].Text = ps.ToString();
                tblMale.Rows[i + 1].Cells[30].Text = Math.Round(ps * 0.20, 2).ToString();

                tblMale.Rows[i + 1].Cells[31].Text = (Convert.ToDouble(tblMale.Rows[i + 1].Cells[14].Text) +
                    Convert.ToDouble(tblMale.Rows[i + 1].Cells[27].Text) + Convert.ToDouble(tblMale.Rows[i + 1].Cells[30].Text)).ToString();
                tblMale.Rows[i + 1].Cells[32].Text = GetTransmutedGrades(tblMale.Rows[i + 1].Cells[31].Text);

                col = 2;
            }
        }
        private void ImplementGradesForFemales(List<StudentInClass> females, List<Grade> gs, List<Criteria> cs)
        {
            List<Criteria> wWorks = cs.Where(s => s.CriteriaType.Equals("WrittenWorks")).Select(s => s).ToList();
            //row1 col2-12 12total
            List<Criteria> performance = cs.Where(s => s.CriteriaType.Equals("Performance")).Select(s => s).ToList();
            //15-25 25total
            List<Criteria> periodicals = cs.Where(s => s.CriteriaType.Equals("Periodicals")).Select(s => s).ToList();
            //exam 28
            int col = 2;
            for (int i = 0; i < females.Count; i++)
            {
                foreach (Criteria c in wWorks)
                {
                    List<Grade> perStudent = GetGradesPerCriteriaPerStudent(females[i].classID, gs, c.CriteriaID);
                    foreach (Grade g in perStudent)
                    {
                        if (i == 0)
                        {
                            tblFemale.Rows[0].Cells[col].Text = GenerateHeader(c.CriteriaName);
                        }
                        tblFemale.Rows[i + 1].Cells[col].Text = g.RawScore.ToString();
                        col++;
                    }
                    

                }
                double total = 0;
                for (int j = 2; j < 12; j++)
                    total += Convert.ToDouble((!tblFemale.Rows[i + 1].Cells[j].Text.Equals("") ? tblFemale.Rows[i + 1].Cells[j].Text : "0"));
                tblFemale.Rows[i + 1].Cells[12].Text = total.ToString();
                double ps = Math.Round((total / Convert.ToDouble(tblHighest.Rows[1].Cells[12].Text)) * 100, 2);
                tblFemale.Rows[i + 1].Cells[13].Text = ps.ToString();
                tblFemale.Rows[i + 1].Cells[14].Text = Math.Round(ps * 0.40, 2).ToString();

                col = 15;
                foreach (Criteria c in performance)
                {
                    if (!c.CriteriaName.Equals("Attendance"))
                    {
                        List<Grade> perStudent = GetGradesPerCriteriaPerStudent(females[i].classID, gs, c.CriteriaID);
                        foreach (Grade g in perStudent)
                        {
                            if (i == 0)
                            {
                                tblFemale.Rows[i].Cells[col].Text = GenerateHeader(c.CriteriaName);
                            }
                            tblFemale.Rows[i + 1].Cells[col].Text = g.RawScore.ToString();
                            col++;
                        }
                        
                    }

                }
                int index = 0;
                for (int j = 15; j < 25; j++)
                {
                    if (tblFemale.Rows[i + 1].Cells[j].Text.Equals(""))
                    {
                        index = j;
                        break;
                    }
                }
                tblFemale.Rows[i + 1].Cells[index].Text = GetAttendanceGrade(females[i].classID);
                tblFemale.Rows[0].Cells[index].Text = "At";
                total = 0;
                double count = 0;
                for (int j = 15; j < 25; j++)
                {
                    if (!tblFemale.Rows[i + 1].Cells[j].Text.Equals(""))
                    {
                        total += Convert.ToDouble((!tblFemale.Rows[i + 1].Cells[j].Text.Equals("") ? tblFemale.Rows[i + 1].Cells[j].Text : "0"));
                        count++;
                    }
                }
                ps = Math.Round((total / count), 2);
                tblFemale.Rows[i + 1].Cells[25].Text = ps.ToString();
                tblFemale.Rows[i + 1].Cells[26].Text = ps.ToString();
                tblFemale.Rows[i + 1].Cells[27].Text = Math.Round(ps * 0.40, 2).ToString();

                List<Grade> perStudentExam = GetGradesPerCriteriaPerStudent(females[i].classID, gs, periodicals[0].CriteriaID);
                tblFemale.Rows[i + 1].Cells[28].Text = perStudentExam[0].RawScore.ToString();
                ps = Math.Round((perStudentExam[0].RawScore / Convert.ToDouble(tblHighest.Rows[1].Cells[28].Text)) * 100, 2);
                tblFemale.Rows[i + 1].Cells[29].Text = ps.ToString();
                tblFemale.Rows[i + 1].Cells[30].Text = Math.Round(ps * 0.20, 2).ToString();

                tblFemale.Rows[i + 1].Cells[31].Text = (Convert.ToDouble(tblFemale.Rows[i + 1].Cells[14].Text) +
                    Convert.ToDouble(tblFemale.Rows[i + 1].Cells[27].Text) + Convert.ToDouble(tblFemale.Rows[i + 1].Cells[30].Text)).ToString();
                tblFemale.Rows[i + 1].Cells[32].Text = GetTransmutedGrades(tblFemale.Rows[i + 1].Cells[31].Text);

                double totalGSA = 0;
                for (int j = 1; j < tblMale.Rows.Count; j++)
                    if (!tblMale.Rows[j].Cells[32].Text.Equals(""))
                        totalGSA += Convert.ToDouble(tblMale.Rows[j].Cells[32].Text);
                for (int j = 1; j < tblFemale.Rows.Count - 1; j++)
                    if (!tblFemale.Rows[j].Cells[32].Text.Equals(""))
                        totalGSA += Convert.ToDouble(tblFemale.Rows[j].Cells[32].Text);
                totalGSA = totalGSA / studentCount;
                tblFemale.Rows[tblFemale.Rows.Count - 1].Cells[31].Text = "GSA";
                tblFemale.Rows[tblFemale.Rows.Count - 1].Cells[32].Text = Math.Round(totalGSA, 2).ToString();
                col = 2;
            }
        }
        private string GetAttendanceGrade(string cid)
        {
            List<Attendance> attendPerStudent = attendees.Where(s => s.ClassID.Equals(cid) && s.IsPresent == false).Select(s => s).ToList();
            double score = 100 - (attendPerStudent.Count * frmReportsPrint.attDeduction);
            return score.ToString();
        }

        private string GetTransmutedGrades(string initialGrade)
        {
            if (initialGrade.Equals(""))
                return "60";
            double g = Convert.ToDouble(initialGrade);
            if (g == 100)
                return "100";
            else if (g >= 98.40 && g <= 99)
                return "99";
            else if (g >= 96.80 && g <= 98.39)
                return "98";
            else if (g >= 95.20 && g <= 96.79)
                return "97";
            else if (g >= 93.60 && g <= 95.19)
                return "96";
            else if (g >= 92 && g <= 93.59)
                return "95";
            else if (g >= 90.40 && g <= 91.99)
                return "94";
            else if (g >= 88.80 && g <= 90.39)
                return "93";
            else if (g >= 87.20 && g <= 88.79)
                return "92";
            else if (g >= 85.60 && g <= 87.19)
                return "91";
            else if (g >= 84 && g <= 85.59)
                return "90";
            else if (g >= 82.40 && g <= 83.99)
                return "89";
            else if (g >= 80.80 && g <= 82.39)
                return "88";
            else if (g >= 79.20 && g <= 80.79)
                return "87";
            else if (g >= 77.60 && g <= 79.19)
                return "86";
            else if (g >= 76 && g <= 77.59)
                return "85";
            else if (g >= 74.40 && g <= 75.99)
                return "84";
            else if (g >= 72.80 && g <= 74.39)
                return "83";
            else if (g >= 71.20 && g <= 72.79)
                return "82";
            else if (g >= 69.60 && g <= 71.19)
                return "81";
            else if (g >= 68 && g <= 69.59)
                return "80";
            else if (g >= 66.40 && g <= 67.99)
                return "79";
            else if (g >= 64.80 && g <= 66.39)
                return "78";
            else if (g >= 63.20 && g <= 64.79)
                return "77";
            else if (g >= 61.60 && g <= 63.19)
                return "76";
            else if (g >= 60 && g <= 61.59)
                return "75";
            else if (g >= 56 && g <= 59.99)
                return "74";
            else if (g >= 52 && g <= 55.99)
                return "73";
            else if (g >= 48 && g <= 51.99)
                return "72";
            else if (g >= 44 && g <= 47.99)
                return "71";
            else if (g >= 40 && g <= 43.99)
                return "70";
            else if (g >= 36 && g <= 39.99)
                return "69";
            else if (g >= 32 && g <= 35.99)
                return "68";
            else if (g >= 28 && g <= 31.99)
                return "67";
            else if (g >= 24 && g <= 27.99)
                return "66";
            else if (g >= 20 && g <= 23.99)
                return "65";
            else if (g >= 16 && g <= 19.99)
                return "64";
            else if (g >= 12 && g <= 15.99)
                return "63";
            else if (g >= 8 && g <= 11.99)
                return "62";
            else if (g >= 4 && g <= 7.99)
                return "61";
            else
                return "60";


        }
        private string GenerateHeader(string name)
        {
            string retVal = "";
            if (name.Contains(" "))
            {
                string[] arr = name.Split(' ');
                foreach (string s in arr)
                    retVal += s.Substring(0, 1).ToUpper() + s.Substring(1, 1).ToLower();
            }
            else if (name.ToLower().Contains("quiz"))
                retVal = "Q";
            else
                retVal = name.Substring(0, 1).ToUpper() + name.Substring(1, 2).ToLower();
            return retVal;
        }
        private List<Grade> GetGradesPerCriteriaPerStudent(string classid, List<Grade> grades, string criteriaID)
        {
            try
            {
                List<Grade> gs = grades.Where(s => s.ClassID.Equals(classid) && s.CriteriaID.Equals(criteriaID)).Select(s => s).OrderBy(s => s.GradesID).ToList();
                return gs;
            }
            catch { return new List<Grade>(); }
        }
        private void SetHeader()
        {
            DataTable dt = db.SelectTable("SELECT * FROM tbluser u INNER JOIN tblschool sc ON u.userid=sc.userid WHERE u.userid = " + frmLogin.userid);
            if (dt != null)
            {
                if (dt.Rows.Count != 0)
                {
                    DataRow r = dt.Rows[0];
                    lblRegion.Text = r["schoolregion"].ToString();
                    lblDivision.Text = r["schooldivision"].ToString();
                    lblSchoolName.Text = r["schoolname"].ToString();
                    lblSchoolID.Text = r["schoolid"].ToString();

                    DataRow rc = db.SelectTable("SELECT * FROM tblclass c INNER JOIN tblyearsection y ON c.yearsecid = y.yearsecid WHERE classSignature='" +
                        frmReportsPrint.classSignature + "' LIMIT 1").Rows[0];
                    lblSchoolYear.Text = rc["schoolyear"].ToString();
                    switch (frmReportsPrint.quarter)
                    {
                        case "1st": tblInformation.Rows[0].Cells[0].Text = "FIRST QUARTER"; break;
                        case "2nd": tblInformation.Rows[0].Cells[0].Text = "SECOND QUARTER"; break;
                        case "3rd": tblInformation.Rows[0].Cells[0].Text = "THIRD QUARTER"; break;
                        case "4th": tblInformation.Rows[0].Cells[0].Text = "FOURTH QUARTER"; break;
                    }
                    tblInformation.Rows[0].Cells[1].Text += rc["year"].ToString() + " - " + rc["sectionname"].ToString().ToUpper();
                    tblInformation.Rows[0].Cells[2].Text += (r["usergender"].ToString().Equals("Male") ? "Mr. " + r["userfullname"].ToString() :
                        "Ms. " + r["userfullname"].ToString());
                    tblInformation.Rows[0].Cells[3].Text += frmReportsPrint.header.Split('/')[0].ToUpper();
                    
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
