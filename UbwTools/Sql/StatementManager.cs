using PoorMansTSqlFormatterLib;
using UbwTools.Sql.Gui;

namespace UbwTools.Sql
{
    public class StatementManager
    {
        private static StatementManager _instance;
        public static StatementManager Instance
        {
            get { return _instance ?? (_instance = new StatementManager()); }
        }

        private StatementManager()
        {
        }

        public void InsertIntoSqlStatement(string text)
        {
            SqlCommon.SqlForm.textBoxSql.Paste(text);
            SqlCommon.SqlForm.textBoxSql.Focus();
        }

        public void SetEntireSqlStatement(string statement)
        {
            SqlCommon.SqlForm.textBoxSql.Text = string.IsNullOrWhiteSpace(statement) ? string.Empty : statement.Trim();
            SqlCommon.SqlForm.textBoxSql.DeselectAll();
            SqlCommon.SqlForm.textBoxSql.Focus();
        }

        public string GetEntireSqlStatement()
        {
            return SqlCommon.SqlForm.textBoxSql.Text.Trim();
        }

        public string GetSqlStatementForExecution()
        {
            return 0 < SqlCommon.SqlForm.textBoxSql.SelectionLength ? SqlCommon.SqlForm.textBoxSql.SelectedText.Trim() : SqlCommon.SqlForm.textBoxSql.Text.Trim();
        }

        public void FormatStatement()
        {
            string original = GetEntireSqlStatement();
            string formatted = SqlFormattingManager.DefaultFormat(original);
            SetEntireSqlStatement(formatted);
        }

        public void EditUndo()
        {
            SqlCommon.SqlForm.textBoxSql.Undo();
        }

        public void EditCut()
        {
            SqlCommon.SqlForm.textBoxSql.Cut();
        }

        public void EditCopy()
        {
            SqlCommon.SqlForm.textBoxSql.Copy();
        }

        public void EditPaste()
        {
            SqlCommon.SqlForm.textBoxSql.Paste();
        }

        public void EditDelete()
        {
            int pos = SqlCommon.SqlForm.textBoxSql.SelectionStart;
            string before = SqlCommon.SqlForm.textBoxSql.Text.Substring(0, SqlCommon.SqlForm.textBoxSql.SelectionStart);
            string after = SqlCommon.SqlForm.textBoxSql.Text.Substring(SqlCommon.SqlForm.textBoxSql.SelectionStart + SqlCommon.SqlForm.textBoxSql.SelectionLength);
            SqlCommon.SqlForm.textBoxSql.Text = before + after;
            SqlCommon.SqlForm.textBoxSql.SelectionStart = pos;
        }

        public void EditSelectAll()
        {
            SqlCommon.SqlForm.textBoxSql.SelectAll();
        }

        public void Drop(NodeTableViewBase node, bool rightDrag, int x, int y)
        {
            if (rightDrag)
            {
                SqlCommon.SqlForm.contextRightDrag.Tag = node;
                SqlCommon.SqlForm.contextRightDrag.Show(x, y);
            }
            else
            {
                node.PasteName();
            }
        }
    }
}
