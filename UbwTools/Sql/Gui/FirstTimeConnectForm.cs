using System;
using System.Drawing;
using System.Windows.Forms;
using UbwTools.Common;
using UbwTools.Common.Gui;
using UbwTools.Sql.Database;

namespace UbwTools.Sql.Gui
{
    public partial class FirstTimeConnectForm : FormBase
    {
        public IDatabaseConnection Connection { get; private set; }
        private string _engineName;

        public FirstTimeConnectForm(IDatabaseConnection connection, bool editExisting = false)
        {
            InitializeComponent();
            RestoreWindowInfo();
            Connection = null;
            if (null == connection)
            {
                PrepareForBrandNewConnection();
            }
            else
            {
                if (editExisting)
                {
                    PrepareForEditExistingConnection(connection);
                }
                else
                {
                    PrepareForAppStartConnection(connection);
                }
            }
        }

        private void FirstTimeConnectForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveWindowInfo();
        }

        private void comboBoxDatabaseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool sqlServer = (0 == comboBoxDatabaseType.SelectedIndex);
            bool oracle = !sqlServer;
            groupBoxSqlServer.Enabled = sqlServer;
            groupBoxOracle.Enabled = oracle;
        }

        private void comboBoxSqlServerAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool sqlServerAuthentication = (1 == comboBoxSqlServerAuthentication.SelectedIndex);
            labelSqlServerUserName.Enabled = sqlServerAuthentication;
            textBoxSqlServerUserName.Enabled = sqlServerAuthentication;
            labelSqlServerPassword.Enabled = sqlServerAuthentication;
            textBoxSqlServerPassword.Enabled = sqlServerAuthentication;
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            TestConnection();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            AcceptConnection();
        }

        private void PrepareForBrandNewConnection()
        {
            Text = "Koble til en database for første gang";
            comboBoxDatabaseType.SelectedIndex = 0;
            comboBoxSqlServerAuthentication.SelectedIndex = 0;
        }

        private void PrepareForAppStartConnection(IDatabaseConnection connection)
        {
            Text = "Koble til en database definert av et AppStart miljø";
            FillCurrentParameters(connection);
        }

        private void PrepareForEditExistingConnection(IDatabaseConnection connection)
        {
            Text = "Redigere en eksisterende databasekobling";
            FillCurrentParameters(connection);
        }

        private void FillCurrentParameters(IDatabaseConnection connection)
        {
            textBoxConnectionName.Text = connection.Name;
            textBoxDescription.Text = connection.Description;
            _engineName = connection.EngineName;
            switch (connection.EngineType)
            {
                case DatabaseEngineType.SqlServer:
                    SqlServerDatabaseConnection sqlServerConnection = connection as SqlServerDatabaseConnection;
                    if (null == sqlServerConnection)
                    {
                        throw new Exception("Intern feil");
                    }
                    comboBoxDatabaseType.SelectedIndex = 0;
                    textBoxSqlServerServerName.Text = connection.ServerName;
                    textBoxSqlServerInstanceName.Text = sqlServerConnection.InstanceName;
                    textBoxSqlServerDatabaseName.Text = sqlServerConnection.DatabaseName;
                    if (sqlServerConnection.WindowsAuthentication)
                    {
                        comboBoxSqlServerAuthentication.SelectedIndex = 0;
                        textBoxSqlServerUserName.Text = string.Empty;
                        textBoxSqlServerPassword.Text = string.Empty;
                    }
                    else
                    {
                        comboBoxSqlServerAuthentication.SelectedIndex = 1;
                        textBoxSqlServerUserName.Text = connection.UserName;
                        textBoxSqlServerPassword.Text = connection.Password;
                    }
                    break;
                case DatabaseEngineType.Oracle:
                    OracleDatabaseConnection oracleConnection = connection as OracleDatabaseConnection;
                    if (null == oracleConnection)
                    {
                        throw new Exception("Intern feil");
                    }
                    comboBoxDatabaseType.SelectedIndex = 1;
                    textBoxOracleServerName.Text = connection.ServerName;
                    textBoxOracleSidOrServiceName.Text = oracleConnection.SidOrServiceName;
                    textBoxOraclePort.Text = oracleConnection.Port;
                    textBoxOracleUserName.Text = connection.UserName;
                    textBoxOraclePassword.Text = connection.Password;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void TestConnection()
        {
            using (new WaitingCursor(this))
            {
                try
                {
                    tipper.SetToolTip(labelTestResult, string.Empty);
                    labelTestResult.Text = string.Empty;
                    Application.DoEvents();
                    IDatabaseConnection connection = MakeConnection();
                    connection.UnderlyingConnection.Open();
                    connection.UnderlyingConnection.Close();
                    labelTestResult.Text = "Suksess";
                    labelTestResult.ForeColor = Color.DarkGreen;
                }
                catch (Exception ex)
                {
                    labelTestResult.Text = "Feil: " + ex.Message;
                    tipper.SetToolTip(labelTestResult, ex.Message);
                    labelTestResult.ForeColor = Color.Red;
                }
            }
        }

        private void AcceptConnection()
        {
            using (new WaitingCursor(this))
            {
                try
                {
                    tipper.SetToolTip(labelTestResult, string.Empty);
                    labelTestResult.Text = string.Empty;
                    Application.DoEvents();
                    IDatabaseConnection connection = MakeConnection();
                    connection.UnderlyingConnection.Open();
                    connection.UnderlyingConnection.Close();
                    Connection = connection;
                    if (SaveConnectionInHistory(connection))
                    {
                        DialogResult = DialogResult.OK;
                    }
                }
                catch (Exception ex)
                {
                    labelTestResult.Text = "Feil: " + ex.Message;
                    tipper.SetToolTip(labelTestResult, ex.Message);
                    labelTestResult.ForeColor = Color.Red;
                }
            }
        }

        private bool SaveConnectionInHistory(IDatabaseConnection connection)
        {
            if (!SqlCommon.History.Exists(connection))
            {
                SqlCommon.History.Save(connection);
                return true;
            }
            if (SqlCommon.History.Identical(connection))
            {
                return true;
            }
            string msg =
                string.Format(
                    "En kobling med navnet {0} finnes allerede.\r\nBortsett fra navnet er koblingen IKKE identisk.\r\nVil du overskrive den eksisterende koblingen?",
                    connection.Name);
            if (DialogResult.Yes ==
                MessageBox.Show(this, msg, Global.FullTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2))
            {
                SqlCommon.History.Save(connection);
                return true;
            }
            return false;
        }

        private IDatabaseConnection MakeConnection()
        {
            string name = textBoxConnectionName.Text.Trim();
            string description = textBoxDescription.Text.Trim();
            bool sqlServer = (0 == comboBoxDatabaseType.SelectedIndex);
            IDatabaseConnection result = sqlServer
                ? MakeSqlServerConnection(name, description)
                : MakeOracleConnection(name, description);
            if (string.IsNullOrEmpty(name))
            {
                textBoxConnectionName.Text = result.Name;
            }
            if (string.IsNullOrEmpty(description))
            {
                textBoxDescription.Text = result.Description;
            }
            return result;
        }

        private IDatabaseConnection MakeSqlServerConnection(string name, string description)
        {
            string serverName = textBoxSqlServerServerName.Text.Trim();
            if (string.IsNullOrEmpty(serverName)) throw new Exception("Manglende servernavn");
            string instanceName = textBoxSqlServerInstanceName.Text.Trim();
            string databaseName = textBoxSqlServerDatabaseName.Text.Trim();
            if (string.IsNullOrEmpty(databaseName)) throw new Exception("Manglende databasenavn");
            bool windowsAuthentication = (0 == comboBoxSqlServerAuthentication.SelectedIndex);
            if (windowsAuthentication)
            {
                return new SqlServerDatabaseConnection(name, description, _engineName, serverName, instanceName,
                    databaseName);
            }
            string userName = textBoxSqlServerUserName.Text.Trim();
            if (string.IsNullOrEmpty(userName)) throw new Exception("Manglende brukernavn");
            string password = textBoxSqlServerPassword.Text.Trim();
            if (string.IsNullOrEmpty(password)) throw new Exception("Manglende passord");
            return new SqlServerDatabaseConnection(name, description, _engineName, serverName, instanceName,
                databaseName, userName, password);
        }

        private IDatabaseConnection MakeOracleConnection(string name, string description)
        {
            string serverName = textBoxOracleServerName.Text.Trim();
            if (string.IsNullOrEmpty(serverName)) throw new Exception("Manglende servernavn");
            string sidOrServiceName = textBoxOracleSidOrServiceName.Text.Trim();
            if (string.IsNullOrEmpty(sidOrServiceName)) throw new Exception("Manglende SID eller service navn");
            string port = textBoxOraclePort.Text.Trim();
            if (string.IsNullOrEmpty(port)) throw new Exception("Manglende port");
            string userName = textBoxOracleUserName.Text.Trim();
            if (string.IsNullOrEmpty(userName)) throw new Exception("Manglende brukernavn");
            string password = textBoxOraclePassword.Text.Trim();
            return new OracleDatabaseConnection(name, description, _engineName, serverName, sidOrServiceName, port,
                userName, password);
        }
    }
}
