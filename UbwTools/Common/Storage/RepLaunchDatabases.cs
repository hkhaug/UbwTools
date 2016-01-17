namespace UbwTools.Common.Storage
{
    public class RepLaunchDatabases : RepBase
    {
        private static RepLaunchDatabases _instance;

        public static RepLaunchDatabases Instance
        {
            get { return _instance ?? (_instance = new RepLaunchDatabases()); }
        }

        private RepLaunchDatabases() : base(RepLaunch.Instance, "Databases")
        {
        }
    }
}
