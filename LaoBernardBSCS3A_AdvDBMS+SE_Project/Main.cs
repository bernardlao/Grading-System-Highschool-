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
    public partial class frmMain : Form
    {
        MySQLDBUtilities db = new MySQLDBUtilities();
        public static bool isAnyFormOpen = true;
        public frmMain()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            isAnyFormOpen = true;
            frmLogin login = new frmLogin();
            login.MdiParent = this;
            login.Show();
        }

        private void tmFilterAccess_Tick(object sender, EventArgs e)
        {
            if (isAnyFormOpen)
                mnsHeader.Enabled = false;
            else
                mnsHeader.Enabled = true;
        }

        private void menuEditCriteria_Click(object sender, EventArgs e)
        {
            frmCriteria crit = new frmCriteria();
            crit.MdiParent = this;
            isAnyFormOpen = true;
            crit.Show();
        }

        private void menuSubject_Click(object sender, EventArgs e)
        {
            frmSubject subj = new frmSubject();
            subj.MdiParent = this;
            isAnyFormOpen = true;
            subj.Show();
        }

        private void menuChangePassword_Click(object sender, EventArgs e)
        {
            frmUserRegister chg = new frmUserRegister();
            chg.MdiParent = this;
            isAnyFormOpen = true;
            chg.isNew = false;
            chg.Show();
        }

        private void menuYS_Click(object sender, EventArgs e)
        {
            frmYearAndSection ys = new frmYearAndSection();
            ys.MdiParent = this;
            isAnyFormOpen = true;
            ys.Show();
        }

        private void menuSubject_Click_1(object sender, EventArgs e)
        {
            frmSubject subj = new frmSubject();
            subj.MdiParent = this;
            isAnyFormOpen = true;
            subj.Show();
        }

        private void menuStudent_Click(object sender, EventArgs e)
        {
            frmStudent stud = new frmStudent();
            stud.MdiParent = this;
            isAnyFormOpen = true;
            stud.Show();
        }

        private void menuLogout_Click(object sender, EventArgs e)
        {
            isAnyFormOpen = true;
            frmLogin log = new frmLogin();
            log.MdiParent = this;
            log.Show();
        }

        private void menuAddClass_Click(object sender, EventArgs e)
        {
            frmClass cl = new frmClass();
            cl.MdiParent = this;
            isAnyFormOpen = true;
            cl.Show();
        }

        private void menuEditClass_Click(object sender, EventArgs e)
        {
            frmEditClass ec = new frmEditClass();
            ec.MdiParent = this;
            isAnyFormOpen = true;
            ec.Show();
        }

        private void menuGrade_Click(object sender, EventArgs e)
        {
            frmGradeSheet gs = new frmGradeSheet();
            gs.MdiParent = this;
            gs.Dock = DockStyle.Fill;
            isAnyFormOpen = true;
            gs.Show();
        }

        private void menuAttendance_Click(object sender, EventArgs e)
        {
            frmAttendance att = new frmAttendance();
            isAnyFormOpen = true;
            att.MdiParent = this;
            att.tmSetter.Enabled = true;
            att.Show();
        }

        private void menuCheckAbsences_Click(object sender, EventArgs e)
        {
            frmAbsences abs = new frmAbsences();
            isAnyFormOpen = true;
            abs.MdiParent = this;
            abs.tmSetter.Enabled = true;
            abs.Show();
        }

        private void menuRecords_Click(object sender, EventArgs e)
        {
            frmReportsPrint rp = new frmReportsPrint();
            isAnyFormOpen = true;
            rp.MdiParent = this;
            rp.Dock = DockStyle.Fill;
            rp.Show();
        }

        private void menuSchoolInfo_Click(object sender, EventArgs e)
        {
            isAnyFormOpen = true;
            frmSchool sc = new frmSchool();
            sc.MdiParent = this;
            sc.Show();
        }

        private void menuDeleteClass_Click(object sender, EventArgs e)
        {
            isAnyFormOpen = true;
            frmEditClass ec = new frmEditClass();
            ec.MdiParent = this;
            ec.btnSelect.Text = "Delete";
            ec.Show();
        }
    }
}
