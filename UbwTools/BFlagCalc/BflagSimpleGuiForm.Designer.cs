namespace UbwTools.BFlagCalc
{
    partial class BflagSimpleGuiForm
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
            this.LabelDecimal = new System.Windows.Forms.Label();
            this.EditDecimal = new System.Windows.Forms.TextBox();
            this.BitList = new System.Windows.Forms.ListView();
            this.ColOn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColBitNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelpUsersGuide = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelDecimal
            // 
            this.LabelDecimal.AutoSize = true;
            this.LabelDecimal.Location = new System.Drawing.Point(12, 38);
            this.LabelDecimal.Name = "LabelDecimal";
            this.LabelDecimal.Size = new System.Drawing.Size(83, 13);
            this.LabelDecimal.TabIndex = 1;
            this.LabelDecimal.Text = "&Kombinert verdi:";
            // 
            // EditDecimal
            // 
            this.EditDecimal.Location = new System.Drawing.Point(102, 35);
            this.EditDecimal.MaxLength = 10;
            this.EditDecimal.Name = "EditDecimal";
            this.EditDecimal.Size = new System.Drawing.Size(103, 20);
            this.EditDecimal.TabIndex = 2;
            this.EditDecimal.Tag = "1";
            this.EditDecimal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EditDecimal_KeyPress);
            this.EditDecimal.Validating += new System.ComponentModel.CancelEventHandler(this.EditDecimal_Validating);
            this.EditDecimal.Validated += new System.EventHandler(this.EditDecimal_Validated);
            // 
            // BitList
            // 
            this.BitList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.BitList.CheckBoxes = true;
            this.BitList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColOn,
            this.ColBitNo,
            this.ColValue});
            this.BitList.FullRowSelect = true;
            this.BitList.GridLines = true;
            this.BitList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.BitList.Location = new System.Drawing.Point(15, 65);
            this.BitList.MultiSelect = false;
            this.BitList.Name = "BitList";
            this.BitList.ShowGroups = false;
            this.BitList.Size = new System.Drawing.Size(190, 300);
            this.BitList.TabIndex = 3;
            this.BitList.Tag = "0";
            this.BitList.UseCompatibleStateImageBehavior = false;
            this.BitList.View = System.Windows.Forms.View.Details;
            this.BitList.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.BitList_ColumnWidthChanging);
            this.BitList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.BitList_ItemChecked);
            this.BitList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BitList_KeyPress);
            // 
            // ColOn
            // 
            this.ColOn.Text = "På";
            this.ColOn.Width = 30;
            // 
            // ColBitNo
            // 
            this.ColBitNo.Text = "Bit nr.";
            this.ColBitNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ColBitNo.Width = 46;
            // 
            // ColValue
            // 
            this.ColValue.Text = "Verdi";
            this.ColValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ColValue.Width = 93;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuHelp});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(220, 24);
            this.menu.TabIndex = 4;
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
            // BflagGuiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(220, 378);
            this.Controls.Add(this.BitList);
            this.Controls.Add(this.EditDecimal);
            this.Controls.Add(this.LabelDecimal);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(236, 688);
            this.MinimumSize = new System.Drawing.Size(236, 178);
            this.Name = "BflagGuiForm";
            this.Text = "Bflag-kalkulator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BflagGuiForm_FormClosing);
            this.Load += new System.EventHandler(this.BflagGuiForm_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelDecimal;
        private System.Windows.Forms.TextBox EditDecimal;
        private System.Windows.Forms.ListView BitList;
        private System.Windows.Forms.ColumnHeader ColOn;
        private System.Windows.Forms.ColumnHeader ColBitNo;
        private System.Windows.Forms.ColumnHeader ColValue;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuFileExit;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuHelpAbout;
        private System.Windows.Forms.ToolStripMenuItem menuHelpUsersGuide;
    }
}