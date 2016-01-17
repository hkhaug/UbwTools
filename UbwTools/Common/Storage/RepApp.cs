using Microsoft.Win32;

namespace UbwTools.Common.Storage
{
    public class RepApp : RepBase
    {
        private static RepApp _instance;

        public static RepApp Instance
        {
            get { return _instance ?? (_instance = new RepApp()); }
        }

        private RepApp() : base(Registry.CurrentUser, @"Software\UbwTools") {}
    }
}
