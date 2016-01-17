using System.Windows.Forms;

namespace UbwTools.Sql.Gui
{
    public sealed class NodeDatabaseView : NodeViewBase
    {
        public NodeDatabaseView(string viewName, ContextMenuStrip menu)
            : base(viewName)
        {
            ContextMenuStrip = menu;
        }
    }
}
