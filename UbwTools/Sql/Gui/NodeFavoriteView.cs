using System.Windows.Forms;

namespace UbwTools.Sql.Gui
{
    public sealed class NodeFavoriteView : NodeViewBase
    {
        public NodeFavoriteView(string viewName, ContextMenuStrip menu)
            : base(viewName)
        {
            ContextMenuStrip = menu;
        }
    }
}
