using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace UbwTools.Sql.Database
{
    public class OracleDatabaseConnection : DatabaseConnectionBase, IDatabaseConnection
    {
        private const string DefaultEngineName = "Oracle";
        public string SidOrServiceName { get; private set; }
        public string Port { get; private set; }

        public OracleDatabaseConnection(string name, string description, string engineName, string serverName,
            string sidOrServiceName, string port, string userName, string password)
            : base(
                DatabaseEngineType.Oracle, name, description,
                string.IsNullOrEmpty(engineName) ? DefaultEngineName : engineName, serverName, userName, password,
                "Server/tablespace", string.Format("{0}/{1}", serverName, sidOrServiceName), "Brukernavn", userName)
        {
            SidOrServiceName = sidOrServiceName;
            Port = port;
        }

        protected override IDbConnection MakeUnderlyingConnection()
        {
            string dataSource = string.Format("{0}:{1}/{2}", ServerName, Port, SidOrServiceName);
            OracleConnectionStringBuilder bld = new OracleConnectionStringBuilder
            {
                DataSource = dataSource,
                UserID = UserName,
                Password = Password
            };
            return new OracleConnection(bld.ConnectionString);
        }

        public bool Equals(IDatabaseConnection other)
        {
            if (Name != other.Name) return false;
            if (Description != other.Description) return false;
            if (EngineName != other.EngineName) return false;
            if (ServerName != other.ServerName) return false;
            if (EngineType != other.EngineType) return false;
            OracleDatabaseConnection typedOther = other as OracleDatabaseConnection;
            if (null == typedOther) return false;
            if (SidOrServiceName != typedOther.SidOrServiceName) return false;
            if (Port != typedOther.Port) return false;
            if (UserName != other.UserName) return false;
            if (Password != other.Password) return false;
            return true;
        }

        protected override string GetAllTableNamesQuery()
        {
            return GetAllNamesQuery("USER_TABLES", "TABLE_NAME");
        }

        protected override string GetAllViewNamesQuery()
        {
            return GetAllNamesQuery("USER_VIEWS", "VIEW_NAME");
        }

        private string GetAllNamesQuery(string kind, string column)
        {
            return string.Format("SELECT DISTINCT {0} FROM {1}", column, kind);
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
            return string.Format("SELECT COLUMN_NAME FROM USER_TAB_COLS WHERE UPPER(TABLE_NAME) = '{0}'", name.ToUpper());
        }

        const string Indent = "    ";

        public string GetCreateTableStatementNative(string tableName)
        {
            SortedList<string, NativeColumnInfo> columns = GetColumnInfo(tableName);
            if (0 == columns.Count)
            {
                return null;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("CREATE TABLE ");
            sb.AppendLine(tableName);
            sb.AppendLine("(");
            NativeColumnInfo agrtid = null;
            bool anyRows = false;
            foreach (KeyValuePair<string, NativeColumnInfo> pair in columns)
            {
                NativeColumnInfo column = pair.Value;
                if (Agrtid.Equals(column.Name, StringComparison.InvariantCultureIgnoreCase))
                {
                    agrtid = column;
                }
                else
                {
                    if (anyRows)
                    {
                        sb.AppendLine(",");
                    }
                    else
                    {
                        anyRows = true;
                    }
                    MakeNativeRow(sb, column);
                }
            }
            if (null != agrtid)
            {
                if (anyRows)
                {
                    sb.AppendLine(",");
                }
                MakeNativeRow(sb, agrtid);
            }
            sb.AppendLine();
            sb.AppendLine(");");
            return sb.ToString();
        }

        private void MakeNativeRow(StringBuilder sb, NativeColumnInfo column)
        {
            sb.Append(Indent);
            sb.Append(column.Name);
            sb.Append(' ');
            sb.Append(NativeType(column));
            if (!string.IsNullOrEmpty(column.Default))
            {
                sb.Append(" DEFAULT ");
                sb.Append(column.Default);
            }
            if (!column.Nullable)
            {
                sb.Append(" NOT");
            }
            sb.Append(" NULL");
        }

        public string GetCreateViewStatementNative(string viewName)
        {
            bool wasClosed = (UnderlyingConnection.State != ConnectionState.Open);
            if (wasClosed)
            {
                UnderlyingConnection.Open();
            }
            OracleCommand cmd = CreateCommand() as OracleCommand;
// ReSharper disable once PossibleNullReferenceException
            cmd.InitialLONGFetchSize = -1; // For a LONG column, the default setting of 0 means read 0 bytes. I'd rather read all bytes.
            cmd.CommandText =
                string.Format("SELECT TEXT FROM USER_VIEWS WHERE UPPER(VIEW_NAME) = '{0}'", viewName.ToUpper());
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
                    string result = "-- Extracted from Oracle USER_VIEWS\r\n" + view;
                    return result;
                }
            }
            return null;
        }

        private static string NativeType(NativeColumnInfo column)
        {
            string result;
            switch (column.DataType.ToLower())
            {
                case "bfile":
                case "blob":
                case "clob":
                case "date":
                case "double":
                case "float":
                case "int":
                case "integer":
                case "nclob":
                case "raw":
                case "real":
                case "rowid":
                case "smallint":
                case "timestamp":
                case "urowid":
                    result = column.DataType;
                    break;
                case "char":
                case "nchar":
                case "nvarchar2":
                case "varchar2":
                    result = string.Format("{0}({1})", column.DataType, column.Length);
                    break;
                case "dec":
                case "decimal":
                case "number":
                case "numeric":
                    result = string.Format("{0}({1},{2})", column.DataType, column.Precision, column.Scale);
                    break;
                default:
                    result = column.DataType;
                    break;
            }
            return result;
        }

        private SortedList<string, NativeColumnInfo> GetColumnInfo(string tableName)
        {
            SortedList<string, NativeColumnInfo> columns = new SortedList<string, NativeColumnInfo>();
            bool wasClosed = (UnderlyingConnection.State != ConnectionState.Open);
            if (wasClosed)
            {
                UnderlyingConnection.Open();
            }
            OracleCommand cmd = CreateCommand() as OracleCommand;
// ReSharper disable once PossibleNullReferenceException
            cmd.InitialLONGFetchSize = -1; // For a LONG column, the default setting of 0 means read 0 bytes. I'd rather read all bytes.
            cmd.CommandText =
                string.Format(
                    "SELECT COLUMN_NAME, DATA_TYPE, DATA_LENGTH, DATA_PRECISION, DATA_SCALE, DATA_DEFAULT, NULLABLE FROM USER_TAB_COLUMNS WHERE UPPER(TABLE_NAME) = '{0}' ORDER BY COLUMN_NAME",
                    tableName.ToUpper());
            using (OracleDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string columnName = reader.GetString(0).ToLower();
                    columns.Add(columnName, new NativeColumnInfo
                    {
                        Name = columnName,
                        DataType = reader.GetString(1),
                        Length = reader.GetInt32(2),
                        Precision = reader.IsDBNull(3) ? -1 : reader.GetInt32(3),
                        Scale = reader.IsDBNull(4) ? -1 : reader.GetInt32(4),
                        Default = reader.IsDBNull(5) ? null : reader.GetValue(5).ToString(),
                        Nullable = ("Y" == reader.GetString(6).ToUpper())
                    });
                }
            }
            if (wasClosed)
            {
                UnderlyingConnection.Close();
            }
            return columns;
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
                    "SELECT COLUMN_NAME, DATA_TYPE, DATA_LENGTH, DATA_PRECISION, DATA_SCALE FROM USER_TAB_COLUMNS WHERE UPPER(TABLE_NAME) = '{0}' ORDER BY COLUMN_NAME",
                    tableName.ToUpper());
            using (IDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string colName = reader.GetString(0);
                    string dataType = GetAsqlType(reader);
                    result.Add(new AsqlColumnInfo { Name = colName, DataType = dataType });
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
                case "BLOB":
                    return "image";
                case "CHAR":
                case "VARCHAR2":
                    int strLen = reader.GetInt32(2);
                    return int.MaxValue == strLen ? string.Format("{0}(MAX)", baseType) : string.Format("{0}({1})", baseType, strLen);
                case "CLOB":
                // TODO
                case "DATE":
                    return "date";
                case "NUMBER":
                    byte numPrecision = reader.GetByte(3);
                    int numScale = reader.GetInt32(4);
                    if (0 == numScale)
                    {
                        if (1 == numPrecision) return "bool";
                        if (3 == numPrecision) return "int1";
                        if (5 == numPrecision) return "int2";
                        if (9 == numPrecision) return "int4";
                        if (15 <= numPrecision) return "int8";
                    }
                    else if (3 == numScale) return "money";
                    else if (8 == numScale) return "float";
                    return string.Format("** UNKNOWN ** Oracle NUMBER({0},{1}) **", numPrecision, numScale);
                case "RAW":
                // TODO
                default:
                    return string.Format("** UNKNOWN ** Oracle {0} **", baseType);
            }
        }
    }
}
