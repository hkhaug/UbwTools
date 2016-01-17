using System;
using System.Collections.Generic;
using Microsoft.Win32;
using UbwTools.Sql.Database;

namespace UbwTools.Common.Storage
{
    public class RepSqlConnections : RepBase
    {
        private const string StorageConnectionName = "Connection name";
        private const string StorageDescription = "Description";
        private const string StorageEngineName = "Engine name";
        private const string StorageServerName = "Server name";
        private const string StorageEngineType = "Engine type";
        private const string StorageSidOrServiceName = "SID or service name";
        private const string StoragePort = "Port";
        private const string StorageInstanceName = "Instance name";
        private const string StorageDatabaseName = "Database name";
        private const string StorageUserName = "User name";
        private const string StoragePassword = "Password";
        private const string StorageAuthentication = "Authentication";
        private const string StorageWindows = "Windows";
        private const string StorageSqlServer = "SQL Server";

        private static RepSqlConnections _instance;

        public static RepSqlConnections Instance
        {
            get { return _instance ?? (_instance = new RepSqlConnections()); }
        }

        private RepSqlConnections() : base(RepSql.Instance, "Connections")
        {
        }

        public void ClearAndSave(IEnumerable<IDatabaseConnection> connections)
        {
            ClearAllSubkeys();
            int counter = 0;
            foreach (IDatabaseConnection connection in connections)
            {
                SaveOne(connection, ++counter);
            }
        }

        private void SaveOne(IDatabaseConnection connection, int counter)
        {
            string key = string.Format("{0:D3}", counter);
            RegistryKey item = Key.CreateSubKey(key);
            if (null != item)
            {
                item.SetValue(StorageConnectionName, connection.Name);
                item.SetValue(StorageDescription, connection.Description);
                item.SetValue(StorageEngineName, connection.EngineName);
                item.SetValue(StorageServerName, connection.ServerName);
                item.SetValue(StorageEngineType, DatabaseEngine.Name(connection.EngineType));
                switch (connection.EngineType)
                {
                    case DatabaseEngineType.SqlServer:
                        {
                            SqlServerDatabaseConnection typedConnection = connection as SqlServerDatabaseConnection;
                            if (null == typedConnection) throw new Exception("Intern feil");
                            item.SetValue(StorageInstanceName, typedConnection.InstanceName);
                            item.SetValue(StorageDatabaseName, typedConnection.DatabaseName);
                            item.SetValue(StorageAuthentication, typedConnection.WindowsAuthentication ? StorageWindows : StorageSqlServer);
                            if (!typedConnection.WindowsAuthentication)
                            {
                                item.SetValue(StorageUserName, connection.UserName);
                                item.SetValue(StoragePassword, connection.Password);
                            }
                            break;
                        }
                    case DatabaseEngineType.Oracle:
                        {
                            OracleDatabaseConnection typedConnection = connection as OracleDatabaseConnection;
                            if (null == typedConnection) throw new Exception("Intern feil");
                            item.SetValue(StorageSidOrServiceName, typedConnection.SidOrServiceName);
                            item.SetValue(StoragePort, typedConnection.Port);
                            item.SetValue(StorageUserName, connection.UserName);
                            item.SetValue(StoragePassword, connection.Password);
                            break;
                        }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public List<IDatabaseConnection> LoadAll()
        {
            List<IDatabaseConnection> result = new List<IDatabaseConnection>();
            IEnumerable<string> names = Key.GetSubKeyNames();
            foreach (string name in names)
            {
                IDatabaseConnection connection = LoadOne(name);
                if (null != connection)
                {
                    result.Add(connection);
                }
            }
            return result;
        }

        private IDatabaseConnection LoadOne(string keyName)
        {
            RegistryKey connectionKey = Key.OpenSubKey(keyName);
            if (null == connectionKey)
            {
                return null;
            }
            string connectionName = (string)connectionKey.GetValue(StorageConnectionName);
            string description = (string)connectionKey.GetValue(StorageDescription);
            string engineName = (string)connectionKey.GetValue(StorageEngineName);
            string serverName = (string)connectionKey.GetValue(StorageServerName);
            string engineTypeName = (string)connectionKey.GetValue(StorageEngineType);
            DatabaseEngineType engineType = DatabaseEngine.EngineType(engineTypeName);
            switch (engineType)
            {
                case DatabaseEngineType.SqlServer:
                    {
                        string instanceName = (string)connectionKey.GetValue(StorageInstanceName);
                        string databaseName = (string)connectionKey.GetValue(StorageDatabaseName);
                        string authentication = (string)connectionKey.GetValue(StorageAuthentication);
                        switch (authentication)
                        {
                            case StorageWindows:
                                return new SqlServerDatabaseConnection(connectionName, description, engineName, serverName,
                                    instanceName, databaseName);
                            case StorageSqlServer:
                                string userName = (string)connectionKey.GetValue(StorageUserName);
                                string password = (string)connectionKey.GetValue(StoragePassword);
                                return new SqlServerDatabaseConnection(connectionName, description, engineName, serverName,
                                    instanceName, databaseName, userName, password);
                            default:
                                throw new ArgumentOutOfRangeException(StorageAuthentication,
                                    string.Format(
                                        "Ugyldig konfigurasjonsverdi \"{0}\". Må være \"{1}\" eller \"{2}\". Gjelder koblingen \"{3}\".",
                                        authentication, StorageWindows, StorageSqlServer, connectionName));
                        }
                    }
                case DatabaseEngineType.Oracle:
                    {
                        string sidOrServiceName = (string)connectionKey.GetValue(StorageSidOrServiceName);
                        string port = (string)connectionKey.GetValue(StoragePort);
                        string userName = (string)connectionKey.GetValue(StorageUserName);
                        string password = (string)connectionKey.GetValue(StoragePassword);
                        return new OracleDatabaseConnection(connectionName, description, engineName, serverName, sidOrServiceName,
                            port, userName, password);
                    }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
