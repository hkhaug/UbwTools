using UbwTools.Common;

namespace UbwTools.Launch
{
    public class LaunchItemDatabase : LaunchItemBase
    {
        public LaunchItemDatabase(string itemName, int iconId)
            : base(GroupDatabases, itemName, iconId, "Start databaseverktøyet og koble til denne databasen.")
        {
        }

        public override bool DefaultAction(bool ctrl)
        {
            string launchCmd = string.Format("{0} {1}", LaunchManager.IdDatabase, ItemName);
            if (ctrl)
            {
                LaunchManager.Instance.LaunchNewInstance(launchCmd);
                return false;
            }
            LaunchCommon.LaunchForm.NextSubapp = launchCmd;
            return true;
        }
    }
}
