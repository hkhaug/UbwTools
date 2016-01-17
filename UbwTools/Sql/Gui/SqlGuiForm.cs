using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using UbwTools.Common;
using UbwTools.Common.Gui;
using UbwTools.Common.Storage;
using UbwTools.Properties;

namespace UbwTools.Sql.Gui
{
    public partial class SqlGuiForm : FormBase
    {
        #region Private members

        private readonly string _requestedConnectionName;
        private bool _statementWasEmpty;
        private bool _anythingWasSelected;
        private bool _clipboardHadContent;
        private bool _rightDrag;
        private Control _lastFocusedControl;

        #endregion Private members

        #region Public constants

        public const int IconFavorites = 0;
        public const int IconDisconnected = 1;
        public const int IconConnected = 2;
        public const int IconFolderClosed = 3;
        public const int IconFolderOpen = 4;
        public const int IconGrid = 5;
        public const int IconView = 6;
        public const int IconSql = 7;
        public const int IconError = 8;
        public const int IconScript = 9;

        #endregion Public constants

        public SqlGuiForm(string requestedConnectionName)
        {
            InitializeComponent();
            _requestedConnectionName = requestedConnectionName;
            Icon = Resources.Database;
            images.Images.Add(Resources.Favorites016);
            images.Images.Add(Resources.DatabaseDisconnect016);
            images.Images.Add(Resources.Database016);
            images.Images.Add(Resources.FolderClosed016);
            images.Images.Add(Resources.FolderOpen016);
            images.Images.Add(Resources.Grid016);
            images.Images.Add(Resources.View016);
            images.Images.Add(Resources.SQL016);
            images.Images.Add(Resources.Error016);
            images.Images.Add(Resources.Script016);
            RestoreWindowInfo();
            _statementWasEmpty = !StatementPresent();
            SqlCommon.SqlForm = this;
            SqlCommon.Status.Set(null);
            SqlCommon.Favorites.PrepareFavoritesPane();
            SqlCommon.DatabaseContent.PrepareDatabasePane();
            AddClipboardFormatListener(this.Handle);
        }

        #region Event handlers

        #region Multiple controls

        public void control_Enter(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (null != dgv)
            {
                _lastFocusedControl = dgv;
                dgv.BackgroundColor = SqlCommon.Settings.CurrentControlColor;
                splitRightHorizontal.Panel2.BackColor = Color.White;
            }
            else
            {
                TabPage tab = sender as TabPage;
                if (null != tab)
                {
                    _lastFocusedControl = tab;
                    splitRightHorizontal.Panel2.BackColor = SqlCommon.Settings.CurrentControlColor;
                }
                else
                {
                    Control ctrl = sender as Control;
                    if (null != ctrl)
                    {
                        _lastFocusedControl = ctrl;
                        ctrl.BackColor = SqlCommon.Settings.CurrentControlColor;
                    }
                }
            }
        }

        public void control_Leave(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (null != dgv)
            {
                dgv.BackgroundColor = Color.White;
                splitRightHorizontal.Panel2.BackColor = SqlCommon.Settings.CurrentControlColor;
            }
            else
            {
                TabPage tab = sender as TabPage;
                if (null != tab)
                {
                    splitRightHorizontal.Panel2.BackColor = Color.White;
                }
                else
                {
                    Control ctrl = sender as Control;
                    if (null != ctrl)
                    {
                        ctrl.BackColor = Color.White;
                    }
                }
            }
        }

        private void SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (null != _lastFocusedControl)
            {
                _lastFocusedControl.Focus();
            }
        }

        #endregion Multiple controls

        #region Form

        private void SqlGuiForm_Load(object sender, EventArgs e)
        {
            Text = Global.FullTitle;
            SqlCommon.Connections.CheckForConnectRequest(_requestedConnectionName);
            SqlCommon.Statements.SetEntireSqlStatement(Repository.Sql.Data.Statements);
            SqlCommon.Favorites.Load();
            textBoxSql.Focus();
            this.Activate();
        }

        private void SqlGuiForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (new WaitingCursor())
            {
                RemoveClipboardFormatListener(this.Handle);
                SqlCommon.Favorites.Save();
                Repository.Sql.Data.Statements = SqlCommon.Statements.GetEntireSqlStatement();
                SaveWindowInfo();
            }
        }

        #endregion Form

        #region Menu

        #region File

        private void menuFile_DropDownOpening(object sender, EventArgs e)
        {
            bool hasStatement = StatementPresent();
            menuFileSave.Enabled = hasStatement;
            menuFileSaveAs.Enabled = hasStatement;
        }

        private void menuFileOpen_Click(object sender, EventArgs e)
        {
            SqlCommon.Files.FileOpen();
        }

        private void menuFileSave_Click(object sender, EventArgs e)
        {
            SqlCommon.Files.FileSave();
        }

        private void menuFileSaveAs_Click(object sender, EventArgs e)
        {
            SqlCommon.Files.FileSaveAs();
        }

        private void menuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion File

        #region Edit

        private void menuEdit_DropDownOpening(object sender, EventArgs e)
        {
            if (textBoxSql.Focused)
            {
                bool canUndo = textBoxSql.CanUndo;
                bool hasStatement = StatementPresent();
                bool anythingSelected = AnythingSelected();
                bool anythingOnClipboard = AnythingOnClipboard();
                menuEditUndo.Enabled = canUndo;
                menuEditCut.Enabled = anythingSelected;
                menuEditCopy.Enabled = anythingSelected;
                menuEditPaste.Enabled = anythingOnClipboard;
                menuEditDelete.Enabled = anythingSelected;
                menuEditSelectAll.Enabled = hasStatement;
            }
            else
            {
                menuEditUndo.Enabled = false;
                menuEditCut.Enabled = false;
                menuEditCopy.Enabled = false;
                menuEditPaste.Enabled = false;
                menuEditDelete.Enabled = false;
                menuEditSelectAll.Enabled = false;
            }
        }

        private void menuEditUndo_Click(object sender, EventArgs e)
        {
            SqlCommon.Statements.EditUndo();
        }

        private void menuEditCut_Click(object sender, EventArgs e)
        {
            SqlCommon.Statements.EditCut();
        }

        private void menuEditCopy_Click(object sender, EventArgs e)
        {
            SqlCommon.Statements.EditCopy();
        }

        private void menuEditPaste_Click(object sender, EventArgs e)
        {
            SqlCommon.Statements.EditPaste();
        }

        private void menuEditDelete_Click(object sender, EventArgs e)
        {
            SqlCommon.Statements.EditDelete();
        }

        private void menuEditSelectAll_Click(object sender, EventArgs e)
        {
            SqlCommon.Statements.EditSelectAll();
        }

        #endregion Edit

        #region Database

        private void menuDatabase_DropDownOpening(object sender, EventArgs e)
        {
            bool anyRecentConnections = HasRecentConnections();
            bool connected = IsCurrentlyConnected();
            menuDatabaseReconnect.Enabled = !connected && anyRecentConnections;
            menuDatabaseConnectAppStart.Enabled = (!connected) && Global.IsUnit4Domain;
            menuDatabaseConfigureAndConnect.Enabled = !connected;
            menuDatabaseDisconnect.Enabled = connected;
        }

        private void menuDatabaseReconnect_Click(object sender, EventArgs e)
        {
            SqlCommon.Connections.HandleReconnect();
        }

        private void menuDatabaseConfigureAndConnect_Click(object sender, EventArgs e)
        {
            SqlCommon.Connections.HandleFirstTimeConnect(null);
        }

        private void menuDatabaseDisconnect_Click(object sender, EventArgs e)
        {
            SqlCommon.Connections.HandleDisconnect();
        }

        private void menuDatabaseConnectAppStart_Click(object sender, EventArgs e)
        {
            SqlCommon.Connections.HandleAppStartConnect();
        }

        #endregion Database

        #region Query

        private void menuQuery_DropDownOpening(object sender, EventArgs e)
        {
            bool connected = IsCurrentlyConnected();
            bool hasStatement = StatementPresent();
            menuQueryExecute.Enabled = connected && hasStatement;
            menuQueryFormat.Enabled = hasStatement;
        }

        private void menuQueryExecute_Click(object sender, EventArgs e)
        {
            SqlCommon.Executor.ExecuteSqlStatements();
        }

        private void menuQueryFormat_Click(object sender, EventArgs e)
        {
            SqlCommon.Statements.FormatStatement();
        }

        private void menuQueryEditorShortcuts_Click(object sender, EventArgs e)
        {
            SqlShortcutsForm form = new SqlShortcutsForm();
            form.ShowDialog(this);
        }

        private void menuF5_Click(object sender, EventArgs e)
        {
            if (IsCurrentlyConnected() && StatementPresent())
            {
                SqlCommon.Executor.ExecuteSqlStatements();
            }
        }

        #endregion Query

        #region Window

        private void menuWindow_DropDownOpening(object sender, EventArgs e)
        {
            menuWindowNewSame.Enabled = IsCurrentlyConnected();
        }

        private void menuWindowNewSame_Click(object sender, EventArgs e)
        {
            LaunchManager.Instance.LaunchDatabase(ConnectionManager.CurrentConnection.Name);
        }

        private void menuWindowNewAnother_Click(object sender, EventArgs e)
        {
            LaunchManager.Instance.LaunchDatabase();
        }

        private void menuWindowBflagCalc_Click(object sender, EventArgs e)
        {
            LaunchManager.Instance.LaunchSimpleBflagCalculator();
        }

        private void toolStripButtonWindowAdvancedBflagCalc_Click(object sender, EventArgs e)
        {
            LaunchManager.Instance.LaunchAdvancedBflagCalculator();
        }

        private void menuWindowNorwegianId_Click(object sender, EventArgs e)
        {
            LaunchManager.Instance.LaunchNorwegianIdentityNumbers();
        }

        #endregion Window

        #region Help

        private void menuHelpAbout_Click(object sender, EventArgs e)
        {
            AboutForm form = new AboutForm();
            form.ShowDialog(this);
        }

        private void menuHelpUsersGuide_Click(object sender, EventArgs e)
        {
            Util.OpenDocument(this, "UBW Tools - Brukermanual.pdf");
        }

        #endregion Help

        #endregion Menu

        #region Toolbar

        private void tools_Paint(object sender, PaintEventArgs e)
        {
            bool canUndo = textBoxSql.CanUndo;
            bool anyRecentConnections = HasRecentConnections();
            bool connected = IsCurrentlyConnected();
            bool hasStatement = StatementPresent();
            bool anythingSelected = AnythingSelected();
            bool anythingOnClipboard = AnythingOnClipboard();
            toolStripButtonFileSave.Enabled = hasStatement;
            toolStripButtonEditUndo.Enabled = canUndo;
            toolStripButtonEditCut.Enabled = anythingSelected;
            toolStripButtonEditCopy.Enabled = anythingSelected;
            toolStripButtonEditPaste.Enabled = anythingOnClipboard;
            toolStripButtonEditDelete.Enabled = anythingSelected;
            toolStripButtonDatabaseReconnect.Enabled = !connected && anyRecentConnections;
            toolStripButtonDatabaseConnectAppStart.Enabled = (!connected) && Global.IsUnit4Domain;
            toolStripButtonDatabaseConfigureAndConnect.Enabled = !connected;
            toolStripButtonDatabaseDisconnect.Enabled = connected;
            toolStripButtonSqlExecute.Enabled = connected && hasStatement;
            toolStripButtonSqlFormat.Enabled = hasStatement;
            toolStripButtonWindowNewSame.Enabled = connected;
        }

        #endregion Toolbar

        #region Context menus

        #region Database and Favorites trees

        private void contextFavoriteTable_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool connected = IsCurrentlyConnected();
            contextFavoriteTableExecuteSelect.Enabled = connected;
            contextFavoriteTableExecuteCount.Enabled = connected;
            contextFavoriteTableCopyToClipboardColumnList.Enabled = connected;
            contextFavoriteTableCopyToClipboardCreateNative.Enabled = connected;
            contextFavoriteTableCopyToClipboardCreateAsql.Enabled = connected;
            contextFavoriteTablePasteToEditColumnList.Enabled = connected;
            contextFavoriteTablePasteToEditCreateNative.Enabled = connected;
            contextFavoriteTablePasteToEditCreateAsql.Enabled = connected;
        }

        private void contextFavoriteView_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool connected = IsCurrentlyConnected();
            contextFavoriteViewExecuteSelect.Enabled = connected;
            contextFavoriteViewExecuteCount.Enabled = connected;
            contextFavoriteViewCopyToClipboardColumnList.Enabled = connected;
            contextFavoriteViewCopyToClipboardCreateNative.Enabled = connected;
            contextFavoriteViewCopyToClipboardCreateAsql.Enabled = connected;
            contextFavoriteViewPasteToEditColumnList.Enabled = connected;
            contextFavoriteViewPasteToEditCreateNative.Enabled = connected;
            contextFavoriteViewPasteToEditCreateAsql.Enabled = connected;
        }

        private void contextFavoriteViewCopyToClipboard_DropDownOpening(object sender, EventArgs e)
        {
            contextFavoriteViewCopyToClipboardCreateAsql.Enabled = IsCurrentlyConnected() && ConnectionManager.CurrentConnection.IsUbwDatabase;
        }

        private void contextFavoriteViewPasteToEdit_DropDownOpening(object sender, EventArgs e)
        {
            contextFavoriteViewPasteToEditCreateAsql.Enabled = IsCurrentlyConnected() && ConnectionManager.CurrentConnection.IsUbwDatabase;
        }

        private void contextDatabaseViewCopyToClipboard_DropDownOpening(object sender, EventArgs e)
        {
            contextDatabaseViewCopyToClipboardCreateAsql.Enabled = ConnectionManager.CurrentConnection.IsUbwDatabase;
        }

        private void contextDatabaseViewPasteToEdit_DropDownOpening(object sender, EventArgs e)
        {
            contextDatabaseViewPasteToEditCreateAsql.Enabled = ConnectionManager.CurrentConnection.IsUbwDatabase;
        }

        private void ContextTreeCopySelect_Click(object sender, EventArgs e)
        {
            NodeTableViewBase node = SelectedNodeFromTree();
            if (null != node)
            {
                node.Select(false);
            }
        }

        private void ContextTreeExecuteSelect_Click(object sender, EventArgs e)
        {
            NodeTableViewBase node = SelectedNodeFromTree();
            if (null != node)
            {
                node.Select(true);
            }
        }

        private void ContextTreeExecuteCount_Click(object sender, EventArgs e)
        {
            NodeTableViewBase node = SelectedNodeFromTree();
            if (null != node)
            {
                node.Count();
            }
        }

        private void ContextTreeCopyToClipboardName_Click(object sender, EventArgs e)
        {
            NodeTableViewBase node = SelectedNodeFromTree();
            if (null != node)
            {
                node.CopyName();
            }
        }

        private void ContextTreeCopyToClipboardColumnList_Click(object sender, EventArgs e)
        {
            NodeTableViewBase node = SelectedNodeFromTree();
            if (null != node)
            {
                node.CopyColumnList(ConnectionManager.CurrentConnection);
            }
        }

        private void ContextTreeCopyToClipboardCreateNative_Click(object sender, EventArgs e)
        {
            NodeTableViewBase node = SelectedNodeFromTree();
            if (null != node)
            {
                node.CopyCreateNative(ConnectionManager.CurrentConnection);
            }
        }

        private void ContextTreeCopyToClipboardCreateAsql_Click(object sender, EventArgs e)
        {
            NodeTableViewBase node = SelectedNodeFromTree();
            if (null != node)
            {
                node.CopyCreateAsql(ConnectionManager.CurrentConnection);
            }
        }

        private void ContextTreePasteToEditName_Click(object sender, EventArgs e)
        {
            NodeTableViewBase node = SelectedNodeFromTree();
            if (null != node)
            {
                node.PasteName();
            }
        }

        private void ContextTreePasteToEditColumnList_Click(object sender, EventArgs e)
        {
            NodeTableViewBase node = SelectedNodeFromTree();
            if (null != node)
            {
                node.PasteColumnList(ConnectionManager.CurrentConnection);
            }
        }

        private void ContextTreePasteToEditCreateNative_Click(object sender, EventArgs e)
        {
            NodeTableViewBase node = SelectedNodeFromTree();
            if (null != node)
            {
                node.PasteCreateNative(ConnectionManager.CurrentConnection);
            }
        }

        private void ContextTreePasteToEditCreateAsql_Click(object sender, EventArgs e)
        {
            NodeTableViewBase node = SelectedNodeFromTree();
            if (null != node)
            {
                node.PasteCreateAsql(ConnectionManager.CurrentConnection);
            }
        }

        private void contextFavoriteTableRemove_Click(object sender, EventArgs e)
        {
            NodeFavoriteTable node = treeFavorites.SelectedNode as NodeFavoriteTable;
            if (null != node)
            {
                SqlCommon.Favorites.RemoveFavoriteTable(node);
            }
        }

        private void contextFavoriteViewRemove_Click(object sender, EventArgs e)
        {
            NodeFavoriteView node = treeFavorites.SelectedNode as NodeFavoriteView;
            if (null != node)
            {
                SqlCommon.Favorites.RemoveFavoriteView(node);
            }
        }

        private void contextDatabaseTableAddToFavorites_Click(object sender, EventArgs e)
        {
            NodeDatabaseTable node = treeDatabase.SelectedNode as NodeDatabaseTable;
            if (null != node)
            {
                SqlCommon.Favorites.AddFavoriteTable(node.Text);
            }
        }

        private void contextDatabaseViewAddToFavorites_Click(object sender, EventArgs e)
        {
            NodeDatabaseView node = treeDatabase.SelectedNode as NodeDatabaseView;
            if (null != node)
            {
                SqlCommon.Favorites.AddFavoriteView(node.Text);
            }
        }

        private NodeTableViewBase SelectedNodeFromTree()
        {
            TreeView tree = _lastFocusedControl as TreeView;
            return null == tree ? null : tree.SelectedNode as NodeTableViewBase;
        }

        #endregion Database and Favorites trees

        #region SQL edit area context menu

        private void contextSql_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool canUndo = textBoxSql.CanUndo;
            bool anythingSelected = AnythingSelected();
            bool anythingOnClipboard = AnythingOnClipboard();
            bool connected = IsCurrentlyConnected();
            bool hasStatement = StatementPresent();
            contextSqlUndo.Enabled = canUndo;
            contextSqlCut.Enabled = anythingSelected;
            contextSqlCopy.Enabled = anythingSelected;
            contextSqlPaste.Enabled = anythingOnClipboard;
            contextSqlSelectAll.Enabled = hasStatement;
            contextSqlDelete.Enabled = anythingSelected;
            contextSqlExecute.Enabled = connected && hasStatement;
            contextSqlFormat.Enabled = hasStatement;
        }

        #endregion SQL edit area context menu

        #endregion Context menus

        #region Trees

        private void tree_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            if (0 == e.Node.Level)
            {
                e.Cancel = true;
            }
        }

        private void tree_KeyUp(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                e.Handled = true;
                TreeView tree = sender as TreeView;
                if (null != tree)
                {
                    NodeTableViewBase node = tree.SelectedNode as NodeTableViewBase;
                    if (null != node)
                    {
                        switch (e.Modifiers)
                        {
                            case 0:
                                node.DefaultAction(false);
                                break;
                            case Keys.Control:
                                node.DefaultAction(true);
                                   break;
                            case Keys.Shift:
                                   node.Count();
                                   break;
                        }
                    }                    
                }
            }
        }

        #region Favorites tree

        private void treeFavorites_DoubleClick(object sender, EventArgs e)
        {
            NodeTableViewBase node = treeFavorites.SelectedNode as NodeTableViewBase;
            if (null != node)
            {
                node.DefaultAction(ModifierKeys == Keys.Control);
            }
        }

        private void treeFavorites_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Item is NodeTableViewBase)
            {
                _rightDrag = (e.Button == MouseButtons.Right);
                DoDragDrop(e.Item, DragDropEffects.Copy);
            }
        }

        private void treeFavorites_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void treeFavorites_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(NodeDatabaseTable)))
            {
                NodeDatabaseTable sourceTable = e.Data.GetData(typeof(NodeDatabaseTable)) as NodeDatabaseTable;
                if (null != sourceTable)
                {
                    FavoritesManager.Instance.AddFavoriteTable(sourceTable.Text);
                }
            }
            else if (e.Data.GetDataPresent(typeof(NodeDatabaseView)))
            {
                NodeDatabaseView sourceView = e.Data.GetData(typeof(NodeDatabaseView)) as NodeDatabaseView;
                if (null != sourceView)
                {
                    FavoritesManager.Instance.AddFavoriteView(sourceView.Text);
                }
            }
        }

        #endregion Favorites tree

        #region Database tree

        private void treeDatabase_DoubleClick(object sender, EventArgs e)
        {
            NodeTableViewBase node = treeDatabase.SelectedNode as NodeTableViewBase;
            if (null != node)
            {
                node.DefaultAction(ModifierKeys == Keys.Control);
            }
        }

        private void treeDatabase_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Item is NodeTableViewBase)
            {
                _rightDrag = (e.Button == MouseButtons.Right);
                DoDragDrop(e.Item, DragDropEffects.Copy);
            }
        }

        #endregion Database tree

        #endregion Trees

        #region Statement entry

        private void textBoxSql_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.Control && (e.KeyCode >= Keys.A) && (e.KeyCode <= Keys.Z))
            {
                e.SuppressKeyPress = true;
            }
            CheckIfSelectionChanged();
        }

        private void textBoxSql_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.Control && (e.KeyCode >= Keys.A) && (e.KeyCode <= Keys.Z))
            {
                int shiftOrNot = e.Shift ? 1 : 0;
                e.Handled = true;
                int index = e.KeyCode - Keys.A;
                string paste = SqlCommon.Settings.SqlShortcuts[shiftOrNot, index];
                if (!string.IsNullOrWhiteSpace(paste))
                {
                    textBoxSql.Paste(paste);
                }
            }
            CheckIfSelectionChanged();
        }

        private void textBoxSql_TextChanged(object sender, EventArgs e)
        {
            bool isEmpty = !StatementPresent();
            if (isEmpty != _statementWasEmpty)
            {
                _statementWasEmpty = isEmpty;
                tools.Invalidate();
            }
        }

        private void textBoxSql_MouseDown(object sender, MouseEventArgs e)
        {
            CheckIfSelectionChanged();
        }

        private void textBoxSql_MouseUp(object sender, MouseEventArgs e)
        {
            CheckIfSelectionChanged();
        }

        private void textBoxSql_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void textBoxSql_DragDrop(object sender, DragEventArgs e)
        {
            NodeTableViewBase node = null;
            if (e.Data.GetDataPresent(typeof (NodeFavoriteTable)))
            {
                node = e.Data.GetData(typeof (NodeFavoriteTable)) as NodeTableViewBase;
            }
            else if (e.Data.GetDataPresent(typeof (NodeFavoriteView)))
            {
                node = e.Data.GetData(typeof (NodeFavoriteView)) as NodeTableViewBase;
            }
            else if (e.Data.GetDataPresent(typeof (NodeDatabaseTable)))
            {
                node = e.Data.GetData(typeof (NodeDatabaseTable)) as NodeTableViewBase;
            }
            else if (e.Data.GetDataPresent(typeof (NodeDatabaseView)))
            {
                node = e.Data.GetData(typeof (NodeDatabaseView)) as NodeTableViewBase;
            }
            if (null != node)
            {
                StatementManager.Instance.Drop(node, _rightDrag, e.X, e.Y);
            }
        }

        #region Right-drop menu

        private void contextRightDrag_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool connected = IsCurrentlyConnected();
            contextRightDragPasteColumnList.Enabled = connected;
            contextRightDragPasteCreateNative.Enabled = connected;
            if (connected)
            {
                NodeTableViewBase node = OriginatingNode(sender as ToolStrip);
                contextRightDragPasteCreateAsql.Enabled = !node.IsView || ConnectionManager.CurrentConnection.IsUbwDatabase;
            }
            else
            {
                contextRightDragPasteCreateAsql.Enabled = false;
            }
        }

        private void contextRightDragPasteName_Click(object sender, EventArgs e)
        {
            NodeTableViewBase node = OriginatingNode(sender as ToolStripItem);
            if (null != node)
            {
                node.PasteName();
            }
        }

        private void contextRightDragPasteColumnList_Click(object sender, EventArgs e)
        {
            NodeTableViewBase node = OriginatingNode(sender as ToolStripItem);
            if (null != node)
            {
                node.PasteColumnList(ConnectionManager.CurrentConnection);
            }
        }

        private void contextRightDragPasteCreateNative_Click(object sender, EventArgs e)
        {
            NodeTableViewBase node = OriginatingNode(sender as ToolStripItem);
            if (null != node)
            {
                node.PasteCreateNative(ConnectionManager.CurrentConnection);
            }
        }

        private void contextRightDragPasteCreateAsql_Click(object sender, EventArgs e)
        {
            NodeTableViewBase node = OriginatingNode(sender as ToolStripItem);
            if (null != node)
            {
                node.PasteCreateAsql(ConnectionManager.CurrentConnection);
            }
        }

        private NodeTableViewBase OriginatingNode(ToolStripItem menuItem)
        {
            return null != menuItem ? OriginatingNode(menuItem.Owner) : null;
        }

        private NodeTableViewBase OriginatingNode(ToolStrip menuItemGroup)
        {
            if (null != menuItemGroup)
            {
                return menuItemGroup.Tag as NodeTableViewBase;
            }
            return null;
        }

        #endregion Right-drop menu

        #endregion Statement entry

        #endregion Event handlers

        #region Status

        private bool HasRecentConnections()
        {
            return !SqlCommon.History.IsEmpty;
        }

        private bool IsCurrentlyConnected()
        {
            return ConnectionManager.CurrentConnection != null;
        }

        private bool StatementPresent()
        {
            return !string.IsNullOrWhiteSpace(textBoxSql.Text);
        }

        private bool AnythingSelected()
        {
            return (textBoxSql.SelectionLength > 0);
        }

        private bool AnythingOnClipboard()
        {
            return Clipboard.ContainsText();
        }

        private void CheckIfSelectionChanged()
        {
            bool anythingSelectedNow = AnythingSelected();
            if (anythingSelectedNow != _anythingWasSelected)
            {
                _anythingWasSelected = anythingSelectedNow;
                tools.Invalidate();
            }
        }

        #endregion Status

        #region Preparation

        protected override string GetFormData()
        {
            List<int> splitterPositions = new List<int>
            {
                GetSplitterPosition(splitVertical),
                GetSplitterPosition(splitLeftHorizontal),
                GetSplitterPosition(splitRightHorizontal)
            };
            return Util.IntListToString(splitterPositions);
        }

        private int GetSplitterPosition(SplitContainer splitContainer)
        {
            return ((splitContainer.Height * 1000) / splitContainer.SplitterDistance);
        }

        protected override void SetFormData(string data)
        {
            IList<int> splitterPositions = Util.StringToIntList(data).ToList();
            if (3 == splitterPositions.Count)
            {
                SetSplitterPosition(splitVertical, splitterPositions[0]);
                SetSplitterPosition(splitLeftHorizontal, splitterPositions[1]);
                SetSplitterPosition(splitRightHorizontal, splitterPositions[2]);
            }
        }

        private void SetSplitterPosition(SplitContainer splitContainer, int splitterPosition)
        {
            splitContainer.SplitterDistance = (splitContainer.Height * 1000) / splitterPosition;
        }

        #endregion Preparation

        #region Clipboard support

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AddClipboardFormatListener(IntPtr hwnd);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool RemoveClipboardFormatListener(IntPtr hwnd);

        protected override void WndProc(ref Message m)
        {
// ReSharper disable once InconsistentNaming
            const int WM_CLIPBOARDUPDATE = 0x031D;

            base.WndProc(ref m);

            if (m.Msg == WM_CLIPBOARDUPDATE)
            {
                bool clipboardHasContentNow = Clipboard.ContainsText();
                if (clipboardHasContentNow != _clipboardHadContent)
                {
                    _clipboardHadContent = clipboardHasContentNow;
                    tools.Invalidate();
                }
            }
        }

        #endregion Clipboard support

        private void copyDROPTABLESScriptToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatabaseContentManager.Instance.CopyDropTablesScript();
        }

        private void pasteDROPTABLESScriptToEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatabaseContentManager.Instance.PasteDropTablesScript();
        }
    }
}
