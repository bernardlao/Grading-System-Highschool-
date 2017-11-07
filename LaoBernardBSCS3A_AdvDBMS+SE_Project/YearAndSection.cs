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
    public partial class frmYearAndSection : Form
    {
        MySQLDBUtilities db = new MySQLDBUtilities();
        HelperMethods hm = new HelperMethods();
        private bool isUpdate = false;
        private string id = "-1";

        public frmYearAndSection()
        {
            InitializeComponent();
        }

        private void frmYearAndSection_Load(object sender, EventArgs e)
        {
            PopulateRecords("ASC");
        }

        private void PopulateRecords(string order)
        {
            lstRecords.Items.Clear();
            DataTable dt = db.SelectTable("SELECT *,CONCAT(year, ' ' , section) FROM tblyearsection ORDER BY CONCAT(year, ' ' , section) " + order);
            foreach (DataRow r in dt.Rows)
            {
                ListViewItem itm = new ListViewItem(r["yearsecid"].ToString());
                itm.SubItems.Add(r["year"].ToString());
                itm.SubItems.Add(r["section"].ToString());
                itm.SubItems.Add(r["sectionname"].ToString());
                lstRecords.Items.Add(itm);
            }
        }

        private void txtSecNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            hm.TextHandle(ref sender, ref e, true);
        }

        private void txtSecName_KeyPress(object sender, KeyPressEventArgs e)
        {
            hm.TextHandle(ref sender, ref e, false);
        }

        private void txtSecName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (IsAllInformationValid())
                {
                    if (DialogResult.Yes == MessageBox.Show("Do you want to save the given information?",
                        "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        if (isUpdate)
                            UpdateDB();
                        else
                            SaveDB();
                        PopulateRecords((optASC.Checked ? "ASC" : "DESC"));
                        SetAllTextBoxToNull();
                        txtYear.Focus();
                    }
                }
            }
        }
        private bool IsAllInformationValid()
        {
            DataTable dt = db.SelectTable("SELECT * FROM tblyearsection WHERE sectionname='" +
                txtSecName.Text.Replace("'", "''") + "'");
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    if (r["year"].ToString().Equals(txtYear.Text))
                    {
                        MessageBox.Show("Class already exist");
                        return false;
                    }
                    if (r["sectionname"].ToString().ToLower().Equals(txtSecName.Text.Replace("'", "''").ToLower()))
                    {
                        MessageBox.Show("Section Name Exist");
                        return false;
                    }
                }
            }
            foreach (ListViewItem itm in lstRecords.Items)
            {
                if (itm.SubItems[1].Text.Equals(txtYear.Text))
                {
                    if (itm.SubItems[2].Text.Equals(txtSecNum.Text))
                    {
                        MessageBox.Show("Class Grade and Section Number exist!");
                        return false;
                    }
                }
            }
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    TextBox t = c as TextBox;
                    if (t.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("Please fillout the " + (t.Name.Equals("txtYear") ? "Grade " :
                            (t.Name.Equals("txtSecNum") ? "Section # " : "Section Name ")));
                        c.Focus();
                        return false;
                    }
                }
            }
            int year = Convert.ToInt32(txtYear.Text);
            int secNum = Convert.ToInt32(txtSecNum.Text);
            if (year < 1 || secNum < 1)
            {
                MessageBox.Show("Grade and Section # must be atleast 1.");
                return false;
            }
            return true;
        }
        private void lstRecords_DoubleClick(object sender, EventArgs e)
        {
            isUpdate = true;
            int x = lstRecords.SelectedIndices[0];
            ListViewItem itm = lstRecords.Items[x];
            id = itm.Text;
            txtYear.Text = itm.SubItems[1].Text;
            txtSecNum.Text = itm.SubItems[2].Text;
            txtSecName.Text = itm.SubItems[3].Text;
        }

        private void SaveDB()
        {
            string sql = "INSERT INTO tblyearsection (year,section,sectionname) VALUES('" +
                Convert.ToUInt32(txtYear.Text) + "','" + Convert.ToInt32(txtSecNum.Text) + "','" + hm.CorrectCasing(txtSecName.Text.Replace("'","''")) + "');";
            db.InsertQuery(sql);
            MessageBox.Show("Saved Successfully!");
        }
        private void UpdateDB()
        {
            string sql = "UPDATE tblyearsection SET year='" + Convert.ToInt32(txtYear.Text) + "', section='"+
                Convert.ToInt32(txtSecNum.Text) + "', sectionname='" + hm.CorrectCasing(txtSecName.Text.Replace("'","''")) + "' WHERE yearsecid=" + id;
            db.InsertQuery(sql);
            MessageBox.Show("Updated Successfully!");
            isUpdate = false;
            id = "-1";
        }
        private void SetAllTextBoxToNull()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                    c.Text = string.Empty;
            }
        }

        private void frmYearAndSection_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMain.isAnyFormOpen = false;
        }

        private void optDESC_CheckedChanged(object sender, EventArgs e)
        {
            PopulateRecords((optASC.Checked ? "ASC" : "DESC"));
        }
    }
}
