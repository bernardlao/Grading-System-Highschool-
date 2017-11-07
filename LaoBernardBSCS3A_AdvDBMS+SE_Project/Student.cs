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
    public partial class frmStudent : Form
    {
        MySQLDBUtilities db = new MySQLDBUtilities();
        HelperMethods hm = new HelperMethods();
        string lrnno;
        bool isUpdate = false;

        public frmStudent()
        {
            InitializeComponent();
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            cmbGender.SelectedItem = cmbGender.Items[0];
            PopulateRecords("");
        }

        private void txtMName_KeyPress(object sender, KeyPressEventArgs e)
        {
            hm.TextHandle(ref sender, ref e, false);
        }

        private void frmStudent_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMain.isAnyFormOpen = false;
        }

        private void txtLRN4_KeyPress(object sender, KeyPressEventArgs e)
        {
            hm.TextHandle(ref sender, ref e, true);
        }

        

        private void lstStudents_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem itm = lstStudents.SelectedItems[0];
            lrnno = itm.Text;
            txtLRN.ReadOnly = true;
            isUpdate = true;
            SetDetails();
        }
        private void PopulateRecords(string criteria)
        {
            lstStudents.Items.Clear();
            DataTable dt = db.SelectTable("SELECT * FROM tblstudent " + (criteria.Trim().Length > 0?"WHERE studno LIKE '%" + criteria + "%'":""));
            if (dt != null)
            {
                if (dt.Rows.Count != 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        string fullname = r["studlname"].ToString() + ", " +
                            r["studfname"].ToString() + " " + r["studmname"].ToString();
                        ListViewItem itm = new ListViewItem(r["studno"].ToString());
                        itm.SubItems.Add(fullname);
                        itm.SubItems.Add(Convert.ToDateTime(r["studbirthdate"].ToString()).ToShortDateString());
                        itm.SubItems.Add(r["studgender"].ToString());
                        lstStudents.Items.Add(itm);
                    }
                }
            }
        }
        private bool IsAllInfoValid()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    if (c.Text.Trim().Equals("") && !c.Name.Equals("txtMName"))
                    {
                        MessageBox.Show("Some information is missing");
                        return false;
                    }
                }
            }
            string lrn = txtLRN.Text;
            DataTable dt = db.SelectTable("SELECT * FROM tblstudent WHERE studno = '" + lrn + "'");
            if (dt != null && !isUpdate)
            {
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("LRN # already exist. This entity must be unique");
                    return false;
                }
            }
            if (txtLRN.Text.Length < 12)
            {
                MessageBox.Show("LRN must be a 12-Digit Number.");
                return false;
            }
            return true;
        }
        private void SetDefaults()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                    c.Text = "";
                if (c is ComboBox)
                    (c as ComboBox).SelectedItem = cmbGender.Items[0];
                if (c is DateTimePicker)
                    (c as DateTimePicker).Value = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            }
            txtLRN.ReadOnly = false;
            txtLName.Focus();
        }
        public void SetDetails()
        {
            DataTable dt = db.SelectTable("SELECT * FROM tblstudent WHERE studno = '" + lrnno + "'");
            if (dt != null)
            {
                foreach(DataRow r in dt.Rows)
                {
                    txtAddress.Text = r["studaddress"].ToString();
                    txtFName.Text = r["studfname"].ToString();
                    txtLName.Text = r["studlname"].ToString();
                    txtMName.Text = r["studmname"].ToString();
                    cmbGender.Text = r["studgender"].ToString();
                    dtpBday.Value = Convert.ToDateTime(r["studbirthdate"].ToString());
                    txtLRN.Text = lrnno;
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsAllInfoValid())
            {
                if (DialogResult.Yes == MessageBox.Show("Do you want to proceed with the following information?", "Save",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    if (isUpdate)
                    {
                        db.SPInUpStudent(lrnno, hm.CorrectCasing(txtFName.Text), hm.CorrectCasing(txtLName.Text), hm.CorrectCasing(txtMName.Text),
                            cmbGender.SelectedItem.ToString(), dtpBday.Value.ToString("yyyy-MM-dd"), hm.CorrectCasing(txtAddress.Text), false);
                        MessageBox.Show("Updated Successfully", "Update");
                        SetDefaults();
                        PopulateRecords("");
                        isUpdate = false;
                    }
                    else
                    {
                        string lrn = txtLRN.Text;
                        db.SPInUpStudent(lrn, hm.CorrectCasing(txtFName.Text), hm.CorrectCasing(txtLName.Text), hm.CorrectCasing(txtMName.Text),
                            cmbGender.SelectedItem.ToString(), dtpBday.Value.ToString("yyyy-MM-dd"), hm.CorrectCasing(txtAddress.Text), true);
                        MessageBox.Show("Saved Successfully", "Saved");
                        PopulateRecords("");
                        SetDefaults();
                    }
                }
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
                PopulateRecords(txtSearch.Text);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PopulateRecords(txtSearch.Text);
        }

    }
}
