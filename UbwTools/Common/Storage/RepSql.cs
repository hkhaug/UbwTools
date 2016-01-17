namespace UbwTools.Common.Storage
{
    public class RepSql : RepBase
    {
        private static RepSql _instance;

        public static RepSql Instance
        {
            get { return _instance ?? (_instance = new RepSql()); }
        }

        private RepSql() : base(RepApp.Instance, "Sql")
        {
        }

        public RepSqlConnections Connections
        {
            get { return RepSqlConnections.Instance; }
        }

        public RepSqlData Data
        {
            get { return RepSqlData.Instance; }
        }

        public RepSqlFavorites Favorites
        {
            get { return RepSqlFavorites.Instance; }
        }
    }
}
