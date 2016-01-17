using System;
using System.Diagnostics;

namespace UbwTools.Common.Gui
{
    public partial class DeveloperForm : FormBase
    {
        private bool _specialTitle;
        private const string Developer = "Utvikleren";
        private const string CodeMonkey = "Kodeapen";

        public DeveloperForm()
        {
            InitializeComponent();
            RestoreWindowInfo();
            SetTitle();
        }

        private void SetTitle()
        {
            Text = _specialTitle ? CodeMonkey : Developer;
        }

        private void DeveloperForm_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            SaveWindowInfo();
        }

        private void pictureBoxDeveloper_Click(object sender, EventArgs e)
        {
            _specialTitle = !_specialTitle;
            if (_specialTitle)
            {
                Text = CodeMonkey;
                pictureBoxDeveloper.Image = Properties.Resources.Developer2;
            }
            else
            {
                Text = Developer;
                pictureBoxDeveloper.Image = Properties.Resources.Developer1;
            }
        }

        private void linkLabelDeveloper_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            linkLabelDeveloper.LinkVisited = true;
            Process.Start("mailto:HansKristian.Haug@unit4.com?subject=UBW%20Tools");
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
