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
    public partial class frmSchool : Form
    {
        MySQLDBUtilities db = new MySQLDBUtilities();
        HelperMethods hm = new HelperMethods();
        private bool isNew = true;

        public frmSchool()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsInfoValid())
            {
                if (DialogResult.Yes == MessageBox.Show("Save informations?", "Save",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    if (isNew)
                        SaveDB();
                    else
                        UpdateDB();
                    this.Close();
                }
            }
        }
        private bool IsInfoValid()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    if ((c as TextBox).Text.Equals(""))
                    {
                        MessageBox.Show("You must fill up every information.", "Unsufficient Information");
                        return false;
                    }
                }
            }
            return true;
        }
        private void SaveDB()
        { //schoolid, schoolname, schooladdress, schooldivision, schoolregion, userid
            string query = "INSERT INTO tblschool (schoolid, schoolname, schooladdress, schooldivision, schoolregion, schoolhead, userid) " +
                "VALUES('" + txtSchoolID.Text + "','" + txtSchoolName.Text.Replace("'", "''").ToUpper() + "','" + hm.CorrectCasing(txtAddress.Text.Replace("'", "''")) +
                "','" + txtDivision.Text.Replace("'", "''").ToUpper() + "','" + txtRegion.Text.ToUpper() + "','" + hm.CorrectCasing(txtSchoolHead.Text) + 
                "'," + frmLogin.userid + ");";
            db.InsertQuery(query);
            MessageBox.Show("Save successful!", "Saved");
        }
        private void UpdateDB()
        {
            string query = "UPDATE tblschool SET schoolid='" + txtSchoolID.Text + "', schoolname='" + txtSchoolName.Text.Replace("'", "''").ToUpper() +
                "', schooladdress='" + hm.CorrectCasing(txtAddress.Text.Replace("'", "''")) + "', schooldivision='" + txtDivision.Text.Replace("'", "''").ToUpper() +
                "', schoolregion='" + txtRegion.Text.ToUpper() + "', schoolhead='" + hm.CorrectCasing(txtSchoolHead.Text) + "' WHERE userid=" + frmLogin.userid;
            db.InsertQuery(query);
            MessageBox.Show("Update successful!", "Updated");
        }
        private void frmSchool_Load(object sender, EventArgs e)
        {
            DataTable dt = db.SelectTable("SELECT * FROM tblschool WHERE userid=" + frmLogin.userid);
            if (dt != null)
            {
                if (dt.Rows.Count != 0)
                {
                    DataRow r = dt.Rows[0];
                    txtSchoolID.Text = r["schoolid"].ToString();
                    txtSchoolName.Text = r["schoolname"].ToString();
                    txtRegion.Text = r["schoolregion"].ToString();
                    txtDivision.Text = r["schooldivision"].ToString();
                    txtAddress.Text = r["schooladdress"].ToString();
                    txtSchoolHead.Text = r["schoolhead"].ToString();
                    isNew = false;
                }
            }
        }

        private void txtSchoolID_KeyPress(object sender, KeyPressEventArgs e)
        {
            hm.TextHandle(ref sender, ref e, true);
        }

        private void txtRegion_KeyPress(object sender, KeyPressEventArgs e)
        {
            hm.TextHandle(ref sender, ref e, false);
        }

        private void frmSchool_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMain.isAnyFormOpen = false;
        }

        private void frmSchool_KeyPress(object sender, KeyPressEventArgs e)
        {
            hm.TextHandle(ref sender, ref e, false);
        }
    }
}
