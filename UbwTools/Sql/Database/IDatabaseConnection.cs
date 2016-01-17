using System.Collections.Generic;
using System.Data;

namespace UbwTools.Sql.Database
{
    public interface IDatabaseConnection
    {
        string Name { get; }
        string Description { get; }
        string EngineName { get; }
        string ServerName { get; }
        string UserName { get; }
        string Password { get; }
        string DataSourceDescription { get; }
        string DataSourceValue { get; }
        string DatabaseDescription { get; }
        string DatabaseValue { get; }
        DatabaseEngineType EngineType { get; }
        IDbConnection UnderlyingConnection { get; }
        bool Equals(IDatabaseConnection other);
        bool IsUbwDatabase { get; }
        string UbwDatabaseDescription { get; }
        IDbCommand CreateCommand();
        void Open();
        void Close();
        IEnumerable<string> GetAllTableNames();
        IEnumerable<string> GetAllViewNames();
        string GetTableColumnList(string tableName);
        string GetViewColumnList(string viewName);
        string GetCreateTableStatementNative(string tableName);
        string GetCreateTableStatementAsql(string tableName);
        string GetCreateViewStatementNative(string viewName);
        string GetCreateViewStatementAsql(string viewName);
    }
}
