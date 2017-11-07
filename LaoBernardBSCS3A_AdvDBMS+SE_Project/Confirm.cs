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
    public partial class frmConfirm : Form
    {
        MySQLDBUtilities db = new MySQLDBUtilities();
        HelperMethods hm = new HelperMethods();
        public string classSignature;
        private string password;

        public frmConfirm()
        {
            InitializeComponent();
        }

        private void frmConfirm_Load(object sender, EventArgs e)
        {
            password = db.DataLookUp("userpassword", "tbluser", "", "userid=" + frmLogin.userid);
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (txtPassword.Text.Equals(password))
                {
                    if (DialogResult.Yes == MessageBox.Show("Password Confirmed. Proceed on deletion?", "Final Confirmation",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        DeleteNow();
                }
                else
                    MessageBox.Show("Incorrect password", "Privelege Denied");
            }
        }
        private void DeleteNow()
        {
            db.InsertQuery("DELETE FROM tblclass WHERE userid=" + frmLogin.userid + " AND classSignature IN('" + classSignature + "');");
            MessageBox.Show("Delete Successful","Deleted");
            this.Close();
        }
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            hm.AlphaNumericOnly(ref sender, ref e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
