using UbwTools.Sql.Database;

namespace UbwTools.Sql.Gui
{
    public class NodeTableBase : NodeTableViewBase
    {
        protected NodeTableBase(string tableName)
            : base(tableName, SqlGuiForm.IconGrid)
        {
        }

        public override void CopyColumnList(IDatabaseConnection connection)
        {
            CopyToClipboardButWarnIfEmpty(connection.GetTableColumnList(Text));
        }

        public override void CopyCreateNative(IDatabaseConnection connection)
        {
            FormatAndCopyToClipboardButWarnIfEmpty(connection.GetCreateTableStatementNative(Text));
        }

        public override void CopyCreateAsql(IDatabaseConnection connection)
        {
            FormatAndCopyToClipboardButWarnIfEmpty(connection.GetCreateTableStatementAsql(Text));
        }

        public override void PasteColumnList(IDatabaseConnection connection)
        {
            PasteToEditAreaButWarnIfEmpty(connection.GetTableColumnList(Text));
        }

        public override void PasteCreateNative(IDatabaseConnection connection)
        {
            FormatAndPasteToEditAreaButWarnIfEmpty(connection.GetCreateTableStatementNative(Text));
        }

        public override void PasteCreateAsql(IDatabaseConnection connection)
        {
            FormatAndPasteToEditAreaButWarnIfEmpty(connection.GetCreateTableStatementAsql(Text));
        }
    }
}
