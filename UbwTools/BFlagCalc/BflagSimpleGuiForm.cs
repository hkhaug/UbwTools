using System;
using System.ComponentModel;
using System.Windows.Forms;
using UbwTools.Common;
using UbwTools.Common.Gui;
using UbwTools.Properties;

namespace UbwTools.BFlagCalc
{
    public partial class BflagSimpleGuiForm : FormBase
    {
        public BflagSimpleGuiForm()
        {
            InitializeComponent();
            Icon = Resources.BFlagS;
            RestoreWindowInfo();
        }

        private void BflagGuiForm_Load(object sender, EventArgs e)
        {
            Int64 nValue = 1;
            this.BitList.BeginUpdate();
            for (int nBit = 0; nBit < 32; ++nBit)
            {
                ListViewItem item = this.BitList.Items.Add("");
                item.Tag = nValue;
                item.SubItems.Add(nBit.ToString());
                item.SubItems.Add(nValue.ToString());
                nValue *= 2;
            }
            this.BitList.EndUpdate();
            this.BitList.FocusedItem = this.BitList.Items[0];
            this.BitList.FocusedItem.Selected = true;
            this.BitList.ColumnWidthChanged += this.BitList_ColumnWidthChanged;
            this.EditDecimal.TextChanged += this.EditDecimal_TextChanged;
            this.Activate();
        }

        private void BflagGuiForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (new WaitingCursor())
            {
                SaveWindowInfo();
            }
        }

        private void menuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuHelpAbout_Click(object sender, EventArgs e)
        {
            AboutForm form = new AboutForm();
            form.ShowDialog(this);
        }

        private void menuHelpUsersGuide_Click(object sender, EventArgs e)
        {
            Util.OpenDocument(this, "UBW Tools - Brukermanual.pdf");
        }

        private void EditDecimal_Validated(object sender, EventArgs e)
        {
            Int64 nValue = Convert.ToInt64(this.EditDecimal.Text);
            this.ShowBits(nValue);
            this.EditDecimal.Text = nValue.ToString();
        }

        private void EditDecimal_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.EditDecimal.Text))
            {
                this.EditDecimal.Text = "0";
            }
            e.Cancel = this.BadNumber(this.EditDecimal.Text);
        }

        private void EditDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == 27)
                {
                    this.CloseApp();
                }
            }
            else
            {
                if (char.IsDigit(e.KeyChar))
                {
                    int nSelPos = this.EditDecimal.SelectionStart;
                    int nSelLen = this.EditDecimal.SelectionLength;
                    string sNumber = this.EditDecimal.Text.Substring(0, nSelPos) + e.KeyChar + this.EditDecimal.Text.Substring(nSelPos + nSelLen);
                    e.Handled = this.BadNumber(sNumber);
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void EditDecimal_TextChanged(object sender, EventArgs e)
        {
            Int64 nValue;
            try
            {
                nValue = Convert.ToInt64(this.EditDecimal.Text);
            }
            catch
            {
                nValue = 0;
            }
            this.ShowBits(nValue);
        }

        private void BitList_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            Int64 nValue = 0;
            foreach (ListViewItem item in this.BitList.Items)
            {
                if (item.Checked)
                {
                    nValue |= (Int64)item.Tag;
                }
            }
            this.EditDecimal.Text = nValue.ToString();
        }

        private void BitList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.CloseApp();
            }
        }

        private void BitList_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
        }

        private void BitList_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            this.BitList.ColumnWidthChanged -= BitList_ColumnWidthChanged;
            switch (e.ColumnIndex)
            {
                case 0: this.BitList.Columns[0].Width = 30; break;
                case 1: this.BitList.Columns[1].Width = 46; break;
                case 2: this.BitList.Columns[2].Width = 93; break;
            }
            this.BitList.ColumnWidthChanged += BitList_ColumnWidthChanged;
        }

        private void ShowBits(Int64 nValue)
        {
            this.BitList.ItemChecked -= BitList_ItemChecked;
            foreach (ListViewItem item in this.BitList.Items)
            {
                item.Checked = ((nValue & (Int64)item.Tag) != 0);
            }
            this.BitList.ItemChecked += BitList_ItemChecked;
        }

        private bool BadNumber(string sNumber)
        {
            bool bError = false;
            Int64 nValue = 0;
            try
            {
                nValue = Convert.ToInt64(sNumber);
            }
            catch
            {
                bError = true;
            }
            if (!bError)
            {
                if ((nValue < 0) || (nValue > 4294967295))
                {
                    bError = true;
                }
            }
            return bError;
        }

        private void CloseApp()
        {
            this.EditDecimal.Validating -= EditDecimal_Validating;
            this.EditDecimal.Validated -= EditDecimal_Validated;
            this.Close();
        }
    }
}
