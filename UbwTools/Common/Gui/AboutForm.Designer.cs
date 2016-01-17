namespace UbwTools.Common.Gui
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.buttonOK = new System.Windows.Forms.Button();
            this.pictureBoxUnit4 = new System.Windows.Forms.PictureBox();
            this.textBoxAboutUbwTools = new System.Windows.Forms.TextBox();
            this.labelVersion = new System.Windows.Forms.Label();
            this.textBoxVersion = new System.Windows.Forms.TextBox();
            this.labelCompiled = new System.Windows.Forms.Label();
            this.textBoxCompileTime = new System.Windows.Forms.TextBox();
            this.buttonDeveloper = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUnit4)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonOK.Location = new System.Drawing.Point(496, 264);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // pictureBoxUnit4
            // 
            this.pictureBoxUnit4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxUnit4.Image")));
            this.pictureBoxUnit4.Location = new System.Drawing.Point(30, 31);
            this.pictureBoxUnit4.Name = "pictureBoxUnit4";
            this.pictureBoxUnit4.Size = new System.Drawing.Size(256, 256);
            this.pictureBoxUnit4.TabIndex = 1;
            this.pictureBoxUnit4.TabStop = false;
            // 
            // textBoxAboutUbwTools
            // 
            this.textBoxAboutUbwTools.BackColor = System.Drawing.Color.White;
            this.textBoxAboutUbwTools.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxAboutUbwTools.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBoxAboutUbwTools.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAboutUbwTools.Location = new System.Drawing.Point(318, 33);
            this.textBoxAboutUbwTools.Multiline = true;
            this.textBoxAboutUbwTools.Name = "textBoxAboutUbwTools";
            this.textBoxAboutUbwTools.ReadOnly = true;
            this.textBoxAboutUbwTools.Size = new System.Drawing.Size(253, 154);
            this.textBoxAboutUbwTools.TabIndex = 2;
            this.textBoxAboutUbwTools.TabStop = false;
            this.textBoxAboutUbwTools.Text = resources.GetString("textBoxAboutUbwTools.Text");
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersion.Location = new System.Drawing.Point(315, 194);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(60, 17);
            this.labelVersion.TabIndex = 3;
            this.labelVersion.Text = "Versjon:";
            // 
            // textBoxVersion
            // 
            this.textBoxVersion.BackColor = System.Drawing.Color.White;
            this.textBoxVersion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxVersion.Location = new System.Drawing.Point(391, 195);
            this.textBoxVersion.Name = "textBoxVersion";
            this.textBoxVersion.ReadOnly = true;
            this.textBoxVersion.Size = new System.Drawing.Size(180, 16);
            this.textBoxVersion.TabIndex = 4;
            this.textBoxVersion.TabStop = false;
            // 
            // labelCompiled
            // 
            this.labelCompiled.AutoSize = true;
            this.labelCompiled.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCompiled.Location = new System.Drawing.Point(315, 217);
            this.labelCompiled.Name = "labelCompiled";
            this.labelCompiled.Size = new System.Drawing.Size(56, 17);
            this.labelCompiled.TabIndex = 5;
            this.labelCompiled.Text = "Bygget:";
            // 
            // textBoxCompileTime
            // 
            this.textBoxCompileTime.BackColor = System.Drawing.Color.White;
            this.textBoxCompileTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCompileTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCompileTime.Location = new System.Drawing.Point(391, 218);
            this.textBoxCompileTime.Name = "textBoxCompileTime";
            this.textBoxCompileTime.ReadOnly = true;
            this.textBoxCompileTime.Size = new System.Drawing.Size(180, 16);
            this.textBoxCompileTime.TabIndex = 6;
            this.textBoxCompileTime.TabStop = false;
            // 
            // buttonDeveloper
            // 
            this.buttonDeveloper.Location = new System.Drawing.Point(318, 264);
            this.buttonDeveloper.Name = "buttonDeveloper";
            this.buttonDeveloper.Size = new System.Drawing.Size(75, 23);
            this.buttonDeveloper.TabIndex = 1;
            this.buttonDeveloper.Text = "&Utvikler";
            this.buttonDeveloper.UseVisualStyleBackColor = true;
            this.buttonDeveloper.Click += new System.EventHandler(this.buttonDeveloper_Click);
            // 
            // AboutForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.buttonOK;
            this.ClientSize = new System.Drawing.Size(600, 314);
            this.Controls.Add(this.buttonDeveloper);
            this.Controls.Add(this.textBoxCompileTime);
            this.Controls.Add(this.labelCompiled);
            this.Controls.Add(this.textBoxVersion);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.textBoxAboutUbwTools);
            this.Controls.Add(this.pictureBoxUnit4);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Om Unit4 Business World Tools";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AboutForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUnit4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.PictureBox pictureBoxUnit4;
        private System.Windows.Forms.TextBox textBoxAboutUbwTools;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.TextBox textBoxVersion;
        private System.Windows.Forms.Label labelCompiled;
        private System.Windows.Forms.TextBox textBoxCompileTime;
        private System.Windows.Forms.Button buttonDeveloper;
    }
}