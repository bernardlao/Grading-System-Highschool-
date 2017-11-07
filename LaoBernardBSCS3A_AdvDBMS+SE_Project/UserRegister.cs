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
    public partial class frmUserRegister : Form
    {
        MySQLDBUtilities db = new MySQLDBUtilities();
        HelperMethods hm = new HelperMethods();
        public bool isNew = true;

        public frmUserRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (IsAllInfoValid())
            {
                if (DialogResult.Yes == MessageBox.Show("Proceed?\nWarning : username cannot be edited after proceeding.\nNote : Fullname format will be used for printouts.",
                    "Finalize Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    if (isNew)
                    {
                        db.SPInUpUser(hm.CorrectCasing(txtFullname.Text), cmbGender.SelectedItem.ToString(),
                            hm.CorrectCasing(txtMajor.Text), txtQuestion.Text, txtAnswer.Text, txtUsername.Text, txtPassword.Text, txtDeduction.Text, true, "0");
                        MessageBox.Show("Registered Successfully!", "Success");
                    }
                    else
                    {
                        db.SPInUpUser(hm.CorrectCasing(txtFullname.Text), cmbGender.SelectedItem.ToString(), hm.CorrectCasing(txtMajor.Text),
                            txtQuestion.Text, txtAnswer.Text, txtUsername.Text, txtPassword.Text, txtDeduction.Text, false, frmLogin.userid);
                        MessageBox.Show("Update Success!", "Success");
                    }
                    this.Close();
                }
            }
        }
        private bool IsAllInfoValid()
        {
            /*if (txtFullname.Text.Equals("") || txtMajor.Text.Equals("") ||
                txtPassword.Text.Equals("") || txtUsername.Text.Equals(""))
            {
                MessageBox.Show("Please fillout the whole form");
                
                return false;
            }*/
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    TextBox t = c as TextBox;
                    if (t.Text == "")
                    {
                        MessageBox.Show("Please provide information at " + t.Name.Replace("txt", ""));
                        c.Focus();
                        return false;
                    }
                }
            }
            if (isNew)
            {
                DataTable dt = db.SelectTable("SELECT * FROM tbluser WHERE username='" + txtUsername.Text.Replace("'", "''") + "'");
                if (dt.Rows.Count != 0)
                {
                    MessageBox.Show("Username already exist!", "Redundant Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private void frmUserRegister_Load(object sender, EventArgs e)
        {
            cmbGender.SelectedItem = cmbGender.Items[0];
            if (!isNew)
            {
                DataTable dt = db.SelectTable("SELECT * FROM tbluser WHERE userid=" + frmLogin.userid);
                DataRow r = dt.Rows[0];
                txtUsername.ReadOnly = true;
                txtUsername.Text = r["username"].ToString();
                txtFullname.Text = r["userfullname"].ToString();
                txtMajor.Text = r["usermajor"].ToString();
                txtQuestion.Text = r["userquestion"].ToString();
                txtAnswer.Text = r["useranswer"].ToString();
                txtDeduction.Text = r["attendanceDeduction"].ToString();
                txtPassword.Text = r["userpassword"].ToString();
                btnRegister.Text = "Update";
                if (r["usergender"].ToString().Equals("Male"))
                    cmbGender.SelectedItem = cmbGender.Items[0];
                else
                    cmbGender.SelectedItem = cmbGender.Items[1];
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            hm.AlphaNumericOnly(ref sender, ref e);
        }

        private void txtAnswer_KeyPress(object sender, KeyPressEventArgs e)
        {
            hm.TextHandle(ref sender, ref e, false);
        }

        private void frmUserRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!isNew)
                frmMain.isAnyFormOpen = false;
        }

        private void txtDeduction_KeyPress(object sender, KeyPressEventArgs e)
        {
            hm.TextHandle(ref sender, ref e, true);
        }

        private void txtFullname_KeyPress(object sender, KeyPressEventArgs e)
        {
            hm.FullnameHandle(ref sender, ref e);
        }
    }
}
