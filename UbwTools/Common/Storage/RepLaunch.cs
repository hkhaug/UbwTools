namespace UbwTools.Common.Storage
{
    public class RepLaunch : RepBase
    {
        private static RepLaunch _instance;

        public static RepLaunch Instance
        {
            get { return _instance ?? (_instance = new RepLaunch()); }
        }

        private RepLaunch() : base(RepApp.Instance, "Launch")
        {
        }

        public RepLaunchDatabases Databases
        {
            get { return RepLaunchDatabases.Instance; }
        }

        public RepLaunchExternals Externals
        {
            get { return RepLaunchExternals.Instance; }
        }
    }
}
