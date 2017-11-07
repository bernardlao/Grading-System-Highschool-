using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MyClassCollection;

namespace LaoBernardBSCS3A_AdvDBMS_SE_Project
{
    public partial class frmConnect : Form
    {
        MySQLDBUtilities db = new MySQLDBUtilities();
        ConnectionStringSolution css = new ConnectionStringSolution();
        public bool isExitInvalid = true;
        string connStr;

        public frmConnect()
        {
            InitializeComponent();
        }

        private void frmConnect_Load(object sender, EventArgs e)
        {
            
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            if (IsConnectionValid())
                MessageBox.Show("Connection Valid!", "Connectivity Test",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Connection Invalid!", "Connectivity Test",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (IsConnectionValid())
            {
                MessageBox.Show("Connection Valid!", "Connectivity Test",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (DialogResult.Yes == MessageBox.Show("Do you want to proceed with the selected connection?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    css.CreateRegistryKey("ConnectionString", connStr);
                    isExitInvalid = false;
                    this.Close();
                }
                
            }
            else
                MessageBox.Show("Connection Invalid!", "Connectivity Test",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool IsConnectionValid()
        {
            connStr = "SERVER=" + txtServer.Text + ";" +
                             "PORT=" + txtPort.Text + ";" +
                             "DATABASE=" + txtDatabase.Text + ";" +
                             "UID=" + txtUID.Text + ";" +
                             "PASSWORD=" + txtPassword.Text + ";";
            
            
            if (db.OpenConnection(connStr) == null)
                return false;
            else
            {
                db.CloseConnection();
                return true;
            }
        }

        private void frmConnect_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && isExitInvalid)
                Environment.Exit(1);
        }
    }
}
