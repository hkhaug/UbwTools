using System;
using System.Windows.Forms;
using UbwTools.Common.Gui;

namespace UbwTools.Sql.Gui
{
    public partial class SqlShortcutsForm : FormBase
    {
        public SqlShortcutsForm()
        {
            InitializeComponent();
            RestoreWindowInfo();
            FillList();
        }

        private void SqlShortcutsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveWindowInfo();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FillList()
        {
            for (int index = 0; index < 26; ++index)
            {
                char ch = (char) ('A' + index);
                ListViewItem item = list.Items.Add(ch.ToString());
                item.SubItems.Add(SqlCommon.Settings.SqlShortcuts[0, index]);
                item.SubItems.Add(SqlCommon.Settings.SqlShortcuts[1, index]);
            }
        }
    }
}
