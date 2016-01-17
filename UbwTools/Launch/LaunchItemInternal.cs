using UbwTools.Common;

namespace UbwTools.Launch
{
    public class LaunchItemInternal : LaunchItemBase
    {
        public readonly string LaunchCmd;

        public LaunchItemInternal(string itemName, int iconId, string tooltip, string launchCmd)
            : base(GroupInternal, itemName, iconId, tooltip)
        {
            LaunchCmd = launchCmd;
        }

        public override bool DefaultAction(bool ctrl)
        {
            if (ctrl)
            {
                LaunchManager.Instance.LaunchNewInstance(LaunchCmd);
                return false;
            }
            LaunchCommon.LaunchForm.NextSubapp = LaunchCmd;
            return true;
        }
    }
}
