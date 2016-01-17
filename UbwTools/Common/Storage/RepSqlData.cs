namespace UbwTools.Common.Storage
{
    public class RepSqlData : RepBase
    {
        private const string StorageStatements = "Statements";

        private static RepSqlData _instance;

        public static RepSqlData Instance
        {
            get { return _instance ?? (_instance = new RepSqlData()); }
        }

        private RepSqlData() : base(RepSql.Instance, "Data")
        {
        }

        public string Statements
        {
            get { return GetString(StorageStatements); }
            set { SetString(StorageStatements, value); }
        }
    }
}
