using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyClassCollection;

namespace LaoBernardBSCS3A_AdvDBMS_SE_Project
{
    public partial class frmReportsPrint : Form
    {
        MySQLDBUtilities db = new MySQLDBUtilities();
        public static bool isValid = false;
        public static bool triggerClose = false;
        public static string classSignature = "";
        public static string header = "";
        public static string[] criterias;

        public static DateTime from = DateTime.Now;
        public static DateTime to = DateTime.Now;
        public static string cIDs = "";
        List<StudentInClass> students;
        List<Grade> grades;
        List<Criteria> crits;
        List<Attendance> attendance;
        public static int attDeduction;
        private double totalRec;
        public static string quarter;

        public frmReportsPrint()
        {
            InitializeComponent();
            students = new List<StudentInClass>();
            grades = new List<Grade>();
            crits = new List<Criteria>();
            attendance = new List<Attendance>();
        }

        private void frmReportsPrint_Load(object sender, EventArgs e)
        {
            frmEditClass ec = new frmEditClass();
            ec.isForRecords = true;
            ec.ShowDialog();
            cmbQuarter.SelectedItem = cmbQuarter.Items[0];
            
        }

        private void tmSetter_Tick(object sender, EventArgs e)
        {
            if (isValid)
            {
                Initialize();
            }
            if (triggerClose)
            {
                triggerClose = false;
                this.Close();
            }
        }
        private void Initialize()
        {
            cmbMonths.SelectedItem = cmbMonths.Items[0];
            tmSetter.Enabled = false;
            isValid = false;
            lblDescription.Text += header;
            PopulateStudents();
            PopulateGrades();
            PopulateCriteria();
            PopulateAttendance();
            PopulateColumns();
            PopulateRecords("1st");
            SetValidDates();
        }
        private void SetValidDates()
        {
            DataTable dtValid = db.SelectTable("SELECT * FROM tblclass WHERE classSignature ='" + classSignature + "' LIMIT 1");
            if (dtValid != null)
            {
                if (dtValid.Rows.Count > 0)
                {
                    DateTime min = Convert.ToDateTime(dtValid.Rows[0]["classStart"].ToString());
                    DateTime max = Convert.ToDateTime(dtValid.Rows[0]["classEnd"].ToString());
                    dtpFrom.MinDate = min;
                    dtpFrom.MaxDate = max;
                    dtpTo.MinDate = min;
                    dtpTo.MaxDate = max;
                }
            }
        }
        private void PopulateStudents()
        {
            cIDs = "";
            students = new List<StudentInClass>();
            DataTable dtStudent = db.SelectTable("SELECT *,CONCAT(studlname,', ', studfname,' ',studmname) FROM (tblstudent s INNER JOIN tblclass c ON s.studno = c.studno) " +
                "WHERE classSignature='" + classSignature + "' ORDER BY CONCAT(studlname,', ', studfname,' ',studmname) ASC");
            foreach (DataRow r in dtStudent.Rows)
            {
                StudentInClass sin = new StudentInClass(r["CONCAT(studlname,', ', studfname,' ',studmname)"].ToString(),
                    r["studno"].ToString(), r["classid"].ToString(),r["studgender"].ToString());
                students.Add(sin);
                cIDs += sin.classID + ",";
            }
            cIDs = cIDs.Remove(cIDs.Length - 1);
        }
        private void PopulateGrades()
        {//gradesid, rawscore, average, quarter, criteriaid, classid, totalitems
            grades = new List<Grade>();
            DataTable dt = db.SelectTable("SELECT * FROM tblgrades WHERE classid IN(" + cIDs + ");");
            foreach (DataRow r in dt.Rows)
            {
                Grade g = new Grade(r["gradesid"].ToString(), Convert.ToDouble(r["rawscore"].ToString()), Convert.ToDouble(r["totalitems"].ToString()),
                    r["quarter"].ToString(), r["criteriaid"].ToString(), r["classid"].ToString(),Convert.ToDouble(r["average"].ToString()));
                grades.Add(g);
            }
        }
        private void PopulateCriteria()
        {
            crits = new List<Criteria>();
            string crIDs = "";
            foreach (string s in criterias)
                crIDs += s + ",";
            crIDs = crIDs.Remove(crIDs.Length - 1);
            DataTable dtCrit = db.SelectTable("SELECT * FROM tblcriteria WHERE criteriaid IN(" + crIDs + ");");
            foreach (DataRow r in dtCrit.Rows)
            {
                Criteria c = new Criteria(r["criteriaid"].ToString(), r["criterianame"].ToString(), r["criteriapercentage"].ToString(),
                    r["userid"].ToString(), r["criteriaIsActive"].ToString(), r["criteriaType"].ToString());
                crits.Add(c);
            }
        }
        private void PopulateAttendance() 
        {
            attendance = new List<Attendance>();
            DataTable dtAttend = db.SelectTable("SELECT * FROM tblattendance WHERE classid IN(" + cIDs + ") AND attendancedate BETWEEN '"+
                dtpFrom.Value.ToString("yyyy-MM-dd") + "' AND '" + dtpTo.Value.ToString("yyyy-MM-dd").ToString() + "';");
            foreach (DataRow r in dtAttend.Rows)
            {
                Attendance att = new Attendance(r["attendanceid"].ToString(),r["isPresent"].ToString(),r["classid"].ToString());
                attendance.Add(att);
            }
            attDeduction = Convert.ToInt32(db.DataLookUp("attendanceDeduction", "tbluser", "", "userid=" + frmLogin.userid));
        }
        private void PopulateColumns()
        {
            foreach (Criteria c in crits)
            {
                lstRecords.Columns.Add(c.CriteriaName + "(" + c.CriteriaPercentage + "%)", 120, HorizontalAlignment.Right);
            }
            lstRecords.Columns.Add("Initial Grade", 120, HorizontalAlignment.Right);
            for (int i = 2; i < lstRecords.Columns.Count - 1; i++)
            {
                lstRecords.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }
        private void PopulateRecords(string quarter)
        {
            lstRecords.Items.Clear();
            
            List<Grade> quarterlyGrades = GetAllGradesPerQuarter(quarter);

            foreach (StudentInClass sic in students)
            {
                totalRec = 0;
                List<Grade> studentGrades = GetAllGradesPerStudent(quarterlyGrades, sic.classID);
                ListViewItem itm = new ListViewItem(sic.studentNo);
                itm.SubItems.Add(sic.fullname);
                foreach (Criteria c in crits)
                {
                    itm.SubItems.Add(GetPerCriteriaAverage(c, sic.classID, studentGrades).ToString());
                    //total += GetPerCriteriaAverage(c, sic.classID, studentGrades);
                }
                itm.SubItems.Add(Math.Round(totalRec,2).ToString());
                lstRecords.Items.Add(itm);
            }
            for (int i = 0; i < lstRecords.Items.Count; i++)
            {
                double totalMax = Convert.ToDouble(lstRecords.Items[i].SubItems[lstRecords.Items[i].SubItems.Count - 1].Text);
                if (totalMax < 75)
                    lstRecords.Items[i].BackColor = Color.Red;
                else if (totalMax > 74 && totalMax < 91)
                    lstRecords.Items[i].BackColor = Color.Gold;
                else if (totalMax > 90)
                    lstRecords.Items[i].BackColor = Color.LightGreen;
            }
        }
        private List<Grade> GetAllGradesPerQuarter(string quater)
        {
            try
            {
                List<Grade> gs = grades.Where(s => s.Quarter.Equals(quater)).Select(s => s).ToList();
                return gs;
            }
            catch { return new List<Grade>(); }
        }
        private List<Grade> GetAllGradesPerStudent(List<Grade> qGrades, string cID)
        {
            try
            {
                List<Grade> gs = qGrades.Where(s => s.ClassID.Equals(cID)).Select(s => s).ToList();
                return gs;
            }
            catch { return new List<Grade>(); }
        }
        private double GetPerCriteriaAverage(Criteria cr, string cID, List<Grade> perStudent)
        {
            try
            {
                if (cr.CriteriaName.Equals("Attendance"))
                {
                    List<Attendance> absences = attendance.Where(s => s.IsPresent == false && s.ClassID.Equals(cID)).Select(s => s).ToList();
                    double total = 100 - (absences.Count * attDeduction);
                    if (total < 70)
                        total = 70;
                    double percent = Convert.ToDouble(cr.CriteriaPercentage) / 100;
                    double retVal = total * percent;
                    totalRec += retVal;
                    return retVal;
                }
                else if (cr.CriteriaType.Equals("WrittenWorks") || cr.CriteriaType.Equals("Periodicals"))
                {
                    List<Grade> gs = perStudent.Where(s => s.CriteriaID.Equals(cr.CriteriaID) && s.ClassID.Equals(cID)).Select(s => s).ToList();
                    double divisor = gs.Sum(s => s.TotalItems);
                    double gradeInCriteria = gs.Sum(s => s.RawScore);
                    double percent = Convert.ToDouble(cr.CriteriaPercentage) / 100;
                    double retVal = ((gradeInCriteria / divisor) * 100) * percent;
                    totalRec += retVal;
                    return Math.Round(retVal, 2);
                }
                else
                {
                    List<Grade> gs = perStudent.Where(s => s.CriteriaID.Equals(cr.CriteriaID) && s.ClassID.Equals(cID)).Select(s => s).ToList();
                    double divisor = gs.Count;
                    double gradeInCriteria = gs.Sum(s => s.RawScore);
                    double percent = Convert.ToDouble(cr.CriteriaPercentage) / 100;
                    double retVal = (gradeInCriteria / divisor) * percent;
                    totalRec += retVal;
                    return Math.Round(retVal, 2);
                }
            }
            catch { return 0; }
        }
        private void frmReportsPrint_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMain.isAnyFormOpen = false;
        }

        private void cmbQuarter_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateRecords(cmbQuarter.SelectedItem.ToString());
        }
        private bool IsAllGradesValid()
        {
            foreach (ListViewItem itm in lstRecords.Items)
            {
                for (int i = 0; i < itm.SubItems.Count; i++)
                {
                    if (itm.SubItems[i].Text.Equals("NaN"))
                    {
                        MessageBox.Show("Some grade(s) is/are missing. Please grade your students before printing grades.", "Inconsistent Information");
                        return false;
                    }
                }
            }
            return true;
        }
        private void btnPrintLMS_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Produce LMS?", "Creating Document(s)",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                LMSReports rep = new LMSReports();
                rep.PrepareData(students);
            }
        }

        private void btnPrintGrade_Click(object sender, EventArgs e)
        {
            if (IsAllGradesValid())
            {
                if (DialogResult.Yes == MessageBox.Show("Produce Class Record?", "Creating Document(s)",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    quarter = cmbQuarter.SelectedItem.ToString();
                    GradeSheetTemplate gs = new GradeSheetTemplate();
                    gs.PrepareData(students, grades, crits, cmbQuarter.SelectedItem.ToString());
                }
            }
        }

        

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Produce Attendance Record?", "Creating Document(s)",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                AttendanceSheet aSheet = new AttendanceSheet();
                string[] splittedSignature = classSignature.Split('-');
                string[] sys = splittedSignature[splittedSignature.Length - 1].Replace("to", " ").Split(' ');
                aSheet.PrepareData((cmbMonths.SelectedIndex + 1), students, sys);
            }
        }
        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            from = dtpFrom.Value;
            to = dtpTo.Value;
            PopulateAttendance();
            PopulateRecords(cmbQuarter.SelectedItem.ToString());
        }
        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            dtpTo.Value = dtpFrom.Value.AddMonths(3);
            from = dtpFrom.Value;
            to = dtpTo.Value;
            PopulateAttendance();
            PopulateRecords(cmbQuarter.SelectedItem.ToString());
        }
    }
}
