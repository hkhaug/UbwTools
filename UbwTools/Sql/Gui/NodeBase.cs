using System.Windows.Forms;

namespace UbwTools.Sql.Gui
{
    public abstract class NodeBase : TreeNode
    {
        protected NodeBase(string text, int icon)
            : base(text, icon, icon)
        {
        }

        protected NodeBase(string text, int icon, int selectedIcon)
            : base(text, icon, selectedIcon)
        {
        }

        protected void SelectStatementToEdit(bool execute)
        {
            StatementToEdit(string.Format("SELECT * FROM {0}", Text), execute);
        }

        protected void CountStatementToEditAndExecute()
        {
            StatementToEdit(string.Format("SELECT COUNT(*) FROM {0}", Text), true);
        }

        private void StatementToEdit(string statement, bool execute)
        {
            SqlCommon.Statements.SetEntireSqlStatement(statement);
            if (execute)
            {
                SqlCommon.Executor.ExecuteSqlStatements();
            }
        }

        protected void CopyToClipboard(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                Clipboard.Clear();
            }
            else
            {
                Clipboard.SetText(text);
            }
        }

        protected void PasteToEditArea(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                SqlCommon.Statements.InsertIntoSqlStatement(text);
            }
        }
    }
}
