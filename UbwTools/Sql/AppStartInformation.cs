using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UbwTools.Common;

namespace UbwTools.Sql
{
    public class AppStartInformation
    {
        private readonly Form _parentForm;
        private readonly Dictionary<string, int> _envGroupsByName = new Dictionary<string, int>();
        private readonly Dictionary<string, int> _relUpdatesByName = new Dictionary<string, int>();
        private readonly Dictionary<string, AppStartDatabaseVersion> _dbVersionsByName = new Dictionary<string, AppStartDatabaseVersion>();
        private readonly Dictionary<int, AppStartDatabaseVersion> _dbVersionsById = new Dictionary<int, AppStartDatabaseVersion>();
        private readonly Dictionary<string, AppStartEnvironment> _environmentsByName = new Dictionary<string, AppStartEnvironment>();

        public AppStartInformation(Form parentForm)
        {
            _parentForm = parentForm;
        }

        public bool Load()
        {
            SqlConnectionStringBuilder bld = new SqlConnectionStringBuilder
            {
                DataSource = GetDataSource(),
                InitialCatalog = "AppStart",
                UserID = "AppStart",
                Password = "agresso"
            };
            SqlConnection conn = new SqlConnection(bld.ToString());
            try
            {
                conn.Open();
                if (!LoadEnvGroups(conn))
                {
                    MessageBox.Show(_parentForm, "Fant ingen AppStart kategorier.", Global.FullTitle, MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
                if (!LoadAgressoUpdates(conn))
                {
                    MessageBox.Show(_parentForm, "Fant ingen AppStart releaser/oppdateringer.", Global.FullTitle,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
                if (!LoadDatabaseVersions(conn))
                {
                    MessageBox.Show(_parentForm, "Fant ingen AppStart databasetyper/versjoner.", Global.FullTitle,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
                if (!LoadEnvironments(conn))
                {
                    MessageBox.Show(_parentForm, "Fant ingen AppStart miljøer.", Global.FullTitle,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(_parentForm,
                    string.Format("Klarer ikke å lese informasjon fra AppStart database:\r\n{0}", ex.Message),
                    Global.FullTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        private string GetDataSource()
        {
#if(DEBUG)
            return "CORPU4AGR" == Environment.UserDomainName ? "noos-agras01t" : "hhaug04";
#else
            return "noos-agras01t";
#endif
        }

        private bool LoadEnvGroups(SqlConnection conn)
        {
            _envGroupsByName.Clear();
            SqlCommand cmd = new SqlCommand("SELECT id, title FROM envGroups WHERE owner IN ('', @owner)", conn);
            cmd.Parameters.Add("@owner", SqlDbType.NVarChar, 50).Value = Environment.UserName.ToUpper();
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    int id = rdr.GetInt32(0);
                    string title = rdr.GetString(1);
                    _envGroupsByName.Add(title, id);
                }
            }
            return _envGroupsByName.Count > 0;
        }

        private bool LoadAgressoUpdates(SqlConnection conn)
        {
            _relUpdatesByName.Clear();
            SqlCommand cmd = new SqlCommand("SELECT u.id, r.title, r.abbrev, u.title FROM releases r, relUpdates u WHERE u.release_id = r.id", conn);
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    int id = rdr.GetInt32(0);
                    string relTitle = rdr.GetString(1);
                    string abbrev = rdr.GetString(2);
                    string updTitle = rdr.GetString(3);
                    StringBuilder sb = new StringBuilder(relTitle);
                    if (abbrev != relTitle)
                    {
                        sb.Append(" (");
                        sb.Append(abbrev);
                        sb.Append(')');
                    }
                    sb.Append(' ');
                    sb.Append(updTitle);
                    string title = sb.ToString();
                    _relUpdatesByName.Add(title, id);
                }
            }
            return _relUpdatesByName.Count > 0;
        }

        private bool LoadDatabaseVersions(SqlConnection conn)
        {
            _dbVersionsByName.Clear();
            _dbVersionsById.Clear();
            SqlCommand cmd = new SqlCommand("SELECT v.id, t.title, v.title FROM dbTypes t, dbVersions v WHERE v.dbType_id = t.id", conn);
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    int id = rdr.GetInt32(0);
                    string typTitle = rdr.GetString(1);
                    string verTitle = rdr.GetString(2);
                    string title = string.Format("{0} {1}", typTitle, verTitle);
                    AppStartDatabaseVersion databaseVersion = new AppStartDatabaseVersion(id, title, verTitle);
                    _dbVersionsByName.Add(title, databaseVersion);
                    _dbVersionsById.Add(id, databaseVersion);
                }
            }
            return _dbVersionsByName.Count > 0;
        }

        private bool LoadEnvironments(SqlConnection conn)
        {
            _environmentsByName.Clear();
            SqlCommand cmd = new SqlCommand("SELECT id, envGroup_id, relUpdate_id, dbVersion_id, name, title, connectionInfo, dbServerInstance, databaseName, userName, password FROM environments", conn);
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    int id = rdr.GetInt32(0);
                    int envGroupId = rdr.GetInt32(1);
                    int relUpdateId = rdr.GetInt32(2);
                    int dbVersionId = rdr.GetInt32(3);
                    string name = rdr.GetString(4);
                    string title = rdr.GetString(5);
                    string connectionInfo = rdr.GetString(6);
                    string dbServerInstance = rdr.GetString(7);
                    string databaseName = rdr.GetString(8);
                    string userName = rdr.GetString(9);
                    string password = rdr.GetString(10);
                    string fullTitle = title.StartsWith(name, StringComparison.InvariantCultureIgnoreCase)
                        ? title
                        : string.Format("{0} ({1})", title, name);
                    AppStartDatabaseVersion dbVersion = GetDatabaseVersion(dbVersionId);
                    AppStartEnvironment environment = new AppStartEnvironment(id, envGroupId, relUpdateId, dbVersionId,
                        fullTitle, dbServerInstance, connectionInfo, databaseName, userName, password, dbVersion);
                    while (_environmentsByName.ContainsKey(fullTitle))
                    {
                        fullTitle += "*";
                    }
                    _environmentsByName.Add(fullTitle, environment);
                }
            }
            return _environmentsByName.Count > 0;
        }

        private AppStartDatabaseVersion GetDatabaseVersion(int dbVersionId)
        {
            return _dbVersionsById[dbVersionId];
            //foreach (KeyValuePair<string, AppStartDatabaseVersion> pair in _dbVersionsByName)
            //{
            //    if (pair.Value.VersionId == dbVersionId)
            //    {
            //        return pair.Value;
            //    }
            //}
            //throw new ArgumentOutOfRangeException("dbVersionId", "Database version not found");
        }

        public void PopulateTree(TreeNodeCollection root)
        {
            PopulateCategories(root);
        }

        private void PopulateCategories(TreeNodeCollection parent)
        {
            foreach (KeyValuePair<string, int> pair in _envGroupsByName.OrderBy(p => p.Key))
            {
                string title = pair.Key;
                TreeNode node = new TreeNode(title);
                PopulateReleaseUpdates(node.Nodes, pair.Value);
                if (node.Nodes.Count > 0)
                {
                    parent.Add(node);
                }
            }
        }

        private void PopulateReleaseUpdates(TreeNodeCollection parent, int envGroupId)
        {
            foreach (KeyValuePair<string, int> pair in _relUpdatesByName.OrderBy(p => p.Key))
            {
                string title = pair.Key;
                TreeNode node = new TreeNode(title);
                PopulateDatabaseVersions(node.Nodes, envGroupId, pair.Value);
                if (node.Nodes.Count > 0)
                {
                    parent.Add(node);
                }
            }
        }

        private void PopulateDatabaseVersions(TreeNodeCollection parent, int envGroupId, int relUpdateId)
        {
            foreach (KeyValuePair<string, AppStartDatabaseVersion> pair in _dbVersionsByName.OrderBy(p => p.Key))
            {
                string title = pair.Key;
                TreeNode node = new TreeNode(title);
                PopulateEnvironments(node.Nodes, envGroupId, relUpdateId, pair.Value.VersionId);
                if (node.Nodes.Count > 0)
                {
                    parent.Add(node);
                }
            }
        }

        private void PopulateEnvironments(TreeNodeCollection parent, int envGroupId, int relUpdateId, int dbVersionId)
        {
            foreach (KeyValuePair<string, AppStartEnvironment> pair in _environmentsByName.OrderBy(p => p.Key))
            {
                AppStartEnvironment environment = pair.Value;
                if ((environment.CategoryId == envGroupId) && (environment.ReleaseUpdateId == relUpdateId) &&
                    (environment.DatabaseVersionId == dbVersionId))
                {
                    string title = pair.Key;
                    TreeNode node = new TreeNode(title);
                    node.Tag = environment;
                    parent.Add(node);
                }
            }
        }
    }
}
