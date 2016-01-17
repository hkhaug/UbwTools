using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using UbwTools.Common.Gui;

namespace UbwTools.Common
{
    public static class Util
    {
        public static string PluralS(string singular, int number)
        {
//            return (1 == number) ? singular : singular + 's';
            return singular;
        }

        public static string CountOf(string singular, int number)
        {
            return string.Format("{0:N0} {1}", number, PluralS(singular, number));
        }

        public static string Rowcount(int numRows)
        {
            switch (numRows)
            {
                case 0:
                    return "Ingen rader";
                case 1:
                    return "1 rad";
                default:
                    return string.Format("{0:N0} rader", numRows);
            }
        }

        public static void OpenDocument(IWin32Window owner, string docName)
        {
            string docPath = Application.StartupPath + Path.DirectorySeparatorChar + docName;
            using (WaitingCursor waitingCursor = new WaitingCursor())
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(docPath);
                try
                {
                    Process.Start(startInfo);
                }
                catch (Exception ex)
                {
                    waitingCursor.StopWaiting();
                    MessageBox.Show(owner,
                        string.Format("Feil ved åpning av dokument:\r\n\r\n{0}\r\n\r\n{1}", docPath, ex.Message),
                        Global.FullTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static string IntListToString(IEnumerable<int> items)
        {
            StringBuilder itemStrings = new StringBuilder();
            bool comma = false;
            foreach (int itemValue in items)
            {
                if (comma)
                {
                    itemStrings.Append(',');
                }
                else
                {
                    comma = true;
                }
                itemStrings.Append(itemValue.ToString(CultureInfo.InvariantCulture));
            }
            return itemStrings.ToString();
        }

        public static IEnumerable<int> StringToIntList(string itemsStr)
        {
            List<int> result = new List<int>();
            string[] items = itemsStr.Split(',');
            foreach (string item in items)
            {
                int itemValue;
                if (!int.TryParse(item, NumberStyles.Integer, CultureInfo.InvariantCulture, out itemValue))
                {
                    itemValue = 0;
                }
                result.Add(itemValue);
            }
            return result;
        }
    }
}
