using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using UbwTools.Common;
using UbwTools.Common.Gui;
using UbwTools.Properties;

namespace UbwTools.BFlagCalc
{
    public partial class BflagAdvancedGuiForm : FormBase
    {
        private enum Originator { Bits, Dec, Hex, Bin };

        private bool _inShowAll;

        public BflagAdvancedGuiForm()
        {
            InitializeComponent();
            Icon = Resources.BFlagA;
            RestoreWindowInfo();
        }

        private void BflagAdvancedGuiForm_Load(object sender, EventArgs e)
        {
            Int64 nBitValue = 1;
            this.BitList.BeginUpdate();
            for (int nBit = 0; nBit < 32; ++nBit)
            {
                ListViewItem item = this.BitList.Items.Add("");
                item.Tag = nBitValue;
                item.SubItems.Add(nBit.ToString());
                item.SubItems.Add(nBitValue.ToString());
                nBitValue *= 2;
            }
            this.BitList.EndUpdate();
            this.BitList.FocusedItem = this.BitList.Items[0];
            this.BitList.FocusedItem.Selected = true;
            this.BitList.ColumnWidthChanged += BitList_ColumnWidthChanged;
            this.BitList.ItemChecked += this.BitList_ItemChecked;
            this.EditDecimal.TextChanged += this.EditDecimal_TextChanged;
            this.EditHexadecimal.TextChanged += this.EditHexadecimal_TextChanged;
            this.EditBinary.TextChanged += this.EditBinary_TextChanged;
        }

        private void BflagAdvancedGuiForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (new WaitingCursor())
            {
                SaveWindowInfo();
            }
        }

        private void menuFileExit_Click(object sender, EventArgs e)
        {
            CloseApp();
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

        #region Bitlist

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
            this.ShowAll(Originator.Bits, nValue);
        }

        private void BitList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.CloseApp();
            }
        }

        #endregion Bitlist

        #region EditDecimal

        private void EditDecimal_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.EditDecimal.Text))
            {
                this.EditDecimal.Text = "0";
            }
            e.Cancel = this.BadDecimal(this.EditDecimal.Text.Trim());
        }

        private void EditDecimal_Validated(object sender, EventArgs e)
        {
            Int64 nValue = Convert.ToInt64(this.EditDecimal.Text);
            this.ShowAll(Originator.Dec, nValue);
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
                    e.Handled = this.BadDecimal(sNumber);
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void EditDecimal_TextChanged(object sender, EventArgs e)
        {
            if (!this._inShowAll)
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
                this.ShowAll(Originator.Dec, nValue);
            }
        }

        #endregion EditDecimal

        #region EditHexadecimal

        private void EditHexadecimal_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.EditHexadecimal.Text))
            {
                this.EditHexadecimal.Text = "0";
            }
            e.Cancel = this.BadHexadecimal(this.EditHexadecimal.Text.Trim().ToUpper());
        }

        private void EditHexadecimal_Validated(object sender, EventArgs e)
        {
            Int64 nValue = Int64.Parse(this.EditHexadecimal.Text, System.Globalization.NumberStyles.HexNumber);
            this.ShowAll(Originator.Hex, nValue);
        }

        private void EditHexadecimal_KeyPress(object sender, KeyPressEventArgs e)
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
                if (char.IsDigit(e.KeyChar) || "ABCDEFabcdef".Contains(e.KeyChar))
                {
                    string s = "" + e.KeyChar;
                    int nSelPos = this.EditHexadecimal.SelectionStart;
                    int nSelLen = this.EditHexadecimal.SelectionLength;
                    string sNumber = this.EditHexadecimal.Text.Substring(0, nSelPos) + s.ToUpper() + this.EditHexadecimal.Text.Substring(nSelPos + nSelLen);
                    e.Handled = this.BadHexadecimal(sNumber);
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void EditHexadecimal_TextChanged(object sender, EventArgs e)
        {
            if (!this._inShowAll)
            {
                Int64 nValue;
                try
                {
                    nValue = Int64.Parse(this.EditHexadecimal.Text, System.Globalization.NumberStyles.HexNumber);
                }
                catch
                {
                    nValue = 0;
                }
                this.ShowAll(Originator.Hex, nValue);
            }
        }

        #endregion EditHexadecimal

        #region EditBinary

        private void EditBinary_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.EditBinary.Text))
            {
                this.EditBinary.Text = "0";
            }
            e.Cancel = this.BadBinary(this.EditBinary.Text.Trim());
        }

        private void EditBinary_Validated(object sender, EventArgs e)
        {
            Int64 nValue = BinToInt64(this.EditBinary.Text);
            this.ShowAll(Originator.Bin, nValue);
        }

        private void EditBinary_KeyPress(object sender, KeyPressEventArgs e)
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
                if ("01".Contains(e.KeyChar))
                {
                    int nSelPos = this.EditBinary.SelectionStart;
                    int nSelLen = this.EditBinary.SelectionLength;
                    string sNumber = this.EditBinary.Text.Substring(0, nSelPos) + e.KeyChar + this.EditBinary.Text.Substring(nSelPos + nSelLen);
                    e.Handled = this.BadBinary(sNumber);
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void EditBinary_TextChanged(object sender, EventArgs e)
        {
            if (!this._inShowAll)
            {
                Int64 nValue = BinToInt64(this.EditBinary.Text);
                this.ShowAll(Originator.Bin, nValue);
            }
        }

        #endregion EditBinary

        private void EditReadOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.CloseApp();
            }
        }

        #region Helpers

        private void ShowAll(Originator eOriginator, Int64 nValue)
        {
            this._inShowAll = true;
            if (eOriginator != Originator.Bits)
            {
                this.ShowBits(nValue);
            }
            if (eOriginator != Originator.Dec)
            {
                this.ShowDecimal(nValue);
            }
            if (eOriginator != Originator.Hex)
            {
                this.ShowHexadecimal(nValue);
            }
            if (eOriginator != Originator.Bin)
            {
                this.ShowBinary(nValue);
            }
            this.ShowSource(nValue);
            this._inShowAll = false;
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

        private void ShowDecimal(Int64 nValue)
        {
            this.EditDecimal.Text = nValue.ToString();
        }

        private void ShowHexadecimal(Int64 nValue)
        {
            this.EditHexadecimal.Text = string.Format("{0:X}", nValue);
        }

        private void ShowBinary(Int64 nValue)
        {
            this.EditBinary.Text = this.ToBinary(nValue);
        }

        private void ShowSource(Int64 nValue)
        {
            string sBitValues = this.BitValuesList(nValue);

            this.ShowSqlTestAllOff(nValue);
            this.ShowSqlTestAllOn(nValue);
            this.ShowSqlTestAnyOn(nValue);
            this.ShowSqlSetAllOff(sBitValues);
            this.ShowSqlSetAllOn(sBitValues);

            this.ShowCTestAllOff(sBitValues);
            this.ShowCTestAllOn(sBitValues);
            this.ShowCTestAnyOn(sBitValues);
            this.ShowCSetAllOff(sBitValues);
            this.ShowCSetAllOn(sBitValues);
        }

        private void ShowSqlTestAllOff(Int64 nValue)
        {
            this.EditSQLtestAllOff.Text = this.TestSql(nValue, "=", "AND");
        }

        private void ShowSqlTestAllOn(Int64 nValue)
        {
            this.EditSQLtestAllOn.Text = this.TestSql(nValue, "!=", "AND");
        }

        private void ShowSqlTestAnyOn(Int64 nValue)
        {
            this.EditSQLtestAnyOn.Text = this.TestSql(nValue, "!=", "OR");
        }

        private void ShowSqlSetAllOff(string sBitValues)
        {
            if (string.IsNullOrEmpty(sBitValues))
            {
                this.EditSQLsetAllOff.Clear();
            }
            else
            {
                this.EditSQLsetAllOff.Text = "n - " + sBitValues;
            }
        }

        private void ShowSqlSetAllOn(string sBitValues)
        {
            if (string.IsNullOrEmpty(sBitValues))
            {
                this.EditSQLsetAllOn.Clear();
            }
            else
            {
                this.EditSQLsetAllOn.Text = "n + " + sBitValues;
            }
        }

        private void ShowCTestAllOff(string sBitValues)
        {
            if (string.IsNullOrEmpty(sBitValues))
            {
                this.EditCtestAllOff.Clear();
            }
            else
            {
                this.EditCtestAllOff.Text = "n & " + sBitValues + " == 0";
            }
        }

        private void ShowCTestAllOn(string sBitValues)
        {
            if (string.IsNullOrEmpty(sBitValues))
            {
                this.EditCtestAllOn.Clear();
            }
            else
            {
                this.EditCtestAllOn.Text = "n & " + sBitValues + " == " + sBitValues;
            }
        }

        private void ShowCTestAnyOn(string sBitValues)
        {
            if (string.IsNullOrEmpty(sBitValues))
            {
                this.EditCtestAnyOn.Clear();
            }
            else
            {
                this.EditCtestAnyOn.Text = "n & " + sBitValues + " != 0";
            }
        }

        private void ShowCSetAllOff(string sBitValues)
        {
            if (string.IsNullOrEmpty(sBitValues))
            {
                this.EditCsetAllOff.Clear();
            }
            else
            {
                this.EditCsetAllOff.Text = "n &= ~" + sBitValues;
            }
        }

        private void ShowCSetAllOn(string sBitValues)
        {
            if (string.IsNullOrEmpty(sBitValues))
            {
                this.EditCsetAllOn.Clear();
            }
            else
            {
                this.EditCsetAllOn.Text = "n |= " + sBitValues;
            }
        }

        private string TestSql(Int64 nValue, string comparisonOp, string logicalOp)
        {
            string sResult = "";
            if (0 != nValue)
            {
                Int64 nBitValue = 1;
                for (int nBit = 0; nBit < 32; ++nBit)
                {
                    if ((nValue & nBitValue) != 0)
                    {
                        if (!string.IsNullOrEmpty(sResult))
                        {
                            sResult += logicalOp + ' ';
                        }
                        sResult += "MOD(n/" + nBitValue + ",2) " + comparisonOp + " 0 ";
                    }
                    nBitValue *= 2;
                }
            }
            return sResult.TrimEnd();
        }

        private string BitValuesList(Int64 nValue)
        {
            string sResult = "";
            bool bMultiple = false;
            Int64 nBitValue = 1;
            for (int nBit = 0; nBit < 32; ++nBit)
            {
                if ((nValue & nBitValue) != 0)
                {
                    if (!string.IsNullOrEmpty(sResult))
                    {
                        sResult += '+';
                        bMultiple = true;
                    }
                    sResult += nBitValue.ToString();
                }
                nBitValue *= 2;
            }
            if (bMultiple)
            {
                sResult = '(' + sResult + ')';
            }
            return sResult;
        }

        private bool BadDecimal(string sNumber)
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

        private bool BadHexadecimal(string sNumber)
        {
            bool bError = false;
            if (sNumber.Length > 8)
            {
                bError = true;
            }
            else
            {
                foreach (char ch in sNumber)
                {
                    if (!"0123456789ABCDEF".Contains(ch))
                    {
                        bError = true;
                        break;
                    }
                }
            }
            return bError;
        }

        private bool BadBinary(string sNumber)
        {
            bool bError = false;
            if (sNumber.Length > 32)
            {
                bError = true;
            }
            else
            {
                foreach (char ch in sNumber)
                {
                    if ((ch != '0') && (ch != '1'))
                    {
                        bError = true;
                        break;
                    }
                }
            }
            return bError;
        }

        private Int64 BinToInt64(string sValue)
        {
            int nPos = sValue.Length;
            Int64 nBitValue = 1;
            Int64 nValue = 0;
            while (nPos > 0)
            {
                --nPos;
                if ('1' == sValue[nPos])
                {
                    nValue |= nBitValue;
                }
                nBitValue *= 2;
            }
            return nValue;
        }

        private string ToBinary(Int64 nValue)
        {
            if (0 >= nValue)
            {
                return "0";
            }
            string result = "";
            Int64 nBitValue = 1;
            while (nValue > 0)
            {
                if (0 == (nValue & nBitValue))
                {
                    result = "0" + result;
                }
                else
                {
                    result = "1" + result;
                    nValue -= nBitValue;
                }
                nBitValue *= 2;
            }
            return result;
        }

        private void CloseApp()
        {
            this.EditBinary.Validating -= this.EditBinary_Validating;
            this.EditBinary.Validated -= this.EditBinary_Validated;
            this.EditHexadecimal.Validating -= this.EditHexadecimal_Validating;
            this.EditHexadecimal.Validated -= this.EditHexadecimal_Validated;
            this.EditDecimal.Validating -= this.EditDecimal_Validating;
            this.EditDecimal.Validated -= this.EditDecimal_Validated;
            this.Close();
        }

        #endregion
    }
}
