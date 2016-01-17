using System.Windows.Forms;

namespace UbwTools.Sql.Gui
{
    public sealed class NodeFavoriteTable : NodeTableBase
    {
        public NodeFavoriteTable(string tableName, ContextMenuStrip menu)
            : base(tableName)
        {
            ContextMenuStrip = menu;
        }
    }
}
