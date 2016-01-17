namespace UbwTools.Launch
{
    public static class LaunchCommon
    {
        public static LaunchGuiForm LaunchForm { get; set; }

        private static QuickDatabases _databases;
        public static QuickDatabases Databases
        {
            get { return _databases ?? (_databases = new QuickDatabases()); }
        }
    }
}
