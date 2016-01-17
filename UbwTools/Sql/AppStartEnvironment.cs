using System;
using UbwTools.Sql.Database;

namespace UbwTools.Sql
{
    public class AppStartEnvironment
    {
        public int EnvironmentId { get; private set; }
        public int CategoryId { get; private set; }
        public int ReleaseUpdateId { get; private set; }
        public int DatabaseVersionId { get; private set; }
        public string Title { get; private set; }
        public string ServerInstance { get; private set; }
        public string ConnectionInfo { get; private set; }
        public string DatabaseName { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public AppStartDatabaseVersion DbVersion { get; private set; }
        public string ServerName { get; private set; }
        public string InstanceName { get; private set; }
        public string SidOrServiceName { get; private set; }
        public string Port { get; private set; }

        public AppStartEnvironment(int environmentId, int categoryId, int releaseUpdateId, int databaseVersionId,
            string title, string serverInstance, string connectionInfo, string databaseName, string userName,
            string password, AppStartDatabaseVersion dbVersion)
        {
            EnvironmentId = environmentId;
            CategoryId = categoryId;
            ReleaseUpdateId = releaseUpdateId;
            DatabaseVersionId = databaseVersionId;
            Title = title;
            ServerInstance = serverInstance;
            ConnectionInfo = connectionInfo;
            DatabaseName = databaseName;
            UserName = userName;
            Password = password;
            DbVersion = dbVersion;
            switch (dbVersion.DbType)
            {
                case DatabaseEngineType.SqlServer:
                    int backslash = serverInstance.IndexOf('\\');
                    ServerName = 0 < backslash ? serverInstance.Substring(0, backslash) : serverInstance;
                    InstanceName = 0 < backslash ? serverInstance.Substring(backslash + 1) : string.Empty;
                    SidOrServiceName = string.Empty;
                    Port = string.Empty;
                    break;
                case DatabaseEngineType.Oracle:
                    int slash = serverInstance.IndexOf('/');
                    string serverAndPort = 0 < slash ? serverInstance.Substring(0, slash) : serverInstance;
                    SidOrServiceName = 0 < slash ? serverInstance.Substring(slash + 1) : string.Empty;
                    int colon = serverAndPort.IndexOf(':');
                    ServerName = 0 < colon ? serverAndPort.Substring(0, colon) : serverAndPort;
                    Port = 0 < colon ? serverAndPort.Substring(colon + 1) : "21";
                    InstanceName = string.Empty;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("dbVersion");
            }
        }
    }
}
