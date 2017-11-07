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
    public partial class frmLogin : Form
    {
        MySQLDBUtilities db = new MySQLDBUtilities();
        HelperMethods hm = new HelperMethods();
        private bool isLoginNotDone = true;
        public static string userid;
        public static bool preventLogin = false;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (db.OpenConnection() == null)
            {
                frmMain.isAnyFormOpen = true;
                frmConnect createConnection = new frmConnect();
                createConnection.ShowDialog();
            }
            else
                db.CloseConnection();
        }

        private bool IsAllInfoValid()
        {
            if (txtUsername.Text.Equals("") || txtPassword.Text.Equals(""))
            {
                foreach (Control c in this.Controls)
                {
                    if (c is TextBox)
                    {
                        TextBox t = c as TextBox;
                        if (t.Text.Equals(""))
                        {
                            MessageBox.Show("Please enter your " +
                                t.Name.Replace("txt", "") + ".");
                            c.Focus();
                            return false;
                        }
                    }
                }
            }
            DataTable dt = db.SelectTable("SELECT * FROM tbluser WHERE username='" +
                txtUsername.Text + "'");
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Username doesn't exist.");
                return false;
            }
            else
            {
                DataRow r = dt.Rows[0];
                if (!r["username"].ToString().Equals(txtUsername.Text))
                {
                    MessageBox.Show("Username doesn't exist");
                    return false;
                }
                else
                {
                    if (!r["userpassword"].ToString().Equals(txtPassword.Text))
                    {
                        MessageBox.Show("Incorrect Password.");
                        return false;
                    }
                    else
                    {
                        userid = r["userid"].ToString();
                        isLoginNotDone = false;
                        frmMain.isAnyFormOpen = false;
                        return true;
                    }
                }
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (IsAllInfoValid())
                {
                    SetCriteriaIfNotExist();
                    this.Close();
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (IsAllInfoValid())
            {
                SetCriteriaIfNotExist();
                this.Close();
            }
        }

        private void SetCriteriaIfNotExist()
        {
            DataTable dt = db.SelectTable("SELECT * FROM tblcriteria WHERE userid =" +
                frmLogin.userid + " AND criteriaIsActive = 1");
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Criteria must be set on your first login.", "Optimize setting",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmCriteria crit = new frmCriteria();
                crit.ShowDialog();
            }
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && isLoginNotDone)
                Environment.Exit(1);
            if (preventLogin)
            {
                e.Cancel = true;
                preventLogin = false;
                isLoginNotDone = true;
            }
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmUserRegister reg = new frmUserRegister();
            reg.ShowDialog();
        }

        private void lnkForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRecoverPassword rp = new frmRecoverPassword();
            rp.ShowDialog();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            hm.AlphaNumericOnly(ref sender, ref e);
        }

        private void lblChangeDBSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmConnect con = new frmConnect();
            con.isExitInvalid = false;
            con.ShowDialog();
        }
    }
}
