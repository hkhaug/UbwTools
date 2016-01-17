using System;
using System.Windows.Forms;

namespace UbwTools.Common.Gui
{
    public partial class AboutForm : FormBase
    {
        public AboutForm()
        {
            InitializeComponent();
            RestoreWindowInfo();
            textBoxVersion.Text = Global.PublishedVersion;
            textBoxCompileTime.Text = string.Format("{0} kl {1}",
                Global.BuildDateTime.ToString("dd.MM.yyyy"),
                Global.BuildDateTime.ToString("HH:mm:ss"));
        }

        private void AboutForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveWindowInfo();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonDeveloper_Click(object sender, EventArgs e)
        {
            DeveloperForm frm = new DeveloperForm();
            frm.ShowDialog(this);
        }
    }
}
