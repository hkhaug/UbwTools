namespace UbwTools.Sql.Gui
{
    partial class ReconnectForm
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
            this.panelBottom = new System.Windows.Forms.Panel();
            this.buttonSaveShortcut = new System.Windows.Forms.Button();
            this.buttonSaveStarter = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.list = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnDescription = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnEngine = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnDataSource = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnDatabase = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.list)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.SystemColors.Control;
            this.panelBottom.Controls.Add(this.buttonSaveShortcut);
            this.panelBottom.Controls.Add(this.buttonSaveStarter);
            this.panelBottom.Controls.Add(this.buttonDelete);
            this.panelBottom.Controls.Add(this.buttonEdit);
            this.panelBottom.Controls.Add(this.buttonCancel);
            this.panelBottom.Controls.Add(this.buttonConnect);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 415);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(934, 47);
            this.panelBottom.TabIndex = 1;
            // 
            // buttonSaveShortcut
            // 
            this.buttonSaveShortcut.Location = new System.Drawing.Point(441, 12);
            this.buttonSaveShortcut.Name = "buttonSaveShortcut";
            this.buttonSaveShortcut.Size = new System.Drawing.Size(140, 23);
            this.buttonSaveShortcut.TabIndex = 4;
            this.buttonSaveShortcut.Text = "&Snarvei på skrivebord";
            this.buttonSaveShortcut.UseVisualStyleBackColor = true;
            this.buttonSaveShortcut.Click += new System.EventHandler(this.buttonSaveShortcut_Click);
            // 
            // buttonSaveStarter
            // 
            this.buttonSaveStarter.Location = new System.Drawing.Point(295, 12);
            this.buttonSaveStarter.Name = "buttonSaveStarter";
            this.buttonSaveStarter.Size = new System.Drawing.Size(140, 23);
            this.buttonSaveStarter.TabIndex = 3;
            this.buttonSaveStarter.Text = "&Lagre i Starter";
            this.buttonSaveStarter.UseVisualStyleBackColor = true;
            this.buttonSaveStarter.Click += new System.EventHandler(this.buttonSaveStarter_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(194, 12);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Slett";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(113, 12);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 1;
            this.buttonEdit.Text = "&Endre";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(847, 12);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Avbryt";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(12, 12);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 23);
            this.buttonConnect.TabIndex = 0;
            this.buttonConnect.Text = "Koble til";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // list
            // 
            this.list.AllColumns.Add(this.olvColumnName);
            this.list.AllColumns.Add(this.olvColumnDescription);
            this.list.AllColumns.Add(this.olvColumnEngine);
            this.list.AllColumns.Add(this.olvColumnDataSource);
            this.list.AllColumns.Add(this.olvColumnDatabase);
            this.list.AllowColumnReorder = true;
            this.list.AlternateRowBackColor = System.Drawing.Color.LemonChiffon;
            this.list.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnName,
            this.olvColumnDescription,
            this.olvColumnEngine,
            this.olvColumnDataSource,
            this.olvColumnDatabase});
            this.list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list.EmptyListMsg = "Finner ingen ting! Dette ser ikke bra ut...";
            this.list.FullRowSelect = true;
            this.list.GridLines = true;
            this.list.HideSelection = false;
            this.list.IncludeColumnHeadersInCopy = true;
            this.list.IncludeHiddenColumnsInDataTransfer = true;
            this.list.Location = new System.Drawing.Point(0, 0);
            this.list.MultiSelect = false;
            this.list.Name = "list";
            this.list.SelectAllOnControlA = false;
            this.list.ShowGroups = false;
            this.list.Size = new System.Drawing.Size(934, 415);
            this.list.TabIndex = 0;
            this.list.UseCompatibleStateImageBehavior = false;
            this.list.UseOverlays = false;
            this.list.View = System.Windows.Forms.View.Details;
            this.list.SelectedIndexChanged += new System.EventHandler(this.list_SelectedIndexChanged);
            this.list.DoubleClick += new System.EventHandler(this.list_DoubleClick);
            // 
            // olvColumnName
            // 
            this.olvColumnName.AspectName = "Name";
            this.olvColumnName.Text = "Navn";
            this.olvColumnName.Width = 250;
            // 
            // olvColumnDescription
            // 
            this.olvColumnDescription.AspectName = "Description";
            this.olvColumnDescription.Text = "Beskrivelse";
            this.olvColumnDescription.Width = 250;
            // 
            // olvColumnEngine
            // 
            this.olvColumnEngine.AspectName = "EngineName";
            this.olvColumnEngine.Text = "Type";
            this.olvColumnEngine.Width = 120;
            // 
            // olvColumnDataSource
            // 
            this.olvColumnDataSource.AspectName = "DataSourceValue";
            this.olvColumnDataSource.Text = "Datakilde";
            this.olvColumnDataSource.Width = 170;
            // 
            // olvColumnDatabase
            // 
            this.olvColumnDatabase.AspectName = "DatabaseName";
            this.olvColumnDatabase.Text = "Database";
            this.olvColumnDatabase.Width = 120;
            // 
            // ReconnectForm
            // 
            this.AcceptButton = this.buttonConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(934, 462);
            this.Controls.Add(this.list);
            this.Controls.Add(this.panelBottom);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(710, 200);
            this.Name = "ReconnectForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Koble til en tidligere brukt database";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReconnectForm_FormClosed);
            this.Shown += new System.EventHandler(this.ReconnectForm_Shown);
            this.Resize += new System.EventHandler(this.ReconnectForm_Resize);
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.list)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonConnect;
        private BrightIdeasSoftware.ObjectListView list;
        private BrightIdeasSoftware.OLVColumn olvColumnName;
        private BrightIdeasSoftware.OLVColumn olvColumnDescription;
        private BrightIdeasSoftware.OLVColumn olvColumnEngine;
        private BrightIdeasSoftware.OLVColumn olvColumnDataSource;
        private BrightIdeasSoftware.OLVColumn olvColumnDatabase;
        private System.Windows.Forms.Button buttonSaveShortcut;
        private System.Windows.Forms.Button buttonSaveStarter;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonEdit;
    }
}