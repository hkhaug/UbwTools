namespace UbwTools.Sql.Gui
{
    partial class FirstTimeConnectForm
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
            this.labelTestResult = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonTest = new System.Windows.Forms.Button();
            this.groupBoxOracle = new System.Windows.Forms.GroupBox();
            this.textBoxOraclePassword = new System.Windows.Forms.TextBox();
            this.labelOraclePassword = new System.Windows.Forms.Label();
            this.textBoxOracleUserName = new System.Windows.Forms.TextBox();
            this.labelOracleUserName = new System.Windows.Forms.Label();
            this.textBoxOraclePort = new System.Windows.Forms.TextBox();
            this.labelOraclePort = new System.Windows.Forms.Label();
            this.textBoxOracleSidOrServiceName = new System.Windows.Forms.TextBox();
            this.labelOracleSidOrServiceName = new System.Windows.Forms.Label();
            this.textBoxOracleServerName = new System.Windows.Forms.TextBox();
            this.labelOracleServerName = new System.Windows.Forms.Label();
            this.groupBoxSqlServer = new System.Windows.Forms.GroupBox();
            this.textBoxSqlServerPassword = new System.Windows.Forms.TextBox();
            this.labelSqlServerPassword = new System.Windows.Forms.Label();
            this.textBoxSqlServerUserName = new System.Windows.Forms.TextBox();
            this.labelSqlServerUserName = new System.Windows.Forms.Label();
            this.comboBoxSqlServerAuthentication = new System.Windows.Forms.ComboBox();
            this.labelSqlServerAuthentication = new System.Windows.Forms.Label();
            this.textBoxSqlServerDatabaseName = new System.Windows.Forms.TextBox();
            this.labelSqlServerDatabaseName = new System.Windows.Forms.Label();
            this.textBoxSqlServerInstanceName = new System.Windows.Forms.TextBox();
            this.labelSqlServerInstanceName = new System.Windows.Forms.Label();
            this.textBoxSqlServerServerName = new System.Windows.Forms.TextBox();
            this.labelSqlServerServerName = new System.Windows.Forms.Label();
            this.comboBoxDatabaseType = new System.Windows.Forms.ComboBox();
            this.labelDatabaseType = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.textBoxConnectionName = new System.Windows.Forms.TextBox();
            this.labelConnectionName = new System.Windows.Forms.Label();
            this.tipper = new System.Windows.Forms.ToolTip(this.components);
            this.groupBoxOracle.SuspendLayout();
            this.groupBoxSqlServer.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTestResult
            // 
            this.labelTestResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTestResult.Location = new System.Drawing.Point(113, 330);
            this.labelTestResult.Name = "labelTestResult";
            this.labelTestResult.Size = new System.Drawing.Size(399, 20);
            this.labelTestResult.TabIndex = 21;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(606, 325);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 23;
            this.buttonCancel.Text = "Avbryt";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(525, 325);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 22;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(24, 325);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(75, 23);
            this.buttonTest.TabIndex = 20;
            this.buttonTest.Text = "&Test";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // groupBoxOracle
            // 
            this.groupBoxOracle.Controls.Add(this.textBoxOraclePassword);
            this.groupBoxOracle.Controls.Add(this.labelOraclePassword);
            this.groupBoxOracle.Controls.Add(this.textBoxOracleUserName);
            this.groupBoxOracle.Controls.Add(this.labelOracleUserName);
            this.groupBoxOracle.Controls.Add(this.textBoxOraclePort);
            this.groupBoxOracle.Controls.Add(this.labelOraclePort);
            this.groupBoxOracle.Controls.Add(this.textBoxOracleSidOrServiceName);
            this.groupBoxOracle.Controls.Add(this.labelOracleSidOrServiceName);
            this.groupBoxOracle.Controls.Add(this.textBoxOracleServerName);
            this.groupBoxOracle.Controls.Add(this.labelOracleServerName);
            this.groupBoxOracle.Location = new System.Drawing.Point(356, 122);
            this.groupBoxOracle.Name = "groupBoxOracle";
            this.groupBoxOracle.Size = new System.Drawing.Size(325, 180);
            this.groupBoxOracle.TabIndex = 19;
            this.groupBoxOracle.TabStop = false;
            this.groupBoxOracle.Text = "Oracle koblingsparametere";
            // 
            // textBoxOraclePassword
            // 
            this.textBoxOraclePassword.Location = new System.Drawing.Point(130, 123);
            this.textBoxOraclePassword.Name = "textBoxOraclePassword";
            this.textBoxOraclePassword.Size = new System.Drawing.Size(180, 20);
            this.textBoxOraclePassword.TabIndex = 9;
            // 
            // labelOraclePassword
            // 
            this.labelOraclePassword.AutoSize = true;
            this.labelOraclePassword.Location = new System.Drawing.Point(6, 126);
            this.labelOraclePassword.Name = "labelOraclePassword";
            this.labelOraclePassword.Size = new System.Drawing.Size(48, 13);
            this.labelOraclePassword.TabIndex = 8;
            this.labelOraclePassword.Text = "&Passord:";
            // 
            // textBoxOracleUserName
            // 
            this.textBoxOracleUserName.Location = new System.Drawing.Point(130, 97);
            this.textBoxOracleUserName.Name = "textBoxOracleUserName";
            this.textBoxOracleUserName.Size = new System.Drawing.Size(180, 20);
            this.textBoxOracleUserName.TabIndex = 7;
            // 
            // labelOracleUserName
            // 
            this.labelOracleUserName.AutoSize = true;
            this.labelOracleUserName.Location = new System.Drawing.Point(6, 100);
            this.labelOracleUserName.Name = "labelOracleUserName";
            this.labelOracleUserName.Size = new System.Drawing.Size(65, 13);
            this.labelOracleUserName.TabIndex = 6;
            this.labelOracleUserName.Text = "Br&ukernavn:";
            // 
            // textBoxOraclePort
            // 
            this.textBoxOraclePort.Location = new System.Drawing.Point(130, 71);
            this.textBoxOraclePort.Name = "textBoxOraclePort";
            this.textBoxOraclePort.Size = new System.Drawing.Size(180, 20);
            this.textBoxOraclePort.TabIndex = 5;
            // 
            // labelOraclePort
            // 
            this.labelOraclePort.AutoSize = true;
            this.labelOraclePort.Location = new System.Drawing.Point(6, 74);
            this.labelOraclePort.Name = "labelOraclePort";
            this.labelOraclePort.Size = new System.Drawing.Size(29, 13);
            this.labelOraclePort.TabIndex = 4;
            this.labelOraclePort.Text = "P&ort:";
            // 
            // textBoxOracleSidOrServiceName
            // 
            this.textBoxOracleSidOrServiceName.Location = new System.Drawing.Point(130, 45);
            this.textBoxOracleSidOrServiceName.Name = "textBoxOracleSidOrServiceName";
            this.textBoxOracleSidOrServiceName.Size = new System.Drawing.Size(180, 20);
            this.textBoxOracleSidOrServiceName.TabIndex = 3;
            // 
            // labelOracleSidOrServiceName
            // 
            this.labelOracleSidOrServiceName.AutoSize = true;
            this.labelOracleSidOrServiceName.Location = new System.Drawing.Point(6, 48);
            this.labelOracleSidOrServiceName.Name = "labelOracleSidOrServiceName";
            this.labelOracleSidOrServiceName.Size = new System.Drawing.Size(114, 13);
            this.labelOracleSidOrServiceName.TabIndex = 2;
            this.labelOracleSidOrServiceName.Text = "S&ID eller service navn:";
            // 
            // textBoxOracleServerName
            // 
            this.textBoxOracleServerName.Location = new System.Drawing.Point(130, 19);
            this.textBoxOracleServerName.Name = "textBoxOracleServerName";
            this.textBoxOracleServerName.Size = new System.Drawing.Size(180, 20);
            this.textBoxOracleServerName.TabIndex = 1;
            // 
            // labelOracleServerName
            // 
            this.labelOracleServerName.AutoSize = true;
            this.labelOracleServerName.Location = new System.Drawing.Point(6, 22);
            this.labelOracleServerName.Name = "labelOracleServerName";
            this.labelOracleServerName.Size = new System.Drawing.Size(65, 13);
            this.labelOracleServerName.TabIndex = 0;
            this.labelOracleServerName.Text = "&Servernavn:";
            // 
            // groupBoxSqlServer
            // 
            this.groupBoxSqlServer.Controls.Add(this.textBoxSqlServerPassword);
            this.groupBoxSqlServer.Controls.Add(this.labelSqlServerPassword);
            this.groupBoxSqlServer.Controls.Add(this.textBoxSqlServerUserName);
            this.groupBoxSqlServer.Controls.Add(this.labelSqlServerUserName);
            this.groupBoxSqlServer.Controls.Add(this.comboBoxSqlServerAuthentication);
            this.groupBoxSqlServer.Controls.Add(this.labelSqlServerAuthentication);
            this.groupBoxSqlServer.Controls.Add(this.textBoxSqlServerDatabaseName);
            this.groupBoxSqlServer.Controls.Add(this.labelSqlServerDatabaseName);
            this.groupBoxSqlServer.Controls.Add(this.textBoxSqlServerInstanceName);
            this.groupBoxSqlServer.Controls.Add(this.labelSqlServerInstanceName);
            this.groupBoxSqlServer.Controls.Add(this.textBoxSqlServerServerName);
            this.groupBoxSqlServer.Controls.Add(this.labelSqlServerServerName);
            this.groupBoxSqlServer.Location = new System.Drawing.Point(24, 122);
            this.groupBoxSqlServer.Name = "groupBoxSqlServer";
            this.groupBoxSqlServer.Size = new System.Drawing.Size(300, 180);
            this.groupBoxSqlServer.TabIndex = 18;
            this.groupBoxSqlServer.TabStop = false;
            this.groupBoxSqlServer.Text = "SQL Server koblingsparametere";
            // 
            // textBoxSqlServerPassword
            // 
            this.textBoxSqlServerPassword.Location = new System.Drawing.Point(105, 150);
            this.textBoxSqlServerPassword.Name = "textBoxSqlServerPassword";
            this.textBoxSqlServerPassword.Size = new System.Drawing.Size(180, 20);
            this.textBoxSqlServerPassword.TabIndex = 11;
            // 
            // labelSqlServerPassword
            // 
            this.labelSqlServerPassword.AutoSize = true;
            this.labelSqlServerPassword.Location = new System.Drawing.Point(6, 153);
            this.labelSqlServerPassword.Name = "labelSqlServerPassword";
            this.labelSqlServerPassword.Size = new System.Drawing.Size(48, 13);
            this.labelSqlServerPassword.TabIndex = 10;
            this.labelSqlServerPassword.Text = "&Passord:";
            // 
            // textBoxSqlServerUserName
            // 
            this.textBoxSqlServerUserName.Location = new System.Drawing.Point(105, 124);
            this.textBoxSqlServerUserName.Name = "textBoxSqlServerUserName";
            this.textBoxSqlServerUserName.Size = new System.Drawing.Size(180, 20);
            this.textBoxSqlServerUserName.TabIndex = 9;
            // 
            // labelSqlServerUserName
            // 
            this.labelSqlServerUserName.AutoSize = true;
            this.labelSqlServerUserName.Location = new System.Drawing.Point(6, 127);
            this.labelSqlServerUserName.Name = "labelSqlServerUserName";
            this.labelSqlServerUserName.Size = new System.Drawing.Size(65, 13);
            this.labelSqlServerUserName.TabIndex = 8;
            this.labelSqlServerUserName.Text = "Br&ukernavn:";
            // 
            // comboBoxSqlServerAuthentication
            // 
            this.comboBoxSqlServerAuthentication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSqlServerAuthentication.FormattingEnabled = true;
            this.comboBoxSqlServerAuthentication.Items.AddRange(new object[] {
            "Windows autentisering",
            "SQL Server autentisering"});
            this.comboBoxSqlServerAuthentication.Location = new System.Drawing.Point(105, 97);
            this.comboBoxSqlServerAuthentication.Name = "comboBoxSqlServerAuthentication";
            this.comboBoxSqlServerAuthentication.Size = new System.Drawing.Size(180, 21);
            this.comboBoxSqlServerAuthentication.TabIndex = 7;
            this.comboBoxSqlServerAuthentication.SelectedIndexChanged += new System.EventHandler(this.comboBoxSqlServerAuthentication_SelectedIndexChanged);
            // 
            // labelSqlServerAuthentication
            // 
            this.labelSqlServerAuthentication.AutoSize = true;
            this.labelSqlServerAuthentication.Location = new System.Drawing.Point(6, 100);
            this.labelSqlServerAuthentication.Name = "labelSqlServerAuthentication";
            this.labelSqlServerAuthentication.Size = new System.Drawing.Size(71, 13);
            this.labelSqlServerAuthentication.TabIndex = 6;
            this.labelSqlServerAuthentication.Text = "&Autentisering:";
            // 
            // textBoxSqlServerDatabaseName
            // 
            this.textBoxSqlServerDatabaseName.Location = new System.Drawing.Point(105, 71);
            this.textBoxSqlServerDatabaseName.Name = "textBoxSqlServerDatabaseName";
            this.textBoxSqlServerDatabaseName.Size = new System.Drawing.Size(180, 20);
            this.textBoxSqlServerDatabaseName.TabIndex = 5;
            // 
            // labelSqlServerDatabaseName
            // 
            this.labelSqlServerDatabaseName.AutoSize = true;
            this.labelSqlServerDatabaseName.Location = new System.Drawing.Point(6, 74);
            this.labelSqlServerDatabaseName.Name = "labelSqlServerDatabaseName";
            this.labelSqlServerDatabaseName.Size = new System.Drawing.Size(80, 13);
            this.labelSqlServerDatabaseName.TabIndex = 4;
            this.labelSqlServerDatabaseName.Text = "Databa&senavn:";
            // 
            // textBoxSqlServerInstanceName
            // 
            this.textBoxSqlServerInstanceName.Location = new System.Drawing.Point(105, 45);
            this.textBoxSqlServerInstanceName.Name = "textBoxSqlServerInstanceName";
            this.textBoxSqlServerInstanceName.Size = new System.Drawing.Size(180, 20);
            this.textBoxSqlServerInstanceName.TabIndex = 3;
            // 
            // labelSqlServerInstanceName
            // 
            this.labelSqlServerInstanceName.AutoSize = true;
            this.labelSqlServerInstanceName.Location = new System.Drawing.Point(6, 48);
            this.labelSqlServerInstanceName.Name = "labelSqlServerInstanceName";
            this.labelSqlServerInstanceName.Size = new System.Drawing.Size(68, 13);
            this.labelSqlServerInstanceName.TabIndex = 2;
            this.labelSqlServerInstanceName.Text = "&Instansnavn:";
            // 
            // textBoxSqlServerServerName
            // 
            this.textBoxSqlServerServerName.Location = new System.Drawing.Point(105, 19);
            this.textBoxSqlServerServerName.Name = "textBoxSqlServerServerName";
            this.textBoxSqlServerServerName.Size = new System.Drawing.Size(180, 20);
            this.textBoxSqlServerServerName.TabIndex = 1;
            // 
            // labelSqlServerServerName
            // 
            this.labelSqlServerServerName.AutoSize = true;
            this.labelSqlServerServerName.Location = new System.Drawing.Point(6, 22);
            this.labelSqlServerServerName.Name = "labelSqlServerServerName";
            this.labelSqlServerServerName.Size = new System.Drawing.Size(65, 13);
            this.labelSqlServerServerName.TabIndex = 0;
            this.labelSqlServerServerName.Text = "&Servernavn:";
            // 
            // comboBoxDatabaseType
            // 
            this.comboBoxDatabaseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDatabaseType.FormattingEnabled = true;
            this.comboBoxDatabaseType.Items.AddRange(new object[] {
            "SQL Server",
            "Oracle"});
            this.comboBoxDatabaseType.Location = new System.Drawing.Point(129, 82);
            this.comboBoxDatabaseType.Name = "comboBoxDatabaseType";
            this.comboBoxDatabaseType.Size = new System.Drawing.Size(180, 21);
            this.comboBoxDatabaseType.TabIndex = 17;
            this.comboBoxDatabaseType.SelectedIndexChanged += new System.EventHandler(this.comboBoxDatabaseType_SelectedIndexChanged);
            // 
            // labelDatabaseType
            // 
            this.labelDatabaseType.AutoSize = true;
            this.labelDatabaseType.Location = new System.Drawing.Point(21, 85);
            this.labelDatabaseType.Name = "labelDatabaseType";
            this.labelDatabaseType.Size = new System.Drawing.Size(76, 13);
            this.labelDatabaseType.TabIndex = 16;
            this.labelDatabaseType.Text = "&Databasetype:";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(129, 46);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(552, 20);
            this.textBoxDescription.TabIndex = 15;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(21, 49);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(64, 13);
            this.labelDescription.TabIndex = 14;
            this.labelDescription.Text = "&Beskrivelse:";
            // 
            // textBoxConnectionName
            // 
            this.textBoxConnectionName.Location = new System.Drawing.Point(129, 20);
            this.textBoxConnectionName.Name = "textBoxConnectionName";
            this.textBoxConnectionName.Size = new System.Drawing.Size(552, 20);
            this.textBoxConnectionName.TabIndex = 13;
            // 
            // labelConnectionName
            // 
            this.labelConnectionName.AutoSize = true;
            this.labelConnectionName.Location = new System.Drawing.Point(21, 23);
            this.labelConnectionName.Name = "labelConnectionName";
            this.labelConnectionName.Size = new System.Drawing.Size(74, 13);
            this.labelConnectionName.TabIndex = 12;
            this.labelConnectionName.Text = "&Koblingsnavn:";
            // 
            // FirstTimeConnectForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(702, 370);
            this.Controls.Add(this.labelTestResult);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonTest);
            this.Controls.Add(this.groupBoxOracle);
            this.Controls.Add(this.groupBoxSqlServer);
            this.Controls.Add(this.comboBoxDatabaseType);
            this.Controls.Add(this.labelDatabaseType);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.textBoxConnectionName);
            this.Controls.Add(this.labelConnectionName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FirstTimeConnectForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "FirstTimeConnectForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FirstTimeConnectForm_FormClosed);
            this.groupBoxOracle.ResumeLayout(false);
            this.groupBoxOracle.PerformLayout();
            this.groupBoxSqlServer.ResumeLayout(false);
            this.groupBoxSqlServer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTestResult;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.GroupBox groupBoxOracle;
        private System.Windows.Forms.TextBox textBoxOraclePassword;
        private System.Windows.Forms.Label labelOraclePassword;
        private System.Windows.Forms.TextBox textBoxOracleUserName;
        private System.Windows.Forms.Label labelOracleUserName;
        private System.Windows.Forms.TextBox textBoxOraclePort;
        private System.Windows.Forms.Label labelOraclePort;
        private System.Windows.Forms.TextBox textBoxOracleSidOrServiceName;
        private System.Windows.Forms.Label labelOracleSidOrServiceName;
        private System.Windows.Forms.TextBox textBoxOracleServerName;
        private System.Windows.Forms.Label labelOracleServerName;
        private System.Windows.Forms.GroupBox groupBoxSqlServer;
        private System.Windows.Forms.TextBox textBoxSqlServerPassword;
        private System.Windows.Forms.Label labelSqlServerPassword;
        private System.Windows.Forms.TextBox textBoxSqlServerUserName;
        private System.Windows.Forms.Label labelSqlServerUserName;
        private System.Windows.Forms.ComboBox comboBoxSqlServerAuthentication;
        private System.Windows.Forms.Label labelSqlServerAuthentication;
        private System.Windows.Forms.TextBox textBoxSqlServerDatabaseName;
        private System.Windows.Forms.Label labelSqlServerDatabaseName;
        private System.Windows.Forms.TextBox textBoxSqlServerInstanceName;
        private System.Windows.Forms.Label labelSqlServerInstanceName;
        private System.Windows.Forms.TextBox textBoxSqlServerServerName;
        private System.Windows.Forms.Label labelSqlServerServerName;
        private System.Windows.Forms.ComboBox comboBoxDatabaseType;
        private System.Windows.Forms.Label labelDatabaseType;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxConnectionName;
        private System.Windows.Forms.Label labelConnectionName;
        private System.Windows.Forms.ToolTip tipper;
    }
}