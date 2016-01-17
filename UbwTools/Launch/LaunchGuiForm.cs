using BrightIdeasSoftware;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using UbwTools.Common;
using UbwTools.Common.Gui;
using UbwTools.Properties;

namespace UbwTools.Launch
{
    public partial class LaunchGuiForm : FormBase
    {
        #region Private members

        private readonly QuickExternals _quickExternals = new QuickExternals();
        private readonly List<LaunchItemBase> _launchItems = new List<LaunchItemBase>();
        private readonly TypedObjectListView<LaunchItemBase> _list;

        #endregion Private members

        #region Private constants

        // Icon order here must match adding of images in LaunchForm_Load().
        // First, icons found in the resource dll, in same order.
        private const int IconBFlagSimple = 0;
        private const int IconBFlagAdvanced = 1;
        private const int IconNin = 2;
        public const int IconSql = 3;
        // Then other icons
        private const int IconUnknown = 4;
        private const int IconBatCmd = 5;

        #endregion Private constants

        public string NextSubapp { get; set; }

        public LaunchGuiForm()
        {
            InitializeComponent();
            Icon = Resources.Unit4;
            RestoreWindowInfo();
            _list = new TypedObjectListView<LaunchItemBase>(olv);
            LaunchCommon.LaunchForm = this;
        }

        private void LaunchForm_Load(object sender, EventArgs e)
        {
            Text = Global.FullTitle;
            images.Images.Add(Resources.BFlagS048);
            images.Images.Add(Resources.BFlagA048);
            images.Images.Add(Resources.NorIdNum048);
            images.Images.Add(Resources.Database048);
            images.Images.Add(Resources.Unknown048);
            images.Images.Add(Resources.BatCmd048);
            olvColumnName.ImageAspectName = "IconId";
            _list.CellToolTipGetter = (column, modelObject) => modelObject.Tooltip;
            this.olv.View = View.LargeIcon;
            PrepareLaunchItems();
            olv.SetObjects(_launchItems);
        }

        private void LaunchForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (new WaitingCursor())
            {
                SaveWindowInfo();
            }
        }

        private void menuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuHelpAbout_Click(object sender, EventArgs e)
        {
            AboutForm form = new AboutForm();
            form.ShowDialog(this);
        }

        private void menuHelpUsersGuide_Click(object sender, EventArgs e)
        {
            Util.OpenDocument(this, "UBW Tools - Brukermanual.pdf");
        }

        private void olv_BeforeCreatingGroups(object sender, CreateGroupsEventArgs e)
        {
            e.Parameters.GroupByColumn = new OLVColumn("Group", "GroupOrder")
            {
                AspectToStringConverter = AspectToStringConverter
            };
        }

        private void olv_CellRightClick(object sender, CellRightClickEventArgs e)
        {
            if (null != e.Item)
            {
                LaunchItemBase item = _list.SelectedObject;
                if ((null != item) && ((item is LaunchItemInternal) || (item is LaunchItemDatabase)))
                {
                    e.MenuStrip = contextItem;
                }
            }
        }

        private void olv_DoubleClick(object sender, EventArgs e)
        {
            LaunchSelected(Keys.Control == ModifierKeys);
        }

        private void olv_KeyPress(object sender, KeyPressEventArgs e)
        {
            char key = e.KeyChar;
            if ((key == 10) || (key == 13))
            {
                e.Handled = true;
                LaunchSelected(key == 10);
            }
        }

        private void contextItemLaunchReplace_Click(object sender, EventArgs e)
        {
            LaunchSelected(false);
        }

        private void contextItemLaunchNew_Click(object sender, EventArgs e)
        {
            LaunchSelected(true);
        }

        private void contextItemCreateShortcut_Click(object sender, EventArgs e)
        {
            LaunchItemBase item = _list.SelectedObject;
            if (null != item)
            {
                CreateDesktopShortcut(item);
            }
        }

        private static string AspectToStringConverter(object value)
        {
            int group = (int) value;
            switch (group)
            {
                case LaunchItemBase.GroupInternal:
                    return "Verktøy innebygget i UBW Tools";
                case LaunchItemBase.GroupDatabases:
                    return "Databaser";
                case LaunchItemBase.GroupExecutables:
                    return "Eksterne programmer og dokumenter";
                default:
                    return string.Format("Gruppe {0}", group);
            }
        }

        private void PrepareLaunchItems()
        {
            _launchItems.Clear();
            AddBuiltInLaunchItems();
            AddDatabaseItems();
            AddExternalItems();
        }

        private void AddBuiltInLaunchItems()
        {
            _launchItems.Add(new LaunchItemInternal("Enkel bflag-kalkulator", IconBFlagSimple,
                "Start dette verktøyet for å arbeide med bflag-verdier.", LaunchManager.IdBflagCalculatorSimple));
            _launchItems.Add(new LaunchItemInternal("Avansert bflag-kalkulator", IconBFlagAdvanced,
                "Start dette verktøyet for å arbeide med bflag-verdier.", LaunchManager.IdBflagCalculatorAdvanced));
            _launchItems.Add(new LaunchItemInternal("Norske identitetsnumre", IconNin,
                "Start dette verktøyet for å arbeide med norske identitetsnumre.",
                LaunchManager.IdNorwegianIdentityNumbers));
            _launchItems.Add(new LaunchItemInternal("Database", IconSql,
                "Start dette verktøyet for å arbeide med SQL databaser.", LaunchManager.IdDatabase));
        }

        private void AddDatabaseItems()
        {
            foreach (string name in LaunchCommon.Databases.Names)
            {
                _launchItems.Add(new LaunchItemDatabase(name, IconSql));
            }
        }

        private void AddExternalItems()
        {
            _quickExternals.LoadAll();
            foreach (QuickExternalItem item in _quickExternals.Items)
            {
                int imageId;
                if (null == item.Value)
                {
                    imageId = IconUnknown;
                }
                else
                {
                    MemoryStream ms = new MemoryStream(item.Value);
                    Bitmap bitmap = new Bitmap(ms);
                    imageId = images.Images.Count;
                    images.Images.Add(bitmap);
                }
                _launchItems.Add(new LaunchItemExternal(item.DisplayName, imageId, item.PathAndFilename));
            }
        }

        private void LaunchSelected(bool ctrl)
        {
            LaunchItemBase item = _list.SelectedObject;
            if (null != item)
            {
                bool closeThis = item.DefaultAction(ctrl);
                if (closeThis)
                {
                    Close();
                }
            }
        }

        private static void CreateDesktopShortcut(LaunchItemBase item)
        {
            LaunchItemInternal itemInternal = item as LaunchItemInternal;
            if (null != itemInternal)
            {
                CreateDesktopShortcut(itemInternal);
                return;
            }

            LaunchItemDatabase itemDatabase = item as LaunchItemDatabase;
            if (null != itemDatabase)
            {
                CreateDesktopShortcut(itemDatabase);
            }
        }

        private static void CreateDesktopShortcut(LaunchItemInternal itemInternal)
        {
            ShortcutMaker.Create(string.Format("{0} {1}", Global.ShortTitle, itemInternal.ItemName), itemInternal.IconId,
                Application.ExecutablePath, itemInternal.LaunchCmd);
        }

        private static void CreateDesktopShortcut(LaunchItemDatabase itemDatabase)
        {
            ShortcutMaker.Create(string.Format("{0} {1}", Global.ShortTitle, itemDatabase.ItemName),
                IconSql, Application.ExecutablePath,
                string.Format("{0} \"{1}\"", LaunchManager.IdDatabase, itemDatabase.ItemName));
        }

        private void olv_CanDrop(object sender, OlvDropEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void olv_Dropped(object sender, OlvDropEventArgs e)
        {
            string pathAndFilename = DragDropFile(e.DataObject);
            if (!string.IsNullOrWhiteSpace(pathAndFilename))
            {
                string extension = Path.GetExtension(pathAndFilename);
                if (string.IsNullOrEmpty(extension))
                {
                    UntypedFileDropped(pathAndFilename);
                }
                else
                {
                    TypedFileDropped(pathAndFilename, extension);
                }
            }
        }

        private void UntypedFileDropped(string pathAndFilename)
        {
            Bitmap bitmap = Get48X48BitmapFromFile(pathAndFilename);
            if (null == bitmap)
            {
                try
                {
                    bitmap = (Bitmap) Image.FromFile(pathAndFilename);
                }
                catch
                {
                }
            }
            FileDropped(pathAndFilename, bitmap);
        }

        private void TypedFileDropped(string pathAndFilename, string extension)
        {
            if ((extension.Equals(".BAT", StringComparison.OrdinalIgnoreCase)) ||
                (extension.Equals(".CMD", StringComparison.OrdinalIgnoreCase)))
            {
                FileDropped(pathAndFilename, IconBatCmd);
            }
            else
            {
                Bitmap bitmap = Get48X48BitmapFromFile(pathAndFilename) ?? Get48X48BitmapForExtension(extension);
                FileDropped(pathAndFilename, bitmap);
            }
        }

        private void FileDropped(string pathAndFilename, Bitmap bitmap)
        {
            int imageId;
            if (null == bitmap)
            {
                imageId = IconUnknown;
                _quickExternals.Add(pathAndFilename, null);
            }
            else
            {
                imageId = images.Images.Count;
                images.Images.Add(bitmap);
                _quickExternals.Add(pathAndFilename, bitmap);
            }
            FileDropped(pathAndFilename, imageId);
        }

        private void FileDropped(string pathAndFilename, int imageId)
        {
            _launchItems.Add(new LaunchItemExternal(Path.GetFileNameWithoutExtension(pathAndFilename), imageId,
                pathAndFilename));
            olv.SetObjects(_launchItems);
        }

        private static string DragDropFile(object dataObject)
        {
            string result = null;
            Array data = ((IDataObject) dataObject).GetData("FileNameW") as Array;
            if (null != data)
            {
                if ((1 == data.Length) && (data.GetValue(0) is string))
                {
                    result = ((string[]) data)[0];
                }
            }
            return result;
        }

        private static Bitmap Get48X48BitmapFromFile(string pathAndFilename)
        {
            Icon icon = IconSucker.GetFirstIconFromExe(pathAndFilename, 48);
            return null == icon ? null : icon.ToBitmap();
        }

        private static Bitmap Get48X48BitmapForExtension(string extension)
        {
            RegistryKey keyExtension = Registry.ClassesRoot.OpenSubKey(extension);
            if (null != keyExtension)
            {
                string fileTypeName = keyExtension.GetValue(string.Empty) as string;
                if (null != fileTypeName)
                {
                    RegistryKey fileTypeKey = Registry.ClassesRoot.OpenSubKey(fileTypeName);
                    if (null != fileTypeKey)
                    {
                        RegistryKey defaultIconKey = fileTypeKey.OpenSubKey("DefaultIcon");
                        if (null != defaultIconKey)
                        {
                            string iconPathAndNumber = defaultIconKey.GetValue(string.Empty) as string;
                            if (null != iconPathAndNumber)
                            {
                                int comma = iconPathAndNumber.LastIndexOf(',');
                                if (0 < comma)
                                {
                                    string pathAndFilename = iconPathAndNumber.Substring(0, comma);
                                    string iconNumberStr = iconPathAndNumber.Substring(comma + 1);
                                    int iconNumber;
                                    if (int.TryParse(iconNumberStr, out iconNumber))
                                    {
                                        Icon icon = IconSucker.GetNumberedIconFromExe(pathAndFilename, 48, iconNumber);
                                        return null == icon ? null : icon.ToBitmap();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }

        private void olv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                LaunchItemDatabase itemDatabase = _list.SelectedObject as LaunchItemDatabase;
                if (null != itemDatabase)
                {
                    LaunchCommon.Databases.Delete(itemDatabase.ItemName);
                    _launchItems.Remove(itemDatabase);
                    PrepareLaunchItems();
                    olv.SetObjects(_launchItems);
                    e.Handled = true;
                    return;
                }
                LaunchItemExternal itemExternal = _list.SelectedObject as LaunchItemExternal;
                if (null != itemExternal)
                {
                    _quickExternals.Delete(itemExternal.LaunchCmd);
                    PrepareLaunchItems();
                    olv.SetObjects(_launchItems);
                    e.Handled = true;
                }
            }
        }
    }
}
