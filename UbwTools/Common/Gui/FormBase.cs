using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UbwTools.Common.Storage;

namespace UbwTools.Common.Gui
{
    public partial class FormBase : Form
    {
        public FormBase()
        {
            InitializeComponent();
        }

        protected void SaveWindowInfo()
        {
            List<int> formSizePos = new List<int>
            {
                WindowState == FormWindowState.Maximized ? 1 : 0,
                Location.X,
                Location.Y,
                Size.Width,
                Size.Height
            };
            StringBuilder sb = new StringBuilder();
            sb.Append(Util.IntListToString(formSizePos));
            sb.Append('|');
            sb.Append(Util.IntListToString(ScreenConfiguration()));
            sb.Append('|');
            sb.Append(GetFormData());
            Repository.Common.Windows.SetString(Name, sb.ToString());
        }

        protected void RestoreWindowInfo()
        {
            string savedInfo = Repository.Common.Windows.GetString(Name);
            if (string.IsNullOrEmpty(savedInfo)) return;
            string[] parts = savedInfo.Split('|');
            if (parts.Length < 2) return;
            int[] formSizePos = Util.StringToIntList(parts[0]).ToArray();
            if (formSizePos.Length != 5) return;
            string currentScreenConfigurationStr = Util.IntListToString(ScreenConfiguration());
            if (parts[1] == currentScreenConfigurationStr)
            {
                StartPosition = FormStartPosition.Manual;
                Location = new Point(formSizePos[1], formSizePos[2]);
                if (FormBorderStyle == FormBorderStyle.Sizable)
                {
                    Size = new Size(Math.Max(formSizePos[3], MinimumSize.Width),
                        Math.Max(formSizePos[4], MinimumSize.Height));
                }
            }
            else
            {
                Rectangle available = Screen.GetWorkingArea(this);
                StartPosition = FormStartPosition.WindowsDefaultLocation;
                if (FormBorderStyle == FormBorderStyle.Sizable)
                {
                    int w = Math.Max(Math.Min(available.Width, formSizePos[3]), MinimumSize.Width);
                    int h = Math.Max(Math.Min(available.Height, formSizePos[4]), MinimumSize.Height);
                    int x = Math.Min(Math.Max(0, formSizePos[1]), available.Width - w);
                    int y = Math.Min(Math.Max(0, formSizePos[2]), available.Height - h);
                    Location = new Point(x, y);
                    Size = new Size(w, h);
                }
                else
                {
                    int w = Math.Max(available.Width, MinimumSize.Width);
                    int h = Math.Max(available.Height, MinimumSize.Height);
                    int x = Math.Min(Math.Max(0, formSizePos[1]), available.Width - w);
                    int y = Math.Min(Math.Max(0, formSizePos[2]), available.Height - h);
                    Location = new Point(x, y);
                }
            }
            WindowState = formSizePos[0] == 0 ? FormWindowState.Normal : FormWindowState.Maximized;
            if (parts.Length > 2)
            {
                SetFormData(parts[2]);
            }
        }

        private IEnumerable<int> ScreenConfiguration()
        {
            List<int> result = new List<int>();
            foreach (Screen screen in Screen.AllScreens)
            {
                result.Add(screen.Primary ? 1 : 0);
                result.Add(screen.WorkingArea.Left);
                result.Add(screen.WorkingArea.Right);
                result.Add(screen.WorkingArea.Width);
                result.Add(screen.WorkingArea.Height);
            }
            return result;
        }

        protected virtual string GetFormData()
        {
            return string.Empty;
        }

        protected virtual void SetFormData(string data)
        {
        }
    }
}
