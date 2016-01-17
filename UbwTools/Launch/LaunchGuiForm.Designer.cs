namespace UbwTools.Launch
{
    partial class LaunchGuiForm
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
            this.status = new System.Windows.Forms.StatusStrip();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelpUsersGuide = new System.Windows.Forms.ToolStripMenuItem();
            this.olv = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.contextItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextItemLaunchReplace = new System.Windows.Forms.ToolStripMenuItem();
            this.contextItemLaunchNew = new System.Windows.Forms.ToolStripMenuItem();
            this.contextItemSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextItemCreateShortcut = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olv)).BeginInit();
            this.contextItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(0, 556);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(911, 22);
            this.status.TabIndex = 0;
            this.status.Text = "statusStrip1";
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuHelp});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(911, 24);
            this.menu.TabIndex = 1;
            this.menu.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(31, 20);
            this.menuFile.Text = "&Fil";
            // 
            // menuFileExit
            // 
            this.menuFileExit.Name = "menuFileExit";
            this.menuFileExit.ShortcutKeyDisplayString = "Alt+F4";
            this.menuFileExit.Size = new System.Drawing.Size(153, 22);
            this.menuFileExit.Text = "&Avslutt";
            this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
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
            // olv
            // 
            this.olv.AllColumns.Add(this.olvColumnName);
            this.olv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnName});
            this.olv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.olv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.olv.IsSimpleDropSink = true;
            this.olv.LargeImageList = this.images;
            this.olv.Location = new System.Drawing.Point(0, 24);
            this.olv.MultiSelect = false;
            this.olv.Name = "olv";
            this.olv.ShowItemToolTips = true;
            this.olv.Size = new System.Drawing.Size(911, 532);
            this.olv.SmallImageList = this.images;
            this.olv.TabIndex = 2;
            this.olv.UseCompatibleStateImageBehavior = false;
            this.olv.View = System.Windows.Forms.View.Details;
            this.olv.BeforeCreatingGroups += new System.EventHandler<BrightIdeasSoftware.CreateGroupsEventArgs>(this.olv_BeforeCreatingGroups);
            this.olv.CanDrop += new System.EventHandler<BrightIdeasSoftware.OlvDropEventArgs>(this.olv_CanDrop);
            this.olv.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.olv_CellRightClick);
            this.olv.Dropped += new System.EventHandler<BrightIdeasSoftware.OlvDropEventArgs>(this.olv_Dropped);
            this.olv.DoubleClick += new System.EventHandler(this.olv_DoubleClick);
            this.olv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.olv_KeyDown);
            this.olv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.olv_KeyPress);
            // 
            // olvColumnName
            // 
            this.olvColumnName.AspectName = "ItemName";
            // 
            // images
            // 
            this.images.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.images.ImageSize = new System.Drawing.Size(48, 48);
            this.images.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // contextItem
            // 
            this.contextItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextItemLaunchReplace,
            this.contextItemLaunchNew,
            this.contextItemSeparator1,
            this.contextItemCreateShortcut});
            this.contextItem.Name = "contextItem";
            this.contextItem.Size = new System.Drawing.Size(265, 76);
            // 
            // contextItemLaunchReplace
            // 
            this.contextItemLaunchReplace.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.contextItemLaunchReplace.Name = "contextItemLaunchReplace";
            this.contextItemLaunchReplace.ShortcutKeyDisplayString = "Enter";
            this.contextItemLaunchReplace.Size = new System.Drawing.Size(264, 22);
            this.contextItemLaunchReplace.Text = "&Start verktøy";
            this.contextItemLaunchReplace.Click += new System.EventHandler(this.contextItemLaunchReplace_Click);
            // 
            // contextItemLaunchNew
            // 
            this.contextItemLaunchNew.Name = "contextItemLaunchNew";
            this.contextItemLaunchNew.ShortcutKeyDisplayString = "Ctrl+Enter";
            this.contextItemLaunchNew.Size = new System.Drawing.Size(264, 22);
            this.contextItemLaunchNew.Text = "Start verktøy i &nytt vindu";
            this.contextItemLaunchNew.Click += new System.EventHandler(this.contextItemLaunchNew_Click);
            // 
            // contextItemSeparator1
            // 
            this.contextItemSeparator1.Name = "contextItemSeparator1";
            this.contextItemSeparator1.Size = new System.Drawing.Size(261, 6);
            // 
            // contextItemCreateShortcut
            // 
            this.contextItemCreateShortcut.Name = "contextItemCreateShortcut";
            this.contextItemCreateShortcut.Size = new System.Drawing.Size(264, 22);
            this.contextItemCreateShortcut.Text = "&Lag snarvei på skrivebordet";
            this.contextItemCreateShortcut.Click += new System.EventHandler(this.contextItemCreateShortcut_Click);
            // 
            // LaunchGuiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(911, 578);
            this.Controls.Add(this.olv);
            this.Controls.Add(this.status);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "LaunchGuiForm";
            this.Text = "LaunchForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LaunchForm_FormClosing);
            this.Load += new System.EventHandler(this.LaunchForm_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olv)).EndInit();
            this.contextItem.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuFileExit;
        private BrightIdeasSoftware.ObjectListView olv;
        private System.Windows.Forms.ImageList images;
        private BrightIdeasSoftware.OLVColumn olvColumnName;
        private System.Windows.Forms.ContextMenuStrip contextItem;
        private System.Windows.Forms.ToolStripMenuItem contextItemLaunchReplace;
        private System.Windows.Forms.ToolStripMenuItem contextItemLaunchNew;
        private System.Windows.Forms.ToolStripSeparator contextItemSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuHelpAbout;
        private System.Windows.Forms.ToolStripMenuItem menuHelpUsersGuide;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem contextItemCreateShortcut;
    }
}