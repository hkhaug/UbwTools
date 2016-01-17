namespace UbwTools.Common.Storage
{
    public class RepCommonWindows : RepBase
    {
        private static RepCommonWindows _instance;

        public static RepCommonWindows Instance
        {
            get { return _instance ?? (_instance = new RepCommonWindows()); }
        }

        private RepCommonWindows() : base(RepCommon.Instance, "Windows")
        {
        }
    }
}
