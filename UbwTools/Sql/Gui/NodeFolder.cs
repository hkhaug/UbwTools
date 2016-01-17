namespace UbwTools.Sql.Gui
{
    public class NodeFolder : NodeBase
    {
        public NodeFolder(string folderName)
            : base(folderName, SqlGuiForm.IconFolderClosed, SqlGuiForm.IconFolderOpen)
        {
        }
    }
}
