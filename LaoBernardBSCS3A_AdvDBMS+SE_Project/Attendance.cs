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
    public partial class frmAttendance : Form
    {
        MySQLDBUtilities db = new MySQLDBUtilities();
        HelperMethods hm = new HelperMethods();
        public static string classSignature = "";
        public static bool triggerClose = false;
        public static string header = "";
        public static bool canInitialize = false;
        private bool isNew;
        List<Attendance> currentAttendance;
        Dictionary<string, Student> students = new Dictionary<string, Student>();
        DateTime fFrom,tTo;

        public frmAttendance()
        {
            InitializeComponent();
            currentAttendance = new List<Attendance>();
        }

        private void Attendance_Load(object sender, EventArgs e)
        {
            frmEditClass ec = new frmEditClass();
            ec.isForAttendance = true;
            ec.ShowDialog();
        }

        private void frmAttendance_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMain.isAnyFormOpen = false;
        }

        private void tmSetter_Tick(object sender, EventArgs e)
        {
            if (canInitialize)
            {
                canInitialize = false;
                lblClassDescription.Text += header;
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
            PopulateStudents();
            PopulateAttendance(dtpSpecifiedDate.Value.ToString("yyyy-MM-dd"));
            SetPossibleDateSpan();
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
                    dtpSpecifiedDate.MinDate = min;
                    dtpSpecifiedDate.MaxDate = max;
                }
            }
        }
        private void SetPossibleDateSpan()
        {
            string[] splittedSignature = classSignature.Split('-');
            string[] sy = splittedSignature[splittedSignature.Length - 1].Replace("to"," ").Split(' ');
            fFrom = Convert.ToDateTime("6/1/" + sy[0]);
            tTo = Convert.ToDateTime("4/16/" + sy[1]);
        }
        private void PopulateStudents()
        {
            DataTable dt = db.SelectTable("SELECT *,CONCAT(studlname,', ',studfname,' ',studmname) FROM tblclass c INNER JOIN tblstudent s ON c.studno=s.studno WHERE classSignature ='" +
                classSignature + "' ORDER BY CONCAT(studlname,', ',studfname,' ',studmname) ASC");
            foreach (DataRow r in dt.Rows)
            {
                Student s = new Student(r["studno"].ToString(), r["studfname"].ToString(), r["studlname"].ToString(),
                    r["studmname"].ToString(), r["studgender"].ToString(), r["studaddress"].ToString(), r["studbirthdate"].ToString());
                students.Add(r["classid"].ToString(),s);
            }
        }
        private void PopulateAttendance(string date)
        {
            currentAttendance = new List<Attendance>();
            string ids = "";
            foreach (string s in students.Keys)
                ids += s + ",";
            ids = ids.Remove(ids.Length - 1);
            DataTable dt = db.SelectTable("SELECT * FROM tblattendance WHERE classid IN(" + ids + ") AND attendancedate = '" + date + "'");

            if (dt.Rows.Count > 0)
            {
                isNew = false;
                foreach (DataRow r in dt.Rows)
                {
                    Attendance a = new Attendance(r["attendanceid"].ToString(), r["isPresent"].ToString(), r["classid"].ToString(), students[r["classid"].ToString()]);
                    currentAttendance.Add(a);
                }
                for (int i = 0; i < students.Count; i++)
                {
                    try
                    {
                        Attendance att = currentAttendance.Where(s => s.ClassID.Equals(students.Keys.ToArray()[i].ToString())).Select(s => s).Single();
                    }
                    catch
                    {
                        Attendance a = new Attendance("0", "0", students.Keys.ToArray()[i], students.Values.ToArray()[i]);
                        currentAttendance.Add(a);
                    }
                }
            }
            else
            {
                isNew = true;
                for(int i = 0; i < students.Count;i++)
                {
                    Attendance a = new Attendance("0", "0", students.Keys.ToArray()[i], students.Values.ToArray()[i]);
                    currentAttendance.Add(a);
                }
            }
            PopulateRecords("");
        }

        private void PopulateRecords(string searchKey)
        {
            try
            {
                List<Attendance> included;
                if (cmbFilter.SelectedItem.ToString().Equals(cmbFilter.Items[0].ToString()))
                    included = currentAttendance.Where(s => s.StudentNo.Contains(searchKey)).Select(s => s).ToList();
                else
                    included = currentAttendance.Where(s => s.Fullname.ToLower().Contains(searchKey.ToLower())).Select(s => s).ToList();
                lstAttendance.Items.Clear();
                foreach (Attendance a in included)
                {
                    ListViewItem itm = new ListViewItem(a.StudentNo);
                    itm.SubItems.Add(a.Fullname);
                    itm.SubItems.Add(a.Gender);
                    itm.SubItems.Add(a.ClassID);
                    if (a.IsPresent)
                        itm.Checked = true;
                    else
                        itm.Checked = false;
                    lstAttendance.Items.Add(itm);
                }
            }
            catch { MessageBox.Show(""); }
        } 
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbFilter.SelectedItem.ToString().Equals("LRN"))
                hm.TextHandle(ref sender, ref e, true);
            else
                hm.TextHandle(ref sender, ref e, false);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                PopulateRecords(txtSearch.Text);
            }
        }

        private void lstGrades_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            DoCheckItemProcedure(e.Item.SubItems[3].Text, e.Item.Checked);
        }
        private void DoCheckItemProcedure(string cID,bool status)
        {
            try
            {
                currentAttendance.Where(s => s.ClassID.Equals(cID)).Select(s => s).Single().IsPresent = status;
            }
            catch { }
        }
        private void dtpSpecifiedDate_ValueChanged(object sender, EventArgs e)
        {
            PopulateAttendance(dtpSpecifiedDate.Value.ToString("yyyy-MM-dd"));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Save Attendance?",
                "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                if (IsDateValid())
                {
                    CheckAttendance();
                }
            }
        }
        private bool IsDateValid()
        {
            /*if (dtpSpecifiedDate.Value < fFrom || dtpSpecifiedDate.Value > tTo)
            {
                MessageBox.Show("Date was not included in Regular school days");
                return false;
            }*/

            if (dtpSpecifiedDate.Value.DayOfWeek == DayOfWeek.Saturday|| dtpSpecifiedDate.Value.DayOfWeek == DayOfWeek.Sunday)
            {
                if (DialogResult.No == MessageBox.Show("Schedule day is on weekends. Are you still want to save attendance?",
                        "Weekend Exception", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    MessageBox.Show("Attendance was not recorded");
                    return false;
                }
            }
            return true;
        }
        private void CheckAttendance()
        {
            List<string> queries = new List<string>();
            foreach (Attendance a in currentAttendance)
            {
                if (a.AttendanceID.Equals("0"))
                {
                    string query = "INSERT INTO tblattendance (attendancedate,isPresent,classid) " +
                        "VALUES('" + dtpSpecifiedDate.Value.ToString("yyyy-MM-dd") + "'," + (a.IsPresent?1:0) + "," + a.ClassID + ");";
                    queries.Add(query);
                }
                else
                {
                    if (a.IsUpdated)
                    {
                        string query = "UPDATE tblattendance SET isPresent=" + (a.IsPresent?1:0) + " WHERE attendanceid=" + a.AttendanceID;
                        queries.Add(query);
                    }
                }
            }
            db.InsertMultiple(queries);
            PopulateAttendance(dtpSpecifiedDate.Value.ToString("yyyy-MM-dd"));
            txtSearch.Text = "";
        }
    }
    
}
