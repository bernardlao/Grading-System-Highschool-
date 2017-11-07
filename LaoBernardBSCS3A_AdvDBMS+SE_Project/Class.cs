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
    public partial class frmClass : Form
    {
        MySQLDBUtilities db = new MySQLDBUtilities();
        List<Student> students = new List<Student>();
        List<ClassRoster> classRosters = new List<ClassRoster>();
        List<Criteria> criterias = new List<Criteria>();
        private string currentCriterias;
        public bool isEdit = false;
        public string classSignature;

        public frmClass()
        {
            InitializeComponent();
            students = new List<Student>();
            classRosters = new List<ClassRoster>();
            criterias = new List<Criteria>();
        }

        private void frmClass_Load(object sender, EventArgs e)
        {
            db.BindComboboxItems("SELECT * FROM tblsubject", cmbSubject, "subjectid", "subjectname");
            db.BindComboboxItems("SELECT yearsecid,CONCAT(year,' - ',section,' ',sectionname) FROM tblyearsection ORDER BY CONCAT(year,' - ',section,' ',sectionname) ASC",
                cmbYearSec, "yearsecid", "CONCAT(year,' - ',section,' ',sectionname)");
            InitializeForm();
            dtpTo.Value = dtpFrom.Value.AddYears(1);
            BoundSearchFilter();
        }
        private void InitializeForm()
        {
            PopulateStudentClass();
            PopulateList();
            PopulateCriteriaClass();
            GetAllActiveCriterias();
            if (isEdit)
            {
                PopulateClassRoster("classSignature='" + classSignature + "'");
                SetEditAppearance();
            }
            else
                PopulateClassRoster("");
        }
        private void SetEditAppearance()
        {
            List<string> lrns = classRosters.Select(s => s.StudentNo).ToList();
            foreach (string lrn in lrns)
            {
                students.Where(s => s.StudentNo.Equals(lrn)).Select(s => s).Single().IsChecked = true;
            }
            for (int i = 0; i < cmbSubject.Items.Count; i++)
            {
                cmbSubject.SelectedItem = cmbSubject.Items[i];
                if (cmbSubject.SelectedValue.ToString().Equals(classRosters[0].SubjectID))
                    break;
            }
            for (int i = 0; i < cmbYearSec.Items.Count; i++)
            {
                cmbYearSec.SelectedItem = cmbYearSec.Items[i];
                if (cmbYearSec.SelectedValue.ToString().Equals(classRosters[0].YearSectionID))
                    break;
            }
            string[] fromTo = classRosters[0].SchoolYear.Split('-');
            dtpFrom.Value = Convert.ToDateTime("1/1/" + fromTo[0].Trim());
            dtpTo.Value = Convert.ToDateTime("1/1/" + fromTo[1].Substring(1));
            dtpTFrom.Value = classRosters[0].TimeFrom;
            dtpTTo.Value = classRosters[0].TimeTo;
            dtpMonthStart.Value = classRosters[0].MonthStart;
            dtpMonthEnd.Value = classRosters[0].MonthEnd;
            gpbSchoolyear.Enabled = false;
            cmbSubject.Enabled = false;
            cmbYearSec.Enabled = false;
            gpbTime.Enabled = false;
            PopulateList();
        }
        private void BoundSearchFilter()
        {
            Dictionary<int,string> d = new Dictionary<int,string>();
            d.Add(1,"Fullname");
            d.Add(2,"LRN No");
            cmbFilterBy.DataSource = new BindingSource(d, null);
            cmbFilterBy.DisplayMember = "value";
            cmbFilterBy.ValueMember = "key";
        }
        private void PopulateStudentClass()
        {
            students.Clear();
            DataTable dt = db.SelectTable("SELECT * FROM tblstudent");
            foreach (DataRow r in dt.Rows)
            {
                Student s = new Student(r["studno"].ToString(), r["studfname"].ToString(), r["studlname"].ToString(),
                    r["studmname"].ToString(), r["studgender"].ToString(), r["studaddress"].ToString(),
                    r["studbirthdate"].ToString());
                students.Add(s);
            }
        }
        private void PopulateClassRoster(string criteria)
        {
            classRosters.Clear();
            DataTable dt = db.SelectTable("SELECT * FROM tblclass WHERE userid =" + frmLogin.userid +
                (criteria.Trim().Length > 0?" AND " + criteria:""));
            foreach (DataRow r in dt.Rows)
            {
                ClassRoster cr = new ClassRoster(r["classid"].ToString(), r["studno"].ToString(), r["subjectid"].ToString(),
                    r["schoolyear"].ToString(), r["yearsecid"].ToString(), r["userid"].ToString(),r["classSignature"].ToString(),
                    r["timeFrom"].ToString(),r["timeTo"].ToString(),r["classStart"].ToString(),r["classEnd"].ToString());
                classRosters.Add(cr);
            }
        }
        private void PopulateCriteriaClass()
        {
            criterias.Clear();
            DataTable dt = db.SelectTable("SELECT * FROM tblcriteria");
            foreach (DataRow r in dt.Rows)
            {
                Criteria c = new Criteria(r["criteriaid"].ToString(), r["criterianame"].ToString(), r["criteriapercentage"].ToString(),
                    r["userid"].ToString(), r["criteriaIsActive"].ToString(),r["criteriaType"].ToString());
                criterias.Add(c);
            }
        }
        private void GetAllActiveCriterias()
        {
            string[] critIds = criterias.Where(s => s.UserID.Equals(frmLogin.userid) && 
                s.IsCriteriaActive).Select(s => s.CriteriaID).ToArray();
            foreach (string s in critIds)
                currentCriterias += s + "|";

            currentCriterias = currentCriterias.Remove(currentCriterias.Length - 1);
        }
        private void PopulateList()
        {
            lstStudents.Items.Clear();
            List<Student> ss = students.Select(s => s).ToList();
            foreach (Student s in ss)
            {
                ListViewItem itm = new ListViewItem(s.StudentNo);
                itm.SubItems.Add(s.FullName);
                if (s.IsChecked)
                    itm.Checked = true;
                else
                    itm.Checked = false;
                lstStudents.Items.Add(itm);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                FilterStudent(Convert.ToInt32(cmbFilterBy.SelectedValue.ToString()));
            }
        }
        private void FilterStudent(int key)
        {
            lstStudents.Items.Clear();
            List<Student> filteredStudents = new List<Student>();
            if (key == 1)
            {
                filteredStudents = students.Where(s => s.FullName.ToLower().Contains(txtSearch.Text.ToLower())).Select(s => s).ToList();
            }
            else
            {
                filteredStudents = students.Where(s => s.StudentNo.Contains(txtSearch.Text)).Select(s => s).ToList();
            }
            foreach (Student s in filteredStudents)
            {
                ListViewItem itm = new ListViewItem(s.StudentNo);
                itm.SubItems.Add(s.FullName);
                if (s.IsChecked)
                    itm.Checked = true;
                else
                    itm.Checked = false;
                lstStudents.Items.Add(itm);
            }
        }

        private void lstStudents_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListViewItem itm = e.Item;
            students.Where(s => s.StudentNo.Equals(itm.Text)).Select(s => s).Single().IsChecked = itm.Checked;
        }

        private void frmClass_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!isEdit)
                frmMain.isAnyFormOpen = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isEdit)
            {
                if (!IsClassEmpty())
                {
                    if (!IsMonthSpanInvalid())
                    {
                        if (DialogResult.Yes == MessageBox.Show("Update records now?\nWarning : Changing School month duration may cause some attendance exclusion.",
                            "Update Database", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            UpdateDB();
                            cmbSubject.Focus();
                        }
                    }
                }
                else
                    MessageBox.Show("Class must contain student(s)", "Empty Class");
            }
            else
            {
                if (IsAllInfoValid())
                {
                    if (DialogResult.Yes == MessageBox.Show("Do you want to proceed with the current selection?\nNote : You can only change students and School Month Duration after saving.",
                        "Publishing Class", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        SaveDB();
                        cmbSubject.Focus();
                    }
                }
            }
        }
        private bool IsAllInfoValid()//error in createdID//ID sequence doesnt contains an element
        {
            if (IsClassExist())
            {
                MessageBox.Show("There is an existing class in your list.", "Class Exist",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (IsClassEmpty())
            {
                MessageBox.Show("You must select some student that will attend your class.",
                    "Empty Roster", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (IsTimeSpanInvalid())
            {
                return false;
            }
            if (IsMonthSpanInvalid())
            {
                return false;
            }
            return true;
        }
        private bool IsMonthSpanInvalid()
        {
            int dedicatedMonths = 0;
            if (dtpMonthStart.Value.Month > dtpMonthEnd.Value.Month)
                dedicatedMonths = (12 - dtpMonthStart.Value.Month) + dtpMonthEnd.Value.Month;
            else if (dtpMonthStart.Value.Month < dtpMonthEnd.Value.Month)
                dedicatedMonths = dtpMonthEnd.Value.Month - dtpMonthStart.Value.Month;
            else if (dtpMonthStart.Value.Month == dtpMonthEnd.Value.Month)
            {
                MessageBox.Show("School duration must be less than a year.", "Excessive Date");
                return true;
            }
            if (dedicatedMonths < 9)
            {
                MessageBox.Show("School duration must be atleast 9 months time.", "Invalid Duration");
                return true;
            }
            return false;
        }
        private bool IsTimeSpanInvalid()
        {
            DateTime timeFrom = Convert.ToDateTime(dtpTFrom.Value.ToString("hh:mm tt"));
            DateTime timeTo = Convert.ToDateTime(dtpTTo.Value.ToString("hh:mm tt"));
            string sy = dtpFrom.Value.Year.ToString() + " - " + dtpTo.Value.Year.ToString();
            if (dtpTFrom.Value >= dtpTTo.Value)
            {
                MessageBox.Show("The time start must be earlier that the time end","Invalid Scheduled Time");
                return true;
            }
            foreach (ClassRoster cr in classRosters)
            {
                if (cr.SchoolYear.Equals(sy))
                {
                    if ((cr.TimeFrom <= timeFrom && timeFrom < cr.TimeTo) || (cr.TimeFrom < timeTo && timeTo <= cr.TimeTo))//||
                        //(timeFrom <= cr.TimeFrom && cr.TimeFrom < timeTo) || (timeFrom < cr.TimeTo && cr.TimeTo <= timeTo))
                    {
                        MessageBox.Show("There is a conflict of schedule in your existing class.\n" +
                            "Informations are as follows :\nSubject : " + db.DataLookUp("subjectname", "tblsubject", "", "subjectid=" + cr.SubjectID) +
                            "\nYear and Section : " + db.DataLookUp("CONCAT(year,' - ',section,' ',sectionname)", "tblyearsection", "", "yearsecid=" + cr.YearSectionID),
                            "Schedule Conflict",MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return true;
                    }
                }
            }
            return false;
        }
        private bool IsClassEmpty()
        {
            bool hasNoStudent = true;
            foreach (Student s in students)
            {
                if (s.IsChecked)
                    hasNoStudent = false;
            }
            return hasNoStudent;
        }
        private bool IsClassExist()
        {
            classSignature = frmLogin.userid + "-" + cmbSubject.SelectedValue.ToString() +
                "-" + cmbYearSec.SelectedValue.ToString() + "-" + dtpFrom.Value.Year.ToString() +
                "to" + dtpTo.Value.Year.ToString();
            try
            {
                if (classRosters.Count > 0)
                {
                    List<string> createdIDs = classRosters.Where(s => s.ClassSignature.Equals(classSignature))
                        .Select(s => s.ClassSignature).ToList();
                    if (createdIDs.Count > 0)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
        private void SaveDB()
        {
            List<string> queries = new List<string>();
            List<Student> saveToClass = GetCheckedStudent();
            string classStart = dtpFrom.Value.Year + "-" + dtpMonthStart.Value.Month + "-1";
            string classEnd = dtpTo.Value.Year + "-" + dtpMonthEnd.Value.Month + "-" + DateTime.DaysInMonth(dtpTo.Value.Year,dtpMonthEnd.Value.Month);
            classSignature = frmLogin.userid + "-" + cmbSubject.SelectedValue.ToString() +
                "-" + cmbYearSec.SelectedValue.ToString() + "-" + dtpFrom.Value.Year.ToString()+
                "to" + dtpTo.Value.Year.ToString();
            foreach (Student s in saveToClass)
            {
                queries.Add("INSERT INTO tblclass(studno, subjectid, schoolyear, yearsecid, userid, criteriaScope, classSignature,timeFrom,timeTo,classStart,classEnd)" +
                    " VALUES('" + s.StudentNo + "'," + cmbSubject.SelectedValue.ToString() + ",'" +
                    dtpFrom.Value.Year + " - " + dtpTo.Value.Year + "'," + cmbYearSec.SelectedValue.ToString() + "," +
                    frmLogin.userid + ",'" + currentCriterias + "','" + classSignature + "','" + dtpTFrom.Value.ToString("HH:mm") +
                    "','" + dtpTTo.Value.ToString("HH:mm") +"','" + classStart + "','" + classEnd+"');");
            }
            db.InsertMultiple(queries);
            PopulateClassRoster("");
            PopulateStudentClass();
            PopulateList();
        }
        private void UpdateDB()
        {
            string classStart = dtpFrom.Value.Year + "-" + dtpMonthStart.Value.Month + "-1";
            string classEnd = dtpTo.Value.Year + "-" + dtpMonthEnd.Value.Month + "-" + DateTime.DaysInMonth(dtpTo.Value.Year,dtpMonthEnd.Value.Month);
            List<string> queries = new List<string>();
            foreach (ClassRoster cr in classRosters)
            {
                bool isIncluded = students.Where(s => s.StudentNo.Equals(cr.StudentNo)).Select(s => s.IsChecked).Single();
                if (!isIncluded)
                {
                    queries.Add("DELETE FROM tblclass WHERE classid=" + cr.ClassID);
                }
            }
            currentCriterias = db.DataLookUp("criteriaScope", "tblclass", "None", "classid=" + classRosters[0].ClassID);
            List<Student> selectedStudent = GetCheckedStudent();
            foreach (Student s in selectedStudent)
            {
                if (!IsStudentAlreadyExist(s.StudentNo))
                    queries.Add("INSERT INTO tblclass(studno, subjectid, schoolyear, yearsecid, userid, criteriaScope, classSignature,timeFrom,timeTo,classStart,classEnd)" +
                        " VALUES('" + s.StudentNo + "'," + classRosters[0].SubjectID + ",'" + classRosters[0].SchoolYear + "'," +
                        classRosters[0].YearSectionID + "," + frmLogin.userid + ",'" + currentCriterias + "','" +
                        classRosters[0].ClassSignature + "','" + dtpTFrom.Value.ToString("HH:mm:ss") + "','" + dtpTTo.Value.ToString("HH:mm:ss") + 
                        "','" + classStart + "','" + classEnd+"');");
                else
                {
                    string studentsCID = GetClassIDIfExist(s.StudentNo);
                    if(!studentsCID.Equals(""))
                        queries.Add("UPDATE tblclass SET classStart ='" + classStart + "', classEnd='" + classEnd + "' WHERE classid=" + studentsCID);
                }
                    
            }
            db.InsertMultiple(queries);
            this.Close();
        }
        private string GetClassIDIfExist(string studno)
        {
            try
            {
                List<string> cid = classRosters.Where(s => s.StudentNo.Equals(studno)).Select(s => s.ClassID).ToList();
                if (cid.Count > 0)
                    return cid[0].ToString();
                else
                    return "";
            }
            catch { return ""; }
        }
        private bool IsStudentAlreadyExist(string studNo)
        {
            try
            {
                List<string> ids = classRosters.Where(s => s.StudentNo.Equals(studNo)).Select(s => s.StudentNo).ToList();
                if (ids.Count > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return true;
            }
        }
        private List<Student> GetCheckedStudent()
        {
            try
            {
                List<Student> temp = students.Where(s => s.IsChecked).Select(s => s).ToList();
                return temp;
            }
            catch
            {
                return null;
            }
        }
        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            dtpTo.Value = dtpFrom.Value.AddYears(1);
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            dtpFrom.Value = dtpTo.Value.AddYears(-1);
        }

        private void dtpMonthStart_ValueChanged(object sender, EventArgs e)
        {
            dtpMonthEnd.Value = dtpMonthStart.Value.AddMonths(10);
        }

        private void dtpTFrom_ValueChanged(object sender, EventArgs e)
        {
            dtpTTo.Value = dtpTFrom.Value.AddHours(1);
        }
    }
}