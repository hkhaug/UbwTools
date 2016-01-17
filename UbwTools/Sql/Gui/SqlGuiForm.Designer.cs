namespace UbwTools.Sql.Gui
{
    partial class SqlGuiForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SqlGuiForm));
            this.statusNoConnection = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusEngine = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusDataSource = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusDatabase = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusUbw = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusName = new System.Windows.Forms.ToolStripStatusLabel();
            this.status = new System.Windows.Forms.StatusStrip();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEditUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEditSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuEditCut = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEditCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEditPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEditDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEditSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuEditSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDatabaseReconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDatabaseConfigureAndConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDatabaseConnectAppStart = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDatabaseDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQueryExecute = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQueryFormat = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuerySeparator = new System.Windows.Forms.ToolStripSeparator();
            this.menuQueryEditorShortcuts = new System.Windows.Forms.ToolStripMenuItem();
            this.menuF5 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWindowNewSame = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWindowNewAnother = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWindowSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.menuWindowBflagCalc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWindowNorwegianId = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelpUsersGuide = new System.Windows.Forms.ToolStripMenuItem();
            this.tools = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonFileOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFileSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonEditUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEditCut = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEditCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEditPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEditDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonDatabaseReconnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDatabaseConfigureAndConnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDatabaseConnectAppStart = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDatabaseDisconnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSqlExecute = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSqlFormat = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonWindowNewSame = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonWindowNewOther = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonWindowBflagCalc = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonWindowNorwegianId = new System.Windows.Forms.ToolStripButton();
            this.splitVertical = new System.Windows.Forms.SplitContainer();
            this.splitLeftHorizontal = new System.Windows.Forms.SplitContainer();
            this.treeFavorites = new System.Windows.Forms.TreeView();
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.treeDatabase = new System.Windows.Forms.TreeView();
            this.splitRightHorizontal = new System.Windows.Forms.SplitContainer();
            this.textBoxSql = new System.Windows.Forms.TextBox();
            this.contextSql = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextSqlUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.contextSqlSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextSqlCut = new System.Windows.Forms.ToolStripMenuItem();
            this.contextSqlCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.contextSqlPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.contextSqlDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.contextSqlSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.contextSqlSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.contextSqlSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.contextSqlExecute = new System.Windows.Forms.ToolStripMenuItem();
            this.contextSqlFormat = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLEditorShortcutsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabResults = new System.Windows.Forms.TabControl();
            this.contextDatabaseTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextDatabaseTableCopySelect = new System.Windows.Forms.ToolStripMenuItem();
            this.contextDatabaseTableExecuteSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.contextDatabaseTableExecuteCount = new System.Windows.Forms.ToolStripMenuItem();
            this.contextDatabaseTableSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextDatabaseTableCopyToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.contextDatabaseTableCopyToClipboardTableName = new System.Windows.Forms.ToolStripMenuItem();
            this.contextDatabaseTableCopyToClipboardColumnList = new System.Windows.Forms.ToolStripMenuItem();
            this.contextDatabaseTableCopyToClipboardCreateNative = new System.Windows.Forms.ToolStripMenuItem();
            this.contextDatabaseTableCopyToClipboardCreateAsql = new System.Windows.Forms.ToolStripMenuItem();
            this.contextDatabaseTablePasteToEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.contextDatabaseTablePasteToEditTableName = new System.Windows.Forms.ToolStripMenuItem();
            this.contextDatabaseTablePasteToEditColumnList = new System.Windows.Forms.ToolStripMenuItem();
            this.contextDatabaseTablePasteToEditCreateNative = new System.Windows.Forms.ToolStripMenuItem();
            this.contextDatabaseTablePasteToEditCreateAsql = new System.Windows.Forms.ToolStripMenuItem();
            this.contextDatabaseTableSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.contextDatabaseTableAddToFavorites = new System.Windows.Forms.ToolStripMenuItem();
            this.contextDatabaseView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextDatabaseViewCopySelect = new System.Windows.Forms.ToolStripMenuItem();
            this.contextDatabaseViewExecuteSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.contextDatabaseViewExecuteCount = new System.Windows.Forms.ToolStripMenuItem();
            this.contextDatabaseViewSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextDatabaseViewCopyToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.contextDatabaseViewCopyToClipboardViewName = new System.Windows.Forms.ToolStripMenuItem();
            this.contextDatabaseViewCopyToClipboardColumnList = new System.Windows.Forms.ToolStripMenuItem();
            this.contextDatabaseViewCopyToClipboardCreateNative = new System.Windows.Forms.ToolStripMenuItem();
            this.contextDatabaseViewCopyToClipboardCreateAsql = new System.Windows.Forms.ToolStripMenuItem();
            this.contextDatabaseViewPasteToEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.contextDatabaseViewPasteToEditViewName = new System.Windows.Forms.ToolStripMenuItem();
            this.contextDatabaseViewPasteToEditColumnList = new System.Windows.Forms.ToolStripMenuItem();
            this.contextDatabaseViewPasteToEditCreateNative = new System.Windows.Forms.ToolStripMenuItem();
            this.contextDatabaseViewPasteToEditCreateAsql = new System.Windows.Forms.ToolStripMenuItem();
            this.contextDatabaseViewSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.contextDatabaseViewAddToFavorites = new System.Windows.Forms.ToolStripMenuItem();
            this.contextFavoriteTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextFavoriteTableCopySelect = new System.Windows.Forms.ToolStripMenuItem();
            this.contextFavoriteTableExecuteSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.contextFavoriteTableExecuteCount = new System.Windows.Forms.ToolStripMenuItem();
            this.contextFavoriteTableSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextFavoriteTableCopyToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.contextFavoriteTableCopyToClipboardTableName = new System.Windows.Forms.ToolStripMenuItem();
            this.contextFavoriteTableCopyToClipboardColumnList = new System.Windows.Forms.ToolStripMenuItem();
            this.contextFavoriteTableCopyToClipboardCreateNative = new System.Windows.Forms.ToolStripMenuItem();
            this.contextFavoriteTableCopyToClipboardCreateAsql = new System.Windows.Forms.ToolStripMenuItem();
            this.contextFavoriteTablePasteToEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.contextFavoriteTablePasteToEditTableName = new System.Windows.Forms.ToolStripMenuItem();
            this.contextFavoriteTablePasteToEditColumnList = new System.Windows.Forms.ToolStripMenuItem();
            this.contextFavoriteTablePasteToEditCreateNative = new System.Windows.Forms.ToolStripMenuItem();
            this.contextFavoriteTablePasteToEditCreateAsql = new System.Windows.Forms.ToolStripMenuItem();
            this.contextFavoriteTableSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.contextFavoriteTableRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.contextFavoriteView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextFavoriteViewCopySelect = new System.Windows.Forms.ToolStripMenuItem();
            this.contextFavoriteViewExecuteSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.contextFavoriteViewExecuteCount = new System.Windows.Forms.ToolStripMenuItem();
            this.contextFavoriteViewSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextFavoriteViewCopyToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.contextFavoriteViewCopyToClipboardViewName = new System.Windows.Forms.ToolStripMenuItem();
            this.contextFavoriteViewCopyToClipboardColumnList = new System.Windows.Forms.ToolStripMenuItem();
            this.contextFavoriteViewCopyToClipboardCreateNative = new System.Windows.Forms.ToolStripMenuItem();
            this.contextFavoriteViewCopyToClipboardCreateAsql = new System.Windows.Forms.ToolStripMenuItem();
            this.contextFavoriteViewPasteToEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.contextFavoriteViewPasteToEditViewName = new System.Windows.Forms.ToolStripMenuItem();
            this.contextFavoriteViewPasteToEditColumnList = new System.Windows.Forms.ToolStripMenuItem();
            this.contextFavoriteViewPasteToEditCreateNative = new System.Windows.Forms.ToolStripMenuItem();
            this.contextFavoriteViewPasteToEditCreateAsql = new System.Windows.Forms.ToolStripMenuItem();
            this.contextFavoriteViewSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.contextFavoriteViewRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.contextRightDrag = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextRightDragPasteName = new System.Windows.Forms.ToolStripMenuItem();
            this.contextRightDragPasteColumnList = new System.Windows.Forms.ToolStripMenuItem();
            this.contextRightDragPasteCreateNative = new System.Windows.Forms.ToolStripMenuItem();
            this.contextRightDragPasteCreateAsql = new System.Windows.Forms.ToolStripMenuItem();
            this.contextHelpTables = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyDROPTABLESScriptToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteDROPTABLESScriptToEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonWindowAdvancedBflagCalc = new System.Windows.Forms.ToolStripButton();
            this.status.SuspendLayout();
            this.menu.SuspendLayout();
            this.tools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitVertical)).BeginInit();
            this.splitVertical.Panel1.SuspendLayout();
            this.splitVertical.Panel2.SuspendLayout();
            this.splitVertical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitLeftHorizontal)).BeginInit();
            this.splitLeftHorizontal.Panel1.SuspendLayout();
            this.splitLeftHorizontal.Panel2.SuspendLayout();
            this.splitLeftHorizontal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitRightHorizontal)).BeginInit();
            this.splitRightHorizontal.Panel1.SuspendLayout();
            this.splitRightHorizontal.Panel2.SuspendLayout();
            this.splitRightHorizontal.SuspendLayout();
            this.contextSql.SuspendLayout();
            this.contextDatabaseTable.SuspendLayout();
            this.contextDatabaseView.SuspendLayout();
            this.contextFavoriteTable.SuspendLayout();
            this.contextFavoriteView.SuspendLayout();
            this.contextRightDrag.SuspendLayout();
            this.contextHelpTables.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusNoConnection
            // 
            this.statusNoConnection.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.statusNoConnection.Image = global::UbwTools.Properties.Resources.DatabaseDisconnect016;
            this.statusNoConnection.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.statusNoConnection.Name = "statusNoConnection";
            this.statusNoConnection.Size = new System.Drawing.Size(20, 20);
            // 
            // statusEngine
            // 
            this.statusEngine.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.statusEngine.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.statusEngine.Name = "statusEngine";
            this.statusEngine.Size = new System.Drawing.Size(4, 20);
            this.statusEngine.Visible = false;
            // 
            // statusDataSource
            // 
            this.statusDataSource.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.statusDataSource.Image = ((System.Drawing.Image)(resources.GetObject("statusDataSource.Image")));
            this.statusDataSource.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.statusDataSource.Name = "statusDataSource";
            this.statusDataSource.Size = new System.Drawing.Size(20, 20);
            this.statusDataSource.Visible = false;
            // 
            // statusDatabase
            // 
            this.statusDatabase.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.statusDatabase.Image = global::UbwTools.Properties.Resources.Database016;
            this.statusDatabase.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.statusDatabase.Name = "statusDatabase";
            this.statusDatabase.Size = new System.Drawing.Size(20, 20);
            this.statusDatabase.Visible = false;
            // 
            // statusUbw
            // 
            this.statusUbw.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.statusUbw.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.statusUbw.Name = "statusUbw";
            this.statusUbw.Size = new System.Drawing.Size(4, 20);
            // 
            // statusName
            // 
            this.statusName.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.statusName.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusName.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.statusName.Name = "statusName";
            this.statusName.Size = new System.Drawing.Size(4, 20);
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusNoConnection,
            this.statusEngine,
            this.statusDataSource,
            this.statusDatabase,
            this.statusUbw,
            this.statusName});
            this.status.Location = new System.Drawing.Point(0, 537);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(784, 25);
            this.status.TabIndex = 1;
            this.status.Text = "statusStrip";
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuEdit,
            this.menuDatabase,
            this.menuQuery,
            this.menuF5,
            this.menuWindow,
            this.menuHelp});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(784, 24);
            this.menu.TabIndex = 2;
            this.menu.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileOpen,
            this.menuFileSave,
            this.menuFileSaveAs,
            this.menuFileSeparator,
            this.menuFileExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(31, 20);
            this.menuFile.Text = "&Fil";
            this.menuFile.DropDownOpening += new System.EventHandler(this.menuFile_DropDownOpening);
            // 
            // menuFileOpen
            // 
            this.menuFileOpen.Image = global::UbwTools.Properties.Resources.OpenFile016;
            this.menuFileOpen.Name = "menuFileOpen";
            this.menuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.menuFileOpen.Size = new System.Drawing.Size(153, 22);
            this.menuFileOpen.Text = "&Åpne";
            this.menuFileOpen.Click += new System.EventHandler(this.menuFileOpen_Click);
            // 
            // menuFileSave
            // 
            this.menuFileSave.Image = global::UbwTools.Properties.Resources.SaveFile016;
            this.menuFileSave.Name = "menuFileSave";
            this.menuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuFileSave.Size = new System.Drawing.Size(153, 22);
            this.menuFileSave.Text = "&Lagre";
            this.menuFileSave.Click += new System.EventHandler(this.menuFileSave_Click);
            // 
            // menuFileSaveAs
            // 
            this.menuFileSaveAs.Name = "menuFileSaveAs";
            this.menuFileSaveAs.Size = new System.Drawing.Size(153, 22);
            this.menuFileSaveAs.Text = "Lagre &som";
            this.menuFileSaveAs.Click += new System.EventHandler(this.menuFileSaveAs_Click);
            // 
            // menuFileSeparator
            // 
            this.menuFileSeparator.Name = "menuFileSeparator";
            this.menuFileSeparator.Size = new System.Drawing.Size(150, 6);
            // 
            // menuFileExit
            // 
            this.menuFileExit.Name = "menuFileExit";
            this.menuFileExit.ShortcutKeyDisplayString = "Alt+F4";
            this.menuFileExit.Size = new System.Drawing.Size(153, 22);
            this.menuFileExit.Text = "&Avslutt";
            this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
            // 
            // menuEdit
            // 
            this.menuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEditUndo,
            this.menuEditSeparator1,
            this.menuEditCut,
            this.menuEditCopy,
            this.menuEditPaste,
            this.menuEditDelete,
            this.menuEditSeparator2,
            this.menuEditSelectAll});
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(59, 20);
            this.menuEdit.Text = "&Rediger";
            this.menuEdit.DropDownOpening += new System.EventHandler(this.menuEdit_DropDownOpening);
            // 
            // menuEditUndo
            // 
            this.menuEditUndo.Image = global::UbwTools.Properties.Resources.Undo016;
            this.menuEditUndo.Name = "menuEditUndo";
            this.menuEditUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.menuEditUndo.Size = new System.Drawing.Size(159, 22);
            this.menuEditUndo.Text = "&Angre";
            this.menuEditUndo.Click += new System.EventHandler(this.menuEditUndo_Click);
            // 
            // menuEditSeparator1
            // 
            this.menuEditSeparator1.Name = "menuEditSeparator1";
            this.menuEditSeparator1.Size = new System.Drawing.Size(156, 6);
            // 
            // menuEditCut
            // 
            this.menuEditCut.Image = global::UbwTools.Properties.Resources.Cut016;
            this.menuEditCut.Name = "menuEditCut";
            this.menuEditCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.menuEditCut.Size = new System.Drawing.Size(159, 22);
            this.menuEditCut.Text = "Klipp &ut";
            this.menuEditCut.Click += new System.EventHandler(this.menuEditCut_Click);
            // 
            // menuEditCopy
            // 
            this.menuEditCopy.Image = global::UbwTools.Properties.Resources.Copy016;
            this.menuEditCopy.Name = "menuEditCopy";
            this.menuEditCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.menuEditCopy.Size = new System.Drawing.Size(159, 22);
            this.menuEditCopy.Text = "&Kopier";
            this.menuEditCopy.Click += new System.EventHandler(this.menuEditCopy_Click);
            // 
            // menuEditPaste
            // 
            this.menuEditPaste.Image = global::UbwTools.Properties.Resources.Paste016;
            this.menuEditPaste.Name = "menuEditPaste";
            this.menuEditPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.menuEditPaste.Size = new System.Drawing.Size(159, 22);
            this.menuEditPaste.Text = "&Lim inn";
            this.menuEditPaste.Click += new System.EventHandler(this.menuEditPaste_Click);
            // 
            // menuEditDelete
            // 
            this.menuEditDelete.Image = global::UbwTools.Properties.Resources.Delete016;
            this.menuEditDelete.Name = "menuEditDelete";
            this.menuEditDelete.ShortcutKeyDisplayString = "Del";
            this.menuEditDelete.Size = new System.Drawing.Size(159, 22);
            this.menuEditDelete.Text = "&Slett";
            this.menuEditDelete.Click += new System.EventHandler(this.menuEditDelete_Click);
            // 
            // menuEditSeparator2
            // 
            this.menuEditSeparator2.Name = "menuEditSeparator2";
            this.menuEditSeparator2.Size = new System.Drawing.Size(156, 6);
            // 
            // menuEditSelectAll
            // 
            this.menuEditSelectAll.Image = global::UbwTools.Properties.Resources.SelectAll016;
            this.menuEditSelectAll.Name = "menuEditSelectAll";
            this.menuEditSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.menuEditSelectAll.Size = new System.Drawing.Size(159, 22);
            this.menuEditSelectAll.Text = "&Merk alt";
            this.menuEditSelectAll.Click += new System.EventHandler(this.menuEditSelectAll_Click);
            // 
            // menuDatabase
            // 
            this.menuDatabase.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDatabaseReconnect,
            this.menuDatabaseConfigureAndConnect,
            this.menuDatabaseConnectAppStart,
            this.menuDatabaseDisconnect});
            this.menuDatabase.Name = "menuDatabase";
            this.menuDatabase.Size = new System.Drawing.Size(67, 20);
            this.menuDatabase.Text = "&Database";
            this.menuDatabase.DropDownOpening += new System.EventHandler(this.menuDatabase_DropDownOpening);
            // 
            // menuDatabaseReconnect
            // 
            this.menuDatabaseReconnect.Image = global::UbwTools.Properties.Resources.DatabaseConnect016;
            this.menuDatabaseReconnect.Name = "menuDatabaseReconnect";
            this.menuDatabaseReconnect.Size = new System.Drawing.Size(348, 22);
            this.menuDatabaseReconnect.Text = "Koble &til en tidligere brukt database...";
            this.menuDatabaseReconnect.Click += new System.EventHandler(this.menuDatabaseReconnect_Click);
            // 
            // menuDatabaseConfigureAndConnect
            // 
            this.menuDatabaseConfigureAndConnect.Image = global::UbwTools.Properties.Resources.DatabaseEdit016;
            this.menuDatabaseConfigureAndConnect.Name = "menuDatabaseConfigureAndConnect";
            this.menuDatabaseConfigureAndConnect.Size = new System.Drawing.Size(348, 22);
            this.menuDatabaseConfigureAndConnect.Text = "&Konfigurer og koble til en database for første gang...";
            this.menuDatabaseConfigureAndConnect.Click += new System.EventHandler(this.menuDatabaseConfigureAndConnect_Click);
            // 
            // menuDatabaseConnectAppStart
            // 
            this.menuDatabaseConnectAppStart.Image = global::UbwTools.Properties.Resources.AppStart016;
            this.menuDatabaseConnectAppStart.Name = "menuDatabaseConnectAppStart";
            this.menuDatabaseConnectAppStart.Size = new System.Drawing.Size(348, 22);
            this.menuDatabaseConnectAppStart.Text = "Koble til en &AppStart-definert database...";
            this.menuDatabaseConnectAppStart.Click += new System.EventHandler(this.menuDatabaseConnectAppStart_Click);
            // 
            // menuDatabaseDisconnect
            // 
            this.menuDatabaseDisconnect.Image = global::UbwTools.Properties.Resources.DatabaseDisconnect016;
            this.menuDatabaseDisconnect.Name = "menuDatabaseDisconnect";
            this.menuDatabaseDisconnect.Size = new System.Drawing.Size(348, 22);
            this.menuDatabaseDisconnect.Text = "Koble &fra den nå tilkoblede databasen";
            this.menuDatabaseDisconnect.Click += new System.EventHandler(this.menuDatabaseDisconnect_Click);
            // 
            // menuQuery
            // 
            this.menuQuery.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuQueryExecute,
            this.menuQueryFormat,
            this.menuQuerySeparator,
            this.menuQueryEditorShortcuts});
            this.menuQuery.Name = "menuQuery";
            this.menuQuery.Size = new System.Drawing.Size(40, 20);
            this.menuQuery.Text = "&SQL";
            this.menuQuery.DropDownOpening += new System.EventHandler(this.menuQuery_DropDownOpening);
            // 
            // menuQueryExecute
            // 
            this.menuQueryExecute.Enabled = false;
            this.menuQueryExecute.Image = global::UbwTools.Properties.Resources.Execute016;
            this.menuQueryExecute.Name = "menuQueryExecute";
            this.menuQueryExecute.ShortcutKeyDisplayString = "F5";
            this.menuQueryExecute.Size = new System.Drawing.Size(169, 22);
            this.menuQueryExecute.Text = "&Utfør";
            this.menuQueryExecute.Click += new System.EventHandler(this.menuQueryExecute_Click);
            // 
            // menuQueryFormat
            // 
            this.menuQueryFormat.Image = global::UbwTools.Properties.Resources.Adjust016;
            this.menuQueryFormat.Name = "menuQueryFormat";
            this.menuQueryFormat.Size = new System.Drawing.Size(169, 22);
            this.menuQueryFormat.Text = "&Formater";
            this.menuQueryFormat.Click += new System.EventHandler(this.menuQueryFormat_Click);
            // 
            // menuQuerySeparator
            // 
            this.menuQuerySeparator.Name = "menuQuerySeparator";
            this.menuQuerySeparator.Size = new System.Drawing.Size(166, 6);
            // 
            // menuQueryEditorShortcuts
            // 
            this.menuQueryEditorShortcuts.Name = "menuQueryEditorShortcuts";
            this.menuQueryEditorShortcuts.Size = new System.Drawing.Size(169, 22);
            this.menuQueryEditorShortcuts.Text = "&Editor hurtigtaster";
            this.menuQueryEditorShortcuts.Click += new System.EventHandler(this.menuQueryEditorShortcuts_Click);
            // 
            // menuF5
            // 
            this.menuF5.Name = "menuF5";
            this.menuF5.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.menuF5.ShowShortcutKeys = false;
            this.menuF5.Size = new System.Drawing.Size(31, 20);
            this.menuF5.Text = "F5";
            this.menuF5.Visible = false;
            this.menuF5.Click += new System.EventHandler(this.menuF5_Click);
            // 
            // menuWindow
            // 
            this.menuWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuWindowNewSame,
            this.menuWindowNewAnother,
            this.menuWindowSeparator,
            this.menuWindowBflagCalc,
            this.menuWindowNorwegianId});
            this.menuWindow.Name = "menuWindow";
            this.menuWindow.Size = new System.Drawing.Size(50, 20);
            this.menuWindow.Text = "&Vindu";
            this.menuWindow.DropDownOpening += new System.EventHandler(this.menuWindow_DropDownOpening);
            // 
            // menuWindowNewSame
            // 
            this.menuWindowNewSame.Enabled = false;
            this.menuWindowNewSame.Image = global::UbwTools.Properties.Resources.Database016;
            this.menuWindowNewSame.Name = "menuWindowNewSame";
            this.menuWindowNewSame.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.menuWindowNewSame.Size = new System.Drawing.Size(287, 22);
            this.menuWindowNewSame.Text = "Nytt vindu til &samme database";
            this.menuWindowNewSame.Click += new System.EventHandler(this.menuWindowNewSame_Click);
            // 
            // menuWindowNewAnother
            // 
            this.menuWindowNewAnother.Image = global::UbwTools.Properties.Resources.DatabaseOther016;
            this.menuWindowNewAnother.Name = "menuWindowNewAnother";
            this.menuWindowNewAnother.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.menuWindowNewAnother.Size = new System.Drawing.Size(287, 22);
            this.menuWindowNewAnother.Text = "Nytt vindu til en &annen database";
            this.menuWindowNewAnother.Click += new System.EventHandler(this.menuWindowNewAnother_Click);
            // 
            // menuWindowSeparator
            // 
            this.menuWindowSeparator.Name = "menuWindowSeparator";
            this.menuWindowSeparator.Size = new System.Drawing.Size(284, 6);
            // 
            // menuWindowBflagCalc
            // 
            this.menuWindowBflagCalc.Image = global::UbwTools.Properties.Resources.BFlagS016;
            this.menuWindowBflagCalc.Name = "menuWindowBflagCalc";
            this.menuWindowBflagCalc.Size = new System.Drawing.Size(287, 22);
            this.menuWindowBflagCalc.Text = "&Bflag-kalkulator";
            this.menuWindowBflagCalc.Click += new System.EventHandler(this.menuWindowBflagCalc_Click);
            // 
            // menuWindowNorwegianId
            // 
            this.menuWindowNorwegianId.Image = global::UbwTools.Properties.Resources.NorIdNum016;
            this.menuWindowNorwegianId.Name = "menuWindowNorwegianId";
            this.menuWindowNorwegianId.Size = new System.Drawing.Size(287, 22);
            this.menuWindowNorwegianId.Text = "&Norske identitetsnumre";
            this.menuWindowNorwegianId.Click += new System.EventHandler(this.menuWindowNorwegianId_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHelpAbout,
            this.menuHelpUsersGuide});
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(47, 20);
            this.menuHelp.Text = "&Hjelp";
            // 
            // menuHelpAbout
            // 
            this.menuHelpAbout.Name = "menuHelpAbout";
            this.menuHelpAbout.Size = new System.Drawing.Size(164, 22);
            this.menuHelpAbout.Text = "&Om UBW Tools...";
            this.menuHelpAbout.Click += new System.EventHandler(this.menuHelpAbout_Click);
            // 
            // menuHelpUsersGuide
            // 
            this.menuHelpUsersGuide.Name = "menuHelpUsersGuide";
            this.menuHelpUsersGuide.Size = new System.Drawing.Size(164, 22);
            this.menuHelpUsersGuide.Text = "&Brukermanual";
            this.menuHelpUsersGuide.Click += new System.EventHandler(this.menuHelpUsersGuide_Click);
            // 
            // tools
            // 
            this.tools.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonFileOpen,
            this.toolStripButtonFileSave,
            this.toolStripSeparator1,
            this.toolStripButtonEditUndo,
            this.toolStripButtonEditCut,
            this.toolStripButtonEditCopy,
            this.toolStripButtonEditPaste,
            this.toolStripButtonEditDelete,
            this.toolStripSeparator2,
            this.toolStripButtonDatabaseReconnect,
            this.toolStripButtonDatabaseConfigureAndConnect,
            this.toolStripButtonDatabaseConnectAppStart,
            this.toolStripButtonDatabaseDisconnect,
            this.toolStripSeparator3,
            this.toolStripButtonSqlExecute,
            this.toolStripButtonSqlFormat,
            this.toolStripSeparator4,
            this.toolStripButtonWindowNewSame,
            this.toolStripButtonWindowNewOther,
            this.toolStripButtonWindowBflagCalc,
            this.toolStripButtonWindowAdvancedBflagCalc,
            this.toolStripButtonWindowNorwegianId});
            this.tools.Location = new System.Drawing.Point(0, 24);
            this.tools.Name = "tools";
            this.tools.Size = new System.Drawing.Size(784, 31);
            this.tools.TabIndex = 3;
            this.tools.Text = "toolStrip1";
            this.tools.Paint += new System.Windows.Forms.PaintEventHandler(this.tools_Paint);
            // 
            // toolStripButtonFileOpen
            // 
            this.toolStripButtonFileOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFileOpen.Image = global::UbwTools.Properties.Resources.OpenFile024;
            this.toolStripButtonFileOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFileOpen.Name = "toolStripButtonFileOpen";
            this.toolStripButtonFileOpen.Size = new System.Drawing.Size(28, 28);
            this.toolStripButtonFileOpen.ToolTipText = "Åpne en fil med SQL-uttrykk";
            this.toolStripButtonFileOpen.Click += new System.EventHandler(this.menuFileOpen_Click);
            // 
            // toolStripButtonFileSave
            // 
            this.toolStripButtonFileSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFileSave.Image = global::UbwTools.Properties.Resources.SaveFile024;
            this.toolStripButtonFileSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFileSave.Name = "toolStripButtonFileSave";
            this.toolStripButtonFileSave.Size = new System.Drawing.Size(28, 28);
            this.toolStripButtonFileSave.ToolTipText = "Lagre gjeldende SQL-uttrykk til en fil";
            this.toolStripButtonFileSave.Click += new System.EventHandler(this.menuFileSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButtonEditUndo
            // 
            this.toolStripButtonEditUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEditUndo.Image = global::UbwTools.Properties.Resources.Undo024;
            this.toolStripButtonEditUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEditUndo.Name = "toolStripButtonEditUndo";
            this.toolStripButtonEditUndo.Size = new System.Drawing.Size(28, 28);
            this.toolStripButtonEditUndo.ToolTipText = "Angre den siste redigeringsoperasjonen.";
            this.toolStripButtonEditUndo.Click += new System.EventHandler(this.menuEditUndo_Click);
            // 
            // toolStripButtonEditCut
            // 
            this.toolStripButtonEditCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEditCut.Image = global::UbwTools.Properties.Resources.Cut024;
            this.toolStripButtonEditCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEditCut.Name = "toolStripButtonEditCut";
            this.toolStripButtonEditCut.Size = new System.Drawing.Size(28, 28);
            this.toolStripButtonEditCut.ToolTipText = "Klipp ut markert tekst fra SQL editor og plasser på utklippstavlen.";
            this.toolStripButtonEditCut.Click += new System.EventHandler(this.menuEditCut_Click);
            // 
            // toolStripButtonEditCopy
            // 
            this.toolStripButtonEditCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEditCopy.Image = global::UbwTools.Properties.Resources.Copy024;
            this.toolStripButtonEditCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEditCopy.Name = "toolStripButtonEditCopy";
            this.toolStripButtonEditCopy.Size = new System.Drawing.Size(28, 28);
            this.toolStripButtonEditCopy.ToolTipText = "Kopier markert tekst fra SQL editor til utklippstavlen.";
            this.toolStripButtonEditCopy.Click += new System.EventHandler(this.menuEditCopy_Click);
            // 
            // toolStripButtonEditPaste
            // 
            this.toolStripButtonEditPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEditPaste.Image = global::UbwTools.Properties.Resources.Paste024;
            this.toolStripButtonEditPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEditPaste.Name = "toolStripButtonEditPaste";
            this.toolStripButtonEditPaste.Size = new System.Drawing.Size(28, 28);
            this.toolStripButtonEditPaste.ToolTipText = "Lim inn tekst fra utklippstavlen til SQL editor.";
            this.toolStripButtonEditPaste.Click += new System.EventHandler(this.menuEditPaste_Click);
            // 
            // toolStripButtonEditDelete
            // 
            this.toolStripButtonEditDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEditDelete.Image = global::UbwTools.Properties.Resources.Delete024;
            this.toolStripButtonEditDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEditDelete.Name = "toolStripButtonEditDelete";
            this.toolStripButtonEditDelete.Size = new System.Drawing.Size(28, 28);
            this.toolStripButtonEditDelete.ToolTipText = "Slett markert tekst fra SQL editor.";
            this.toolStripButtonEditDelete.Click += new System.EventHandler(this.menuEditDelete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButtonDatabaseReconnect
            // 
            this.toolStripButtonDatabaseReconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDatabaseReconnect.Image = global::UbwTools.Properties.Resources.DatabaseConnect024;
            this.toolStripButtonDatabaseReconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDatabaseReconnect.Name = "toolStripButtonDatabaseReconnect";
            this.toolStripButtonDatabaseReconnect.Size = new System.Drawing.Size(28, 28);
            this.toolStripButtonDatabaseReconnect.ToolTipText = "Koble til en tidligere brukt database.";
            this.toolStripButtonDatabaseReconnect.Click += new System.EventHandler(this.menuDatabaseReconnect_Click);
            // 
            // toolStripButtonDatabaseConfigureAndConnect
            // 
            this.toolStripButtonDatabaseConfigureAndConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDatabaseConfigureAndConnect.Image = global::UbwTools.Properties.Resources.DatabaseEdit024;
            this.toolStripButtonDatabaseConfigureAndConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDatabaseConfigureAndConnect.Name = "toolStripButtonDatabaseConfigureAndConnect";
            this.toolStripButtonDatabaseConfigureAndConnect.Size = new System.Drawing.Size(28, 28);
            this.toolStripButtonDatabaseConfigureAndConnect.ToolTipText = "Konfigurer og koble til en database for første gang.";
            this.toolStripButtonDatabaseConfigureAndConnect.Click += new System.EventHandler(this.menuDatabaseConfigureAndConnect_Click);
            // 
            // toolStripButtonDatabaseConnectAppStart
            // 
            this.toolStripButtonDatabaseConnectAppStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDatabaseConnectAppStart.Image = global::UbwTools.Properties.Resources.AppStart024;
            this.toolStripButtonDatabaseConnectAppStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDatabaseConnectAppStart.Name = "toolStripButtonDatabaseConnectAppStart";
            this.toolStripButtonDatabaseConnectAppStart.Size = new System.Drawing.Size(28, 28);
            this.toolStripButtonDatabaseConnectAppStart.ToolTipText = "Koble til en AppStart-definert database.";
            this.toolStripButtonDatabaseConnectAppStart.Click += new System.EventHandler(this.menuDatabaseConnectAppStart_Click);
            // 
            // toolStripButtonDatabaseDisconnect
            // 
            this.toolStripButtonDatabaseDisconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDatabaseDisconnect.Image = global::UbwTools.Properties.Resources.DatabaseDisconnect024;
            this.toolStripButtonDatabaseDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDatabaseDisconnect.Name = "toolStripButtonDatabaseDisconnect";
            this.toolStripButtonDatabaseDisconnect.Size = new System.Drawing.Size(28, 28);
            this.toolStripButtonDatabaseDisconnect.ToolTipText = "Koble fra den nå tilkoblede databasen.";
            this.toolStripButtonDatabaseDisconnect.Click += new System.EventHandler(this.menuDatabaseDisconnect_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButtonSqlExecute
            // 
            this.toolStripButtonSqlExecute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSqlExecute.Image = global::UbwTools.Properties.Resources.Execute024;
            this.toolStripButtonSqlExecute.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSqlExecute.Name = "toolStripButtonSqlExecute";
            this.toolStripButtonSqlExecute.Size = new System.Drawing.Size(28, 28);
            this.toolStripButtonSqlExecute.ToolTipText = "Utfør gjeldende SQL-uttrykk.";
            this.toolStripButtonSqlExecute.Click += new System.EventHandler(this.menuQueryExecute_Click);
            // 
            // toolStripButtonSqlFormat
            // 
            this.toolStripButtonSqlFormat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSqlFormat.Image = global::UbwTools.Properties.Resources.Adjust024;
            this.toolStripButtonSqlFormat.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButtonSqlFormat.Name = "toolStripButtonSqlFormat";
            this.toolStripButtonSqlFormat.Size = new System.Drawing.Size(28, 28);
            this.toolStripButtonSqlFormat.ToolTipText = "Formater gjeldende SQL-uttrykk.";
            this.toolStripButtonSqlFormat.Click += new System.EventHandler(this.menuQueryFormat_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButtonWindowNewSame
            // 
            this.toolStripButtonWindowNewSame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonWindowNewSame.Image = global::UbwTools.Properties.Resources.Database024;
            this.toolStripButtonWindowNewSame.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonWindowNewSame.Name = "toolStripButtonWindowNewSame";
            this.toolStripButtonWindowNewSame.Size = new System.Drawing.Size(28, 28);
            this.toolStripButtonWindowNewSame.Text = "toolStripButton1";
            this.toolStripButtonWindowNewSame.ToolTipText = "Åpne et nytt vindu med samme database";
            this.toolStripButtonWindowNewSame.Click += new System.EventHandler(this.menuWindowNewSame_Click);
            // 
            // toolStripButtonWindowNewOther
            // 
            this.toolStripButtonWindowNewOther.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonWindowNewOther.Image = global::UbwTools.Properties.Resources.DatabaseOther024;
            this.toolStripButtonWindowNewOther.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonWindowNewOther.Name = "toolStripButtonWindowNewOther";
            this.toolStripButtonWindowNewOther.Size = new System.Drawing.Size(28, 28);
            this.toolStripButtonWindowNewOther.Text = "toolStripButton1";
            this.toolStripButtonWindowNewOther.ToolTipText = "Åpne et nytt vindu uten valgt database";
            this.toolStripButtonWindowNewOther.Click += new System.EventHandler(this.menuWindowNewAnother_Click);
            // 
            // toolStripButtonWindowBflagCalc
            // 
            this.toolStripButtonWindowBflagCalc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonWindowBflagCalc.Image = global::UbwTools.Properties.Resources.BFlagS024;
            this.toolStripButtonWindowBflagCalc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonWindowBflagCalc.Name = "toolStripButtonWindowBflagCalc";
            this.toolStripButtonWindowBflagCalc.Size = new System.Drawing.Size(28, 28);
            this.toolStripButtonWindowBflagCalc.Text = "toolStripButton1";
            this.toolStripButtonWindowBflagCalc.ToolTipText = "Åpne et nytt vindu med den enkle Bflag-kalkulatoren";
            this.toolStripButtonWindowBflagCalc.Click += new System.EventHandler(this.menuWindowBflagCalc_Click);
            // 
            // toolStripButtonWindowNorwegianId
            // 
            this.toolStripButtonWindowNorwegianId.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonWindowNorwegianId.Image = global::UbwTools.Properties.Resources.NorIdNum024;
            this.toolStripButtonWindowNorwegianId.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonWindowNorwegianId.Name = "toolStripButtonWindowNorwegianId";
            this.toolStripButtonWindowNorwegianId.Size = new System.Drawing.Size(28, 28);
            this.toolStripButtonWindowNorwegianId.Text = "toolStripButton1";
            this.toolStripButtonWindowNorwegianId.ToolTipText = "Åpne et nytt vindu med norske identitetsnumre";
            this.toolStripButtonWindowNorwegianId.Click += new System.EventHandler(this.menuWindowNorwegianId_Click);
            // 
            // splitVertical
            // 
            this.splitVertical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitVertical.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitVertical.Location = new System.Drawing.Point(0, 55);
            this.splitVertical.Name = "splitVertical";
            // 
            // splitVertical.Panel1
            // 
            this.splitVertical.Panel1.Controls.Add(this.splitLeftHorizontal);
            // 
            // splitVertical.Panel2
            // 
            this.splitVertical.Panel2.Controls.Add(this.splitRightHorizontal);
            this.splitVertical.Size = new System.Drawing.Size(784, 482);
            this.splitVertical.SplitterDistance = 233;
            this.splitVertical.TabIndex = 4;
            this.splitVertical.TabStop = false;
            this.splitVertical.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.SplitterMoved);
            // 
            // splitLeftHorizontal
            // 
            this.splitLeftHorizontal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitLeftHorizontal.Location = new System.Drawing.Point(0, 0);
            this.splitLeftHorizontal.Name = "splitLeftHorizontal";
            this.splitLeftHorizontal.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitLeftHorizontal.Panel1
            // 
            this.splitLeftHorizontal.Panel1.Controls.Add(this.treeFavorites);
            // 
            // splitLeftHorizontal.Panel2
            // 
            this.splitLeftHorizontal.Panel2.Controls.Add(this.treeDatabase);
            this.splitLeftHorizontal.Size = new System.Drawing.Size(233, 482);
            this.splitLeftHorizontal.SplitterDistance = 156;
            this.splitLeftHorizontal.TabIndex = 0;
            this.splitLeftHorizontal.TabStop = false;
            this.splitLeftHorizontal.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.SplitterMoved);
            // 
            // treeFavorites
            // 
            this.treeFavorites.AllowDrop = true;
            this.treeFavorites.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeFavorites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeFavorites.HideSelection = false;
            this.treeFavorites.ImageIndex = 0;
            this.treeFavorites.ImageList = this.images;
            this.treeFavorites.Location = new System.Drawing.Point(0, 0);
            this.treeFavorites.Name = "treeFavorites";
            this.treeFavorites.SelectedImageIndex = 0;
            this.treeFavorites.ShowRootLines = false;
            this.treeFavorites.Size = new System.Drawing.Size(233, 156);
            this.treeFavorites.TabIndex = 1;
            this.treeFavorites.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.tree_BeforeCollapse);
            this.treeFavorites.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeFavorites_ItemDrag);
            this.treeFavorites.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeFavorites_DragDrop);
            this.treeFavorites.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeFavorites_DragEnter);
            this.treeFavorites.DoubleClick += new System.EventHandler(this.treeFavorites_DoubleClick);
            this.treeFavorites.Enter += new System.EventHandler(this.control_Enter);
            this.treeFavorites.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tree_KeyUp);
            this.treeFavorites.Leave += new System.EventHandler(this.control_Leave);
            // 
            // images
            // 
            this.images.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.images.ImageSize = new System.Drawing.Size(16, 16);
            this.images.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // treeDatabase
            // 
            this.treeDatabase.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeDatabase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeDatabase.HideSelection = false;
            this.treeDatabase.ImageIndex = 0;
            this.treeDatabase.ImageList = this.images;
            this.treeDatabase.Location = new System.Drawing.Point(0, 0);
            this.treeDatabase.Name = "treeDatabase";
            this.treeDatabase.SelectedImageIndex = 0;
            this.treeDatabase.ShowRootLines = false;
            this.treeDatabase.Size = new System.Drawing.Size(233, 322);
            this.treeDatabase.TabIndex = 1;
            this.treeDatabase.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.tree_BeforeCollapse);
            this.treeDatabase.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeDatabase_ItemDrag);
            this.treeDatabase.DoubleClick += new System.EventHandler(this.treeDatabase_DoubleClick);
            this.treeDatabase.Enter += new System.EventHandler(this.control_Enter);
            this.treeDatabase.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tree_KeyUp);
            this.treeDatabase.Leave += new System.EventHandler(this.control_Leave);
            // 
            // splitRightHorizontal
            // 
            this.splitRightHorizontal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitRightHorizontal.Location = new System.Drawing.Point(0, 0);
            this.splitRightHorizontal.Name = "splitRightHorizontal";
            this.splitRightHorizontal.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitRightHorizontal.Panel1
            // 
            this.splitRightHorizontal.Panel1.Controls.Add(this.textBoxSql);
            // 
            // splitRightHorizontal.Panel2
            // 
            this.splitRightHorizontal.Panel2.BackColor = System.Drawing.Color.White;
            this.splitRightHorizontal.Panel2.BackgroundImage = global::UbwTools.Properties.Resources.Unit4Logo;
            this.splitRightHorizontal.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.splitRightHorizontal.Panel2.Controls.Add(this.tabResults);
            this.splitRightHorizontal.Size = new System.Drawing.Size(547, 482);
            this.splitRightHorizontal.SplitterDistance = 156;
            this.splitRightHorizontal.TabIndex = 0;
            this.splitRightHorizontal.TabStop = false;
            this.splitRightHorizontal.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.SplitterMoved);
            // 
            // textBoxSql
            // 
            this.textBoxSql.AcceptsReturn = true;
            this.textBoxSql.AllowDrop = true;
            this.textBoxSql.BackColor = System.Drawing.Color.White;
            this.textBoxSql.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSql.ContextMenuStrip = this.contextSql;
            this.textBoxSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSql.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSql.HideSelection = false;
            this.textBoxSql.Location = new System.Drawing.Point(0, 0);
            this.textBoxSql.MaxLength = 0;
            this.textBoxSql.Multiline = true;
            this.textBoxSql.Name = "textBoxSql";
            this.textBoxSql.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxSql.Size = new System.Drawing.Size(547, 156);
            this.textBoxSql.TabIndex = 1;
            this.textBoxSql.WordWrap = false;
            this.textBoxSql.TextChanged += new System.EventHandler(this.textBoxSql_TextChanged);
            this.textBoxSql.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxSql_DragDrop);
            this.textBoxSql.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxSql_DragEnter);
            this.textBoxSql.Enter += new System.EventHandler(this.control_Enter);
            this.textBoxSql.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSql_KeyDown);
            this.textBoxSql.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxSql_KeyUp);
            this.textBoxSql.Leave += new System.EventHandler(this.control_Leave);
            this.textBoxSql.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBoxSql_MouseDown);
            this.textBoxSql.MouseUp += new System.Windows.Forms.MouseEventHandler(this.textBoxSql_MouseUp);
            // 
            // contextSql
            // 
            this.contextSql.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextSqlUndo,
            this.contextSqlSeparator1,
            this.contextSqlCut,
            this.contextSqlCopy,
            this.contextSqlPaste,
            this.contextSqlDelete,
            this.contextSqlSeparator2,
            this.contextSqlSelectAll,
            this.contextSqlSeparator3,
            this.contextSqlExecute,
            this.contextSqlFormat,
            this.sQLEditorShortcutsToolStripMenuItem});
            this.contextSql.Name = "contextSql";
            this.contextSql.Size = new System.Drawing.Size(179, 220);
            this.contextSql.Opening += new System.ComponentModel.CancelEventHandler(this.contextSql_Opening);
            // 
            // contextSqlUndo
            // 
            this.contextSqlUndo.Image = global::UbwTools.Properties.Resources.Undo016;
            this.contextSqlUndo.Name = "contextSqlUndo";
            this.contextSqlUndo.ShortcutKeyDisplayString = "Ctrl+Z";
            this.contextSqlUndo.Size = new System.Drawing.Size(178, 22);
            this.contextSqlUndo.Text = "&Angre";
            this.contextSqlUndo.Click += new System.EventHandler(this.menuEditUndo_Click);
            // 
            // contextSqlSeparator1
            // 
            this.contextSqlSeparator1.Name = "contextSqlSeparator1";
            this.contextSqlSeparator1.Size = new System.Drawing.Size(175, 6);
            // 
            // contextSqlCut
            // 
            this.contextSqlCut.Image = global::UbwTools.Properties.Resources.Cut016;
            this.contextSqlCut.Name = "contextSqlCut";
            this.contextSqlCut.ShortcutKeyDisplayString = "Ctrl+X";
            this.contextSqlCut.Size = new System.Drawing.Size(178, 22);
            this.contextSqlCut.Text = "Klipp &ut";
            this.contextSqlCut.Click += new System.EventHandler(this.menuEditCut_Click);
            // 
            // contextSqlCopy
            // 
            this.contextSqlCopy.Image = global::UbwTools.Properties.Resources.Copy016;
            this.contextSqlCopy.Name = "contextSqlCopy";
            this.contextSqlCopy.ShortcutKeyDisplayString = "Ctrl+C";
            this.contextSqlCopy.Size = new System.Drawing.Size(178, 22);
            this.contextSqlCopy.Text = "&Kopier";
            this.contextSqlCopy.Click += new System.EventHandler(this.menuEditCopy_Click);
            // 
            // contextSqlPaste
            // 
            this.contextSqlPaste.Image = global::UbwTools.Properties.Resources.Paste016;
            this.contextSqlPaste.Name = "contextSqlPaste";
            this.contextSqlPaste.ShortcutKeyDisplayString = "Ctrl+V";
            this.contextSqlPaste.Size = new System.Drawing.Size(178, 22);
            this.contextSqlPaste.Text = "&Lim inn";
            this.contextSqlPaste.Click += new System.EventHandler(this.menuEditPaste_Click);
            // 
            // contextSqlDelete
            // 
            this.contextSqlDelete.Image = global::UbwTools.Properties.Resources.Delete016;
            this.contextSqlDelete.Name = "contextSqlDelete";
            this.contextSqlDelete.ShortcutKeyDisplayString = "Del";
            this.contextSqlDelete.Size = new System.Drawing.Size(178, 22);
            this.contextSqlDelete.Text = "&Slett";
            this.contextSqlDelete.Click += new System.EventHandler(this.menuEditDelete_Click);
            // 
            // contextSqlSeparator2
            // 
            this.contextSqlSeparator2.Name = "contextSqlSeparator2";
            this.contextSqlSeparator2.Size = new System.Drawing.Size(175, 6);
            // 
            // contextSqlSelectAll
            // 
            this.contextSqlSelectAll.Image = global::UbwTools.Properties.Resources.SelectAll016;
            this.contextSqlSelectAll.Name = "contextSqlSelectAll";
            this.contextSqlSelectAll.ShortcutKeyDisplayString = "Ctrl+A";
            this.contextSqlSelectAll.Size = new System.Drawing.Size(178, 22);
            this.contextSqlSelectAll.Text = "&Merk alt";
            this.contextSqlSelectAll.Click += new System.EventHandler(this.menuEditSelectAll_Click);
            // 
            // contextSqlSeparator3
            // 
            this.contextSqlSeparator3.Name = "contextSqlSeparator3";
            this.contextSqlSeparator3.Size = new System.Drawing.Size(175, 6);
            // 
            // contextSqlExecute
            // 
            this.contextSqlExecute.Image = global::UbwTools.Properties.Resources.Execute016;
            this.contextSqlExecute.Name = "contextSqlExecute";
            this.contextSqlExecute.ShortcutKeyDisplayString = "F5";
            this.contextSqlExecute.Size = new System.Drawing.Size(178, 22);
            this.contextSqlExecute.Text = "&Utfør";
            this.contextSqlExecute.Click += new System.EventHandler(this.menuQueryExecute_Click);
            // 
            // contextSqlFormat
            // 
            this.contextSqlFormat.Image = global::UbwTools.Properties.Resources.Adjust016;
            this.contextSqlFormat.Name = "contextSqlFormat";
            this.contextSqlFormat.Size = new System.Drawing.Size(178, 22);
            this.contextSqlFormat.Text = "&Formater";
            this.contextSqlFormat.Click += new System.EventHandler(this.menuQueryFormat_Click);
            // 
            // sQLEditorShortcutsToolStripMenuItem
            // 
            this.sQLEditorShortcutsToolStripMenuItem.Name = "sQLEditorShortcutsToolStripMenuItem";
            this.sQLEditorShortcutsToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.sQLEditorShortcutsToolStripMenuItem.Text = "&Editor hurtigtaster...";
            this.sQLEditorShortcutsToolStripMenuItem.Click += new System.EventHandler(this.menuQueryEditorShortcuts_Click);
            // 
            // tabResults
            // 
            this.tabResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabResults.ImageList = this.images;
            this.tabResults.Location = new System.Drawing.Point(0, 0);
            this.tabResults.Name = "tabResults";
            this.tabResults.SelectedIndex = 0;
            this.tabResults.ShowToolTips = true;
            this.tabResults.Size = new System.Drawing.Size(547, 322);
            this.tabResults.TabIndex = 1;
            this.tabResults.Visible = false;
            // 
            // contextDatabaseTable
            // 
            this.contextDatabaseTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextDatabaseTableCopySelect,
            this.contextDatabaseTableExecuteSelect,
            this.contextDatabaseTableExecuteCount,
            this.contextDatabaseTableSeparator1,
            this.contextDatabaseTableCopyToClipboard,
            this.contextDatabaseTablePasteToEdit,
            this.contextDatabaseTableSeparator2,
            this.contextDatabaseTableAddToFavorites});
            this.contextDatabaseTable.Name = "contextDatabaseTable";
            this.contextDatabaseTable.Size = new System.Drawing.Size(315, 148);
            // 
            // contextDatabaseTableCopySelect
            // 
            this.contextDatabaseTableCopySelect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.contextDatabaseTableCopySelect.Image = global::UbwTools.Properties.Resources.Paste016;
            this.contextDatabaseTableCopySelect.Name = "contextDatabaseTableCopySelect";
            this.contextDatabaseTableCopySelect.ShortcutKeyDisplayString = "Enter";
            this.contextDatabaseTableCopySelect.Size = new System.Drawing.Size(314, 22);
            this.contextDatabaseTableCopySelect.Text = "Lim &SELECT * uttrykk inn i SQL editor";
            this.contextDatabaseTableCopySelect.ToolTipText = "Innholdet i SQL editor slettes først.";
            this.contextDatabaseTableCopySelect.Click += new System.EventHandler(this.ContextTreeCopySelect_Click);
            // 
            // contextDatabaseTableExecuteSelect
            // 
            this.contextDatabaseTableExecuteSelect.Image = global::UbwTools.Properties.Resources.Execute016;
            this.contextDatabaseTableExecuteSelect.Name = "contextDatabaseTableExecuteSelect";
            this.contextDatabaseTableExecuteSelect.ShortcutKeyDisplayString = "Ctrl+Enter";
            this.contextDatabaseTableExecuteSelect.Size = new System.Drawing.Size(314, 22);
            this.contextDatabaseTableExecuteSelect.Text = "&Utfør SELECT * uttrykk";
            this.contextDatabaseTableExecuteSelect.ToolTipText = "Slett innholdet i SQL editor, lim inn uttrykk og utfør det.";
            this.contextDatabaseTableExecuteSelect.Click += new System.EventHandler(this.ContextTreeExecuteSelect_Click);
            // 
            // contextDatabaseTableExecuteCount
            // 
            this.contextDatabaseTableExecuteCount.Image = global::UbwTools.Properties.Resources.Count016;
            this.contextDatabaseTableExecuteCount.Name = "contextDatabaseTableExecuteCount";
            this.contextDatabaseTableExecuteCount.ShortcutKeyDisplayString = "Shift+Enter";
            this.contextDatabaseTableExecuteCount.Size = new System.Drawing.Size(314, 22);
            this.contextDatabaseTableExecuteCount.Text = "Utfør SELECT &COUNT(*) uttrykk";
            this.contextDatabaseTableExecuteCount.ToolTipText = "Slett innholdet i SQL editor, lim inn uttrykk og utfør det.";
            this.contextDatabaseTableExecuteCount.Click += new System.EventHandler(this.ContextTreeExecuteCount_Click);
            // 
            // contextDatabaseTableSeparator1
            // 
            this.contextDatabaseTableSeparator1.Name = "contextDatabaseTableSeparator1";
            this.contextDatabaseTableSeparator1.Size = new System.Drawing.Size(311, 6);
            // 
            // contextDatabaseTableCopyToClipboard
            // 
            this.contextDatabaseTableCopyToClipboard.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextDatabaseTableCopyToClipboardTableName,
            this.contextDatabaseTableCopyToClipboardColumnList,
            this.contextDatabaseTableCopyToClipboardCreateNative,
            this.contextDatabaseTableCopyToClipboardCreateAsql});
            this.contextDatabaseTableCopyToClipboard.Image = global::UbwTools.Properties.Resources.Copy016;
            this.contextDatabaseTableCopyToClipboard.Name = "contextDatabaseTableCopyToClipboard";
            this.contextDatabaseTableCopyToClipboard.Size = new System.Drawing.Size(314, 22);
            this.contextDatabaseTableCopyToClipboard.Text = "&Kopier til utklippstavle";
            // 
            // contextDatabaseTableCopyToClipboardTableName
            // 
            this.contextDatabaseTableCopyToClipboardTableName.Name = "contextDatabaseTableCopyToClipboardTableName";
            this.contextDatabaseTableCopyToClipboardTableName.Size = new System.Drawing.Size(225, 22);
            this.contextDatabaseTableCopyToClipboardTableName.Text = "&Tabellnavn";
            this.contextDatabaseTableCopyToClipboardTableName.Click += new System.EventHandler(this.ContextTreeCopyToClipboardName_Click);
            // 
            // contextDatabaseTableCopyToClipboardColumnList
            // 
            this.contextDatabaseTableCopyToClipboardColumnList.Name = "contextDatabaseTableCopyToClipboardColumnList";
            this.contextDatabaseTableCopyToClipboardColumnList.Size = new System.Drawing.Size(225, 22);
            this.contextDatabaseTableCopyToClipboardColumnList.Text = "&Kolonneliste";
            this.contextDatabaseTableCopyToClipboardColumnList.Click += new System.EventHandler(this.ContextTreeCopyToClipboardColumnList_Click);
            // 
            // contextDatabaseTableCopyToClipboardCreateNative
            // 
            this.contextDatabaseTableCopyToClipboardCreateNative.Name = "contextDatabaseTableCopyToClipboardCreateNative";
            this.contextDatabaseTableCopyToClipboardCreateNative.Size = new System.Drawing.Size(225, 22);
            this.contextDatabaseTableCopyToClipboardCreateNative.Text = "&CREATE TABLE uttrykk";
            this.contextDatabaseTableCopyToClipboardCreateNative.Click += new System.EventHandler(this.ContextTreeCopyToClipboardCreateNative_Click);
            // 
            // contextDatabaseTableCopyToClipboardCreateAsql
            // 
            this.contextDatabaseTableCopyToClipboardCreateAsql.Name = "contextDatabaseTableCopyToClipboardCreateAsql";
            this.contextDatabaseTableCopyToClipboardCreateAsql.Size = new System.Drawing.Size(225, 22);
            this.contextDatabaseTableCopyToClipboardCreateAsql.Text = "&ASQL CREATE TABLE uttrykk";
            this.contextDatabaseTableCopyToClipboardCreateAsql.Click += new System.EventHandler(this.ContextTreeCopyToClipboardCreateAsql_Click);
            // 
            // contextDatabaseTablePasteToEdit
            // 
            this.contextDatabaseTablePasteToEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextDatabaseTablePasteToEditTableName,
            this.contextDatabaseTablePasteToEditColumnList,
            this.contextDatabaseTablePasteToEditCreateNative,
            this.contextDatabaseTablePasteToEditCreateAsql});
            this.contextDatabaseTablePasteToEdit.Image = global::UbwTools.Properties.Resources.Paste016;
            this.contextDatabaseTablePasteToEdit.Name = "contextDatabaseTablePasteToEdit";
            this.contextDatabaseTablePasteToEdit.Size = new System.Drawing.Size(314, 22);
            this.contextDatabaseTablePasteToEdit.Text = "&Lim inn i SQL editor";
            // 
            // contextDatabaseTablePasteToEditTableName
            // 
            this.contextDatabaseTablePasteToEditTableName.Name = "contextDatabaseTablePasteToEditTableName";
            this.contextDatabaseTablePasteToEditTableName.Size = new System.Drawing.Size(225, 22);
            this.contextDatabaseTablePasteToEditTableName.Text = "&Tabellnavn";
            this.contextDatabaseTablePasteToEditTableName.Click += new System.EventHandler(this.ContextTreePasteToEditName_Click);
            // 
            // contextDatabaseTablePasteToEditColumnList
            // 
            this.contextDatabaseTablePasteToEditColumnList.Name = "contextDatabaseTablePasteToEditColumnList";
            this.contextDatabaseTablePasteToEditColumnList.Size = new System.Drawing.Size(225, 22);
            this.contextDatabaseTablePasteToEditColumnList.Text = "&Kolonneliste";
            this.contextDatabaseTablePasteToEditColumnList.Click += new System.EventHandler(this.ContextTreePasteToEditColumnList_Click);
            // 
            // contextDatabaseTablePasteToEditCreateNative
            // 
            this.contextDatabaseTablePasteToEditCreateNative.Name = "contextDatabaseTablePasteToEditCreateNative";
            this.contextDatabaseTablePasteToEditCreateNative.Size = new System.Drawing.Size(225, 22);
            this.contextDatabaseTablePasteToEditCreateNative.Text = "&CREATE TABLE uttrykk";
            this.contextDatabaseTablePasteToEditCreateNative.Click += new System.EventHandler(this.ContextTreePasteToEditCreateNative_Click);
            // 
            // contextDatabaseTablePasteToEditCreateAsql
            // 
            this.contextDatabaseTablePasteToEditCreateAsql.Name = "contextDatabaseTablePasteToEditCreateAsql";
            this.contextDatabaseTablePasteToEditCreateAsql.Size = new System.Drawing.Size(225, 22);
            this.contextDatabaseTablePasteToEditCreateAsql.Text = "&ASQL CREATE TABLE uttrykk";
            this.contextDatabaseTablePasteToEditCreateAsql.Click += new System.EventHandler(this.ContextTreePasteToEditCreateAsql_Click);
            // 
            // contextDatabaseTableSeparator2
            // 
            this.contextDatabaseTableSeparator2.Name = "contextDatabaseTableSeparator2";
            this.contextDatabaseTableSeparator2.Size = new System.Drawing.Size(311, 6);
            // 
            // contextDatabaseTableAddToFavorites
            // 
            this.contextDatabaseTableAddToFavorites.Image = global::UbwTools.Properties.Resources.FavoritesAdd016;
            this.contextDatabaseTableAddToFavorites.Name = "contextDatabaseTableAddToFavorites";
            this.contextDatabaseTableAddToFavorites.Size = new System.Drawing.Size(314, 22);
            this.contextDatabaseTableAddToFavorites.Text = "Legg til &favoritter";
            this.contextDatabaseTableAddToFavorites.Click += new System.EventHandler(this.contextDatabaseTableAddToFavorites_Click);
            // 
            // contextDatabaseView
            // 
            this.contextDatabaseView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextDatabaseViewCopySelect,
            this.contextDatabaseViewExecuteSelect,
            this.contextDatabaseViewExecuteCount,
            this.contextDatabaseViewSeparator1,
            this.contextDatabaseViewCopyToClipboard,
            this.contextDatabaseViewPasteToEdit,
            this.contextDatabaseViewSeparator2,
            this.contextDatabaseViewAddToFavorites});
            this.contextDatabaseView.Name = "contextDatabaseView";
            this.contextDatabaseView.Size = new System.Drawing.Size(315, 148);
            // 
            // contextDatabaseViewCopySelect
            // 
            this.contextDatabaseViewCopySelect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.contextDatabaseViewCopySelect.Image = global::UbwTools.Properties.Resources.Paste016;
            this.contextDatabaseViewCopySelect.Name = "contextDatabaseViewCopySelect";
            this.contextDatabaseViewCopySelect.ShortcutKeyDisplayString = "Enter";
            this.contextDatabaseViewCopySelect.Size = new System.Drawing.Size(314, 22);
            this.contextDatabaseViewCopySelect.Text = "Lim &SELECT * uttrykk inn i SQL editor";
            this.contextDatabaseViewCopySelect.ToolTipText = "Innholdet i SQL editor slettes først.";
            this.contextDatabaseViewCopySelect.Click += new System.EventHandler(this.ContextTreeCopySelect_Click);
            // 
            // contextDatabaseViewExecuteSelect
            // 
            this.contextDatabaseViewExecuteSelect.Image = global::UbwTools.Properties.Resources.Execute016;
            this.contextDatabaseViewExecuteSelect.Name = "contextDatabaseViewExecuteSelect";
            this.contextDatabaseViewExecuteSelect.ShortcutKeyDisplayString = "Ctrl+Enter";
            this.contextDatabaseViewExecuteSelect.Size = new System.Drawing.Size(314, 22);
            this.contextDatabaseViewExecuteSelect.Text = "&Utfør SELECT * uttrykk";
            this.contextDatabaseViewExecuteSelect.ToolTipText = "Slett innholdet i SQL editor, lim inn uttrykk og utfør det.";
            this.contextDatabaseViewExecuteSelect.Click += new System.EventHandler(this.ContextTreeExecuteSelect_Click);
            // 
            // contextDatabaseViewExecuteCount
            // 
            this.contextDatabaseViewExecuteCount.Image = global::UbwTools.Properties.Resources.Count016;
            this.contextDatabaseViewExecuteCount.Name = "contextDatabaseViewExecuteCount";
            this.contextDatabaseViewExecuteCount.ShortcutKeyDisplayString = "Shift+Enter";
            this.contextDatabaseViewExecuteCount.Size = new System.Drawing.Size(314, 22);
            this.contextDatabaseViewExecuteCount.Text = "Utfør SELECT &COUNT(*) uttrykk";
            this.contextDatabaseViewExecuteCount.ToolTipText = "Slett innholdet i SQL editor, lim inn uttrykk og utfør det.";
            this.contextDatabaseViewExecuteCount.Click += new System.EventHandler(this.ContextTreeExecuteCount_Click);
            // 
            // contextDatabaseViewSeparator1
            // 
            this.contextDatabaseViewSeparator1.Name = "contextDatabaseViewSeparator1";
            this.contextDatabaseViewSeparator1.Size = new System.Drawing.Size(311, 6);
            // 
            // contextDatabaseViewCopyToClipboard
            // 
            this.contextDatabaseViewCopyToClipboard.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextDatabaseViewCopyToClipboardViewName,
            this.contextDatabaseViewCopyToClipboardColumnList,
            this.contextDatabaseViewCopyToClipboardCreateNative,
            this.contextDatabaseViewCopyToClipboardCreateAsql});
            this.contextDatabaseViewCopyToClipboard.Image = global::UbwTools.Properties.Resources.Copy016;
            this.contextDatabaseViewCopyToClipboard.Name = "contextDatabaseViewCopyToClipboard";
            this.contextDatabaseViewCopyToClipboard.Size = new System.Drawing.Size(314, 22);
            this.contextDatabaseViewCopyToClipboard.Text = "&Kopier til utklippstavle";
            this.contextDatabaseViewCopyToClipboard.DropDownOpening += new System.EventHandler(this.contextDatabaseViewCopyToClipboard_DropDownOpening);
            // 
            // contextDatabaseViewCopyToClipboardViewName
            // 
            this.contextDatabaseViewCopyToClipboardViewName.Name = "contextDatabaseViewCopyToClipboardViewName";
            this.contextDatabaseViewCopyToClipboardViewName.Size = new System.Drawing.Size(218, 22);
            this.contextDatabaseViewCopyToClipboardViewName.Text = "&View-navn";
            this.contextDatabaseViewCopyToClipboardViewName.Click += new System.EventHandler(this.ContextTreeCopyToClipboardName_Click);
            // 
            // contextDatabaseViewCopyToClipboardColumnList
            // 
            this.contextDatabaseViewCopyToClipboardColumnList.Name = "contextDatabaseViewCopyToClipboardColumnList";
            this.contextDatabaseViewCopyToClipboardColumnList.Size = new System.Drawing.Size(218, 22);
            this.contextDatabaseViewCopyToClipboardColumnList.Text = "&Kolonneliste";
            this.contextDatabaseViewCopyToClipboardColumnList.Click += new System.EventHandler(this.ContextTreeCopyToClipboardColumnList_Click);
            // 
            // contextDatabaseViewCopyToClipboardCreateNative
            // 
            this.contextDatabaseViewCopyToClipboardCreateNative.Name = "contextDatabaseViewCopyToClipboardCreateNative";
            this.contextDatabaseViewCopyToClipboardCreateNative.Size = new System.Drawing.Size(218, 22);
            this.contextDatabaseViewCopyToClipboardCreateNative.Text = "&CREATE VIEW uttrykk";
            this.contextDatabaseViewCopyToClipboardCreateNative.Click += new System.EventHandler(this.ContextTreeCopyToClipboardCreateNative_Click);
            // 
            // contextDatabaseViewCopyToClipboardCreateAsql
            // 
            this.contextDatabaseViewCopyToClipboardCreateAsql.Name = "contextDatabaseViewCopyToClipboardCreateAsql";
            this.contextDatabaseViewCopyToClipboardCreateAsql.Size = new System.Drawing.Size(218, 22);
            this.contextDatabaseViewCopyToClipboardCreateAsql.Text = "&ASQL CREATE VIEW uttrykk";
            this.contextDatabaseViewCopyToClipboardCreateAsql.Click += new System.EventHandler(this.ContextTreeCopyToClipboardCreateAsql_Click);
            // 
            // contextDatabaseViewPasteToEdit
            // 
            this.contextDatabaseViewPasteToEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextDatabaseViewPasteToEditViewName,
            this.contextDatabaseViewPasteToEditColumnList,
            this.contextDatabaseViewPasteToEditCreateNative,
            this.contextDatabaseViewPasteToEditCreateAsql});
            this.contextDatabaseViewPasteToEdit.Image = global::UbwTools.Properties.Resources.Paste016;
            this.contextDatabaseViewPasteToEdit.Name = "contextDatabaseViewPasteToEdit";
            this.contextDatabaseViewPasteToEdit.Size = new System.Drawing.Size(314, 22);
            this.contextDatabaseViewPasteToEdit.Text = "&Lim inn i SQL editor";
            this.contextDatabaseViewPasteToEdit.DropDownOpening += new System.EventHandler(this.contextDatabaseViewPasteToEdit_DropDownOpening);
            // 
            // contextDatabaseViewPasteToEditViewName
            // 
            this.contextDatabaseViewPasteToEditViewName.Name = "contextDatabaseViewPasteToEditViewName";
            this.contextDatabaseViewPasteToEditViewName.Size = new System.Drawing.Size(218, 22);
            this.contextDatabaseViewPasteToEditViewName.Text = "&View-navn";
            this.contextDatabaseViewPasteToEditViewName.Click += new System.EventHandler(this.ContextTreePasteToEditName_Click);
            // 
            // contextDatabaseViewPasteToEditColumnList
            // 
            this.contextDatabaseViewPasteToEditColumnList.Name = "contextDatabaseViewPasteToEditColumnList";
            this.contextDatabaseViewPasteToEditColumnList.Size = new System.Drawing.Size(218, 22);
            this.contextDatabaseViewPasteToEditColumnList.Text = "&Kolonneliste";
            this.contextDatabaseViewPasteToEditColumnList.Click += new System.EventHandler(this.ContextTreePasteToEditColumnList_Click);
            // 
            // contextDatabaseViewPasteToEditCreateNative
            // 
            this.contextDatabaseViewPasteToEditCreateNative.Name = "contextDatabaseViewPasteToEditCreateNative";
            this.contextDatabaseViewPasteToEditCreateNative.Size = new System.Drawing.Size(218, 22);
            this.contextDatabaseViewPasteToEditCreateNative.Text = "&CREATE VIEW uttrykk";
            this.contextDatabaseViewPasteToEditCreateNative.Click += new System.EventHandler(this.ContextTreePasteToEditCreateNative_Click);
            // 
            // contextDatabaseViewPasteToEditCreateAsql
            // 
            this.contextDatabaseViewPasteToEditCreateAsql.Name = "contextDatabaseViewPasteToEditCreateAsql";
            this.contextDatabaseViewPasteToEditCreateAsql.Size = new System.Drawing.Size(218, 22);
            this.contextDatabaseViewPasteToEditCreateAsql.Text = "&ASQL CREATE VIEW uttrykk";
            this.contextDatabaseViewPasteToEditCreateAsql.Click += new System.EventHandler(this.ContextTreePasteToEditCreateAsql_Click);
            // 
            // contextDatabaseViewSeparator2
            // 
            this.contextDatabaseViewSeparator2.Name = "contextDatabaseViewSeparator2";
            this.contextDatabaseViewSeparator2.Size = new System.Drawing.Size(311, 6);
            // 
            // contextDatabaseViewAddToFavorites
            // 
            this.contextDatabaseViewAddToFavorites.Image = global::UbwTools.Properties.Resources.FavoritesAdd016;
            this.contextDatabaseViewAddToFavorites.Name = "contextDatabaseViewAddToFavorites";
            this.contextDatabaseViewAddToFavorites.Size = new System.Drawing.Size(314, 22);
            this.contextDatabaseViewAddToFavorites.Text = "Legg til &favoritter";
            this.contextDatabaseViewAddToFavorites.Click += new System.EventHandler(this.contextDatabaseViewAddToFavorites_Click);
            // 
            // contextFavoriteTable
            // 
            this.contextFavoriteTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextFavoriteTableCopySelect,
            this.contextFavoriteTableExecuteSelect,
            this.contextFavoriteTableExecuteCount,
            this.contextFavoriteTableSeparator1,
            this.contextFavoriteTableCopyToClipboard,
            this.contextFavoriteTablePasteToEdit,
            this.contextFavoriteTableSeparator2,
            this.contextFavoriteTableRemove});
            this.contextFavoriteTable.Name = "contextDatabaseTable";
            this.contextFavoriteTable.Size = new System.Drawing.Size(315, 148);
            this.contextFavoriteTable.Opening += new System.ComponentModel.CancelEventHandler(this.contextFavoriteTable_Opening);
            // 
            // contextFavoriteTableCopySelect
            // 
            this.contextFavoriteTableCopySelect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.contextFavoriteTableCopySelect.Image = global::UbwTools.Properties.Resources.Paste016;
            this.contextFavoriteTableCopySelect.Name = "contextFavoriteTableCopySelect";
            this.contextFavoriteTableCopySelect.ShortcutKeyDisplayString = "Enter";
            this.contextFavoriteTableCopySelect.Size = new System.Drawing.Size(314, 22);
            this.contextFavoriteTableCopySelect.Text = "Lim &SELECT * uttrykk inn i SQL editor";
            this.contextFavoriteTableCopySelect.ToolTipText = "Innholdet i SQL editor slettes først.";
            this.contextFavoriteTableCopySelect.Click += new System.EventHandler(this.ContextTreeCopySelect_Click);
            // 
            // contextFavoriteTableExecuteSelect
            // 
            this.contextFavoriteTableExecuteSelect.Image = global::UbwTools.Properties.Resources.Execute016;
            this.contextFavoriteTableExecuteSelect.Name = "contextFavoriteTableExecuteSelect";
            this.contextFavoriteTableExecuteSelect.ShortcutKeyDisplayString = "Ctrl+Enter";
            this.contextFavoriteTableExecuteSelect.Size = new System.Drawing.Size(314, 22);
            this.contextFavoriteTableExecuteSelect.Text = "&Utfør SELECT * uttrykk";
            this.contextFavoriteTableExecuteSelect.ToolTipText = "Slett innholdet i SQL editor, lim inn uttrykk og utfør det.";
            this.contextFavoriteTableExecuteSelect.Click += new System.EventHandler(this.ContextTreeExecuteSelect_Click);
            // 
            // contextFavoriteTableExecuteCount
            // 
            this.contextFavoriteTableExecuteCount.Image = global::UbwTools.Properties.Resources.Count016;
            this.contextFavoriteTableExecuteCount.Name = "contextFavoriteTableExecuteCount";
            this.contextFavoriteTableExecuteCount.ShortcutKeyDisplayString = "Shift+Enter";
            this.contextFavoriteTableExecuteCount.Size = new System.Drawing.Size(314, 22);
            this.contextFavoriteTableExecuteCount.Text = "Utfør SELECT &COUNT(*) uttrykk";
            this.contextFavoriteTableExecuteCount.ToolTipText = "Slett innholdet i SQL editor, lim inn uttrykk og utfør det.";
            this.contextFavoriteTableExecuteCount.Click += new System.EventHandler(this.ContextTreeExecuteCount_Click);
            // 
            // contextFavoriteTableSeparator1
            // 
            this.contextFavoriteTableSeparator1.Name = "contextFavoriteTableSeparator1";
            this.contextFavoriteTableSeparator1.Size = new System.Drawing.Size(311, 6);
            // 
            // contextFavoriteTableCopyToClipboard
            // 
            this.contextFavoriteTableCopyToClipboard.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextFavoriteTableCopyToClipboardTableName,
            this.contextFavoriteTableCopyToClipboardColumnList,
            this.contextFavoriteTableCopyToClipboardCreateNative,
            this.contextFavoriteTableCopyToClipboardCreateAsql});
            this.contextFavoriteTableCopyToClipboard.Image = global::UbwTools.Properties.Resources.Copy016;
            this.contextFavoriteTableCopyToClipboard.Name = "contextFavoriteTableCopyToClipboard";
            this.contextFavoriteTableCopyToClipboard.Size = new System.Drawing.Size(314, 22);
            this.contextFavoriteTableCopyToClipboard.Text = "&Kopier til utklippstavle";
            // 
            // contextFavoriteTableCopyToClipboardTableName
            // 
            this.contextFavoriteTableCopyToClipboardTableName.Name = "contextFavoriteTableCopyToClipboardTableName";
            this.contextFavoriteTableCopyToClipboardTableName.Size = new System.Drawing.Size(225, 22);
            this.contextFavoriteTableCopyToClipboardTableName.Text = "&Tabellnavn";
            this.contextFavoriteTableCopyToClipboardTableName.Click += new System.EventHandler(this.ContextTreeCopyToClipboardName_Click);
            // 
            // contextFavoriteTableCopyToClipboardColumnList
            // 
            this.contextFavoriteTableCopyToClipboardColumnList.Name = "contextFavoriteTableCopyToClipboardColumnList";
            this.contextFavoriteTableCopyToClipboardColumnList.Size = new System.Drawing.Size(225, 22);
            this.contextFavoriteTableCopyToClipboardColumnList.Text = "&Kolonneliste";
            this.contextFavoriteTableCopyToClipboardColumnList.Click += new System.EventHandler(this.ContextTreeCopyToClipboardColumnList_Click);
            // 
            // contextFavoriteTableCopyToClipboardCreateNative
            // 
            this.contextFavoriteTableCopyToClipboardCreateNative.Name = "contextFavoriteTableCopyToClipboardCreateNative";
            this.contextFavoriteTableCopyToClipboardCreateNative.Size = new System.Drawing.Size(225, 22);
            this.contextFavoriteTableCopyToClipboardCreateNative.Text = "&CREATE TABLE uttrykk";
            this.contextFavoriteTableCopyToClipboardCreateNative.Click += new System.EventHandler(this.ContextTreeCopyToClipboardCreateNative_Click);
            // 
            // contextFavoriteTableCopyToClipboardCreateAsql
            // 
            this.contextFavoriteTableCopyToClipboardCreateAsql.Name = "contextFavoriteTableCopyToClipboardCreateAsql";
            this.contextFavoriteTableCopyToClipboardCreateAsql.Size = new System.Drawing.Size(225, 22);
            this.contextFavoriteTableCopyToClipboardCreateAsql.Text = "&ASQL CREATE TABLE uttrykk";
            this.contextFavoriteTableCopyToClipboardCreateAsql.Click += new System.EventHandler(this.ContextTreeCopyToClipboardCreateAsql_Click);
            // 
            // contextFavoriteTablePasteToEdit
            // 
            this.contextFavoriteTablePasteToEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextFavoriteTablePasteToEditTableName,
            this.contextFavoriteTablePasteToEditColumnList,
            this.contextFavoriteTablePasteToEditCreateNative,
            this.contextFavoriteTablePasteToEditCreateAsql});
            this.contextFavoriteTablePasteToEdit.Image = global::UbwTools.Properties.Resources.Paste016;
            this.contextFavoriteTablePasteToEdit.Name = "contextFavoriteTablePasteToEdit";
            this.contextFavoriteTablePasteToEdit.Size = new System.Drawing.Size(314, 22);
            this.contextFavoriteTablePasteToEdit.Text = "&Lim inn i SQL editor";
            // 
            // contextFavoriteTablePasteToEditTableName
            // 
            this.contextFavoriteTablePasteToEditTableName.Name = "contextFavoriteTablePasteToEditTableName";
            this.contextFavoriteTablePasteToEditTableName.Size = new System.Drawing.Size(225, 22);
            this.contextFavoriteTablePasteToEditTableName.Text = "&Tabellnavn";
            this.contextFavoriteTablePasteToEditTableName.Click += new System.EventHandler(this.ContextTreePasteToEditName_Click);
            // 
            // contextFavoriteTablePasteToEditColumnList
            // 
            this.contextFavoriteTablePasteToEditColumnList.Name = "contextFavoriteTablePasteToEditColumnList";
            this.contextFavoriteTablePasteToEditColumnList.Size = new System.Drawing.Size(225, 22);
            this.contextFavoriteTablePasteToEditColumnList.Text = "&Kolonneliste";
            this.contextFavoriteTablePasteToEditColumnList.Click += new System.EventHandler(this.ContextTreePasteToEditColumnList_Click);
            // 
            // contextFavoriteTablePasteToEditCreateNative
            // 
            this.contextFavoriteTablePasteToEditCreateNative.Name = "contextFavoriteTablePasteToEditCreateNative";
            this.contextFavoriteTablePasteToEditCreateNative.Size = new System.Drawing.Size(225, 22);
            this.contextFavoriteTablePasteToEditCreateNative.Text = "&CREATE TABLE uttrykk";
            this.contextFavoriteTablePasteToEditCreateNative.Click += new System.EventHandler(this.ContextTreePasteToEditCreateNative_Click);
            // 
            // contextFavoriteTablePasteToEditCreateAsql
            // 
            this.contextFavoriteTablePasteToEditCreateAsql.Name = "contextFavoriteTablePasteToEditCreateAsql";
            this.contextFavoriteTablePasteToEditCreateAsql.Size = new System.Drawing.Size(225, 22);
            this.contextFavoriteTablePasteToEditCreateAsql.Text = "&ASQL CREATE TABLE uttrykk";
            this.contextFavoriteTablePasteToEditCreateAsql.Click += new System.EventHandler(this.ContextTreePasteToEditCreateAsql_Click);
            // 
            // contextFavoriteTableSeparator2
            // 
            this.contextFavoriteTableSeparator2.Name = "contextFavoriteTableSeparator2";
            this.contextFavoriteTableSeparator2.Size = new System.Drawing.Size(311, 6);
            // 
            // contextFavoriteTableRemove
            // 
            this.contextFavoriteTableRemove.Image = global::UbwTools.Properties.Resources.FavoritesRemove016;
            this.contextFavoriteTableRemove.Name = "contextFavoriteTableRemove";
            this.contextFavoriteTableRemove.Size = new System.Drawing.Size(314, 22);
            this.contextFavoriteTableRemove.Text = "Fjern fra &favoritter";
            this.contextFavoriteTableRemove.Click += new System.EventHandler(this.contextFavoriteTableRemove_Click);
            // 
            // contextFavoriteView
            // 
            this.contextFavoriteView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextFavoriteViewCopySelect,
            this.contextFavoriteViewExecuteSelect,
            this.contextFavoriteViewExecuteCount,
            this.contextFavoriteViewSeparator1,
            this.contextFavoriteViewCopyToClipboard,
            this.contextFavoriteViewPasteToEdit,
            this.contextFavoriteViewSeparator2,
            this.contextFavoriteViewRemove});
            this.contextFavoriteView.Name = "contextDatabaseView";
            this.contextFavoriteView.Size = new System.Drawing.Size(315, 148);
            this.contextFavoriteView.Opening += new System.ComponentModel.CancelEventHandler(this.contextFavoriteView_Opening);
            // 
            // contextFavoriteViewCopySelect
            // 
            this.contextFavoriteViewCopySelect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.contextFavoriteViewCopySelect.Image = global::UbwTools.Properties.Resources.Paste016;
            this.contextFavoriteViewCopySelect.Name = "contextFavoriteViewCopySelect";
            this.contextFavoriteViewCopySelect.ShortcutKeyDisplayString = "Enter";
            this.contextFavoriteViewCopySelect.Size = new System.Drawing.Size(314, 22);
            this.contextFavoriteViewCopySelect.Text = "Lim &SELECT * uttrykk inn i SQL editor";
            this.contextFavoriteViewCopySelect.ToolTipText = "Innholdet i SQL editor slettes først.";
            this.contextFavoriteViewCopySelect.Click += new System.EventHandler(this.ContextTreeCopySelect_Click);
            // 
            // contextFavoriteViewExecuteSelect
            // 
            this.contextFavoriteViewExecuteSelect.Image = global::UbwTools.Properties.Resources.Execute016;
            this.contextFavoriteViewExecuteSelect.Name = "contextFavoriteViewExecuteSelect";
            this.contextFavoriteViewExecuteSelect.ShortcutKeyDisplayString = "Ctrl+Enter";
            this.contextFavoriteViewExecuteSelect.Size = new System.Drawing.Size(314, 22);
            this.contextFavoriteViewExecuteSelect.Text = "&Utfør SELECT * uttrykk";
            this.contextFavoriteViewExecuteSelect.ToolTipText = "Slett innholdet i SQL editor, lim inn uttrykk og utfør det.";
            this.contextFavoriteViewExecuteSelect.Click += new System.EventHandler(this.ContextTreeExecuteSelect_Click);
            // 
            // contextFavoriteViewExecuteCount
            // 
            this.contextFavoriteViewExecuteCount.Image = global::UbwTools.Properties.Resources.Count016;
            this.contextFavoriteViewExecuteCount.Name = "contextFavoriteViewExecuteCount";
            this.contextFavoriteViewExecuteCount.ShortcutKeyDisplayString = "Shift+Enter";
            this.contextFavoriteViewExecuteCount.Size = new System.Drawing.Size(314, 22);
            this.contextFavoriteViewExecuteCount.Text = "Utfør SELECT &COUNT(*) uttrykk";
            this.contextFavoriteViewExecuteCount.ToolTipText = "Slett innholdet i SQL editor, lim inn uttrykk og utfør det.";
            this.contextFavoriteViewExecuteCount.Click += new System.EventHandler(this.ContextTreeExecuteCount_Click);
            // 
            // contextFavoriteViewSeparator1
            // 
            this.contextFavoriteViewSeparator1.Name = "contextFavoriteViewSeparator1";
            this.contextFavoriteViewSeparator1.Size = new System.Drawing.Size(311, 6);
            // 
            // contextFavoriteViewCopyToClipboard
            // 
            this.contextFavoriteViewCopyToClipboard.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextFavoriteViewCopyToClipboardViewName,
            this.contextFavoriteViewCopyToClipboardColumnList,
            this.contextFavoriteViewCopyToClipboardCreateNative,
            this.contextFavoriteViewCopyToClipboardCreateAsql});
            this.contextFavoriteViewCopyToClipboard.Image = global::UbwTools.Properties.Resources.Copy016;
            this.contextFavoriteViewCopyToClipboard.Name = "contextFavoriteViewCopyToClipboard";
            this.contextFavoriteViewCopyToClipboard.Size = new System.Drawing.Size(314, 22);
            this.contextFavoriteViewCopyToClipboard.Text = "&Kopier til utklippstavle";
            this.contextFavoriteViewCopyToClipboard.DropDownOpening += new System.EventHandler(this.contextFavoriteViewCopyToClipboard_DropDownOpening);
            // 
            // contextFavoriteViewCopyToClipboardViewName
            // 
            this.contextFavoriteViewCopyToClipboardViewName.Name = "contextFavoriteViewCopyToClipboardViewName";
            this.contextFavoriteViewCopyToClipboardViewName.Size = new System.Drawing.Size(218, 22);
            this.contextFavoriteViewCopyToClipboardViewName.Text = "&View-navn";
            this.contextFavoriteViewCopyToClipboardViewName.Click += new System.EventHandler(this.ContextTreeCopyToClipboardName_Click);
            // 
            // contextFavoriteViewCopyToClipboardColumnList
            // 
            this.contextFavoriteViewCopyToClipboardColumnList.Name = "contextFavoriteViewCopyToClipboardColumnList";
            this.contextFavoriteViewCopyToClipboardColumnList.Size = new System.Drawing.Size(218, 22);
            this.contextFavoriteViewCopyToClipboardColumnList.Text = "&Kolonneliste";
            this.contextFavoriteViewCopyToClipboardColumnList.Click += new System.EventHandler(this.ContextTreeCopyToClipboardColumnList_Click);
            // 
            // contextFavoriteViewCopyToClipboardCreateNative
            // 
            this.contextFavoriteViewCopyToClipboardCreateNative.Name = "contextFavoriteViewCopyToClipboardCreateNative";
            this.contextFavoriteViewCopyToClipboardCreateNative.Size = new System.Drawing.Size(218, 22);
            this.contextFavoriteViewCopyToClipboardCreateNative.Text = "&CREATE VIEW uttrykk";
            this.contextFavoriteViewCopyToClipboardCreateNative.Click += new System.EventHandler(this.ContextTreeCopyToClipboardCreateNative_Click);
            // 
            // contextFavoriteViewCopyToClipboardCreateAsql
            // 
            this.contextFavoriteViewCopyToClipboardCreateAsql.Name = "contextFavoriteViewCopyToClipboardCreateAsql";
            this.contextFavoriteViewCopyToClipboardCreateAsql.Size = new System.Drawing.Size(218, 22);
            this.contextFavoriteViewCopyToClipboardCreateAsql.Text = "&ASQL CREATE VIEW uttrykk";
            this.contextFavoriteViewCopyToClipboardCreateAsql.Click += new System.EventHandler(this.ContextTreeCopyToClipboardCreateAsql_Click);
            // 
            // contextFavoriteViewPasteToEdit
            // 
            this.contextFavoriteViewPasteToEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextFavoriteViewPasteToEditViewName,
            this.contextFavoriteViewPasteToEditColumnList,
            this.contextFavoriteViewPasteToEditCreateNative,
            this.contextFavoriteViewPasteToEditCreateAsql});
            this.contextFavoriteViewPasteToEdit.Image = global::UbwTools.Properties.Resources.Paste016;
            this.contextFavoriteViewPasteToEdit.Name = "contextFavoriteViewPasteToEdit";
            this.contextFavoriteViewPasteToEdit.Size = new System.Drawing.Size(314, 22);
            this.contextFavoriteViewPasteToEdit.Text = "&Lim inn i SQL editor";
            this.contextFavoriteViewPasteToEdit.DropDownOpening += new System.EventHandler(this.contextFavoriteViewPasteToEdit_DropDownOpening);
            // 
            // contextFavoriteViewPasteToEditViewName
            // 
            this.contextFavoriteViewPasteToEditViewName.Name = "contextFavoriteViewPasteToEditViewName";
            this.contextFavoriteViewPasteToEditViewName.Size = new System.Drawing.Size(218, 22);
            this.contextFavoriteViewPasteToEditViewName.Text = "&View-navn";
            this.contextFavoriteViewPasteToEditViewName.Click += new System.EventHandler(this.ContextTreePasteToEditName_Click);
            // 
            // contextFavoriteViewPasteToEditColumnList
            // 
            this.contextFavoriteViewPasteToEditColumnList.Name = "contextFavoriteViewPasteToEditColumnList";
            this.contextFavoriteViewPasteToEditColumnList.Size = new System.Drawing.Size(218, 22);
            this.contextFavoriteViewPasteToEditColumnList.Text = "&Kolonneliste";
            this.contextFavoriteViewPasteToEditColumnList.Click += new System.EventHandler(this.ContextTreePasteToEditColumnList_Click);
            // 
            // contextFavoriteViewPasteToEditCreateNative
            // 
            this.contextFavoriteViewPasteToEditCreateNative.Name = "contextFavoriteViewPasteToEditCreateNative";
            this.contextFavoriteViewPasteToEditCreateNative.Size = new System.Drawing.Size(218, 22);
            this.contextFavoriteViewPasteToEditCreateNative.Text = "&CREATE VIEW uttrykk";
            this.contextFavoriteViewPasteToEditCreateNative.Click += new System.EventHandler(this.ContextTreePasteToEditCreateNative_Click);
            // 
            // contextFavoriteViewPasteToEditCreateAsql
            // 
            this.contextFavoriteViewPasteToEditCreateAsql.Name = "contextFavoriteViewPasteToEditCreateAsql";
            this.contextFavoriteViewPasteToEditCreateAsql.Size = new System.Drawing.Size(218, 22);
            this.contextFavoriteViewPasteToEditCreateAsql.Text = "&ASQL CREATE VIEW uttrykk";
            this.contextFavoriteViewPasteToEditCreateAsql.Click += new System.EventHandler(this.ContextTreePasteToEditCreateAsql_Click);
            // 
            // contextFavoriteViewSeparator2
            // 
            this.contextFavoriteViewSeparator2.Name = "contextFavoriteViewSeparator2";
            this.contextFavoriteViewSeparator2.Size = new System.Drawing.Size(311, 6);
            // 
            // contextFavoriteViewRemove
            // 
            this.contextFavoriteViewRemove.Image = global::UbwTools.Properties.Resources.FavoritesRemove016;
            this.contextFavoriteViewRemove.Name = "contextFavoriteViewRemove";
            this.contextFavoriteViewRemove.Size = new System.Drawing.Size(314, 22);
            this.contextFavoriteViewRemove.Text = "Fjern fra &favoritter";
            this.contextFavoriteViewRemove.Click += new System.EventHandler(this.contextFavoriteViewRemove_Click);
            // 
            // contextRightDrag
            // 
            this.contextRightDrag.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextRightDragPasteName,
            this.contextRightDragPasteColumnList,
            this.contextRightDragPasteCreateNative,
            this.contextRightDragPasteCreateAsql});
            this.contextRightDrag.Name = "contextRightDrag";
            this.contextRightDrag.Size = new System.Drawing.Size(232, 92);
            this.contextRightDrag.Opening += new System.ComponentModel.CancelEventHandler(this.contextRightDrag_Opening);
            // 
            // contextRightDragPasteName
            // 
            this.contextRightDragPasteName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.contextRightDragPasteName.Name = "contextRightDragPasteName";
            this.contextRightDragPasteName.Size = new System.Drawing.Size(231, 22);
            this.contextRightDragPasteName.Text = "Lim inn &navn";
            this.contextRightDragPasteName.Click += new System.EventHandler(this.contextRightDragPasteName_Click);
            // 
            // contextRightDragPasteColumnList
            // 
            this.contextRightDragPasteColumnList.Name = "contextRightDragPasteColumnList";
            this.contextRightDragPasteColumnList.Size = new System.Drawing.Size(231, 22);
            this.contextRightDragPasteColumnList.Text = "Lim inn &kolonneliste";
            this.contextRightDragPasteColumnList.Click += new System.EventHandler(this.contextRightDragPasteColumnList_Click);
            // 
            // contextRightDragPasteCreateNative
            // 
            this.contextRightDragPasteCreateNative.Name = "contextRightDragPasteCreateNative";
            this.contextRightDragPasteCreateNative.Size = new System.Drawing.Size(231, 22);
            this.contextRightDragPasteCreateNative.Text = "Lim inn &CREATE uttrykk";
            this.contextRightDragPasteCreateNative.Click += new System.EventHandler(this.contextRightDragPasteCreateNative_Click);
            // 
            // contextRightDragPasteCreateAsql
            // 
            this.contextRightDragPasteCreateAsql.Name = "contextRightDragPasteCreateAsql";
            this.contextRightDragPasteCreateAsql.Size = new System.Drawing.Size(231, 22);
            this.contextRightDragPasteCreateAsql.Text = "Lim inn &ASQL CREATE uttrykk";
            this.contextRightDragPasteCreateAsql.Click += new System.EventHandler(this.contextRightDragPasteCreateAsql_Click);
            // 
            // contextHelpTables
            // 
            this.contextHelpTables.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyDROPTABLESScriptToClipboardToolStripMenuItem,
            this.pasteDROPTABLESScriptToEditorToolStripMenuItem});
            this.contextHelpTables.Name = "contextHelpTables";
            this.contextHelpTables.Size = new System.Drawing.Size(295, 48);
            // 
            // copyDROPTABLESScriptToClipboardToolStripMenuItem
            // 
            this.copyDROPTABLESScriptToClipboardToolStripMenuItem.Name = "copyDROPTABLESScriptToClipboardToolStripMenuItem";
            this.copyDROPTABLESScriptToClipboardToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.copyDROPTABLESScriptToClipboardToolStripMenuItem.Text = "Kopier DROP TABLE skript til utklippstavle";
            this.copyDROPTABLESScriptToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyDROPTABLESScriptToClipboardToolStripMenuItem_Click);
            // 
            // pasteDROPTABLESScriptToEditorToolStripMenuItem
            // 
            this.pasteDROPTABLESScriptToEditorToolStripMenuItem.Name = "pasteDROPTABLESScriptToEditorToolStripMenuItem";
            this.pasteDROPTABLESScriptToEditorToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.pasteDROPTABLESScriptToEditorToolStripMenuItem.Text = "Lim inn DROP TABLE skript til SQL editor";
            this.pasteDROPTABLESScriptToEditorToolStripMenuItem.Click += new System.EventHandler(this.pasteDROPTABLESScriptToEditorToolStripMenuItem_Click);
            // 
            // toolStripButtonWindowAdvancedBflagCalc
            // 
            this.toolStripButtonWindowAdvancedBflagCalc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonWindowAdvancedBflagCalc.Image = global::UbwTools.Properties.Resources.BFlagA024;
            this.toolStripButtonWindowAdvancedBflagCalc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonWindowAdvancedBflagCalc.Name = "toolStripButtonWindowAdvancedBflagCalc";
            this.toolStripButtonWindowAdvancedBflagCalc.Size = new System.Drawing.Size(28, 28);
            this.toolStripButtonWindowAdvancedBflagCalc.Text = "toolStripButton1";
            this.toolStripButtonWindowAdvancedBflagCalc.ToolTipText = "Åpne et nytt vindu med den avanserte Bflag-kalkulatoren";
            this.toolStripButtonWindowAdvancedBflagCalc.Click += new System.EventHandler(this.toolStripButtonWindowAdvancedBflagCalc_Click);
            // 
            // SqlGuiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.splitVertical);
            this.Controls.Add(this.tools);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.status);
            this.Name = "SqlGuiForm";
            this.Text = "";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SqlGuiForm_FormClosing);
            this.Load += new System.EventHandler(this.SqlGuiForm_Load);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.tools.ResumeLayout(false);
            this.tools.PerformLayout();
            this.splitVertical.Panel1.ResumeLayout(false);
            this.splitVertical.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitVertical)).EndInit();
            this.splitVertical.ResumeLayout(false);
            this.splitLeftHorizontal.Panel1.ResumeLayout(false);
            this.splitLeftHorizontal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitLeftHorizontal)).EndInit();
            this.splitLeftHorizontal.ResumeLayout(false);
            this.splitRightHorizontal.Panel1.ResumeLayout(false);
            this.splitRightHorizontal.Panel1.PerformLayout();
            this.splitRightHorizontal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitRightHorizontal)).EndInit();
            this.splitRightHorizontal.ResumeLayout(false);
            this.contextSql.ResumeLayout(false);
            this.contextDatabaseTable.ResumeLayout(false);
            this.contextDatabaseView.ResumeLayout(false);
            this.contextFavoriteTable.ResumeLayout(false);
            this.contextFavoriteView.ResumeLayout(false);
            this.contextRightDrag.ResumeLayout(false);
            this.contextHelpTables.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripStatusLabel statusNoConnection;
        private System.Windows.Forms.ToolStripStatusLabel statusEngine;
        private System.Windows.Forms.ToolStripStatusLabel statusDataSource;
        private System.Windows.Forms.ToolStripStatusLabel statusDatabase;
        private System.Windows.Forms.ToolStripStatusLabel statusUbw;
        private System.Windows.Forms.ToolStripStatusLabel statusName;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menuDatabase;
        private System.Windows.Forms.ToolStripMenuItem menuDatabaseReconnect;
        private System.Windows.Forms.ToolStripMenuItem menuDatabaseConfigureAndConnect;
        private System.Windows.Forms.ToolStripMenuItem menuDatabaseDisconnect;
        private System.Windows.Forms.ToolStripMenuItem menuDatabaseConnectAppStart;
        private System.Windows.Forms.ToolStripMenuItem menuQuery;
        private System.Windows.Forms.ToolStripMenuItem menuQueryExecute;
        private System.Windows.Forms.ToolStripMenuItem menuQueryFormat;
        private System.Windows.Forms.ToolStripMenuItem menuF5;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuHelpAbout;
        private System.Windows.Forms.ToolStripButton toolStripButtonDatabaseReconnect;
        private System.Windows.Forms.ToolStripButton toolStripButtonDatabaseConfigureAndConnect;
        private System.Windows.Forms.ToolStripButton toolStripButtonDatabaseDisconnect;
        private System.Windows.Forms.ToolStripButton toolStripButtonDatabaseConnectAppStart;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSqlExecute;
        private System.Windows.Forms.ToolStripButton toolStripButtonSqlFormat;
        private System.Windows.Forms.SplitContainer splitVertical;
        private System.Windows.Forms.SplitContainer splitLeftHorizontal;
        private System.Windows.Forms.SplitContainer splitRightHorizontal;
        public System.Windows.Forms.TabControl tabResults;
        private System.Windows.Forms.ImageList images;
        private System.Windows.Forms.ToolStripMenuItem contextDatabaseTableCopySelect;
        private System.Windows.Forms.ToolStripMenuItem contextDatabaseTableExecuteSelect;
        private System.Windows.Forms.ToolStripMenuItem contextDatabaseTableExecuteCount;
        private System.Windows.Forms.ToolStripSeparator contextDatabaseTableSeparator1;
        private System.Windows.Forms.ToolStripMenuItem contextDatabaseTableCopyToClipboard;
        private System.Windows.Forms.ToolStripMenuItem contextDatabaseTableCopyToClipboardTableName;
        private System.Windows.Forms.ToolStripMenuItem contextDatabaseTableCopyToClipboardColumnList;
        private System.Windows.Forms.ToolStripMenuItem contextDatabaseTableCopyToClipboardCreateNative;
        private System.Windows.Forms.ToolStripMenuItem contextDatabaseTableCopyToClipboardCreateAsql;
        private System.Windows.Forms.ToolStripMenuItem contextDatabaseTableAddToFavorites;
        private System.Windows.Forms.ToolStripMenuItem contextDatabaseViewCopySelect;
        private System.Windows.Forms.ToolStripMenuItem contextDatabaseViewExecuteSelect;
        private System.Windows.Forms.ToolStripMenuItem contextDatabaseViewExecuteCount;
        private System.Windows.Forms.ToolStripSeparator contextDatabaseViewSeparator1;
        private System.Windows.Forms.ToolStripMenuItem contextDatabaseViewCopyToClipboard;
        private System.Windows.Forms.ToolStripMenuItem contextDatabaseViewCopyToClipboardViewName;
        private System.Windows.Forms.ToolStripMenuItem contextDatabaseViewCopyToClipboardColumnList;
        private System.Windows.Forms.ToolStripMenuItem contextDatabaseViewCopyToClipboardCreateNative;
        private System.Windows.Forms.ToolStripMenuItem contextDatabaseViewCopyToClipboardCreateAsql;
        private System.Windows.Forms.ToolStripMenuItem contextDatabaseViewAddToFavorites;
        private System.Windows.Forms.ToolStripMenuItem menuHelpUsersGuide;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripMenuItem menuEditCut;
        private System.Windows.Forms.ToolStripMenuItem menuEditCopy;
        private System.Windows.Forms.ToolStripMenuItem menuEditPaste;
        private System.Windows.Forms.ToolStripSeparator menuEditSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuEditSelectAll;
        private System.Windows.Forms.ToolStripMenuItem menuEditDelete;
        private System.Windows.Forms.ToolStripButton toolStripButtonEditCut;
        private System.Windows.Forms.ToolStripButton toolStripButtonEditCopy;
        private System.Windows.Forms.ToolStripButton toolStripButtonEditPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonEditDelete;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem menuFileSave;
        private System.Windows.Forms.ToolStripMenuItem menuFileSaveAs;
        private System.Windows.Forms.ToolStripSeparator menuFileSeparator;
        private System.Windows.Forms.ToolStripMenuItem menuFileExit;
        private System.Windows.Forms.ToolStripButton toolStripButtonFileOpen;
        private System.Windows.Forms.ToolStripButton toolStripButtonFileSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem contextDatabaseTablePasteToEdit;
        private System.Windows.Forms.ToolStripMenuItem contextDatabaseTablePasteToEditTableName;
        private System.Windows.Forms.ToolStripMenuItem contextDatabaseTablePasteToEditColumnList;
        private System.Windows.Forms.ToolStripMenuItem contextDatabaseTablePasteToEditCreateNative;
        private System.Windows.Forms.ToolStripMenuItem contextDatabaseTablePasteToEditCreateAsql;
        private System.Windows.Forms.ToolStripSeparator contextDatabaseTableSeparator2;
        private System.Windows.Forms.ToolStripMenuItem contextDatabaseViewPasteToEdit;
        private System.Windows.Forms.ToolStripMenuItem contextDatabaseViewPasteToEditViewName;
        private System.Windows.Forms.ToolStripMenuItem contextDatabaseViewPasteToEditColumnList;
        private System.Windows.Forms.ToolStripMenuItem contextDatabaseViewPasteToEditCreateNative;
        private System.Windows.Forms.ToolStripMenuItem contextDatabaseViewPasteToEditCreateAsql;
        private System.Windows.Forms.ContextMenuStrip contextSql;
        private System.Windows.Forms.ToolStripMenuItem contextSqlCut;
        private System.Windows.Forms.ToolStripMenuItem contextSqlCopy;
        private System.Windows.Forms.ToolStripMenuItem contextSqlPaste;
        private System.Windows.Forms.ToolStripMenuItem contextSqlDelete;
        private System.Windows.Forms.ToolStripSeparator contextSqlSeparator1;
        private System.Windows.Forms.ToolStripMenuItem contextSqlExecute;
        private System.Windows.Forms.ToolStripMenuItem contextSqlFormat;
        private System.Windows.Forms.ToolStripMenuItem menuEditUndo;
        private System.Windows.Forms.ToolStripSeparator menuEditSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonEditUndo;
        private System.Windows.Forms.ToolStripMenuItem contextSqlUndo;
        private System.Windows.Forms.ToolStripSeparator contextSqlSeparator2;
        public System.Windows.Forms.TreeView treeFavorites;
        public System.Windows.Forms.TreeView treeDatabase;
        public System.Windows.Forms.ContextMenuStrip contextDatabaseTable;
        public System.Windows.Forms.ContextMenuStrip contextDatabaseView;
        public System.Windows.Forms.ToolStrip tools;
        public System.Windows.Forms.ToolStripMenuItem menuWindow;
        public System.Windows.Forms.ToolStripMenuItem menuWindowNewSame;
        public System.Windows.Forms.ToolStripMenuItem menuWindowNewAnother;
        public System.Windows.Forms.TextBox textBoxSql;
        public System.Windows.Forms.StatusStrip status;
        public System.Windows.Forms.ContextMenuStrip contextFavoriteTable;
        private System.Windows.Forms.ToolStripMenuItem contextFavoriteTableCopySelect;
        private System.Windows.Forms.ToolStripMenuItem contextFavoriteTableExecuteSelect;
        private System.Windows.Forms.ToolStripMenuItem contextFavoriteTableExecuteCount;
        private System.Windows.Forms.ToolStripSeparator contextFavoriteTableSeparator1;
        private System.Windows.Forms.ToolStripMenuItem contextFavoriteTableCopyToClipboard;
        private System.Windows.Forms.ToolStripMenuItem contextFavoriteTableCopyToClipboardTableName;
        private System.Windows.Forms.ToolStripMenuItem contextFavoriteTableCopyToClipboardColumnList;
        private System.Windows.Forms.ToolStripMenuItem contextFavoriteTableCopyToClipboardCreateNative;
        private System.Windows.Forms.ToolStripMenuItem contextFavoriteTableCopyToClipboardCreateAsql;
        private System.Windows.Forms.ToolStripMenuItem contextFavoriteTablePasteToEdit;
        private System.Windows.Forms.ToolStripMenuItem contextFavoriteTablePasteToEditTableName;
        private System.Windows.Forms.ToolStripMenuItem contextFavoriteTablePasteToEditColumnList;
        private System.Windows.Forms.ToolStripMenuItem contextFavoriteTablePasteToEditCreateNative;
        private System.Windows.Forms.ToolStripMenuItem contextFavoriteTablePasteToEditCreateAsql;
        private System.Windows.Forms.ToolStripSeparator contextFavoriteTableSeparator2;
        private System.Windows.Forms.ToolStripMenuItem contextFavoriteTableRemove;
        private System.Windows.Forms.ToolStripSeparator contextDatabaseViewSeparator2;
        public System.Windows.Forms.ContextMenuStrip contextFavoriteView;
        private System.Windows.Forms.ToolStripMenuItem contextFavoriteViewCopySelect;
        private System.Windows.Forms.ToolStripMenuItem contextFavoriteViewExecuteSelect;
        private System.Windows.Forms.ToolStripMenuItem contextFavoriteViewExecuteCount;
        private System.Windows.Forms.ToolStripSeparator contextFavoriteViewSeparator1;
        private System.Windows.Forms.ToolStripMenuItem contextFavoriteViewCopyToClipboard;
        private System.Windows.Forms.ToolStripMenuItem contextFavoriteViewCopyToClipboardViewName;
        private System.Windows.Forms.ToolStripMenuItem contextFavoriteViewCopyToClipboardColumnList;
        private System.Windows.Forms.ToolStripMenuItem contextFavoriteViewCopyToClipboardCreateNative;
        private System.Windows.Forms.ToolStripMenuItem contextFavoriteViewCopyToClipboardCreateAsql;
        private System.Windows.Forms.ToolStripMenuItem contextFavoriteViewPasteToEdit;
        private System.Windows.Forms.ToolStripMenuItem contextFavoriteViewPasteToEditViewName;
        private System.Windows.Forms.ToolStripMenuItem contextFavoriteViewPasteToEditColumnList;
        private System.Windows.Forms.ToolStripMenuItem contextFavoriteViewPasteToEditCreateNative;
        private System.Windows.Forms.ToolStripMenuItem contextFavoriteViewPasteToEditCreateAsql;
        private System.Windows.Forms.ToolStripSeparator contextFavoriteViewSeparator2;
        private System.Windows.Forms.ToolStripMenuItem contextFavoriteViewRemove;
        private System.Windows.Forms.ToolStripMenuItem contextRightDragPasteName;
        private System.Windows.Forms.ToolStripMenuItem contextRightDragPasteColumnList;
        private System.Windows.Forms.ToolStripMenuItem contextRightDragPasteCreateNative;
        private System.Windows.Forms.ToolStripMenuItem contextRightDragPasteCreateAsql;
        public System.Windows.Forms.ContextMenuStrip contextRightDrag;
        private System.Windows.Forms.ToolStripMenuItem contextSqlSelectAll;
        private System.Windows.Forms.ToolStripSeparator contextSqlSeparator3;
        private System.Windows.Forms.ToolStripMenuItem copyDROPTABLESScriptToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteDROPTABLESScriptToEditorToolStripMenuItem;
        public System.Windows.Forms.ContextMenuStrip contextHelpTables;
        private System.Windows.Forms.ToolStripMenuItem sQLEditorShortcutsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator menuWindowSeparator;
        private System.Windows.Forms.ToolStripMenuItem menuWindowBflagCalc;
        private System.Windows.Forms.ToolStripMenuItem menuWindowNorwegianId;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButtonWindowNewSame;
        private System.Windows.Forms.ToolStripButton toolStripButtonWindowNewOther;
        private System.Windows.Forms.ToolStripButton toolStripButtonWindowBflagCalc;
        private System.Windows.Forms.ToolStripButton toolStripButtonWindowNorwegianId;
        private System.Windows.Forms.ToolStripSeparator menuQuerySeparator;
        private System.Windows.Forms.ToolStripMenuItem menuQueryEditorShortcuts;
        private System.Windows.Forms.ToolStripButton toolStripButtonWindowAdvancedBflagCalc;
    }
}