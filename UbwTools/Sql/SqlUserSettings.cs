using System.Drawing;

namespace UbwTools.Sql
{
    public class SqlUserSettings
    {
        private static SqlUserSettings _instance;
        public static SqlUserSettings Instance
        {
            get { return _instance ?? (_instance = new SqlUserSettings()); }
        }

        private SqlUserSettings()
        {
        }

        public bool BeautifyColumnNames
        {
            get { return true; }
        }

        private readonly string[,] _sqlShortcuts =
        {
            {
                "AND ", "BETWEEN ", "CASE ", "DISTINCT ", "EXISTS ", "FROM ", "GROUP BY ", "HAVING ", "INNER ",
                "JOIN ", "", "LEFT ", "", "NOT ", "ORDER BY ", "OR ", "", "RIGHT ", "SELECT ",
                "THEN ", "UNION ", "VIEW ", "WHERE ", "WHEN ", "", ""
            },
            {
                "ALTER ", "BEGIN ", "COMMIT ", "DELETE ", "COALESCE ", "FULL ", "CREATE ", "DROP ", "INSERT INTO ",
                "INDEX ", "", "LIKE ", "MERGE ", "NULL ", "OVER ", "OUTER ", "", "ROLLBACK ",
                "TABLE ", "TRANSACTION ", "UPDATE ", "VALUES ", "WHEN ", "WITH ", "", ""
            }
        };

        public string[,] SqlShortcuts
        {
            get
            {
                return _sqlShortcuts;
            }
        }

        public Color CurrentControlColor
        {
            get { return Color.MintCream; }
        }
    }
}
