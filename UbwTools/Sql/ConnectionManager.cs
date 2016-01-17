using System;
using System.Windows.Forms;
using UbwTools.Common;
using UbwTools.Sql.Database;
using UbwTools.Sql.Gui;

namespace UbwTools.Sql
{
    public class ConnectionManager
    {
        private static ConnectionManager _instance;
        public static ConnectionManager Instance
        {
            get { return _instance ?? (_instance = new ConnectionManager()); }
        }

        private ConnectionManager()
        {
        }

        public static IDatabaseConnection CurrentConnection;

        public void HandleReconnect()
        {
            ReconnectForm form = new ReconnectForm();
            if (form.ShowDialog(SqlCommon.SqlForm) == DialogResult.OK)
            {
                TerminateCurrentConnectionIfAny();
                PrepareCurrentConnection(form.Connection);
                SqlCommon.SqlForm.tools.Invalidate();
            }
        }

        public void HandleAppStartConnect()
        {
            AppStartConnectForm form = new AppStartConnectForm();
            if (form.ShowDialog(SqlCommon.SqlForm) == DialogResult.OK)
            {
                HandleFirstTimeConnect(form.Connection);
            }
        }

        public void HandleFirstTimeConnect(IDatabaseConnection connection)
        {
            FirstTimeConnectForm form = new FirstTimeConnectForm(connection);
            if (form.ShowDialog(SqlCommon.SqlForm) == DialogResult.OK)
            {
                TerminateCurrentConnectionIfAny();
                PrepareCurrentConnection(form.Connection);
                SqlCommon.SqlForm.tools.Invalidate();
            }
        }

        private void PrepareCurrentConnection(IDatabaseConnection connection)
        {
            CurrentConnection = connection;
            CurrentConnection.Open();
            SqlCommon.Status.Set(CurrentConnection);
            CurrentConnection.Close();
            SqlCommon.SqlForm.Text = String.Format("{0}  -  {1}", connection.Name, Global.FullTitle);
            SqlCommon.DatabaseContent.ConnectedTo();
            SqlCommon.SqlForm.menuWindowNewSame.Enabled = true;
        }

        private void TerminateCurrentConnectionIfAny()
        {
            SqlCommon.SqlForm.menuWindowNewSame.Enabled = false;
            if (null != CurrentConnection)
            {
                SqlCommon.DatabaseContent.ShowDatabaseDisconnected();
                CurrentConnection = null;
            }
        }

        public void HandleDisconnect()
        {
            TerminateCurrentConnectionIfAny();
            SqlCommon.Status.Set(CurrentConnection);
            SqlCommon.SqlForm.tools.Invalidate();
        }

        public void CheckForConnectRequest(string requestedConnectionName)
        {
            if (null == requestedConnectionName)
            {
                string[] argv = Environment.GetCommandLineArgs();
                if (argv.Length > 2)
                {
                    requestedConnectionName = argv[2];
                }
            }
            if (!string.IsNullOrEmpty(requestedConnectionName))
            {
                IDatabaseConnection connection = SqlCommon.History.Get(requestedConnectionName);
                if (null == connection)
                {
                    MessageBox.Show(SqlCommon.SqlForm,
                        String.Format("Klarer ikke å finne noen kobling med navnet\r\n{0}.", requestedConnectionName),
                        Global.FullTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    PrepareCurrentConnection(connection);
                }
            }
        }
    }
}
