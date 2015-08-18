using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using System.Data.SqlClient;

namespace Btomic
{
    public partial class Connection : Form
    {
        public Connection()
        {
            InitializeComponent();
        }


        public void PopulateSQLServers()
        {
            cmbServers.Items.Clear();
            DataTable dt = SmoApplication.EnumAvailableSqlServers(false);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    cmbServers.Items.Add(dr["Name"].ToString());
                }
            }

        }

        public void PopulateSQLDatabases()
        {
            cmbDatabase.Items.Clear();
            String connString = "";
            try
            {
                if (radWindowsAuth.Checked == true)
                {
                    connString = "Data Source=" + cmbServers.SelectedItem.ToString() + "; Integrated Security=True;";
                }
                else
                {

                    connString = "Data Source=" + cmbServers.SelectedItem.ToString() + "; uid=" + txtUsername.Text.Trim() + "; pwd=" + txtPassword.Text.Trim() + ";";
                }
           
                using (SqlConnection sqlConx = new SqlConnection(connString))
                {
                    try
                    {
                        sqlConx.Open();

                        DataTable tblDatabases = sqlConx.GetSchema("Databases");
                        sqlConx.Close();

                        foreach (DataRow row in tblDatabases.Rows)
                        {
                            cmbDatabase.Items.Add(row["database_name"].ToString());
                        }
                    }
                    catch (InvalidOperationException)
                    {
                        //MessageBox.Show("The connection to SQL Server could not be established.","SQL Error",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1);
                        //groupBox2.Enabled = false;
                    }
                    catch (SqlException)
                    {
                        //MessageBox.Show("The connection to SQL Server could not be established.", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        //groupBox2.Enabled = false;
                    }
                }
            }
            catch
            {
            }
        }

        private void ConnectionStringBuilderPopup_Load(object sender, EventArgs e)
        {
            try
            {
                GetConnectionInfo(DBSettings.MyConnectionString);
                if (DBSettings.Server != "")
                {
                    this.Cursor = Cursors.WaitCursor;
                    //Populate Server Dropdownlist
                    PopulateSQLServers();
                    cmbServers.SelectedIndex = cmbServers.FindString(DBSettings.Server);

                    if (DBSettings.Integrated == "false")
                    {
                        radSQLAuth.Checked = true;
                        txtUsername.Text = DBSettings.Username;
                        txtPassword.Text = DBSettings.Password;
                    }
                    PopulateSQLDatabases();
                    cmbDatabase.SelectedIndex = cmbDatabase.FindString(DBSettings.Database);
                    this.Cursor = Cursors.Default;
                }
            }
            catch
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            PopulateSQLServers();
            this.Cursor = Cursors.Default;
        }

        private void GetConnectionInfo(string MyCS)
        {
            string[] Conn = MyCS.Split(';');
            if (Conn.Length == 4)
            {
                //Integrated
                DBSettings.Server = Conn[0].Replace("Data Source=", "").Replace(";", "").Trim();
                DBSettings.Database = Conn[2].Replace("Initial Catalog=", "").Replace(";", "").Trim();
                DBSettings.Integrated = Conn[1].Replace("Integrated Security=", "").Replace(";", "").Trim();
                DBSettings.Username = "";
                DBSettings.Password = "";
            }
            else if (Conn.Length == 5)
            {
                //SQL Auth
                DBSettings.Server = Conn[0].Replace("Data Source=", "").Replace(";", "").Trim();
                DBSettings.Database = Conn[3].Replace("Initial Catalog=", "").Replace(";", "").Trim();
                DBSettings.Username = Conn[1].Replace("uid=", "").Replace(";", "").Trim();
                DBSettings.Password = Conn[2].Replace("pwd=", "").Replace(";", "").Trim();
                DBSettings.Integrated = "false";
            }
        }


        private void cmbServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbServers.SelectedIndex != -1)
            {
                groupBox2.Enabled = true;
                PopulateSQLDatabases();
            }
            else
            {
                groupBox2.Enabled = false;
            }
        }

        private void cmbServers_DropDown(object sender, EventArgs e)
        {
            if (cmbServers.Items.Count == 0)
            {
                this.Cursor = Cursors.WaitCursor;
                PopulateSQLServers();
                this.Cursor = Cursors.Default;
            }
        }

        private void radWindowsAuth_CheckedChanged(object sender, EventArgs e)
        {
            if (radWindowsAuth.Checked == true)
            {
                cmbDatabase.Items.Clear();
                cmbDatabase.Text = "";
                label4.Enabled = false;
                txtUsername.Enabled = false;
                label5.Enabled = false;
                txtPassword.Enabled = false;
                if (cmbServers.SelectedIndex != -1)
                {
                    groupBox2.Enabled = true;
                }
            }
        }

        private void radSQLAuth_CheckedChanged(object sender, EventArgs e)
        {
            if (radSQLAuth.Checked == true)
            {
                cmbDatabase.Items.Clear();
                cmbDatabase.Text = "";
                label4.Enabled = true;
                txtUsername.Enabled = true;
                label5.Enabled = true;
                txtPassword.Enabled = true;
                CheckText();
            }
        }

        private void CheckText()
        {
            if ((txtUsername.Text.Trim() != "") && (txtPassword.Text.Trim() != ""))
            {
                groupBox2.Enabled = true;
            }
            else
            {
                groupBox2.Enabled = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (TestConnection("btnOK") == true)
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void cmbDatabase_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            PopulateSQLDatabases();
            this.Cursor = Cursors.Default;
        }


        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            CheckText();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            CheckText();
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            TestConnection("btnTestConnection");
        }

        private bool TestConnection(string ButtonSource)
        {
            if (cmbDatabase.SelectedIndex != -1)
            {
                string connString = "";
                if (radWindowsAuth.Checked == true)
                {
                    connString = "Data Source=" + cmbServers.SelectedItem.ToString() + "; Integrated Security=True;";
                    connString += " Initial Catalog=" + cmbDatabase.Text.Trim() + ";";
                }
                else
                {
                    connString = "Data Source=" + cmbServers.SelectedItem.ToString() + "; uid=" + txtUsername.Text.Trim() + "; pwd=" + txtPassword.Text.Trim() + ";";
                    connString += " Initial Catalog=" + cmbDatabase.Text.Trim() + ";";
                }
                SqlConnection connection = new SqlConnection(connString);
                try
                {
                    connection.Open();
                    if (ButtonSource == "btnTestConnection")
                    {
                        MessageBox.Show("Test Connection Succeeded.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    DBSettings.MyConnectionString = connString;
                    return true;
                }
                catch (InvalidOperationException exc)
                {
                    MessageBox.Show(exc.Message, "The connection to SQL Server could not be established", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return false;
                }
                catch (SqlException exc)
                {
                    MessageBox.Show(exc.Message, "The connection to SQL Server could not be established", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Please select a database from the dropdown list.", "The connection to SQL Server could not be established", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
        }
    }
}
