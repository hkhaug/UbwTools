using System;
using System.Diagnostics;
using System.Windows.Forms;
using UbwTools.Common;

namespace UbwTools.Launch
{
    public class LaunchItemExternal : LaunchItemBase
    {
        public readonly string LaunchCmd;

        public LaunchItemExternal(string itemName, int iconId, string launchCmd)
            : base(GroupExecutables, itemName, iconId, "Kjør dette programmet eller åpne dette dokumentet.")
        {
            LaunchCmd = launchCmd;
        }

        public override bool DefaultAction(bool ctrl)
        {
            try
            {
                Process.Start(LaunchCmd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(LaunchCommon.LaunchForm,
                    string.Format("Klarer ikke å starte {0}:\r\n{1}", LaunchCmd, ex.Message), Global.FullTitle);
            }
            return false;
        }
    }
}
