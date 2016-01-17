using System.Windows.Forms;
using IWshRuntimeLibrary;
using System;
using System.IO;

namespace UbwTools.Common
{
    public static class ShortcutMaker
    {
        public static void Create(string name, int icon, string command, string parameters)
        {
            string link = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + Path.DirectorySeparatorChar + name + ".lnk";
            WshShell shell = new WshShell();
            IWshShortcut shortcut = shell.CreateShortcut(link) as IWshShortcut;
            if (null != shortcut)
            {
                shortcut.TargetPath = command;
                shortcut.Arguments = parameters;
                shortcut.IconLocation = string.Format(@"{0}\UbwToolsRes.dll,{1}", Application.StartupPath, icon);
                shortcut.Save();
            }
        }
    }
}
