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
    public partial class frmAbsences : Form
    {
        MySQLDBUtilities db = new MySQLDBUtilities();
        HelperMethods hm = new HelperMethods();
        public static string classSignature = "";
        public static bool triggerClose = false;
        public static string header = "";
        public static bool canInitialize = false;
        private string cIDs = "";
        List<Record> records;
        List<StudentInClass> students;

        public frmAbsences()
        {
            InitializeComponent();
            records = new List<Record>();
            students = new List<StudentInClass>();
        }

        private void frmAbsences_Load(object sender, EventArgs e)
        {
            frmEditClass ec = new frmEditClass();
            ec.isForAbsences = true;
            ec.ShowDialog();
        }

        private void tmSetter_Tick(object sender, EventArgs e)
        {
            if (canInitialize)
            {
                canInitialize = false;
                lblDescription.Text += header;
                Initialize();
            }
            if (triggerClose)
            {
                triggerClose = false;
                canInitialize = false;
                this.Close();
            }
        }
        private void Initialize()
        {
            tmSetter.Enabled = false;
            cmbFilter.SelectedItem = cmbFilter.Items[0];
            PopulateAttendance();
            PopulateStudents();
            PopulateList("");
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
        private void PopulateAttendance()//Do solution. load query to class and linq
        {
            records = new List<Record>();
            cIDs = "";
            DataTable dt = db.SelectTable("SELECT * FROM tblclass WHERE classSignature='" + classSignature + "'");
            foreach(DataRow r in dt.Rows)
                cIDs += r["classid"].ToString() + ",";
            cIDs = cIDs.Remove(cIDs.Length - 1);
            DataTable att = db.SelectTable("SELECT * FROM tblattendance WHERE classid IN(" + cIDs + ") AND attendancedate BETWEEN '" + dtpFrom.Value.ToString("yyyy-MM-dd") + 
                "' AND '" + dtpTo.Value.ToString("yyyy-MM-dd") + "'");
            foreach (DataRow r in att.Rows)
            {
                Record rec = new Record(r["classid"].ToString(), r["attendancedate"].ToString(), r["isPresent"].ToString());
                records.Add(rec);
            }
        }
        private void PopulateStudents()
        {
            students = new List<StudentInClass>();
            DataTable dtStudent = db.SelectTable("SELECT *,CONCAT(studlname,', ', studfname,' ',studmname) FROM (tblstudent s INNER JOIN tblclass c ON s.studno = c.studno) " +
                "WHERE classSignature='" + classSignature + "'");
            foreach(DataRow r in dtStudent.Rows)
            {
                StudentInClass sin = new StudentInClass(r["CONCAT(studlname,', ', studfname,' ',studmname)"].ToString(),
                    r["studno"].ToString(),r["classid"].ToString(),r["studgender"].ToString());
                students.Add(sin);
            }
        }
        private void PopulateList(string criteria)
        {
            int max = GetMaxSchoolDays();
            List<StudentInClass> sin;
            try
            {
                if (cmbFilter.SelectedItem.ToString().Equals("LRN"))
                    sin = students.Where(s => s.studentNo.Contains(criteria)).Select(s => s).ToList();
                else
                    sin = students.Where(s => s.fullname.ToLower().Contains(criteria.ToLower())).Select(s => s).ToList();
            }
            catch { 
                sin = new List<StudentInClass>(); }
            lstRecords.Items.Clear();
            LoadListDate(sin);
            foreach (StudentInClass s in sin)
            {
                ListViewItem itm = new ListViewItem(s.studentNo);
                itm.SubItems.Add(s.fullname);
                itm.SubItems.Add(CheckAbsenceCount(s.classID, true).ToString());
                itm.SubItems.Add(CheckAbsenceCount(s.classID,false).ToString());
                itm.SubItems.Add(max.ToString());
                lstRecords.Items.Add(itm);
            }
        }
        private void LoadListDate(List<StudentInClass> cs)
        {
            lstByDate.Items.Clear();
            List<Record> currentRecs;
            try
            {
                currentRecs = records.Where(s => (dtpFrom.Value < s.date) && (s.date < dtpTo.Value)).Select(s => s).ToList();
            }
            catch { currentRecs = new List<Record>(); }
            foreach (StudentInClass sic in cs)
            {
                List<Record> rec = records.Where(s => s.classID.Equals(sic.classID)).OrderBy(s => s.date).Select(s => s).ToList();
                foreach (Record r in rec)
                {
                    ListViewItem itm = new ListViewItem(sic.studentNo);
                    itm.SubItems.Add(sic.fullname);
                    itm.SubItems.Add(r.date.ToString("MMM dd, yyyy"));
                    if (r.isPresent)
                        itm.SubItems.Add("Yes");
                    else
                        itm.SubItems.Add("No");
                    lstByDate.Items.Add(itm);
                }
            }
        }
        private int CheckAbsenceCount(string cid, bool isForPresent)
        {
            try
            {
                List<Record> recs = records.Where(s => s.isPresent == isForPresent && s.classID.Equals(cid)).Select(s => s).ToList();
                return recs.Count;
            }
            catch { return 0; }
        }
        private int GetMaxSchoolDays()
        {
            int max = 0;
            foreach (StudentInClass st in students)
            {
                try
                {
                    List<Record> recs = records.Where(s => s.classID.Equals(st.classID)).Select(s => s).ToList();
                    if (max < recs.Count)
                        max = recs.Count;
                }
                catch { }
            }
            return max;
        }
        private void frmAbsences_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMain.isAnyFormOpen = false;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                PopulateList(txtSearch.Text);
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbFilter.SelectedItem.ToString().Equals("LRN"))
                hm.TextHandle(ref sender, ref e, true);
            else
                hm.TextHandle(ref sender, ref e, false);
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            PopulateAttendance();
            PopulateList(txtSearch.Text);
        }

        private void chkDateList_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDateList.Checked)
            {
                lstByDate.Visible = true;
                lstRecords.Visible = false;
            }
            else
            {
                lstRecords.Visible = true;
                lstByDate.Visible = false;
            }
        }
    }
    
    class Record
    {
        public string classID;
        public DateTime date;
        public bool isPresent;

        public Record(string cid, string d, string iP)
        {
            this.classID = cid;
            this.date = Convert.ToDateTime(d);
            if (iP.Equals("1"))
                this.isPresent = true;
            else
                this.isPresent = false;
        }
    }
}
