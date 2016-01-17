using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UbwTools.Common;
using UbwTools.Sql.Gui;

namespace UbwTools.Sql
{
    public class DatabaseContentManager
    {
        private static DatabaseContentManager _instance;
        public static DatabaseContentManager Instance
        {
            get { return _instance ?? (_instance = new DatabaseContentManager()); }
        }

        private DatabaseContentManager()
        {
        }

        private TreeNode _database;
        private TreeNode _databaseDataTables;
        private TreeNode _databaseDataViews;
        private TreeNode _databaseHelpTables;
        private TreeNode _databaseOtherTables;
        private TreeNode _databaseOtherViews;

        public void PrepareDatabasePane()
        {
            ShowDatabaseDisconnected();
        }

        public void ShowDatabaseDisconnected()
        {
            SqlCommon.SqlForm.Text = Global.FullTitle;
            SqlCommon.SqlForm.treeDatabase.BeginUpdate();
            SqlCommon.SqlForm.treeDatabase.Nodes.Clear();
            SqlCommon.SqlForm.treeDatabase.Nodes.Add(_database = new NodeRoot("Ikke koblet til en database", SqlGuiForm.IconDisconnected));
            SqlCommon.SqlForm.treeDatabase.EndUpdate();
        }

        public void ConnectedTo()
        {
            SqlCommon.SqlForm.treeDatabase.BeginUpdate();
            SqlCommon.SqlForm.treeDatabase.Nodes.Clear();
            SqlCommon.SqlForm.treeDatabase.Nodes.Add(_database = new NodeRoot("Database", SqlGuiForm.IconConnected));
            if (ConnectionManager.CurrentConnection.IsUbwDatabase)
            {
                PopulateTreeForUbwBase();
            }
            else
            {
                PopulateTreeForNonUbwBase();
            }
            _database.Expand();
            SqlCommon.SqlForm.treeDatabase.EndUpdate();
        }

        private void PopulateTreeForUbwBase()
        {
            List<string> tables = ConnectionManager.CurrentConnection.GetAllTableNames().ToList();
            IEnumerable<string> views = ConnectionManager.CurrentConnection.GetAllViewNames();

            _database.Nodes.Add(_databaseDataTables = new NodeFolder("UBW tabeller"));
            PopulateUbwTablesOrViews(
                tables.Where(x => x.StartsWith("A", StringComparison.OrdinalIgnoreCase)),
                _databaseDataTables, name => new NodeDatabaseTable(name, SqlCommon.SqlForm.contextDatabaseTable));

            _database.Nodes.Add(_databaseDataViews = new NodeFolder("UBW views"));
            PopulateUbwTablesOrViews(
                views.Where(x => x.StartsWith("A", StringComparison.OrdinalIgnoreCase)),
                _databaseDataViews, name => new NodeDatabaseView(name, SqlCommon.SqlForm.contextDatabaseView));

            _database.Nodes.Add(_databaseHelpTables = new NodeFolder("Hjelpetabeller"));
            _databaseHelpTables.ContextMenuStrip = SqlCommon.SqlForm.contextHelpTables;
            PopulatePlainTablesOrViews(
                tables.Where(x => x.StartsWith("H", StringComparison.OrdinalIgnoreCase)),
                _databaseHelpTables, name => new NodeDatabaseTable(name, SqlCommon.SqlForm.contextDatabaseTable));

            _database.Nodes.Add(_databaseOtherTables = new NodeFolder("Andre tabeller"));
            PopulatePlainTablesOrViews(
                tables.Where(x => !(x.StartsWith("A", StringComparison.OrdinalIgnoreCase) || x.StartsWith("H", StringComparison.OrdinalIgnoreCase))),
                _databaseOtherTables, name => new NodeDatabaseTable(name, SqlCommon.SqlForm.contextDatabaseTable));

            _database.Nodes.Add(_databaseOtherViews = new NodeFolder("Andre views"));
            PopulatePlainTablesOrViews(
                views.Where(x => !(x.StartsWith("A", StringComparison.OrdinalIgnoreCase))),
                _databaseOtherViews, name => new NodeDatabaseView(name, SqlCommon.SqlForm.contextDatabaseView));
        }

        private void PopulateTreeForNonUbwBase()
        {
            IEnumerable<string> tables = ConnectionManager.CurrentConnection.GetAllTableNames();
            IEnumerable<string> views = ConnectionManager.CurrentConnection.GetAllViewNames();

            _database.Nodes.Add(_databaseDataTables = new NodeFolder("Tabeller"));
            PopulatePlainTablesOrViews(
                tables,
                _databaseDataTables, name => new NodeDatabaseTable(name, SqlCommon.SqlForm.contextDatabaseTable));

            _database.Nodes.Add(_databaseDataViews = new NodeFolder("Views"));
            PopulatePlainTablesOrViews(
                views,
                _databaseDataViews, name => new NodeDatabaseView(name, SqlCommon.SqlForm.contextDatabaseView));
        }

        private delegate NodeTableViewBase MakeTableOrTreeNode(string name);

        private void PopulateUbwTablesOrViews(IEnumerable<string> names, TreeNode parent, MakeTableOrTreeNode nodeMaker)
        {
            const string norwegianProductsPrefix = "A47";
            string lastGroupName = string.Empty;
            TreeNode groupNode = null;
            string lastSubgroupName = string.Empty;
            TreeNode subgroupNode = null;
            int subgroupPosition = 0;
            foreach (string name in names)
            {
                string groupName = name.Substring(0, name.Substring(0, 4).ToUpper() == "ASYS" ? 4 : 3);
                if (groupName.ToUpper() != lastGroupName)
                {
                    lastGroupName = groupName.ToUpper();
                    groupNode = new NodeFolder(groupName);
                    if (lastGroupName == norwegianProductsPrefix)
                    {
                        parent.Nodes.Insert(0, groupNode);
                    }
                    else
                    {
                        parent.Nodes.Add(groupNode);
                    }
                }
                NodeTableViewBase newNode = nodeMaker(name);
                //                NodeDatabaseTable newNode = new NodeDatabaseTable(name, SqlCommon.SqlForm.contextDatabaseTable);
                if (lastGroupName == norwegianProductsPrefix)
                {
                    if (char.IsLetter(name[3]) &&
                        char.IsLetter(name[4]) &&
                        char.IsDigit(name[5]) &&
                        char.IsDigit(name[6]) &&
                        char.IsLetter(name[7]))
                    {
                        string subgroupName = name.Substring(3, 4).ToUpper();
                        if (subgroupName != lastSubgroupName)
                        {
                            lastSubgroupName = subgroupName;
                            subgroupNode = new NodeFolder(subgroupName);
                            Debug.Assert(groupNode != null, "groupNode != null");
                            groupNode.Nodes.Insert(subgroupPosition, subgroupNode);
                            ++subgroupPosition;
                        }
                        Debug.Assert(subgroupNode != null, "subgroupNode != null");
                        subgroupNode.Nodes.Add(newNode);
                    }
                    else
                    {
                        Debug.Assert(groupNode != null, "groupNode != null");
                        groupNode.Nodes.Add(newNode);
                    }
                }
                else
                {
                    Debug.Assert(groupNode != null, "groupNode != null");
                    groupNode.Nodes.Add(newNode);
                }
            }
        }

        private void PopulatePlainTablesOrViews(IEnumerable<string> names, TreeNode parent, MakeTableOrTreeNode nodeMaker)
        {
            foreach (string name in names)
            {
                NodeTableViewBase newNode = nodeMaker(name);
                parent.Nodes.Add(newNode);
            }            
        }

        public void CopyDropTablesScript()
        {
            string dropTablesScript = MakeDropTablesScriptButWarnIfEmpty();
            if (!string.IsNullOrEmpty(dropTablesScript))
            {
                Clipboard.SetText(dropTablesScript);
            }
        }

        public void PasteDropTablesScript()
        {
            string dropTablesScript = MakeDropTablesScriptButWarnIfEmpty();
            if (!string.IsNullOrEmpty(dropTablesScript))
            {
                StatementManager.Instance.InsertIntoSqlStatement(dropTablesScript);
            }
        }

        private string MakeDropTablesScriptButWarnIfEmpty()
        {
            if (0 >= _databaseHelpTables.Nodes.Count)
            {
                MessageBox.Show(SqlCommon.SqlForm, "Ingen hjelpetabeller funnet.", Global.FullTitle, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
            StringBuilder sb = new StringBuilder();
            foreach (TreeNode node in _databaseHelpTables.Nodes)
            {
                sb.Append("DROP TABLE ");
                sb.Append(node.Text);
                sb.AppendLine(";");
            }
            return sb.ToString();
        }
    }
}
