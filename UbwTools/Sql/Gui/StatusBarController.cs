using System.Windows.Forms;
using UbwTools.Properties;
using UbwTools.Sql.Database;

namespace UbwTools.Sql.Gui
{
    public class StatusBarController
    {
        private static StatusBarController _instance;

        public static StatusBarController Instance
        {
            get { return _instance ?? (_instance = new StatusBarController()); }
        }

        private StatusBarController()
        {
            SqlCommon.SqlForm.status.Items[SectionNotConnected].Text = " Ikke koblet til en database  ";
        }

        private const int SectionNotConnected = 0;
        private const int SectionEngine = 1;
        private const int SectionDataSource = 2;
        private const int SectionDatabase = 3;
        private const int SectionUbw = 4;
        private const int SectionName = 5;

        public void Set(IDatabaseConnection connection)
        {
            if (null == connection)
            {
                ShowNoConnection();
            }
            else
            {
                ShowConnectionDescription(connection);
            }
        }

        private void ShowNoConnection()
        {
            SetNotConnectedVisible(true);
        }

        private void ShowConnectionDescription(IDatabaseConnection currentConnection)
        {
            switch (currentConnection.EngineType)
            {
                case DatabaseEngineType.SqlServer:
                    SqlCommon.SqlForm.status.Items[SectionEngine].Image = Resources.SqlServer016;
                    break;
                case DatabaseEngineType.Oracle:
                    SqlCommon.SqlForm.status.Items[SectionEngine].Image = Resources.Oracle016;
                    break;
            }
            SqlCommon.SqlForm.status.Items[SectionEngine].Text = string.Format(" Type: {0}  ", currentConnection.EngineName);
            SqlCommon.SqlForm.status.Items[SectionDataSource].Text = string.Format(" {0}: {1}  ", currentConnection.DataSourceDescription,
                currentConnection.DataSourceValue);
            SqlCommon.SqlForm.status.Items[SectionDatabase].Text = string.Format(" {0}: {1}  ", currentConnection.DatabaseDescription, currentConnection.DatabaseValue);
            if (currentConnection.IsUbwDatabase)
            {
                SqlCommon.SqlForm.status.Items[SectionUbw].Image = Resources.Unit4016;
                SqlCommon.SqlForm.status.Items[SectionUbw].Text = string.Format(" UBW {0}  ", currentConnection.UbwDatabaseDescription);
            }
            else
            {
                SqlCommon.SqlForm.status.Items[SectionUbw].Image = Resources.NoUnit4016;
                SqlCommon.SqlForm.status.Items[SectionUbw].Text = " Ikke en UBW database  ";
            }
            SqlCommon.SqlForm.status.Items[SectionName].Text = string.Format(" {0}  ", currentConnection.Name);
            SetNotConnectedVisible(false);
        }

        private void SetNotConnectedVisible(bool visible)
        {
            SqlCommon.SqlForm.status.Items[SectionNotConnected].Visible = visible;
            SqlCommon.SqlForm.status.Items[SectionEngine].Visible = !visible;
            SqlCommon.SqlForm.status.Items[SectionDataSource].Visible = !visible;
            SqlCommon.SqlForm.status.Items[SectionDatabase].Visible = !visible;
            SqlCommon.SqlForm.status.Items[SectionUbw].Visible = !visible;
            SqlCommon.SqlForm.status.Items[SectionName].Visible = !visible;
        }
    }
}
