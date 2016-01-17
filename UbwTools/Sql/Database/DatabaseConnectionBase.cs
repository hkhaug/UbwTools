using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace UbwTools.Sql.Database
{
    public abstract class DatabaseConnectionBase
    {
        protected const string Agrtid = "agrtid";
        public DatabaseEngineType EngineType { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string EngineName { get; private set; }
        public string ServerName { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string DataSourceDescription { get; private set; }
        public string DataSourceValue { get; private set; }
        public string DatabaseDescription { get; private set; }
        public string DatabaseValue { get; private set; }
        public bool IsUbwDatabase { get; private set; }
        public string UbwDatabaseDescription { get; private set; }

        private IDbConnection _underlyingConnection;
        public IDbConnection UnderlyingConnection
        {
            get { return _underlyingConnection ?? (_underlyingConnection = MakeUnderlyingConnection()); }
        }

        protected DatabaseConnectionBase(DatabaseEngineType engineType, string name, string description,
            string engineName, string serverName, string userName, string password, string dataSourceDescription,
            string dataSourceValue, string databaseDescription, string databaseValue)
        {
            EngineType = engineType;
            Name = name;
            Description = description;
            EngineName = engineName;
            ServerName = serverName;
            UserName = userName;
            Password = password;
            DataSourceDescription = dataSourceDescription;
            DataSourceValue = dataSourceValue;
            DatabaseDescription = databaseDescription;
            DatabaseValue = databaseValue;
        }

        protected abstract IDbConnection MakeUnderlyingConnection();

        public IDbCommand CreateCommand()
        {
            return UnderlyingConnection.CreateCommand();
        }

        public void Open()
        {
            if (UnderlyingConnection.State != ConnectionState.Open)
            {
                UnderlyingConnection.Open();
                CheckForUbwDatabase();
            }
        }

        public void Close()
        {
            UnderlyingConnection.Close();
        }

        private bool _ubwDatabaseChecked;

        private void CheckForUbwDatabase()
        {
            if (_ubwDatabaseChecked) return;

            _ubwDatabaseChecked = true;
            IDbCommand cmd = CreateCommand();
            cmd.CommandText = "SELECT number1, number3 FROM asyssetup WHERE name = 'BASE_VERSION'";
            try
            {
                IDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    int major = reader.GetInt32(0);
                    int minor = reader.GetInt32(1);
                    string version;
                    switch (major)
                    {
                        case 550:
                            version = "553";
                            break;
                        case 560:
                            version = "Milestone 3";
                            break;
                        case 570:
                            version = "Milestone 4";
                            break;
                        default:
                            version = string.Format("Unknown ({0})", major);
                            break;
                    }
                    string update = (minor > 0) ? string.Format(" Update {0}", minor) : string.Empty;
                    UbwDatabaseDescription = version + update;
                    IsUbwDatabase = true;
                }
            }
            catch
            {
                UbwDatabaseDescription = null;
                IsUbwDatabase = false;
            }
        }

        public IEnumerable<string> GetAllTableNames()
        {
            string query = GetAllTableNamesQuery();
            return GetAllNames(query);
        }

        protected abstract string GetAllTableNamesQuery();

        public IEnumerable<string> GetAllViewNames()
        {
            string query = GetAllViewNamesQuery();
            return GetAllNames(query);
        }

        protected abstract string GetAllViewNamesQuery();

        private IEnumerable<string> GetAllNames(string query)
        {
            bool wasClosed = (UnderlyingConnection.State != ConnectionState.Open);
            if (wasClosed)
            {
                UnderlyingConnection.Open();
            }
            List<string> result = new List<string>();
            IDbCommand cmd = CreateCommand();
            cmd.CommandText = query;
            using (IDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(reader.GetString(0).ToLower());
                }
                result.Sort();
            }
            if (wasClosed)
            {
                UnderlyingConnection.Close();
            }
            return result;
        }

        protected abstract string GetTableColumnListQuery(string tableName);

        public string GetTableColumnList(string tableName)
        {
            string query = GetTableColumnListQuery(tableName);
            return GetColumnList(query);
        }

        protected abstract string GetViewColumnListQuery(string viewName);

        public string GetViewColumnList(string viewName)
        {
            string query = GetViewColumnListQuery(viewName);
            return GetColumnList(query);
        }

        private string GetColumnList(string query)
        {
            bool wasClosed = (UnderlyingConnection.State != ConnectionState.Open);
            if (wasClosed)
            {
                UnderlyingConnection.Open();
            }
            List<string> columns = new List<string>();
            IDbCommand cmd = CreateCommand();
            cmd.CommandText = query;
            using (IDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    columns.Add(reader.GetString(0).ToLowerInvariant());
                }
            }
            if (wasClosed)
            {
                UnderlyingConnection.Close();
            }
            columns.Sort();
            StringBuilder sb = new StringBuilder();
            bool anyColumns = false;
            bool agrtidColumn = false;
            foreach (string column in columns)
            {
                if (Agrtid == column)
                {
                    agrtidColumn = true;
                }
                else
                {
                    if (anyColumns)
                    {
                        sb.Append(", ");
                    }
                    else
                    {
                        anyColumns = true;
                    }
                    sb.Append(column);
                }
            }
            if (agrtidColumn)
            {
                if (anyColumns)
                {
                    sb.Append(", ");
                }
                sb.Append(Agrtid);
            }
            return sb.ToString();
        }

        public string GetCreateTableStatementAsql(string tableName)
        {
            List<AsqlColumnInfo> columns = GetAsqlColumnInfo(tableName);
            if (0 == columns.Count)
            {
                return null;
            }
            AsqlBuilder ab = new AsqlBuilder();
            BuildAsqlCreateHeader(ab, tableName);
            BuildAsqlCreateLines(ab, columns);
            BuildAsqlCreateFooter(ab);
            return ab.ToString();
        }

        private void BuildAsqlCreateHeader(AsqlBuilder ab, string tableName)
        {
            ab.SlashLine("on error exit");
            ab.SlashLine("define oldtabloc ident(50)");
            ab.IndentWrite("if not exists ");
            ab.SlashLine(tableName);
            ab.IncIndent();
            ab.SlashLine("begin sqlserver");
            ab.IncIndent();
            ab.IndentWriteLine("select distinct s.groupname into :oldtabloc");
            ab.IncIndent();
            ab.IndentWriteLine("from sysobjects t, sysindexes i, sysfilegroups s, syscolumns c");
            ab.IndentWriteLine("where t.type = 'U'");
            ab.IndentWriteLine("and t.id = c.id");
            ab.IndentWriteLine("and t.id = i.id");
            ab.IndentWriteLine("and (i.indid=0 OR i.indid=1)");
            ab.IndentWriteLine("and i.groupid = s.groupid");
            ab.IndentWrite("and t.name = '");
            ab.Write(tableName);
            ab.WriteLine("'");
            ab.DecIndent();
            ab.SlashLine();
            ab.DecIndent();
            ab.SlashLine("end /* sqlserver */");
            ab.SlashLine("begin oracle");
            ab.IncIndent();
            ab.IndentWriteLine("select tablespace_name into :oldtabloc");
            ab.IncIndent();
            ab.IndentWriteLine("from user_tables");
            ab.IndentWrite("where LOWER(table_name) = '");
            ab.Write(tableName);
            ab.WriteLine("'");
            ab.DecIndent();
            ab.SlashLine();
            ab.DecIndent();
            ab.SlashLine("end /* oracle */");
            ab.IndentWrite("create table ");
            ab.Write(tableName);
            ab.WriteLine(" (");
            ab.IncIndent();
        }

        protected abstract List<AsqlColumnInfo> GetAsqlColumnInfo(string tableName);

        private void BuildAsqlCreateLines(AsqlBuilder ab, List<AsqlColumnInfo> columns)
        {
            bool anyRows = false;
            columns.Sort((left, right) => String.Compare(left.Name, right.Name, StringComparison.Ordinal));
            int maxNameLength = columns.Max(x => x.Name.Length);
            foreach (AsqlColumnInfo column in columns)
            {
                if (column.Name != "agrtid")
                {
                    if (anyRows)
                    {
                        ab.WriteLine(",");
                    }
                    else
                    {
                        anyRows = true;
                    }
                    ab.IndentWrite(column.Name);
                    ab.Write(new string(' ', maxNameLength - column.Name.Length + 1));
                    ab.Write(column.DataType);
                }
            }
        }

        private void BuildAsqlCreateFooter(AsqlBuilder ab)
        {
            ab.WriteLine(")");
            ab.DecIndent();
            ab.SlashLine("tabspace = :oldtabloc");
            ab.DecIndent();
            ab.SlashLine("end if");
        }

        public string GetCreateViewStatementAsql(string viewName)
        {
            const string mssqlId = "mssql";
            const string oracleId = "oracle";
            string generalQuery = null;
            string mssqlQuery = null;
            string oracleQuery = null;
            int variationsFound = 0;
            bool wasClosed = (UnderlyingConnection.State != ConnectionState.Open);
            if (wasClosed)
            {
                UnderlyingConnection.Open();
            }
            IDbCommand cmd = CreateCommand();
            cmd.CommandText =
                string.Format("SELECT db_name, query FROM asysview WHERE table_name = '{0}' AND status = 'N' AND db_name IN ('', '{1}', '{2}') ORDER BY db_name", viewName, mssqlId, oracleId);
            using (IDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string dbName = reader.GetString(0);
                    string query = reader.GetString(1);
                    if (!string.IsNullOrWhiteSpace(query))
                    {
                        switch (dbName)
                        {
                            case mssqlId:
                                mssqlQuery = query;
                                break;
                            case oracleId:
                                oracleQuery = query;
                                break;
                            default:
                                generalQuery = query;
                                break;
                        }
                        ++variationsFound;
                    }
                }
            }
            if (wasClosed)
            {
                UnderlyingConnection.Close();
            }
            if (0 < variationsFound)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("-- Extracted from asysview");
                if (!string.IsNullOrWhiteSpace(generalQuery))
                {
                    sb.AppendLine();
                    sb.AppendLine("-- Statement valid for both SQL Server and Oracle databases:");
                    sb.Append(generalQuery);
                }
                if (!string.IsNullOrWhiteSpace(mssqlQuery))
                {
                    sb.AppendLine();
                    sb.AppendLine("-- SQL Server specific statement:");
                    sb.Append(mssqlQuery);
                }
                if (!string.IsNullOrWhiteSpace(oracleQuery))
                {
                    sb.AppendLine();
                    sb.AppendLine("-- Oracle specific statement:");
                    sb.Append(oracleQuery);
                }
                return sb.ToString();
            }
            return null;
        }
    }
}
/*

define oldtabloc ident(50)
/

if not exists apsnoabslog
/
	begin sqlserver
	/
		select distinct s.groupname into :oldtabloc
				   from sysobjects t, sysindexes i, sysfilegroups s, syscolumns c
				  where t.type = 'U'
					and t.id   = c.id
					and t.id   = i.id
					and (i.indid=0 OR i.indid=1)
					and i.groupid = s.groupid
					and t.name = 'acrclient'
		/
	end
	/

	begin oracle
	/
		select tablespace_name into :oldtabloc
			from user_tables
			where LOWER(table_name) = 'acrclient'
		/
	end
	/

	create table apsnoabslog (
		abs_id				int			,
		abs_seq				int			,
		absence_code		vchar(25)	,
		account				vchar(25)	,
		amount				money		,
		amount_1			money		,
		amount_2			money		,
		amount_3			money		,
		amount_4			money		,
		amount_5			money		,
		amount_6			money		,
		amount_7			money		,
		amount_8			money		,
		amount_9			money		,
		amount_10			money		,
		amount_11			money		,
		amount_12			money		,
		amount_13			money		,
		apar_id				vchar(25)	,
		apar_name			vchar(255)	,
		apar_type			vchar(1)	,
		att_1_id			vchar(4)	,
		att_2_id			vchar(4)	,
		att_3_id			vchar(4)	,
		att_4_id			vchar(4)	,
		att_5_id			vchar(4)	,
		att_6_id			vchar(4)	,
		att_7_id			vchar(4)	,
		attribute_id		vchar(4)	,
		base_period			int			,
		bflag				int			,
		bflag2				int			,
		bflag3				int			,
		claim_no			int8		,
		client				vchar(25)	,
		column_1			vchar(25)	,
		column_2			vchar(25)	,
		column_3			vchar(25)	,
		column_4			vchar(25)	,
		column_5			vchar(25)	,
		column_6			vchar(25)	,
		consultant			vchar(255)	,
		consultant_phone	vchar(35)	,
		date_col1			date		,
		date_col2			date		,
		date_col3			date		,
		date_col4			date		,
		date_col5			date		,
		date_col6			date		,
		date_col7			date		,
		date_col8			date		,
		date_col9			date		,
		date_col10			date		,
		date_from			date		,
		date_to				date		,
		ded_amount_1		money		,
		ded_amount_2		money		,
		ded_amount_3		money		,
		ded_amount_4		money		,
		ded_amount_5		money		,
		description			vchar(255)	,
		dim_1				vchar(25)	,
		dim_2				vchar(25)	,
		dim_3				vchar(25)	,
		dim_4				vchar(25)	,
		dim_5				vchar(25)	,
		dim_6				vchar(25)	,
		dim_7				vchar(25)	,
		dim_value			vchar(25)	,
		last_update			date		,
		m_date				date		,
		municipal			vchar(25)	,
		municipal2			vchar(25)	,
		no_of_days			int			,
		number_1			int			,
		number2				int			,
		number3				int			,
		parttime_pct		float		,
		pay_amount_1		money		,
		pay_amount_2		money		,
		pay_amount_3		money		,
		pay_amount_4		money		,
		pay_amount_5		money		,
		pd					vchar(25)	,
		percentage			float		,
		period				int			,
		period_2			int			,
		post_id				vchar(25)	,
		rate_1				money		,
		rate_2				money		,
		rate_3				money		,
		rate_4				money		,
		rate_5				money		,
		rate_bflag			int			,
		recalc				int			,
		record_type			vchar(12)	,
		reimb_type			vchar(2)	,
		rel_attr_id			vchar(4)	,
		resource_id			vchar(25)	,
		rest_amount			money		,
		sequence_no			int			,
		sequence_no2		int			,
		social_sec			vchar(20)	,
		status				vchar(1)	,
		status_2			vchar(1)	,
		supplier_id_1		vchar(25)	,
		supplier_id_2		vchar(25)	,
		supplier_id_3		vchar(25)	,
		supplier_id_4		vchar(25)	,
		supplier_id_5		vchar(25)	,
		supplier_id_6		vchar(25)	,
		supplier_id_7		vchar(25)	,
		supplier_name_1		vchar(255)	,
		supplier_name_2		vchar(255)	,
		supplier_name_3		vchar(255)	,
		supplier_name_4		vchar(255)	,
		supplier_name_5		vchar(255)	,
		supplier_name_6		vchar(255)	,
		supplier_name_7		vchar(255)	,
		tax_number			vchar(25)	,
		tax_pct				float		,
		text1				vchar(100)	,
		text2				vchar(100)	,
		text3				vchar(100)	,
		trans_id			int8		,
		user_id				vchar(25)	,
		value_1				float		,
		value_2				float		,
		value_3				float		,
		value_4				float		,
		value_5				float		,
		value_6				float		,
		value_7				float		,
		value_8				float		,
		value_9				float		,
		value_10			float		,
		value_11			float		,
		value_12			float		,
		value_13			float		,
		voucher_no			int8		,
		voucher_no2			int8		,
		voucher_type		vchar(25)	)
    tabspace = :oldtabloc
    /

	create index aiapsnoabslog1 on apsnoabslog (client, resource_id, absence_code, date_from, date_to)
	/
	create index aiapsnoabslog2 on apsnoabslog (client, resource_id, claim_no, status)
	/
	create index aiapsnoabslog3 on apsnoabslog (client, resource_id, voucher_no, apar_id, status)
	/
end if
/

if exists apsnoabslog
/
  if not exists apsnoabslog consultant
  /
    begin oracle
    /
      alter table apsnoabslog add (consultant varchar2(255) default ' ' not null,
                                   consultant_phone varchar2(35) default ' ' not null)
      /
    end
    /
    begin sqlserver
    /
      alter table apsnoabslog add consultant varchar(255) default ' ' not null,
                                  consultant_phone varchar(35) default ' ' not null
      /
    end
    /
  /
  end 
  /
  if not exists apsnoabslog status_gl07
  /
    begin oracle
    /
      alter table apsnoabslog add status_gl07 varchar(1) default ' ' not null
      /
    end
    /
    begin sqlserver
    /
      alter table apsnoabslog add status_gl07 varchar(1) default ' ' not null
      /
    end
  /
  end
  /

  if not exists apsnoabslog counter
  /
    begin oracle
    /
      alter table apsnoabslog add counter int default 0 not null
      /
    end
    /
    begin sqlserver
    /
      alter table apsnoabslog add counter int default 0 not null
      /
    end
  /
  end
  /

end if
/

*/
