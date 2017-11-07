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
    public partial class frmGradeSheet : Form
    {
        MySQLDBUtilities db = new MySQLDBUtilities();
        HelperMethods hm = new HelperMethods();
        public static bool isValid = false;
        public static bool triggerClose = false;
        public static string classSignature = "";
        public static string header = "";
        public static string[] criterias;

        public static bool isTotalItemsGood = false;
        private bool isNew;
        private bool isAllGood;
        private int currentColumnIndex = 0;
        DataTable dt;
        private int[] perCriteriaCount;
        List<DataGridItem> itemsInFirst;
        List<DataGridItem> itemsInSecond;
        List<DataGridItem> itemsInThird;
        List<DataGridItem> itemsInFourth;
        DataGridView dgvSelected;
        Dictionary<string, string> criteriaDics;

        public frmGradeSheet()
        {
            InitializeComponent();
            itemsInFirst = new List<DataGridItem>();
            itemsInSecond = new List<DataGridItem>();
            itemsInThird = new List<DataGridItem>();
            itemsInFourth = new List<DataGridItem>();
            criteriaDics = new Dictionary<string, string>();
        }

        private void frmGradeSheet_Load(object sender, EventArgs e)
        {
            frmEditClass ec = new frmEditClass();
            ec.isForGradeSheet = true;
            ec.ShowDialog();
            cmbFilter.SelectedItem = cmbFilter.Items[0];
        }
        private void PopulateCriteriaDictionary()
        {
            criteriaDics = new Dictionary<string, string>();
            string crIDs = "";
            foreach (string c in criterias)
                crIDs += c + ",";
            crIDs = crIDs.Remove(crIDs.Length - 1);
            DataTable dtCriteria = db.SelectTable("SELECT * FROM tblcriteria WHERE criteriaid IN(" + crIDs + ");");
            foreach (DataRow r in dtCriteria.Rows)
            {
                criteriaDics.Add(r["criteriaid"].ToString(), r["criteriaType"].ToString());
            }
        }
        private void SetTotalItemsRestriction(DataGridView dgv)
        {
            DataGridViewRow r = dgv.Rows[0];
            for (int i = 3; i < r.Cells.Count; i++)
            {
                if (r.Cells[i].Value.ToString().Equals("%"))
                    dgv.Rows[0].Cells[i].ReadOnly = true;
                else if (r.Cells[i].Value.ToString().Equals(""))
                    dgv.Rows[0].Cells[i].ReadOnly = true;
                else
                    dgv.Rows[0].Cells[i].ReadOnly = false;
            }
        }
        private void SetDetailsWithDatas(DataGridView dgv, string quarter, List<DataGridItem> itemsInGrid)
        {
            List<Grade> grades = new List<Grade>();
            string classIDs = "";
            dgv.Columns.Clear();
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            //DataGridViewCell cell = new DataGridViewTextBoxCell();
            
            //column.CellTemplate = cell;
            column.Name = "0";
            column.Visible = false;
            column.DisplayIndex = 0;
            dgv.Columns.Add(column);
            column = new DataGridViewTextBoxColumn();
            //column.CellTemplate = cell;
            column.Name = "1";
            column.HeaderText = "LRN";
            column.Width = 100;
            column.ReadOnly = true;
            column.DisplayIndex = 1;
            dgv.Columns.Add(column);
            column = new DataGridViewTextBoxColumn();
            //column.CellTemplate = cell;
            column.Name = "2";
            column.Width = 250;
            column.HeaderText = "Student Fullname";
            column.ReadOnly = true;
            column.DisplayIndex = 2;
            dgv.Columns.Add(column);
            foreach (DataRow r in dt.Rows)
            {
                classIDs += r["classid"].ToString() + ",";
            }
            classIDs = classIDs.Remove(classIDs.Length - 1);
            DataTable dtGrades = db.SelectTable("SELECT * FROM tblgrades WHERE classid IN(" + classIDs + ") AND quarter='" + quarter + "'");
            isNew = (dtGrades.Rows.Count == 0 ? true : false);
            for (int i = 0; i < dtGrades.Rows.Count;i++ )
            {
                DataRow r = dtGrades.Rows[i];
                Grade g = new Grade(r["gradesid"].ToString(), Convert.ToDouble(r["rawscore"].ToString()), Convert.ToDouble(r["totalitems"].ToString()),
                    r["quarter"].ToString(), r["criteriaid"].ToString(), r["classid"].ToString(), criteriaDics[r["criteriaid"].ToString()]);
                grades.Add(g);
            }
            
            for (int i = 0; i < perCriteriaCount.Length; i++)
            {
                perCriteriaCount[i] = (grades.Count > 0 ? CountCriteria(criterias[i + 1], dtGrades.Rows[0]["classid"].ToString(), grades) : 1);
            }
            if (grades.Count == 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    for (int i = 1; i < criterias.Length; i++)
                    {
                        Grade g = new Grade("0", 0, 0, quarter, criterias[i], r["classid"].ToString(),criteriaDics[criterias[i]]);
                        grades.Add(g);
                    }
                }
            }
            for (int i = 1; i < criterias.Length; i++)
            {
                for (int j = 1; j <= perCriteriaCount[i - 1]; j++)
                {
                    column = new DataGridViewTextBoxColumn();
                    //column.CellTemplate = cell;
                    column.ContextMenuStrip = (j == perCriteriaCount[i - 1] ? cmsFirst : null);
                    column.Width = 80;
                    column.HeaderText = db.DataLookUp("criterianame", "tblcriteria", "", "criteriaid=" + criterias[i]) + "#" + j;
                    column.Name = criterias[i];
                    dgv.Columns.Add(column);
                }
                column = new DataGridViewTextBoxColumn();
                column.HeaderText = "Total";
                column.Name = criterias[i];
                column.ReadOnly = true;
                dgv.Columns.Add(column);
            }
            foreach (DataRow r in dt.Rows)
            {
                DataGridItem itm = new DataGridItem(r["classid"].ToString(), r["studno"].ToString(),
                    r["CONCAT(studlname,', ',studfname,' ',studmname)"].ToString());
                try
                {
                    List<Grade> testGradeIfExist = grades.Where(s => s.ClassID.Equals(r["classid"].ToString())).Select(s => s).ToList();
                    if (testGradeIfExist.Count > 0)
                    {
                        for (int i = 1; i < criterias.Length; i++)
                        {
                            itm.AddDataCellRange(GetGradesPerCriteriaPerStudent(r["classid"].ToString(), grades, criterias[i]));
                            itm.AddDataCell(new Grade("-1", -1, -1, quarter, "-1", r["classid"].ToString(), ""));
                        }
                    }
                    else
                    {
                        for (int i = 1; i < criterias.Length; i++)
                        {
                            //itm.AddDataCellRange(GetGradesPerCriteriaPerStudent(r["classid"].ToString(), grades, criterias[i]));
                            for (int j = 0; j < perCriteriaCount[i - 1]; j++)
                            {
                                Grade g = new Grade("0", 0, 0, quarter, criterias[i], r["classid"].ToString(), criteriaDics[criterias[i]]);
                                itm.AddDataCell(g);
                            }
                            itm.AddDataCell(new Grade("-1", -1, -1, quarter, "-1", r["classid"].ToString(), ""));
                        }
                    }
                }
                catch
                {   }
                itemsInGrid.Add(itm);
            }
            dgv.Rows.Add(itemsInGrid[0].GetRowTotalItems(criterias));
            foreach (DataGridItem dgi in itemsInGrid)
            {
                dgv.Rows.Add(dgi.GetRowData(criterias));
                if (!isTotalItemsGood)
                {
                    dgv.Rows.RemoveAt(0);
                    dgv.Rows.Insert(0, dgi.GetRowTotalItems(criterias));
                }
            }
            SetTotalItemsRestriction(dgv);
        }
        private int CountCriteria(string criteriaid,string classid, List<Grade> grades)
        {
            try
            {
                List<Grade> gs = grades.Where(s => s.CriteriaID.Equals(criteriaid) && s.ClassID.Equals(classid)).Select(s => s).ToList();
                return gs.Count;
            }
            catch { return 1; }
        }
        private List<Grade> GetGradesPerCriteriaPerStudent(string classid, List<Grade> grades, string criteriaID)
        {
            try
            {
                List<Grade> gs = grades.Where(s => s.ClassID.Equals(classid) && s.CriteriaID.Equals(criteriaID)).Select(s => s).OrderBy(s => s.GradesID).ToList();
                return gs;
            }
            catch { return new List<Grade>(); }
        }

        private void tmSetter_Tick(object sender, EventArgs e)
        {
            if (isValid)
            {
                lblClassName.Text += header;
                InitializeGrading();
            }
            if (triggerClose)
            {
                triggerClose = false;
                this.Close();
            }
        }
        private void InitializeGrading()
        {
            PopulateCriteriaDictionary();
            itemsInFirst = new List<DataGridItem>();
            itemsInSecond = new List<DataGridItem>();
            itemsInThird = new List<DataGridItem>();
            itemsInFourth = new List<DataGridItem>();

            dt = db.SelectTable("SELECT *,CONCAT(studlname,', ',studfname,' ',studmname) FROM tblclass c INNER JOIN tblstudent s ON c.studno = s.studno" +
                                   " WHERE classSignature='" + classSignature + "' ORDER BY CONCAT(studlname,', ',studfname,' ',studmname) ASC");
            perCriteriaCount = new int[criterias.Length - 1];
            tmSetter.Enabled = false;
            
            SetDetailsWithDatas(dgvFirst, "1st", itemsInFirst);
            SetDetailsWithDatas(dgvSecond, "2nd", itemsInSecond);
            SetDetailsWithDatas(dgvThird, "3rd", itemsInThird);
            SetDetailsWithDatas(dgvFourth, "4th", itemsInFourth);
        }
        private void frmGradeSheet_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMain.isAnyFormOpen = false;
            isValid = false;
            triggerClose = false;
            classSignature = "";
            header = "";
            criterias = null;
            isTotalItemsGood = false;
        }

        private void dgvFirst_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txt = e.Control as TextBox;
            if (txt != null)
            {
                txt.KeyPress += new KeyPressEventHandler(CellKeyPress);
            }
        }
        private void CellKeyPress(object sender, KeyPressEventArgs e)
        {
            hm.TextHandle(ref sender, ref e, true);
        }
        private void menuAddCol_Click(object sender, EventArgs e)
        {
            string selected = dgvSelected.Name;
            if(selected.Equals("dgvFirst"))
                AddColumnInDataGrid(dgvSelected, "1st", itemsInFirst);
            if (selected.Equals("dgvSecond"))
                AddColumnInDataGrid(dgvSecond, "2nd", itemsInSecond);
            if (selected.Equals("dgvThird"))
                AddColumnInDataGrid(dgvThird, "3rd", itemsInThird);
            if (selected.Equals("dgvFourth"))
                AddColumnInDataGrid(dgvFourth, "4th", itemsInFourth);
        }
        private void menuDeleteCol_Click(object sender, EventArgs e)
        {
            string selected = dgvSelected.Name;
            if(selected.Equals("dgvFirst"))
                DeleteColumnInDataGrid(dgvFirst, itemsInFirst);
            if (selected.Equals("dgvSecond"))
                DeleteColumnInDataGrid(dgvSecond, itemsInSecond);
            if (selected.Equals("dgvThird"))
                DeleteColumnInDataGrid(dgvThird, itemsInThird);
            if (selected.Equals("dgvFourth"))
                DeleteColumnInDataGrid(dgvFourth, itemsInFourth);
        }
        private void AddColumnInDataGrid(DataGridView dgv,string quarter,List<DataGridItem> itemsInGrid)
        {
            int index = currentColumnIndex;
            string header = dgv.Columns[index].HeaderText;
            int number = 0;
            DataGridViewColumn col = new DataGridViewTextBoxColumn();
            if (header.Contains("#"))
                number = Convert.ToInt32(header.Split('#')[1].ToString());
            col.HeaderText = header.Replace(("#" + number), "#" + (number + 1));
            col.ContextMenuStrip = cmsFirst;
            col.Name = dgv.Columns[index].Name;
            dgv.Columns[index].ContextMenuStrip = null;
            dgv.Columns.Insert(index + 1, col);
            string totalType = "";
            foreach (DataGridItem itm in itemsInGrid)
            {
                Grade g = new Grade("0", 0, 0, quarter, col.Name, itm.ClassID,criteriaDics[col.Name]);
                if(g.CriteriaType.Equals("Performance"))
                    totalType = "%";
                else
                    totalType = "0";
                itm.InsertDataCell(index - 2, g);
            }
            foreach (DataGridViewRow r in dgv.Rows)
            {
                r.Cells[index + 1].Value = "0";
            }
            dgv.Rows[0].Cells[index + 1].Value = totalType;
            SetTotalItemsRestriction(dgv);
        }
        private void DeleteColumnInDataGrid(DataGridView dgv,List<DataGridItem> itemsInGrid)
        {
            int index = currentColumnIndex;
            DataGridViewColumn col = dgv.Columns[index - 1];
            if (!col.ReadOnly)
            {
                foreach (DataGridItem itm in itemsInGrid)
                {
                    itm.RemoveDataCell(index - 3);
                }
                dgv.Columns.RemoveAt(currentColumnIndex);
                dgv.Columns[index - 1].ContextMenuStrip = cmsFirst;
            }
        }
        private void dgvFirst_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgvSelected = sender as DataGridView;
            currentColumnIndex = e.ColumnIndex;
        }
        private void ValueChanged(ref object sender, ref DataGridViewCellEventArgs e, List<DataGridItem> itemsInGrid)
        {
            try
            {
                DataGridView dgv = sender as DataGridView;
                if (e.RowIndex > 0)
                {
                    DataGridViewRow rowGrade = dgv.Rows[e.RowIndex];
                    int gIndex = e.ColumnIndex - 3;
                    string val = rowGrade.Cells[e.ColumnIndex].Value.ToString();
                    if (!dgv.Columns[e.ColumnIndex].HeaderText.Equals("Total"))
                        itemsInGrid[e.RowIndex - 1].SetRawScoreInGrade(gIndex, val);
                    ComputeForTotal(e.ColumnIndex, e.RowIndex, dgv, false, itemsInGrid);
                    itemsInGrid[e.RowIndex - 1].SetUpdateStatus(e.ColumnIndex - 3);
                }
                else
                {
                    DataGridViewRow rowTotal = dgv.Rows[e.RowIndex];
                    int gIndex = e.ColumnIndex - 3;
                    string val = rowTotal.Cells[e.ColumnIndex].Value.ToString();
                    foreach (DataGridItem itm in itemsInGrid)
                    {
                        itm.SetTotalItemInGrade(gIndex, val);
                        itm.SetUpdateStatus(e.ColumnIndex - 3);
                    }
                    ComputeForTotal(e.ColumnIndex, e.RowIndex, dgv, true, itemsInGrid);
                }
            }
            catch { }
            
        }
        private void ComputeForTotal(int columnIndex, int rowIndex, DataGridView dgv, bool isForAll,List<DataGridItem>itemsInGrid)
        {
            int totalIndex = 0;
            string crID = "";
            for (int i = columnIndex; i < dgv.Columns.Count; i++)
            {
                if (dgv.Columns[i].HeaderText.Equals("Total"))
                {
                    totalIndex = i;
                    crID = dgv.Columns[i].Name;
                    break;
                }
            }
            if (isForAll)
            {
                for (int i = 0; i < itemsInGrid.Count; i++)
                {
                    dgv.Rows[i + 1].Cells[totalIndex].Value = itemsInGrid[i].AverageScore(crID);
                }
            }
            else
                dgv.Rows[rowIndex].Cells[totalIndex].Value = itemsInGrid[rowIndex-1].AverageScore(crID);
        }

        private void dgvFirst_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if(dgv.Name.Equals("dgvFirst"))
                ValueChanged(ref sender, ref e, itemsInFirst);
            if (dgv.Name.Equals("dgvSecond"))
                ValueChanged(ref sender, ref e, itemsInSecond);
            if (dgv.Name.Equals("dgvThird"))
                ValueChanged(ref sender, ref e, itemsInThird);
            if (dgv.Name.Equals("dgvFourth"))
                ValueChanged(ref sender, ref e, itemsInFourth);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CheckDataEncoded();
            if (isAllGood)
            {
                if (DialogResult.Yes == MessageBox.Show("Are you sure to save changes?", "Save"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    isTotalItemsGood = false;
                    SaveAll();
                }
            }
            else
                MessageBox.Show("Some data are inconsistent. Please recheck your Encoded Grades.",
                    "Value Overflow", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void SaveAll()
        {//gradesid, rawscore, average, quarter, criteriaid, classid, totalitems
            List<string> queries = new List<string>();
            SaveSome(itemsInFirst, queries);
            SaveSome(itemsInSecond, queries);
            SaveSome(itemsInThird, queries);
            SaveSome(itemsInFourth, queries);
            db.InsertMultiple(queries);
            InitializeGrading();
        }
        private void SaveSome(List<DataGridItem> items, List<string> queries) 
        {
            foreach (DataGridItem itm in items)
            {
                List<Grade> perStudentGrades = itm.Grades;
                for (int i = 0; i < perStudentGrades.Count; i++)
                {
                    Grade g = perStudentGrades[i];
                    long gID = Convert.ToInt64(g.GradesID);
                    if (gID == 0)
                    {
                        string query = "INSERT INTO tblgrades(rawscore,average,quarter,criteriaid,classid,totalitems) VALUES(" +
                            g.RawScore + "," + g.Average + ",'" + g.Quarter + "'," + g.CriteriaID + "," + g.ClassID + "," + g.TotalItems + ");";
                        queries.Add(query);
                    }
                    else if (gID > 0)
                    {
                        if (g.IsUpdated)
                        {
                            string query = "UPDATE tblgrades SET rawscore =" + g.RawScore + ", average=" + g.Average + ", totalitems=" + g.TotalItems +
                                " WHERE gradesid = " + g.GradesID;
                            queries.Add(query);
                        }
                    }
                }
                List<string> dIDs = itm.DeletedIDs;
                foreach (string d in dIDs)
                {
                    if (!d.Equals("0") && !d.Equals("-1"))
                    {
                        string query = "DELETE FROM tblgrades WHERE gradesid =" + d;
                        queries.Add(query);
                    }
                }
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                int x = 0;
                if (cmbFilter.SelectedItem.ToString().Equals("LRN"))
                    x = 1;
                else
                    x = 2;
                switch (tcGrading.SelectedTab.Name)
                {
                    case "tpFirst": SetColor(dgvFirst,x); break;
                    case "tpSecond": SetColor(dgvSecond,x); break;
                    case "tpThird": SetColor(dgvThird,x); break;
                    case "tpFourth": SetColor(dgvFourth,x); break;
                }
            }
        }
        public void SetColor(DataGridView dgv, int col)
        {
            DefaultColor(dgv);
            if (!txtSearch.Text.Equals(""))
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    if (dgv.Rows[i].Cells[col].Value.ToString().ToLower().Contains(txtSearch.Text.ToLower()))
                        dgv.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
            else
                DefaultColor(dgv);

        }
        private void DefaultColor(DataGridView dgv)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
                dgv.Rows[i].DefaultCellStyle.BackColor = SystemColors.Control;
        }
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbFilter.SelectedItem.ToString().Equals("LRN"))
                hm.TextHandle(ref sender, ref e, true);
            else
                hm.TextHandle(ref sender, ref e, false);
        }

        private void dgvFirst_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DefaultColor(sender as DataGridView);
        }
        private void CheckDataEncoded()
        {
            isAllGood = true;
            PerTableCheck(dgvFirst);
            PerTableCheck(dgvSecond);
            PerTableCheck(dgvThird);
            PerTableCheck(dgvFourth);
        }
        private void PerTableCheck(DataGridView dgv)
        {
            double total = 0;
            for (int i = 3; i < dgv.Columns.Count; i++)
            {
                if (!dgv.Rows[0].Cells[i].ReadOnly && !dgv.Rows[0].Cells[i].Value.ToString().Equals(""))
                {
                    total = Convert.ToDouble(dgv.Rows[0].Cells[i].Value.ToString());
                    for (int j = 1; j < dgv.Rows.Count; j++)
                    {
                        double raw = Convert.ToDouble(dgv.Rows[j].Cells[i].Value.ToString());
                        if (total < raw)
                        {
                            dgv.Rows[j].Cells[i].Style.BackColor = Color.Red;
                            isAllGood = false;
                        }
                        else
                        {
                            dgv.Rows[j].Cells[i].Style.BackColor = SystemColors.Control;
                        }
                    }
                }
                else if (dgv.Rows[0].Cells[i].ReadOnly && dgv.Rows[0].Cells[i].Value.ToString().Equals("%"))
                {
                    for (int j = 1; j < dgv.Rows.Count; j++)
                    {
                        double raw = Convert.ToDouble(dgv.Rows[j].Cells[i].Value.ToString());
                        if (raw > 100)
                        {
                            dgv.Rows[j].Cells[i].Style.BackColor = Color.Red;
                            isAllGood = false;
                        }
                        else
                        {
                            dgv.Rows[j].Cells[i].Style.BackColor = SystemColors.Control;
                        }
                    }
                }
            }
        }
    }



    class DataGridItem
    {
        private string classID, lrn,studName;
        private bool isNew;
        private List<Grade> grades;
        private List<string> deletedIDs;

        public DataGridItem(string classID, string studentLRN, string studentName)
        {
            this.classID = classID;
            this.lrn = studentLRN;
            this.studName = studentName;
            grades = new List<Grade>();
            deletedIDs = new List<string>();
        }
        public void AddDataCell(Grade g)
        {
            this.grades.Add(g);
        }
        public void AddDataCellRange(List<Grade> gs)
        {
            this.grades.AddRange(gs);
        }
        public void InsertDataCell(int index, Grade g)
        {
            this.grades.Insert(index, g);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index">Note: The specified index will be deleted.</param>
        public void RemoveDataCell(int index)
        {
            deletedIDs.Add(grades[index].GradesID.ToString());
            this.grades.RemoveAt(index);
        }
        public string[] GetRowTotalItems(string[] criterias)
        {
            string currID = "";
            if (grades.Count > 0)
                currID = grades[0].CriteriaID;
            string[] temp = new string[((criterias.Length - 1) + 3 + grades.Count)];
            temp[0] = "";
            temp[1] = "";
            temp[2] = "Total item per Activities";
            int tempCount = 3;
            for (int i = 1; i < criterias.Length; i++)
            {
                List<Grade> gs = GetGradesPerCriteria(criterias[i]);
                foreach (Grade g in gs)
                {
                    string total;
                    if (g.CriteriaType.Equals("Performance"))
                        total = "%";
                    else
                        total = g.TotalItems.ToString();
                    temp[tempCount] = total;
                    tempCount++;
                    if (!total.Equals("0") && !total.Equals("%"))
                        frmGradeSheet.isTotalItemsGood = true;
                }
                temp[tempCount] = "";
                tempCount++;
            }
            return temp;
        }
        public string[] GetRowData(string[] criterias)
        {
            string currID = "";
            if (grades.Count > 0)
                currID = grades[0].CriteriaID;
            string[] temp = new string[((criterias.Length - 1) + 3 + grades.Count)];
            temp[0] = this.classID;
            temp[1] = this.lrn;
            temp[2] = this.studName;
            int tempCount = 3;
            for (int i = 1; i < criterias.Length; i++)
            {
                List<Grade> gs = GetGradesPerCriteria(criterias[i]);
                foreach (Grade g in gs)
                {
                    temp[tempCount] = g.RawScore.ToString();
                    tempCount++;
                }
                temp[tempCount] = AverageScore(criterias[i]);
                tempCount++;
            }
            return temp;
        }
        private List<Grade> GetGradesPerCriteria(string criteriaid)
        {
            try
            {
                List<Grade> gs = grades.Where(s => s.CriteriaID.Equals(criteriaid)).OrderBy(s=>s.GradesID).Select(s => s).ToList();
                return gs;
            }
            catch { return new List<Grade>(); }
        }
        public string AverageScore(string criteriaID)
        {
            try
            {
                List<Grade> gs = grades.Where(s => s.CriteriaID.Equals(criteriaID)).Select(s => s).ToList();
                if (gs[0].CriteriaType.Equals("Performance"))
                {
                    double divisor = gs.Count;
                    double ave = 0;
                    foreach (Grade g in gs)
                    {
                        ave += g.Average;
                    }
                    ave = ave / divisor;
                    ave = Math.Round(ave, 2);
                    return ave.ToString();
                }
                else
                {
                    double divisor = gs.Sum(s=>s.TotalItems);
                    double raw = gs.Sum(s => s.RawScore);
                    double ave = (raw / divisor) * 100;
                    return Math.Round(ave, 2).ToString();
                }
                
            }
            catch { return "0"; }
        }
        public void SetTotalItemInGrade(int index, string value)
        {
            grades[index].TotalItems = Convert.ToDouble(value);
        }
        public void SetRawScoreInGrade(int index, string value)
        {
            grades[index].RawScore = Convert.ToDouble(value);
        }
        public void SetUpdateStatus(int index)
        {
            grades[index].IsUpdated = true;
        }
        public string ClassID
        {
            get { return this.classID; }
        }
        public List<Grade> Grades
        {
            get { return this.grades; }
        }
        public List<string> DeletedIDs
        {
            get { return this.deletedIDs; }
        }
    }
}
