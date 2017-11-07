using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.IO;
using System.Security.Permissions;
using System.Security.AccessControl;
using System.Security.Cryptography;
using Microsoft.Win32;
using DevExpress.XtraReports.UI;

namespace MyClassCollection
{
    class MySQLDBUtilities
    {
        MySqlConnection conn;
        MySqlCommand com;
        MySqlDataAdapter myAdapter;
        ConnectionStringSolution css = new ConnectionStringSolution();

        public MySQLDBUtilities()
        {
            com = new MySqlCommand();
        }
        public MySqlConnection OpenConnection()
        {
            conn = new MySqlConnection();
            try
            {
                conn.ConnectionString = GetSettings();
                conn.Open();
                return conn;
            }
            catch
            {
                return null;
            }
        }
        public MySqlConnection OpenConnection(string settings)
        {
            conn = new MySqlConnection();
            try
            {
                conn.ConnectionString = settings;
                conn.Open();
                return conn;
            }
            catch
            {
                return null;
            }
        }
        public void CloseConnection()
        {
            if (conn != null)
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
        public string GetSettings()
        {
            /*string temp = string.Empty;
            if (File.Exists("C:\\Users\\" + Environment.UserName + "\\Documents\\Grading System\\settings.ini"))
            {
                string[] setting = File.ReadAllLines("C:\\Users\\" + Environment.UserName + "\\Documents\\Grading System\\settings.ini");
                foreach (string s in setting)
                    temp += s;
            }
            return temp;*/
            string temp = "";
            try
            {
                temp = css.ReadRegistryKey("ConnectionString", "mysqllao");
            }
            catch (Exception e)
            {
                
            }
            return temp;
        }
        public DataTable SelectTable(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                myAdapter = new MySqlDataAdapter(query, OpenConnection());
                myAdapter.Fill(dt);
                myAdapter.Dispose();
                CloseConnection();
                return dt;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
        public void InsertQuery(string query)
        {
            com.CommandText = query;
            try
            {
                com.Connection = OpenConnection();
                int res = com.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public string[] GetColumnDatas(string query, string colname)
        {
            List<string> temp = new List<string>();
            DataTable dt = SelectTable(query);
            foreach (DataRow r in dt.Rows)
                temp.Add(r[colname].ToString());
            if (temp.Count == 0)
                temp.Add("");
            return temp.ToArray();
        }

        public long GetID(string query, string colname)
        {
            DataTable dt = SelectTable(query);
            if (dt.Rows.Count != 0)
            {
                DataRow r = dt.Rows[0];
                long i = Convert.ToInt64(r[colname].ToString());
                return i;
            }
            else
                return 0;
        }
        public string DataLookUp(string columnName, string table, string defaultValue, string criteria)
        {
            string query = "SELECT " + columnName + " FROM " + table + " " +
                (criteria.Trim().Length > 0 ? "WHERE " + criteria + " " : "");
            DataTable dt = SelectTable(query);
            if (dt.Rows.Count == 0)
                return defaultValue;
            else
            {
                DataRow r = dt.Rows[0];
                return r[columnName].ToString();
            }
        }
        public void BindComboboxItems(string query, ComboBox cmb, string columnKey, string columnValue)
        {
            DataTable dt = SelectTable(query);
            Dictionary<string, string> d = new Dictionary<string, string>();
            foreach (DataRow r in dt.Rows)
            {
                d.Add(r[columnKey].ToString(), r[columnValue].ToString());
            }
            if (dt.Rows.Count > 0)
            {
                cmb.DataSource = new BindingSource(d, null);
                cmb.ValueMember = "key";
                cmb.DisplayMember = "value";
            }
        }
        //Current Project based Function
        public void SPInUpUser(string fullname,string gender,string major,string question,string answer, string username, string password,string attendanceDeduction,bool isInsert,string userid)
        {
            com.Parameters.Clear();
            string procedurename = "InUp_user";
            com.CommandText = procedurename;
            com.Connection = OpenConnection();
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.Add(new MySqlParameter("?userfullname1", fullname));
            com.Parameters.Add(new MySqlParameter("?usergender1", gender));
            com.Parameters.Add(new MySqlParameter("?usermajor1", major));
            com.Parameters.Add(new MySqlParameter("?userquestion1", question));
            com.Parameters.Add(new MySqlParameter("?useranswer1", answer));
            com.Parameters.Add(new MySqlParameter("?username1", username));
            com.Parameters.Add(new MySqlParameter("?userpassword1", password));
            com.Parameters.Add(new MySqlParameter("?attendanceDeduction1", attendanceDeduction));
            com.Parameters.Add(new MySqlParameter("?isInsert", (isInsert?1:0)));
            com.Parameters.Add(new MySqlParameter("?userid1", userid));

            com.ExecuteNonQuery();
            CloseConnection();
        }
        public void SPInUpStudent(string lrn, string fname, string lname, string mname, string gender, string birthdate, string address,bool isInsert)
        {
            com.Parameters.Clear();
            string procedurename = "InUp_student";
            com.CommandText = procedurename;
            com.Connection = OpenConnection();
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.Add(new MySqlParameter("?studno1", lrn));
            com.Parameters.Add(new MySqlParameter("?studfname1", fname));
            com.Parameters.Add(new MySqlParameter("?studlname1", lname));
            com.Parameters.Add(new MySqlParameter("?studmname1", mname));
            com.Parameters.Add(new MySqlParameter("?studgender1", gender));
            com.Parameters.Add(new MySqlParameter("?studbirthdate1", birthdate));
            com.Parameters.Add(new MySqlParameter("?studaddress1", address));
            com.Parameters.Add(new MySqlParameter("?isinsert", (isInsert?1:0)));

            com.ExecuteNonQuery();
            CloseConnection();
        }
        
        public void InsertMultiple(List<string> queries)
        {
            OpenConnection();
            MySqlCommand command = conn.CreateCommand();
            MySqlTransaction trans = conn.BeginTransaction();

            command.Connection = conn;
            command.Transaction = trans;
            try
            {
                for (int i = 0; i < queries.Count; i++)
                {
                    command.CommandText = queries[i].ToString();
                    command.ExecuteNonQuery();
                }
                trans.Commit();
                MessageBox.Show("Committed successfully!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                try
                {
                    trans.Rollback();
                }
                catch (MySqlException ex)
                {
                    if (trans.Connection != null)
                    {
                        Console.WriteLine("An exception of type " + ex.GetType() +
                                          " was encountered while attempting to roll back the transaction.");
                    }
                }
            }
            finally
            {
                CloseConnection();
            }
        }
    }
    class InteractionAddOns
    {
        Point formPoint;
        Point mousePoint;
        public bool isMoving;

        public InteractionAddOns()
        {
            formPoint = new Point();
            mousePoint = new Point();
            isMoving = false;
        }
        public Point FormMove(ref object sender, ref MouseEventArgs e, Point mouseXY)
        {
            Point m = mouseXY;
            int x, y;
            x = m.X - mousePoint.X;
            y = m.Y - mousePoint.Y;
            x = formPoint.X + x;
            y = formPoint.Y + y;
            m = new Point(x, y);
            return m;
        }
        public void FormDrag(ref object sender, ref MouseEventArgs e, Point mouseXY, Point formXY)
        {
            if (e.Button == MouseButtons.Left)
            {
                formPoint = formXY;
                mousePoint = mouseXY;
                isMoving = true;
            }
        }
        public void FormDrop(ref object sender, ref MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                isMoving = false;
        }

    }

    class DynamicCreator
    {
        public Label CreateLabel(int x, int y, Size s, string name, string text)
        {
            Label lbl = new Label();
            lbl.Location = new Point(x, y);
            lbl.Size = s;
            lbl.Name = name;
            lbl.Text = text;
            return lbl;
        }
        public TextBox CreateTextBox(int x, int y, Size s, string name, string text)
        {
            TextBox txt = new TextBox();
            txt.Location = new Point(x, y);
            txt.Size = s;
            txt.Name = name;
            txt.Text = text;
            return txt;
        }
        public Button CreateButton(int x, int y, Size s, string name, string text)
        {
            Button btn = new Button();
            btn.Location = new Point(x, y);
            btn.Size = s;
            btn.Name = name;
            btn.Text = text;
            return btn;
        }
    }

    class HelperMethods
    {
        public string CorrectCasing(string source)
        {
            string retval = "";
            if (!source.Equals(""))
            {
                if (source.Contains(' '))
                {
                    string[] temp = source.Split(' ');
                    for (int i = 0; i < temp.Length; i++)
                    {
                        if (temp[i].Length > 1)
                            retval += temp[i].Substring(0, 1).ToUpper() + temp[i].Substring(1).ToLower() + " ";
                        else
                            retval += temp[i].ToUpper();
                    }
                }
                else
                    retval += source.Substring(0, 1).ToUpper() + source.Substring(1).ToLower() + " ";
            }
            retval = retval.Trim();
            return retval;
        }
        public Image GetCopyImage(string path)
        {
            using (Image im = Image.FromFile(path))
            {
                Bitmap bm = new Bitmap(im);
                return bm;
            }
        }
        public void TextHandle(ref object sender, ref KeyPressEventArgs e, bool IsDigit)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && IsDigit)
                e.Handled = true;
            if (!char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsSymbol(e.KeyChar) && !IsDigit)
                e.Handled = true;
        }
        public void FullnameHandle(ref object sender, ref KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsLetter(e.KeyChar) && !e.KeyChar.Equals(',') && !e.KeyChar.Equals('.'))
                e.Handled = true;
        }
        public void AlphaNumericOnly(ref object sender, ref KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        public void DecimalHandle(ref object sender, ref KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Text.Contains(".") && e.KeyChar == '.')
                e.Handled = true;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
        }
        public void LimitTo(ref object sender, ref KeyPressEventArgs e, double count)
        {
            TextBox t = (TextBox)sender;
            if (!t.Text.Equals("") && !t.Text.Equals(".") && !char.IsControl(e.KeyChar))
            {
                try
                {
                    double temp = Convert.ToDouble(t.Text + e.KeyChar);
                    if (temp > count)
                        e.Handled = true;
                }
                catch
                {
                    e.Handled = true;
                }
            }
        }
        /*public DataTable ConvertToDataTable<T>(List<T> data)
        {
            DataTable table = new DataTable();
            FieldInfo[] fields = typeof(T).GetField();
            foreach (FieldInfo field in fields)
            {
                table.Columns.Add(field.Name, field.FieldType);
            }
            foreach (T item in data)
            {
                DataRow row = new DataRow();
                foreach (FieldInfo field in fields)
                {
                    row[field.Name] = field.GetValue(item);
                }
                table.Rows.Add(row);
            }
            return table;
        }*/
    }
    class DevExUtilities
    {
        private void BindData(object sender, string propertyName, string dbSource, string fieldName, string format = "")
        {
            try
            {
                string typeName = sender.GetType().Name;
                if (typeName.Equals("XRLabel"))
                {
                    XRLabel label = (XRLabel)sender;
                    label.DataBindings.Add(new XRBinding(propertyName, dbSource, fieldName, format));
                }
                else if (typeName.Equals("XRTableCell"))
                {
                    XRTableCell tableCell = (XRTableCell)sender;
                    tableCell.DataBindings.Add(new XRBinding(propertyName, dbSource, fieldName, format));
                }
            }
            catch (Exception ex) { }
        }
    }
    class ConnectionStringSolution
    {
        public string AES_Encrypt(string clearText, string passkey)
        {
            RijndaelManaged AES = new RijndaelManaged();
            MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();
            string encryptedString = "";
            try
            {
                byte[] hash = new byte[32];
                byte[] temp = hashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(passkey));
                Array.Copy(temp, 0, hash, 0, 16);
                Array.Copy(temp, 0, hash, 15, 16);
                AES.Key = hash;
                AES.Mode = CipherMode.ECB;
                ICryptoTransform DESEncrypter = AES.CreateEncryptor();
                byte[] buffer = ASCIIEncoding.ASCII.GetBytes(clearText);
                encryptedString = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(buffer, 0, buffer.Length));
            }
            catch (Exception e)
            {
                return "";
            }
            return encryptedString;
        }
        public string AES_Decrypt(string encryptedText, string passkey)
        {
            RijndaelManaged AES = new RijndaelManaged();
            MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();
            string decryptedString = "";
            try
            {
                byte[] hash = new byte[32];
                byte[] temp = hashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(passkey));
                Array.Copy(temp, 0, hash, 0, 16);
                Array.Copy(temp, 0, hash, 15, 16);
                AES.Key = hash;
                AES.Mode = CipherMode.ECB;
                ICryptoTransform DESDecrypter = AES.CreateDecryptor();
                byte[] buffer = Convert.FromBase64String(encryptedText);
                decryptedString = ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(buffer, 0, buffer.Length));
            }
            catch (Exception e)
            {
                return "";
            }
            return decryptedString;
        }
        public void CreateRegistryKey(string key, string value)
        {
            value = AES_Encrypt(value, "mysqllao");
            try
            {
                RegistryKey regKey = Registry.CurrentUser.OpenSubKey("Software", true);
                regKey.CreateSubKey("Project Grading System");
                regKey = regKey.OpenSubKey("Project Grading System", true);
                regKey.SetValue(key, value);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public string ReadRegistryKey(string key, string passkey)
        {
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("Software", true);
            regKey.CreateSubKey("Project Grading System");
            regKey = regKey.OpenSubKey("Project Grading System", true);
            return AES_Decrypt(regKey.GetValue(key).ToString(), passkey);

        }
    }//studno, studfname, studlname, studmname, studgender, studbirthdate, studaddress
    class Student
    {
        private string studNo, fname, lname, mname, gender, address, birthdate;
        private bool isChecked;

        public Student(string sn,string fn,string ln, string mn, string g, string a, string bd)
        {
            this.studNo = sn;
            this.fname = fn;
            this.lname = ln;
            this.mname = mn;
            this.gender = g;
            this.address = a;
            this.birthdate = bd;
        }
        public string StudentNo
        {
            get { return this.studNo; }
        }
        public string FirstName
        {
            get { return this.fname; }
        }
        public string LastName
        {
            get { return this.lname; }
        }
        public string MiddleName
        {
            get { return this.mname; }
        }
        public string Gender
        {
            get { return this.gender; }
        }
        public string Address
        {
            get { return this.address; }
        }
        public string Birthdate
        {
            get { return this.birthdate; }
        }
        public string FullName
        {
            get { return (this.lname + ", " + this.fname + " " + this.mname); }
        }
        public bool IsChecked
        {
            set { this.isChecked = value; }
            get { return this.isChecked; }
        }
    }//classid, studno, subjectid, schoolyear, yearsecid, userid
    class ClassRoster
    {
        private string classID, studentNo, subjectID, schoolYear, yearSecID, userID, classSignature;
        private DateTime from, to;
        private DateTime monthStart, monthEnd;

        public ClassRoster(string clid, string sn, string sid, string sy, string ysid, string uid, string cs,string tfrom,string tto,string monthStart, string monthEnd)
        {
            this.classID = clid;
            this.studentNo = sn;
            this.subjectID = sid;
            this.schoolYear = sy;
            this.yearSecID = ysid;
            this.userID = uid;
            this.classSignature = cs;
            this.from = Convert.ToDateTime(tfrom);
            this.to = Convert.ToDateTime(tto);
            this.monthStart = Convert.ToDateTime(monthStart);
            this.monthEnd = Convert.ToDateTime(monthEnd);
        }
        public string ClassID
        {
            get { return this.classID; }
        }
        public string StudentNo
        {
            get { return this.studentNo; }
        }
        public string SubjectID
        {
            get { return this.subjectID; }
        }
        public string SchoolYear
        {
            get { return this.schoolYear; }
        }
        public string YearSectionID
        {
            get { return this.yearSecID; }
        }
        public string UserID
        {
            get { return this.userID; }
        }
        public string ClassSignature
        {
            get { return this.classSignature; }
        }
        public DateTime TimeFrom 
        {
            set { this.from = value; }
            get { return this.from; }
        }
        public DateTime TimeTo
        {
            set { this.to = value; }
            get { return this.to; }
        }
        public DateTime MonthStart
        {
            get { return this.monthStart; }
        }
        public DateTime MonthEnd
        {
            get { return this.monthEnd; }
        }
    }//criteriaid, criterianame, criteriapercentage, userid, criteriaIsActive
    public class Criteria
    {
        private string criteriaID, criteriaName, criteriaPercentage, userID, criteriaType;
        private bool criteriaIsActive;

        public Criteria(string cid,string cn,string cp,string uid,string cia,string ctype)
        {
            this.criteriaID = cid;
            this.criteriaName = cn;
            this.criteriaPercentage = cp;
            this.userID = uid;
            this.criteriaType = ctype;
            if (cia.Equals("0"))
                criteriaIsActive = false;
            else
                criteriaIsActive = true;
        }
        public string CriteriaID
        {
            get { return this.criteriaID; }
        }
        public string CriteriaName
        {
            get { return this.criteriaName; }
        }
        public string CriteriaPercentage
        {
            get { return this.criteriaPercentage; }
        }
        public string UserID
        {
            get { return this.userID; }
        }
        public string CriteriaType
        {
            get { return this.criteriaType; }
        }
        public bool IsCriteriaActive
        {
            get { return this.criteriaIsActive; }
        }
    }
    class YearAndSection
    {
        private string yearSecID, year, section, sectionName;

        public YearAndSection(string id, string y, string s, string sn)
        {
            this.yearSecID = id;
            this.year = y;
            this.section = s;
            this.sectionName = sn;
        }
        public string YearSectionID
        {
            get { return this.yearSecID; }
        }
        public string YearSection
        {
            get { return (this.year + " - " + this.section + " " + this.sectionName); }
        }
    }
    
    public class Grade
    {
        //gradesid, rawscore, average, quarter, criteriaid, classid, totalitems
        private long gradesID;
        private string criteriaID, classID, quarter, criteriaType;
        private double rawScore, totalItems, average;
        private bool isUpdated;
        public Grade(string gID, double raw, double max, string q, string crID, string cID,string crType)
        {
            this.gradesID = Convert.ToInt64(gID);
            this.rawScore = raw;
            this.totalItems = max;
            this.quarter = q;
            this.criteriaID = crID;
            this.classID = cID;
            this.isUpdated = false;
            this.criteriaType = crType;
            ComputeAverage();
        }
        public Grade(string gID, double raw, double max, string q, string crID, string cID,double ave)
        {
            this.gradesID = Convert.ToInt64(gID);
            this.rawScore = raw;
            this.totalItems = max;
            this.quarter = q;
            this.criteriaID = crID;
            this.classID = cID;
            this.average = ave;
        }
        public void ComputeAverage()
        {
            if (criteriaType.Equals("Performance"))
                this.average = this.rawScore;
            else
                this.average = ((rawScore / (totalItems < 1 ?1:totalItems)) * 50) + 50;
        }
        public long GradesID
        {
            get { return this.gradesID; }
        }
        public string CriteriaID
        {
            get { return this.criteriaID; }
        }
        public string ClassID
        {
            get { return this.classID; }
        }
        public double RawScore
        {
            get { return this.rawScore; }
            set { this.rawScore = value; ComputeAverage(); }
        }
        public double TotalItems
        {
            get { return this.totalItems; }
            set { this.totalItems = value; ComputeAverage(); }
        }
        public double Average
        {
            get { return this.average; }
        }
        public string Quarter
        {
            get { return this.quarter; }
            set { this.quarter = value; }
        }
        public bool IsUpdated
        {
            get { return this.isUpdated; }
            set { this.isUpdated = value; }
        }
        public string CriteriaType
        {
            get { return this.criteriaType; }
        }
    }
    public class StudentInClass
    {
        public string fullname, studentNo, classID, gender;
        public StudentInClass(string fn, string sn, string cid, string g)
        {
            this.fullname = fn;
            this.studentNo = sn;
            this.classID = cid;
            this.gender = g;
        }
    }
    
    class Attendance
    {
        private string attendanceID;
        private bool isPresent;
        private string classID;
        private bool isUpdated;
        private Student student;
        private DateTime attendanceDate;

        public Attendance(string aID, string iP, string cid, Student s)
        {
            this.attendanceID = aID;
            if (iP.Equals("1"))
                this.isPresent = true;
            else
                this.isPresent = false;
            this.classID = cid;
            this.student = s;
            this.isUpdated = false;
        }
        public Attendance(string aID, string iP, string cid)
        {
            this.attendanceID = aID;
            if (iP.Equals("1"))
                this.isPresent = true;
            else
                this.isPresent = false;
            this.classID = cid;
        }
        public Attendance(string aID, string iP, string cid, string d)
        {
            this.attendanceID = aID;
            if (iP.Equals("1"))
                this.isPresent = true;
            else
                this.isPresent = false;
            this.classID = cid;
            attendanceDate = Convert.ToDateTime(d);
        }
        public string AttendanceID
        {
            get { return this.attendanceID; }
        }
        public string ClassID
        {
            get { return this.classID; }
        }
        public bool IsPresent
        {
            set { this.isPresent = value; this.isUpdated = true; }
            get { return this.isPresent; }
        }
        public bool IsUpdated
        {
            get { return this.isUpdated; }
        }
        public string StudentNo
        {
            get { return this.student.StudentNo; }
        }
        public string Gender
        {
            get { return this.student.Gender; }
        }
        public string Fullname
        {
            get { return this.student.FullName; }
        }
        public DateTime AttendanceDate
        {
            get { return this.attendanceDate; }
        }
    }
}
