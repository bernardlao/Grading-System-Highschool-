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
    public partial class frmSubject : Form
    {
        MySQLDBUtilities db = new MySQLDBUtilities();
        HelperMethods hm = new HelperMethods();
        private long id = -1;

        public frmSubject()
        {
            InitializeComponent();
        }

        private void frmSubject_Load(object sender, EventArgs e)
        {
            PopulateRecords("ASC");
        }
        private void PopulateRecords(string criteria)
        {
            lstSubject.Items.Clear();
            DataTable dt = db.SelectTable("SELECT * FROM tblsubject ORDER BY subjectname " + criteria);
            if (dt.Rows.Count != 0) 
            {
                foreach (DataRow r in dt.Rows)
                {
                    ListViewItem itm = new ListViewItem(r["subjectid"].ToString());
                    itm.SubItems.Add(r["subjectname"].ToString());
                    lstSubject.Items.Add(itm);
                }
            }
        }

        private void txtSubjectName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (!txtSubjectName.Text.Trim().Equals(""))
                {
                    if (DialogResult.Yes == MessageBox.Show("Save Data?", "Save",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        if (id == -1)
                            SaveDB();
                        else
                            UpdateDB();
                        txtSubjectName.Text = "";
                        PopulateRecords("ASC");
                    }
                }
                else
                    MessageBox.Show("Subject name must not be empty.");
            }
        }
        private void SaveDB()
        {
            DataTable dt = db.SelectTable("SELECT * FROM tblsubject WHERE subjectname='" +
                txtSubjectName.Text.Replace("'", "''") + "'");
            if (dt.Rows.Count == 0)
            {
                string query = "INSERT INTO tblsubject (subjectname) VALUES('" +
                    hm.CorrectCasing(txtSubjectName.Text.Replace("'", "''")) + "');";
                db.InsertQuery(query);
                MessageBox.Show("Save Successfully!", "Saved");
            }
            else
                MessageBox.Show("Subject already exist!", "Duplicate");
        }
        private void UpdateDB()
        {
            string query = "UPDATE tblsubject SET subjectname='" + 
                hm.CorrectCasing(txtSubjectName.Text.Replace("'", "''")) +
                "' WHERE subjectid=" + id;
            db.InsertQuery(query);
            id = -1;
            MessageBox.Show("Updated Successfully!", "Updated");
        }

        private void lstSubject_DoubleClick(object sender, EventArgs e)
        {
            int x = lstSubject.SelectedIndices[0];
            ListViewItem itm = lstSubject.Items[x];
            id = Convert.ToInt64(itm.Text);
            txtSubjectName.Text = itm.SubItems[1].Text;
        }

        private void frmSubject_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMain.isAnyFormOpen = false;
        }

        private void optZA_CheckedChanged(object sender, EventArgs e)
        {
            if (optAZ.Checked)
                PopulateRecords("ASC");
            else
                PopulateRecords("DESC");
        }
    }
}
