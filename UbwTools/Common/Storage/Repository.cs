namespace UbwTools.Common.Storage
{
    public static class Repository
    {
        public static RepCommon Common
        {
            get { return RepCommon.Instance; }
        }

        public static RepLaunch Launch
        {
            get { return RepLaunch.Instance; }
        }

        public static RepSql Sql
        {
            get { return RepSql.Instance; }
        }
    }
}
