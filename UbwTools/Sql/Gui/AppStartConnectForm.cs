using System;
using System.Globalization;
using System.Windows.Forms;
using UbwTools.Common.Gui;
using UbwTools.Sql.Database;

namespace UbwTools.Sql.Gui
{
    public partial class AppStartConnectForm : FormBase
    {
        public IDatabaseConnection Connection { get; private set; }

        public AppStartConnectForm()
        {
            InitializeComponent();
            RestoreWindowInfo();
        }

        private void AppStartConnectForm_Shown(object sender, EventArgs e)
        {
            FillTree();
        }

        private void AppStartConnectForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveWindowInfo();
        }

        private void tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            AppStartEnvironment environment = e.Node.Tag as AppStartEnvironment;
            SelectEnvironment(environment);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            AcceptSelection();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            CloseWithoutSelection();
        }

        private void FillTree()
        {
            AppStartInformation appStartInformation = new AppStartInformation(this);
            if (appStartInformation.Load())
            {
                tree.BeginUpdate();
                appStartInformation.PopulateTree(tree.Nodes);
                tree.ExpandAll();
                foreach (TreeNode node in tree.Nodes)
                {
                    node.Collapse(true);
                }
                tree.EndUpdate();
            }
            else
            {
                Close();
            }
        }

        private void SelectEnvironment(AppStartEnvironment environment)
        {
            if (null == environment)
            {
                ShowNoEnvironment();
            }
            else
            {
                ShowEnvironment(environment);
            }
        }

        private void ShowNoEnvironment()
        {
            buttonOk.Enabled = false;
            panelEnvironmentInfo.Visible = false;
        }

        private void ShowEnvironment(AppStartEnvironment environment)
        {
            textBoxId.Text = environment.EnvironmentId.ToString(CultureInfo.InvariantCulture);
            textBoxTitle.Text = environment.Title;
            textBoxServer.Text = environment.ServerInstance;
            textBoxDatabase.Text = environment.DatabaseName;
            textBoxConnectionInfo.Text = environment.ConnectionInfo;
            textBoxUsername.Text = environment.UserName;
            textBoxPassword.Text = environment.Password;
            panelEnvironmentInfo.Visible = true;
            buttonOk.Enabled = true;
        }

        private void AcceptSelection()
        {
            AppStartEnvironment environment = this.tree.SelectedNode.Tag as AppStartEnvironment;
            if (null == environment) return;
            switch (environment.DbVersion.DbType)
            {
                case DatabaseEngineType.SqlServer:
                    Connection = new SqlServerDatabaseConnection(environment.Title, environment.Title,
                        environment.DbVersion.Title, environment.ServerName, environment.InstanceName,
                        environment.DatabaseName, environment.UserName, environment.Password);
                    break;
                case DatabaseEngineType.Oracle:
                    Connection = new OracleDatabaseConnection(environment.Title, environment.Title,
                        environment.DbVersion.Title, environment.ServerName, environment.SidOrServiceName, environment.Port,
                        environment.UserName, environment.Password);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            DialogResult = DialogResult.OK;
        }

        private void CloseWithoutSelection()
        {
            Connection = null;
            DialogResult = DialogResult.Cancel;
        }
    }
}
