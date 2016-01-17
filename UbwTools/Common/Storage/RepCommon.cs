namespace UbwTools.Common.Storage
{
    public class RepCommon : RepBase
    {
        private static RepCommon _instance;

        public static RepCommon Instance
        {
            get { return _instance ?? (_instance = new RepCommon()); }
        }

        private RepCommon() : base(RepApp.Instance, "Common")
        {
        }

        public RepCommonWindows Windows
        {
            get { return RepCommonWindows.Instance; }
        }
    }
}
