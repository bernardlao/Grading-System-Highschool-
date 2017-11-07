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
    public partial class frmCriteria : Form
    {
        struct Criteria
        {
            public string criteriaID;
            public string criteriaName;
            public int percentage;
            public string criteriaType;
            public TextBox txtCriteriaName;
            public TextBox txtPercentage;
            public bool isEdited;
        }

        MySQLDBUtilities db = new MySQLDBUtilities();
        DynamicCreator dc = new DynamicCreator();
        HelperMethods hm = new HelperMethods();
        private List<Criteria> criterias = new List<Criteria>();
        private int count = 0;
        private bool isExitInvalid = true;
        private bool isNew = true;
        private int criteriaCounter = 0;
        private bool isCancel = false;

        private int locx = 15,locx2 = 15,locx3 = 15;
        private int locy = 15,locy2 = 15,locy3 = 15;
        private const int padx = 15;
        private const int pady = 15;

        public frmCriteria()
        {
            InitializeComponent();
        }

        private void frmCriteria_Load(object sender, EventArgs e)
        {
            DataTable dt = db.SelectTable("SELECT * FROM tblcriteria WHERE userid=" +
                frmLogin.userid + " AND criteriaIsActive=1");
            if (dt.Rows.Count != 0)
            {
                DialogResult d = MessageBox.Show("Do you want to create new Criteria settings?" +
                    "\n\nYes to Create new\nNo to Edit existing Criteria", "Options", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);
                if (DialogResult.No == d)
                {
                    count = dt.Rows.Count;
                    isNew = false;
                    SetDetailsIfExist(dt);//setControls here
                }
                else if (DialogResult.Yes == d)
                {
                    SetDefaults();
                }
                else
                {
                    isExitInvalid = true;
                    isCancel = true;
                }
                isExitInvalid = false;
            }
            else
                SetDefaults();
            if (!isNew)
            {
                btnPlusPerformance.Dispose();
                btnMinusPerformance.Dispose();
                btnPlusWrittenWorks.Dispose();
                btnMinusWrittenWorks.Dispose();
                btnPlusPeriodicals.Dispose();
                btnMinusPeriodicals.Dispose();
            }
            ComputeTotal();
            btnSave.Click += new EventHandler(btn_Click);
        }
        private void txtno_KeyPress(object sender, KeyPressEventArgs e)
        {
            hm.TextHandle(ref sender, ref e, true);
            hm.LimitTo(ref sender, ref e, 100);
        }

        private void SetDefaults()
        {
            SetControls("Performance", pnlPerformance, ref locx, ref locy);
            SetControls("Performance", pnlPerformance, ref locx, ref locy);
            SetControls("Performance", pnlPerformance, ref locx, ref locy);
            SetControls("WrittenWorks", pnlWritten, ref locx2, ref locy2);
            SetControls("WrittenWorks", pnlWritten, ref locx2, ref locy2);
            SetControls("WrittenWorks", pnlWritten, ref locx2, ref locy2);
            SetControls("Periodicals", pnlPeriodicals, ref locx3, ref locy3);
            criterias[0].txtCriteriaName.Text = "Attendance";
            criterias[0].txtCriteriaName.ReadOnly = true;
            criterias[0].txtPercentage.Text = "10";
            criterias[1].txtCriteriaName.Text = "Project";
            criterias[1].txtPercentage.Text = "20";
            criterias[2].txtCriteriaName.Text = "Recitation";
            criterias[2].txtPercentage.Text = "10";
            criterias[3].txtCriteriaName.Text = "Quiz";
            criterias[3].txtPercentage.Text = "20";
            criterias[4].txtCriteriaName.Text = "Activities";
            criterias[4].txtPercentage.Text = "10";
            criterias[5].txtCriteriaName.Text = "Assignments";
            criterias[5].txtPercentage.Text = "10";
            criterias[6].txtCriteriaName.Text = "Examination";
            criterias[6].txtPercentage.Text = "20";
        }
        private void SetControls(string criteriaType,Panel pnl,ref int x,ref int y)
        {

            Criteria criteria = new Criteria();
            criteria.criteriaName = "";
            criteria.percentage = 0;
            criteria.criteriaType = criteriaType;

            TextBox cName = dc.CreateTextBox(x, y, new Size(200, 27), criteriaCounter.ToString(), "");
            cName.KeyPress += new KeyPressEventHandler(txt_KeyPressTextOnly);
            lblPercentage.Location = new Point(cName.Size.Width + 25, lblPercentage.Location.Y);
            x += cName.Size.Width + padx;
            TextBox per = dc.CreateTextBox(x, y, new Size(50, 27), criteriaCounter.ToString(), "");
            per.KeyPress += new KeyPressEventHandler(txt_KeyPressNumber);
            per.KeyUp += new KeyEventHandler(TextBox_KeyUp);
            per.TextAlign = HorizontalAlignment.Right;
            criteria.txtCriteriaName = cName;
            criteria.txtPercentage = per;
            pnl.Controls.Add(criteria.txtCriteriaName);
            pnl.Controls.Add(criteria.txtPercentage);
            criterias.Add(criteria);

            x = padx;
            y += per.Size.Height + pady;
            criteriaCounter++;
            //Button btn = dc.CreateButton(100, locy + 20, new Size(150, 40), "btnSave", "Save");
            //btn.Click += new EventHandler(btn_Click);
            //btn.BackColor = SystemColors.Control;
            //pnlCriteria.Controls.Add(btn);
            //criteriaCounter++;

        }

        private void SetDetailsIfExist(DataTable dt)
        {
            foreach (DataRow r in dt.Rows)
            {
                if (r["criteriaType"].ToString().Equals("Performance"))
                    SetControls(r["criteriaType"].ToString(), pnlPerformance, ref locx, ref locy);
                else if (r["criteriaType"].ToString().Equals("WrittenWorks"))
                    SetControls(r["criteriaType"].ToString(), pnlWritten, ref locx2, ref locy2);
                else
                    SetControls(r["criteriaType"].ToString(), pnlPeriodicals, ref locx3, ref locy3);
            }
            for (int i = 0; i < count; i++)
            {
                DataRow r = dt.Rows[i];
                Criteria c = criterias[i];
                c.criteriaID = r["criteriaid"].ToString();
                c.criteriaName = r["criterianame"].ToString();
                c.percentage = Convert.ToInt32(r["criteriapercentage"].ToString());
                c.txtCriteriaName.Text = c.criteriaName;
                c.txtPercentage.Text = c.percentage.ToString();
                criterias[i] = c;
            }
            criterias[0].txtCriteriaName.ReadOnly = true;
        }

        private void frmCriteria_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMain.isAnyFormOpen = false;
            frmLogin.preventLogin = false;
            if (e.CloseReason == CloseReason.UserClosing && isExitInvalid)
            {
                MessageBox.Show("The criteria must be set to proceed.", "Access Denied!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                frmMain.isAnyFormOpen = true;
                frmLogin.preventLogin = true;
            }

        }
        private void txt_KeyPressTextOnly(object sender, KeyPressEventArgs e)
        {
            hm.TextHandle(ref sender, ref e, false);
            TextBox t = (TextBox)sender;
            int x = Convert.ToInt32(t.Name);
            Criteria c = criterias[x];
            c.isEdited = true;
            criterias[x] = c;
        }
        private void txt_KeyPressNumber(object sender, KeyPressEventArgs e)
        {
            hm.TextHandle(ref sender, ref e,true);
            hm.LimitTo(ref sender, ref e, 100);
            TextBox t = (TextBox)sender;
            int x = Convert.ToInt32(t.Name);
            Criteria c = criterias[x];
            c.isEdited = true;
            criterias[x] = c;
        }
        private void btn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < criterias.Count; i++)
            {
                Criteria c = criterias[i];
                c.criteriaName = c.txtCriteriaName.Text;
                c.percentage = Convert.ToInt32((c.txtPercentage.Text.Equals("")?"0":c.txtPercentage.Text));
                criterias[i] = c;
            }
            if (IsAllInfoValid())
            {
                if (DialogResult.Yes == MessageBox.Show("Proceed?", "Save",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    if (isNew)
                        SaveDB();
                    else
                        UpdateDB();
                    isExitInvalid = false;
                    frmMain.isAnyFormOpen = false;
                    this.Close();
                }
            }
        }//criteriaid, criterianame, criteriapercentage, userid, criteriaIsActive
        private bool IsAllInfoValid()
        {
            List<string> existCheck = new List<string>();
            foreach (Criteria c in criterias)
            {
                if (existCheck.Contains(c.criteriaName.ToLower()))
                {
                    MessageBox.Show("The Criteria name field must not be redundant.");
                    return false;
                }
                else
                    existCheck.Add(c.criteriaName.ToLower());
                //totalPercent += Convert.ToDouble((c.percentage == ""?"0":c.percentage));
                if (c.criteriaName.Equals(""))
                {
                    MessageBox.Show("Criteria name must not be empty.");
                    return false;
                }
                if (c.percentage < 1)
                {
                    MessageBox.Show("Criteria percent must be atleast 1%.");
                    return false;
                }
            }
            int performance = SumPercentage("Performance");
            int written = SumPercentage("WrittenWorks");
            int periodicals = SumPercentage("Periodicals");
            if (performance != 40)
            {
                MessageBox.Show("Performance must be total to 40%", "Invalid Total");
                return false;
            }
            if (written != 40)
            {
                MessageBox.Show("Written Works must be total to 40%", "Invalid Total");
                return false;
            }
            if (periodicals != 20)
            {
                MessageBox.Show("Periodicals must be total to 20%", "Invalid Total");
                return false;
            }
            
            return true;
        }
        private int SumPercentage(string criteria)
        {
            try
            {
                int sum = criterias.Where(s => s.criteriaType.Equals(criteria)).Select(s=>s.percentage).Sum();
                return sum;
            }
            catch (Exception e)
            { return 0; }
        }
        private void SaveDB()
        {
            List<string> queries = new List<string>();
            DataTable dt = db.SelectTable("SELECT criteriaid FROM tblcriteria WHERE userid = " + frmLogin.userid + " AND criteriaIsactive=1");
            if (dt != null)
            {
                if (dt.Rows.Count != 0)
                {
                    foreach(DataRow r in dt.Rows)
                    {
                        string query = "UPDATE tblcriteria SET criteriaIsActive=0 WHERE criteriaid=" + r["criteriaid"].ToString();
                        queries.Add(query);
                    }
                }
            }
            foreach (Criteria c in criterias)
            {
                string query = "INSERT INTO tblcriteria (criterianame,criteriapercentage,userid,criteriaIsActive,criteriaType)" +
                    " VALUES('" + hm.CorrectCasing(c.criteriaName.Replace("'","''")) + "'," + c.percentage + "," + 
                    frmLogin.userid + "," + 1 + ",'" + c.criteriaType + "')";
                queries.Add(query);
            }
            
            db.InsertMultiple(queries);
        }
        private void UpdateDB()
        {
            List<string> queries = new List<string>();
            foreach (Criteria c in criterias)
            {
                if (c.isEdited)
                {
                    string query = "UPDATE tblcriteria SET criterianame='" + hm.CorrectCasing(c.criteriaName.Replace("'", "''")) +
                        "'," +" criteriapercentage=" + c.percentage + " WHERE criteriaid=" + c.criteriaID;
                    queries.Add(query);
                }
            }
            db.InsertMultiple(queries);
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            string type = (sender as Button).Name.Replace("btnPlus","");
            if (type.Equals("Performance"))
                SetControls(type, pnlPerformance, ref locx, ref locy);
            else if (type.Equals("WrittenWorks"))
                SetControls(type, pnlWritten, ref locx2, ref locy2);
            else
                SetControls(type, pnlPeriodicals, ref locx3, ref locy3);
            //SetControls(type);
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            string type = (sender as Button).Name.Replace("btnMinus", "");

            if (criterias.Count > 0)
            {
                if (type.Equals("Performance"))
                {
                    for (int i = criterias.Count - 1; i > -1; i--)
                    {
                        if (type.Equals(criterias[i].criteriaType))
                        {
                            if (locy != 57)
                            {
                                DoSetControlLocation(ref locy, i);
                            }
                            break;
                        }
                    }
                }
                else if (type.Equals("WrittenWorks"))
                {
                    for (int i = criterias.Count - 1; i > -1; i--)
                    {
                        if (type.Equals(criterias[i].criteriaType))
                        {
                            DoSetControlLocation(ref locy2, i);
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = criterias.Count - 1; i > -1; i--)
                    {
                        if (type.Equals(criterias[i].criteriaType))
                        {
                            DoSetControlLocation(ref locy3, i);
                            break;
                        }
                    }
                }
                
            }

        }
        private void DoSetControlLocation(ref int y, int i)
        {
            if (criteriaCounter != 0)
                criteriaCounter--;
            int heightDifference = criterias[i].txtCriteriaName.Size.Height + pady;
            y = y - heightDifference;
            criterias[i].txtCriteriaName.Dispose();
            criterias[i].txtPercentage.Dispose();
            criterias.RemoveAt(i);
        }
        private void doCancel_Tick(object sender, EventArgs e)
        {
            if (isCancel)
                this.Close();
        }
        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            ComputeTotal();
        }
        private void ComputeTotal()
        {
            int performanceTotal = 0;
            int writtenTotal = 0;
            int periodicalsTotal = 0;
            foreach (Criteria c in criterias)
            {
                switch (c.criteriaType)
                {
                    case "Performance": performanceTotal += Convert.ToInt32((c.txtPercentage.Text.Equals("")?"0":c.txtPercentage.Text)); break;
                    case "WrittenWorks": writtenTotal += Convert.ToInt32((c.txtPercentage.Text.Equals("") ? "0" : c.txtPercentage.Text)); break;
                    case "Periodicals": periodicalsTotal += Convert.ToInt32((c.txtPercentage.Text.Equals("") ? "0" : c.txtPercentage.Text)); break;
                }
            }
            lblTotalPerformance.Text = "Total : " + performanceTotal;
            lblTotalWritten.Text = "Total : " + writtenTotal;
            lblTotalPeriodicals.Text = "Total : " + periodicalsTotal;
        }
    }
}
