using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;

namespace UbwTools.Sql.Database
{
    public class SqlServerDatabaseConnection : DatabaseConnectionBase, IDatabaseConnection
    {
        private const string DefaultEngineName = "SQL Server";
        private const string DatasourcePrefix = "Server/instans";
        private const string DatabasePrefix = "Database";
        public string InstanceName { get; private set; }
        public string DatabaseName { get; private set; }
        public bool WindowsAuthentication { get; private set; }

        public SqlServerDatabaseConnection(string name, string description, string engineName, string serverName,
            string instanceName, string databaseName)
            : base(
                DatabaseEngineType.SqlServer, name, description, MakeEngineName(engineName), serverName, string.Empty,
                string.Empty, DatasourcePrefix, MakeDataSourceValue(serverName, instanceName), DatabasePrefix,
                databaseName)
        {
            InstanceName = instanceName;
            DatabaseName = databaseName;
            WindowsAuthentication = true;
        }

        public SqlServerDatabaseConnection(string name, string description, string engineName, string serverName,
            string instanceName, string databaseName, string userName, string password)
            : base(
                DatabaseEngineType.SqlServer, name, description, MakeEngineName(engineName), serverName, userName,
                password, DatasourcePrefix, MakeDataSourceValue(serverName, instanceName), DatabasePrefix,
                databaseName)
        {
            InstanceName = instanceName;
            DatabaseName = databaseName;
            WindowsAuthentication = false;
        }

        private static string MakeEngineName(string maybeAnEngineName)
        {
            return string.IsNullOrEmpty(maybeAnEngineName) ? DefaultEngineName : maybeAnEngineName;
        }

        private static string MakeDataSourceValue(string serverName, string instanceName)
        {
            return string.IsNullOrEmpty(instanceName) ? serverName : string.Format(@"{0}\{1}", serverName, instanceName);
        }

        protected override IDbConnection MakeUnderlyingConnection()
        {
            string dataSource = string.IsNullOrEmpty(InstanceName)
                ? ServerName
                : string.Format(@"{0}\{1}", ServerName, InstanceName);
            SqlConnectionStringBuilder bld = WindowsAuthentication
                ? new SqlConnectionStringBuilder
                {
                    DataSource = dataSource,
                    InitialCatalog = DatabaseName,
                    IntegratedSecurity = true
                }
                : new SqlConnectionStringBuilder
                {
                    DataSource = dataSource,
                    InitialCatalog = DatabaseName,
                    IntegratedSecurity = false,
                    UserID = UserName,
                    Password = Password
                };
            return new SqlConnection(bld.ConnectionString);
        }

        public bool Equals(IDatabaseConnection other)
        {
            if (Name != other.Name) return false;
            if (Description != other.Description) return false;
            if (EngineName != other.EngineName) return false;
            if (ServerName != other.ServerName) return false;
            if (EngineType != other.EngineType) return false;
            SqlServerDatabaseConnection typedOther = other as SqlServerDatabaseConnection;
            if (null == typedOther) return false;
            if (InstanceName != typedOther.InstanceName) return false;
            if (DatabaseName != typedOther.DatabaseName) return false;
            if (WindowsAuthentication != typedOther.WindowsAuthentication) return false;
            if (!WindowsAuthentication)
            {
                if (UserName != other.UserName) return false;
                if (Password != other.Password) return false;
            }
            return true;
        }

        protected override string GetAllTableNamesQuery()
        {
            return GetAllNamesQuery("BASE TABLE");
        }

        protected override string GetAllViewNamesQuery()
        {
            return GetAllNamesQuery("VIEW");
        }

        private string GetAllNamesQuery(string kind)
        {
            return string.Format("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = '{0}'", kind);
        }

        protected override string GetTableColumnListQuery(string tableName)
        {
            return GetColumnListQuery(tableName);
        }

        protected override string GetViewColumnListQuery(string viewName)
        {
            return GetColumnListQuery(viewName);
        }

        private string GetColumnListQuery(string name)
        {
            return string.Format("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}'", name);
        }

        const string Indent = "    ";

        public string GetCreateTableStatementNative(string tableName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("CREATE TABLE ");
            sb.AppendLine(tableName);
            sb.AppendLine("(");
            bool anyRows = false;
            SortedList<string, string> defaults = new SortedList<string, string>();
            bool wasClosed = (UnderlyingConnection.State != ConnectionState.Open);
            if (wasClosed)
            {
                UnderlyingConnection.Open();
            }
            StringBuilder cb = new StringBuilder();
            cb.Append("SELECT CHARACTER_MAXIMUM_LENGTH, COLUMN_DEFAULT, COLUMN_NAME, DATA_TYPE, DATETIME_PRECISION, IS_NULLABLE, NUMERIC_PRECISION, NUMERIC_SCALE ");
            cb.Append("FROM ");
            cb.Append("( ");
            cb.Append("    SELECT CHARACTER_MAXIMUM_LENGTH, COLUMN_DEFAULT, COLUMN_NAME, DATA_TYPE, DATETIME_PRECISION, IS_NULLABLE, NUMERIC_PRECISION, NUMERIC_SCALE, ");
            cb.Append("           CASE WHEN LOWER(COLUMN_NAME) = 'agrtid' THEN 1 ELSE 0 END AS seq ");
            cb.Append("    FROM INFORMATION_SCHEMA.COLUMNS ");
            cb.Append("    WHERE TABLE_NAME = '{0}' ");
            cb.Append(") z ");
            cb.Append("ORDER BY seq, COLUMN_NAME ");
            IDbCommand cmd = CreateCommand();
            cmd.CommandText = string.Format(cb.ToString(), tableName);
            using (IDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string colName = reader.GetString(2);
                    if (!reader.IsDBNull(1))
                    {
                        string defaultVal = reader.GetString(1);
                        defaults.Add(colName, defaultVal);
                    }
                    if (anyRows)
                    {
                        sb.AppendLine(",");
                    }
                    else
                    {
                        anyRows = true;
                    }
                    MakeNativeRow(sb, colName, reader);
                }
            }
            sb.AppendLine();
            sb.AppendLine(");");
            foreach (KeyValuePair<string, string> pair in defaults)
            {
                string column = pair.Key;
                string defaultVal = pair.Value;
                sb.Append("ALTER TABLE ");
                sb.Append(tableName);
                sb.Append(" ADD DEFAULT ");
                sb.Append(defaultVal);
                sb.Append(" FOR ");
                sb.Append(column);
                sb.AppendLine(";");
            }
            if (wasClosed)
            {
                UnderlyingConnection.Close();
            }
            return anyRows ? sb.ToString() : null;
        }

        private static void MakeNativeRow(StringBuilder sb, string colName, IDataRecord reader)
        {
            int charMaxLen = reader.IsDBNull(0) ? -1 : reader.GetInt32(0);
            string dataType = reader.GetString(3);
            int dateTimePrec = reader.IsDBNull(4) ? -1 : reader.GetInt16(4);
            bool nullable = ("YES" == reader.GetString(5));
            int numericPrec = reader.IsDBNull(6) ? -1 : reader.GetByte(6);
            int numericScale = reader.IsDBNull(7) ? -1 : reader.GetInt32(7);
            sb.Append(Indent);
            sb.Append(colName);
            sb.Append(' ');
            sb.Append(NativeType(dataType, charMaxLen, dateTimePrec, numericPrec, numericScale).ToUpper());
            if (!nullable)
            {
                sb.Append(" NOT");
            }
            sb.Append(" NULL");
        }

        private static string NativeType(string dataType, int charMaxLen, int dateTimePrec, int numericPrec, int numericScale)
        {
            string result;
            switch (dataType)
            {
                case "bigint":
                case "bit":
                case "date":
                case "datetime":
                case "float":
                case "geography":
                case "geometry":
                case "hierarchyid":
                case "image":
                case "int":
                case "money":
                case "ntext":
                case "real":
                case "smalldatetime":
                case "smallint":
                case "smallmoney":
                case "sql_variant":
                case "text":
                case "timestamp":
                case "tinyint":
                case "uniqueidentifier":
                case "xml":
                    result = dataType;
                    break;
                case "binary":
                case "char":
                case "nchar":
                    result = string.Format("{0}({1})", dataType, charMaxLen);
                    break;
                case "datetime2":
                case "datetimeoffset":
                case "time":
                    result = string.Format("{0}({1})", dataType, dateTimePrec);
                    break;
                case "decimal":
                case "numeric":
                    result = string.Format("{0}({1},{2})", dataType, numericPrec, numericScale);
                    break;
                case "nvarchar":
                case "varbinary":
                case "varchar":
                    result = string.Format("{0}({1})", dataType, (charMaxLen > 0) ? charMaxLen.ToString(CultureInfo.InvariantCulture) : "MAX");
                    break;
                default:
                    result = dataType;
                    break;
            }
            return result;
        }

        public string GetCreateViewStatementNative(string viewName)
        {
            bool wasClosed = (UnderlyingConnection.State != ConnectionState.Open);
            if (wasClosed)
            {
                UnderlyingConnection.Open();
            }
            IDbCommand cmd = CreateCommand();
            cmd.CommandText =
                string.Format("SELECT VIEW_DEFINITION FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = '{0}'", viewName);
            object obj = cmd.ExecuteScalar();
            if (wasClosed)
            {
                UnderlyingConnection.Close();
            }
            if (null != obj)
            {
                string view = obj.ToString();
                if (!string.IsNullOrWhiteSpace(view))
                {
                    string result = "-- Extracted from SQL Server INFORMATION_SCHEMA.VIEWS\r\n" + view;
                    return result;
                }
            }
            return null;
        }

        protected override List<AsqlColumnInfo> GetAsqlColumnInfo(string tableName)
        {
            bool wasClosed = (UnderlyingConnection.State != ConnectionState.Open);
            if (wasClosed)
            {
                UnderlyingConnection.Open();
            }
            List<AsqlColumnInfo> result = new List<AsqlColumnInfo>();
            IDbCommand cmd = CreateCommand();
            cmd.CommandText =
                string.Format(
                    "SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE, COLUMN_DEFAULT, DATETIME_PRECISION, IS_NULLABLE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}' ORDER BY COLUMN_NAME",
                    tableName);
            using (IDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string colName = reader.GetString(0);
                    string dataType = GetAsqlType(reader);
                    result.Add(new AsqlColumnInfo {Name = colName, DataType = dataType});
                }
            }
            if (wasClosed)
            {
                UnderlyingConnection.Close();
            }
            return result;
        }

        private static string GetAsqlType(IDataReader reader)
        {
            string baseType = reader.GetString(1);
            switch (baseType)
            {
                case "bigint":
                    return "int8";
                case "bit":
                    return "bool";
                case "char":
                case "nchar":
                case "nvarchar":
                case "varchar":
                    int strLen = reader.GetInt32(2);
                    return int.MaxValue == strLen ? string.Format("{0}(MAX)", baseType) : string.Format("{0}({1})", baseType, strLen);
                case "datetime":
                    return "date";
                case "decimal":
                case "numeric":
                    byte numPrecision = reader.GetByte(3);
                    int numScale = reader.GetInt32(4);
                    if ((15 == numPrecision) && (0 == numScale)) return "int";
                    if (28 == numPrecision)
                    {
                        if (3 == numScale) return "money";
                        if (8 == numScale) return "float";
                    }
                    return string.Format("** UNKNOWN ** MSSQL {0}({1},{2}) **", baseType, numPrecision, numScale);
                case "float":
                case "int":
                    return baseType;
                case "smallint":
                    return "int2";
                case "tinyint":
                    return "int1";
                case "money":
                    return "money";
                case "uniqueidentifier":
                    return "guid";
                case "varbinary":
                    return "image";
                default:
                    return string.Format("** UNKNOWN ** MSSQL {0} **", baseType);
            }
        }
    }
}
