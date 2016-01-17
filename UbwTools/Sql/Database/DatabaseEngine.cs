using System;

namespace UbwTools.Sql.Database
{
    public enum DatabaseEngineType
    {
        SqlServer,
        Oracle
    };

    public static class DatabaseEngine
    {
        public const DatabaseEngineType DummyDatabaseEngineType = (DatabaseEngineType)(-1);
        public const string SqlServer = "SQL Server";
        public const string Oracle = "Oracle";

        public static string Name(DatabaseEngineType engineType)
        {
            switch (engineType)
            {
                case DatabaseEngineType.SqlServer:
                    return SqlServer;
                case DatabaseEngineType.Oracle:
                    return Oracle;
                default:
                    throw new ArgumentOutOfRangeException("engineType");
            }
        }

        public static DatabaseEngineType EngineType(string name)
        {
            switch (name)
            {
                case SqlServer:
                    return DatabaseEngineType.SqlServer;
                case Oracle:
                    return DatabaseEngineType.Oracle;
                default:
                    throw new ArgumentOutOfRangeException("name");
            }
        }
    }
}
