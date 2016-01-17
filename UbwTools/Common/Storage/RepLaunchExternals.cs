namespace UbwTools.Common.Storage
{
    public class RepLaunchExternals : RepBase
    {
        private static RepLaunchExternals _instance;

        public static RepLaunchExternals Instance
        {
            get { return _instance ?? (_instance = new RepLaunchExternals()); }
        }

        private RepLaunchExternals() : base(RepLaunch.Instance, "Externals")
        {
        }
    }
}
