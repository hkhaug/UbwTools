using UbwTools.Sql.Database;

namespace UbwTools.Sql.Gui
{
    public class NodeViewBase : NodeTableViewBase
    {
        protected NodeViewBase(string tableName)
            : base(tableName, SqlGuiForm.IconView)
        {
        }

        public override void CopyColumnList(IDatabaseConnection connection)
        {
            CopyToClipboardButWarnIfEmpty(connection.GetViewColumnList(Text));
        }

        public override void CopyCreateNative(IDatabaseConnection connection)
        {
            FormatAndCopyToClipboardButWarnIfEmpty(connection.GetCreateViewStatementNative(Text));
        }

        public override void CopyCreateAsql(IDatabaseConnection connection)
        {
            FormatAndCopyToClipboardButWarnIfEmpty(connection.GetCreateViewStatementAsql(Text));
        }

        public override void PasteColumnList(IDatabaseConnection connection)
        {
            PasteToEditAreaButWarnIfEmpty(connection.GetViewColumnList(Text));
        }

        public override void PasteCreateNative(IDatabaseConnection connection)
        {
            FormatAndPasteToEditAreaButWarnIfEmpty(connection.GetCreateViewStatementNative(Text));
        }

        public override void PasteCreateAsql(IDatabaseConnection connection)
        {
            FormatAndPasteToEditAreaButWarnIfEmpty(connection.GetCreateViewStatementAsql(Text));
        }
    }
}
