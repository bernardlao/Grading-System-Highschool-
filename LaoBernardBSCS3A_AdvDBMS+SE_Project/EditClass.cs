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
    public partial class frmEditClass : Form
    {
        List<YearAndSection> sections = new List<YearAndSection>();
        private MySQLDBUtilities db = new MySQLDBUtilities();
        DataTable dt;
        private string classSignature = "";
        public bool isForGradeSheet = false;
        private bool isNotDone = true;
        public bool isForAttendance = false;
        public bool isForAbsences = false;
        public bool isForRecords = false;

        public frmEditClass()
        {
            InitializeComponent();
        }
        private void frmEditClass_Load(object sender, EventArgs e)
        {
            dt = db.SelectTable("SELECT * FROM tblclass WHERE userid = " + frmLogin.userid +
                " GROUP BY classSignature");
            PopulateSections();
            PopulateList();
        }
        private void PopulateSections()
        {
            sections.Clear();
            DataTable sec = db.SelectTable("SELECT * FROM tblyearsection");
            foreach (DataRow r in sec.Rows)
            {
                YearAndSection ys = new YearAndSection(r["yearsecid"].ToString(), r["year"].ToString(),
                    r["section"].ToString(), r["sectionname"].ToString());
                sections.Add(ys);
            }
        }
        private void PopulateList()
        {
            lstClasses.Items.Clear();
            foreach (DataRow r in dt.Rows)
            {
                ListViewItem itm = new ListViewItem(r["classSignature"].ToString());
                itm.SubItems.Add(db.DataLookUp("subjectname", "tblsubject", "Invalid",
                    "subjectid = " + r["subjectid"].ToString()));
                itm.SubItems.Add(db.DataLookUp("CONCAT(year,' - ',section,' ',sectionname)", "tblyearsection",
                    "Invalid", "yearsecid=" + r["yearsecid"].ToString()));
                itm.SubItems.Add(Convert.ToDateTime(r["timeFrom"].ToString()).ToString("hh:mm tt") + " - " +
                    Convert.ToDateTime(r["timeTo"].ToString()).ToString("hh:mm tt"));
                itm.SubItems.Add(r["schoolyear"].ToString());
                lstClasses.Items.Add(itm);
            }
        }

        private void frmEditClass_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isForGradeSheet && isNotDone)
            {
                frmGradeSheet.triggerClose = true;
            }
            else if (isForAttendance && isNotDone)
            {
                frmAttendance.triggerClose = true;
            }
            else if (isForAbsences && isNotDone)
            {
                frmAbsences.triggerClose = true;
            }
            else if (isForRecords && isNotDone)
            {
                frmReportsPrint.triggerClose = true;
            }
            else if (!isForAbsences && !isForAttendance && !isForGradeSheet && !isForRecords)
                frmMain.isAnyFormOpen = false;
        }

        private void lstClasses_Click(object sender, EventArgs e)
        {
            ListViewItem itm = lstClasses.SelectedItems[0];
            classSignature = itm.Text;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (!btnSelect.Text.Equals("Delete"))
            {
                if (isForGradeSheet)
                {
                    ForGradingSheet();
                }
                else if (isForAttendance)
                {
                    ForAttendance();
                }
                else if (isForAbsences)
                {
                    ForAbsences();
                }
                else if (isForRecords)
                {
                    ForRecords();
                }
                else
                    Proceed();
            }
            else
                DeleteClass();
        }

        private void lstClasses_DoubleClick(object sender, EventArgs e)
        {
            if (!btnSelect.Text.Equals("Delete"))
            {
                if (isForGradeSheet)
                {
                    ForGradingSheet();
                }
                else if (isForAttendance)
                {
                    ForAttendance();
                }
                else if (isForAbsences)
                {
                    ForAbsences();
                }
                else if (isForRecords)
                {
                    ForRecords();
                }
                else
                    Proceed();
            }
            else
                DeleteClass();
        }
        private void DeleteClass()
        {
            if (classSignature.Equals(""))
            {
                MessageBox.Show("Please select a class first.", "No data selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Are you sure to Delete Specific Class.\n" +
                    "Deleting will cause deletion of information related to the selected class.", "Delete Class",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    frmConfirm con = new frmConfirm();
                    con.classSignature = this.classSignature;
                    con.ShowDialog();
                    dt = db.SelectTable("SELECT * FROM tblclass WHERE userid = " + frmLogin.userid +
                        " GROUP BY classSignature");
                    PopulateList();
                }
            }
        }
        private void Proceed()
        {
            if (classSignature.Equals(""))
            {
                MessageBox.Show("Please select a class first.", "No data selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                frmClass cl = new frmClass();
                cl.isEdit = true;
                cl.classSignature = this.classSignature;
                cl.ShowDialog();
            }
        }
        private void ForGradingSheet()
        {
            if (classSignature.Equals(""))
                MessageBox.Show("Please select a class first.", "No data selected",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                isNotDone = false;
                ListViewItem itm = lstClasses.SelectedItems[0];
                frmGradeSheet.criterias = db.DataLookUp("criteriaScope", "tblclass", "", "classSignature='" +
                    classSignature + "'").Split('|');
                frmGradeSheet.header = itm.SubItems[1].Text + " / Y&S: " + itm.SubItems[2].Text +
                   " / Time: " + itm.SubItems[3].Text + " / SY: " + itm.SubItems[4].Text;
                frmGradeSheet.classSignature = this.classSignature;
                frmGradeSheet.isValid = true;
                this.Close();
            }
        }
        private void ForRecords()
        {
            if (classSignature.Equals(""))
                MessageBox.Show("Please select a class first.", "No data selected",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                isNotDone = false;
                ListViewItem itm = lstClasses.SelectedItems[0];
                frmReportsPrint.criterias = db.DataLookUp("criteriaScope", "tblclass", "", "classSignature='" +
                    classSignature + "'").Split('|');
                frmReportsPrint.header = itm.SubItems[1].Text + " / Y&S: " + itm.SubItems[2].Text +
                     " / Time: " + itm.SubItems[3].Text + " / SY: " + itm.SubItems[4].Text;
                frmReportsPrint.classSignature = this.classSignature;
                frmReportsPrint.isValid = true;
                this.Close();
            }
        }
        private void ForAttendance()
        {
            if (classSignature.Equals(""))
            {
                MessageBox.Show("Please select a class first.", "No data selected",
                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                isNotDone = false;
                ListViewItem itm = lstClasses.SelectedItems[0];
                frmAttendance.header = itm.SubItems[1].Text + " / Y&S: " + itm.SubItems[2].Text +
                     " / Time: " + itm.SubItems[3].Text + " / SY: " + itm.SubItems[4].Text;
                frmAttendance.classSignature = this.classSignature;
                frmAttendance.canInitialize = true;
                this.Close();
            }

        }
        private void ForAbsences()
        {
            if (classSignature.Equals(""))
            {
                MessageBox.Show("Please select a class first.", "No data selected",
                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                isNotDone = false;
                ListViewItem itm = lstClasses.SelectedItems[0];
                frmAbsences.header = itm.SubItems[1].Text + " / Y&S: " + itm.SubItems[2].Text +
                     " / Time: " + itm.SubItems[3].Text + " / SY: " + itm.SubItems[4].Text;
                frmAbsences.classSignature = this.classSignature;
                frmAbsences.canInitialize = true;
                this.Close();
            }
        }
    }
}
