namespace UbwTools.Common.Gui
{
    partial class DeveloperForm
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
            this.pictureBoxDeveloper = new System.Windows.Forms.PictureBox();
            this.textBoxContact = new System.Windows.Forms.TextBox();
            this.linkLabelDeveloper = new System.Windows.Forms.LinkLabel();
            this.buttonOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDeveloper)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxDeveloper
            // 
            this.pictureBoxDeveloper.Image = global::UbwTools.Properties.Resources.Developer1;
            this.pictureBoxDeveloper.Location = new System.Drawing.Point(30, 30);
            this.pictureBoxDeveloper.Name = "pictureBoxDeveloper";
            this.pictureBoxDeveloper.Size = new System.Drawing.Size(128, 128);
            this.pictureBoxDeveloper.TabIndex = 0;
            this.pictureBoxDeveloper.TabStop = false;
            this.pictureBoxDeveloper.Click += new System.EventHandler(this.pictureBoxDeveloper_Click);
            // 
            // textBoxContact
            // 
            this.textBoxContact.BackColor = System.Drawing.Color.White;
            this.textBoxContact.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxContact.Location = new System.Drawing.Point(190, 39);
            this.textBoxContact.Multiline = true;
            this.textBoxContact.Name = "textBoxContact";
            this.textBoxContact.ReadOnly = true;
            this.textBoxContact.Size = new System.Drawing.Size(323, 51);
            this.textBoxContact.TabIndex = 1;
            this.textBoxContact.TabStop = false;
            this.textBoxContact.Text = "Hvis du har en idé som kan gjøre dette programmet bedre, ønsker jeg meg en e-post" +
    " fra deg.";
            // 
            // linkLabelDeveloper
            // 
            this.linkLabelDeveloper.AutoSize = true;
            this.linkLabelDeveloper.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelDeveloper.Location = new System.Drawing.Point(187, 97);
            this.linkLabelDeveloper.Name = "linkLabelDeveloper";
            this.linkLabelDeveloper.Size = new System.Drawing.Size(201, 17);
            this.linkLabelDeveloper.TabIndex = 2;
            this.linkLabelDeveloper.TabStop = true;
            this.linkLabelDeveloper.Text = "HansKristian.Haug@unit4.com";
            this.linkLabelDeveloper.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDeveloper_LinkClicked);
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonOk.Location = new System.Drawing.Point(408, 135);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // DeveloperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.buttonOk;
            this.ClientSize = new System.Drawing.Size(514, 183);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.linkLabelDeveloper);
            this.Controls.Add(this.textBoxContact);
            this.Controls.Add(this.pictureBoxDeveloper);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeveloperForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DeveloperForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDeveloper)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxDeveloper;
        private System.Windows.Forms.TextBox textBoxContact;
        private System.Windows.Forms.LinkLabel linkLabelDeveloper;
        private System.Windows.Forms.Button buttonOk;
    }
}