using System.Windows.Forms;
using PoorMansTSqlFormatterLib;
using UbwTools.Common;
using UbwTools.Sql.Database;

namespace UbwTools.Sql.Gui
{
    public abstract class NodeTableViewBase : NodeBase
    {
        public bool IsFavorite
        {
            get { return (this is NodeFavoriteTable) || (this is NodeFavoriteView); }
        }

        public bool IsDatabase
        {
            get { return (this is NodeDatabaseTable) || (this is NodeDatabaseView); }
        }

        private bool IsTable
        {
            get { return this is NodeTableBase; }
        }

        public bool IsView
        {
            get { return this is NodeViewBase; }
        }

        protected NodeTableViewBase(string tableName, int icon)
            : base(tableName, icon)
        {
        }

        public void DefaultAction(bool ctrl)
        {
            SelectStatementToEdit(ctrl);
        }

        public void Select(bool execute)
        {
            SelectStatementToEdit(execute);
        }

        public void Count()
        {
            CountStatementToEditAndExecute();
        }

        public void CopyName()
        {
            CopyToClipboard(Text);
        }

        public abstract void CopyColumnList(IDatabaseConnection connection);

        public abstract void CopyCreateNative(IDatabaseConnection connection);

        public abstract void CopyCreateAsql(IDatabaseConnection connection);

        public void PasteName()
        {
            PasteToEditArea(Text);
        }

        public abstract void PasteColumnList(IDatabaseConnection connection);

        public abstract void PasteCreateNative(IDatabaseConnection connection);

        public abstract void PasteCreateAsql(IDatabaseConnection connection);

        protected void CopyToClipboardButWarnIfEmpty(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                SayNotFoundInDatabase();
            }
            else
            {
                CopyToClipboard(str);
            }
        }

        protected void FormatAndCopyToClipboardButWarnIfEmpty(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                SayNotFoundInDatabase();
            }
            else
            {
                CopyToClipboard(SqlFormattingManager.DefaultFormat(str));
            }
        }

        protected void PasteToEditAreaButWarnIfEmpty(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                SayNotFoundInDatabase();
            }
            else
            {
                PasteToEditArea(str);
            }
        }

        protected void FormatAndPasteToEditAreaButWarnIfEmpty(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                SayNotFoundInDatabase();
            }
            else
            {
                PasteToEditArea(SqlFormattingManager.DefaultFormat(str));
            }
        }

        private void SayNotFoundInDatabase()
        {
            MessageBox.Show(SqlCommon.SqlForm, string.Format("{0} '{1}' finnes ikke i databasen.", IsTable ? "Tabellen" : "Viewet", Text), Global.FullTitle,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
