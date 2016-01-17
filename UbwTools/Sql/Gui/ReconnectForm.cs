using System;
using System.Windows.Forms;
using UbwTools.Common;
using UbwTools.Common.Gui;
using UbwTools.Launch;
using UbwTools.Sql.Database;

namespace UbwTools.Sql.Gui
{
    public partial class ReconnectForm : FormBase
    {
        public IDatabaseConnection Connection { get; private set; }

        public ReconnectForm()
        {
            InitializeComponent();
            RestoreWindowInfo();
            SqlCommon.History.LoadAll();
            InitializeListView();
        }

        private void ReconnectForm_Shown(object sender, EventArgs e)
        {
            if (list.Items.Count > 0)
            {
                list.Items[0].Selected = true;
            }
            list.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void ReconnectForm_Resize(object sender, EventArgs e)
        {
            list.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void ReconnectForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveWindowInfo();
        }

        private void list_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool anySelected = (list.SelectedItems.Count > 0);
            buttonConnect.Enabled = anySelected;
            buttonEdit.Enabled = anySelected;
            buttonDelete.Enabled = anySelected;
            buttonSaveStarter.Enabled = anySelected;
            buttonSaveShortcut.Enabled = anySelected;
        }

        private void list_DoubleClick(object sender, EventArgs e)
        {
            ConnectToSelected();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            ConnectToSelected();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            EditConnection();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteConnection();
        }

        private void buttonSaveStarter_Click(object sender, EventArgs e)
        {
            SaveToStarter();
        }

        private void buttonSaveShortcut_Click(object sender, EventArgs e)
        {
            SaveShortcutToDesktop();
        }

        private void InitializeListView()
        {
            list.SetObjects(SqlCommon.History.GetItems());
        }

        private void ConnectToSelected()
        {
            Connection = list.SelectedObject as IDatabaseConnection;
            if (null == Connection) return;
            using (WaitingCursor waitingCursor = new WaitingCursor(this))
            {
                try
                {
                    Connection.UnderlyingConnection.Open();
                    Connection.UnderlyingConnection.Close();
                    SqlCommon.History.MoveToTop(Connection);
                    DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show(this, "Klarer ikke å koble til databasen:\r\n" + ex.Message, Global.FullTitle,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    waitingCursor.StopWaiting();
                }
            }
        }

        private void EditConnection()
        {
            IDatabaseConnection connection = list.SelectedObject as IDatabaseConnection;
            if (null != connection)
            {
                FirstTimeConnectForm form = new FirstTimeConnectForm(connection, true);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    InitializeListView();
                }
            }
        }

        private void DeleteConnection()
        {
            IDatabaseConnection connection = list.SelectedObject as IDatabaseConnection;
            if (null != connection)
            {
                SqlCommon.History.Delete(connection.Name);
                InitializeListView();
            }
        }

        private void SaveToStarter()
        {
            IDatabaseConnection connection = list.SelectedObject as IDatabaseConnection;
            if (null != connection)
            {
                LaunchCommon.Databases.Add(connection.Name);
            }
        }

        private void SaveShortcutToDesktop()
        {
            IDatabaseConnection connection = list.SelectedObject as IDatabaseConnection;
            if (null != connection)
            {
                ShortcutMaker.Create(string.Format("{0} {1}", Global.ShortTitle, connection.Name), LaunchGuiForm.IconSql, Application.ExecutablePath, string.Format("{0} {1}", LaunchManager.IdDatabase, connection.Name));
            }
        }
    }
}
