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
    public partial class frmRecoverPassword : Form
    {
        MySQLDBUtilities db = new MySQLDBUtilities();
        HelperMethods hm = new HelperMethods();
        DataTable dt;
        public frmRecoverPassword()
        {
            InitializeComponent();
            dt = new DataTable();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {

        }


        private bool IsInfoValid() 
        {
            
            return true;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            dt = db.SelectTable("SELECT * FROM tbluser WHERE username ='" + txtUsername.Text + "'");
            if (dt.Rows.Count > 0)
            {
                txtQuestion.Text = dt.Rows[0]["userquestion"].ToString();
                txtAnswer.Enabled = true;
            }
            else
            {
                MessageBox.Show("No such user exist");
                txtAnswer.Enabled = false;
            }
        }

        private void txtAnswer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (dt.Rows[0]["useranswer"].ToString().Equals(txtAnswer.Text))
                {
                    txtAnswer.Enabled = false;
                    btnCheck.Enabled = false;
                    txtUsername.Enabled = false;
                    gpbSet.Enabled = true;
                    txtNew.Focus();
                }
                else
                    MessageBox.Show("Incorrect answer.", "Incorrect");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtNew.Text = "";
            txtRetype.Text = "";
            txtUsername.Text = "";
            txtUsername.Enabled = true;
            txtAnswer.Text = "";
            txtAnswer.Enabled = false;
            txtQuestion.Text = "";
            btnCheck.Enabled = true;
            gpbSet.Enabled = false;
        }

        private void txtRetype_KeyPress(object sender, KeyPressEventArgs e)
        {
            hm.AlphaNumericOnly(ref sender, ref e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNew.Text.Equals(txtRetype.Text))
            {
                if (DialogResult.Yes == MessageBox.Show("Save new password?", "Finalize information",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    string query = "UPDATE tbluser SET userpassword='" + txtRetype.Text + "' WHERE userid=" +
                        dt.Rows[0]["userid"].ToString();
                    db.InsertQuery(query);
                    MessageBox.Show("Updated successfully", "Update success");
                    this.Close();
                }
            }
            else
                MessageBox.Show("Password doesn't match","Invalid Passwords");
        }
    }
}
