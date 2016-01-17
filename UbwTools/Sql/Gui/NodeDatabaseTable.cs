using System.Windows.Forms;

namespace UbwTools.Sql.Gui
{
    public sealed class NodeDatabaseTable : NodeTableBase
    {
        public NodeDatabaseTable(string tableName, ContextMenuStrip menu)
            : base(tableName)
        {
            ContextMenuStrip = menu;
        }
    }
}
