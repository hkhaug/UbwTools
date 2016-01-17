using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using UbwTools.Common;
using UbwTools.Common.Gui;
using UbwTools.Sql.Database;
using UbwTools.Sql.Gui;

namespace UbwTools.Sql
{
    public class ExecutionManager
    {
        private static ExecutionManager _instance;
        public static ExecutionManager Instance
        {
            get { return _instance ?? (_instance = new ExecutionManager()); }
        }

        private ExecutionManager()
        {
        }

        public void ExecuteSqlStatements()
        {
            if (null == ConnectionManager.CurrentConnection)
            {
                return;
            }
            // It looks like a b.u.g, but maybe it's just bad event handling:
            // The very first time this is called during application lifetime,
            // if one or more SQL statements is a SELECT resulting in a grid,
            // the DataGridView reports zero columns although all relevant
            // columns are shown. The cheap workaround is to just repeat once.
            //bool success = ExecuteStatements();
            //if (!success)
            //{
            ExecuteStatements();
            //}
            SqlCommon.SqlForm.tabResults.TabPages[0].Controls[0].Select();
            SqlCommon.SqlForm.tabResults.TabPages[0].Controls[0].Focus();
        }

        // ReSharper disable once UnusedMethodReturnValue.Local
        private bool ExecuteStatements()
        {
            bool anyGridMade = false;
            bool allGridColumnsShapedUp = true;
            using (new WaitingCursor(SqlCommon.SqlForm))
            {
                IEnumerable<string> statements = SqlParser.Split(SqlCommon.Statements.GetSqlStatementForExecution());
                try
                {
                    SqlCommon.SqlForm.tabResults.Visible = false;
                    SqlCommon.SqlForm.tabResults.TabPages.Clear();
                    ScriptRunner runner = new ScriptRunner();
                    int tabCounter = 0;
                    ConnectionManager.CurrentConnection.Open();
                    foreach (string statement in statements)
                    {
                        if ((tabCounter >= 26) || ((tabCounter >= 25) && runner.AnythingAdded))
                        {
                            break;
                        }
                        Dictionary<string, ColumnInfo> columnInfo = GetColumnInfo(runner, statement);
                        if (null != columnInfo)
                        {
                            IDbCommand cmd = ConnectionManager.CurrentConnection.CreateCommand();
                            cmd.CommandText = statement;
                            try
                            {
                                using (
                                    IDataReader reader =
                                        cmd.ExecuteReader(CommandBehavior.Default | CommandBehavior.SequentialAccess |
                                                          CommandBehavior.SingleResult))
                                {
                                    int rowsAffected = reader.RecordsAffected;
                                    if (rowsAffected < 0)
                                    {
                                        anyGridMade = true;
                                        DataGridView dgv = MakeGridPage(statement, tabCounter, reader);
                                        if (!ShapeUpColumns(dgv, columnInfo))
                                        {
                                            allGridColumnsShapedUp = false;
                                        }
                                        ++tabCounter;
                                    }
                                    else
                                    {
                                        runner.AddResult(statement, rowsAffected);
                                    }
                                    reader.Close();
                                }
                            }
                            catch (Exception ex)
                            {
                                runner.AddError(statement, ex);
                            }
                        }
                    }
                    if (runner.AnythingAdded)
                    {
                        MakeTextPage(runner, tabCounter);
                    }
                }
                finally
                {
                    SqlCommon.SqlForm.tabResults.Visible = (SqlCommon.SqlForm.tabResults.TabCount > 0);
                    ConnectionManager.CurrentConnection.Close();
                }
            }
            return !anyGridMade || allGridColumnsShapedUp;
        }

        private Dictionary<string, ColumnInfo> GetColumnInfo(ScriptRunner runner, string statement)
        {
            Dictionary<string, ColumnInfo> result = new Dictionary<string, ColumnInfo>();
            try
            {
                IDbCommand cmd = ConnectionManager.CurrentConnection.CreateCommand();
                cmd.CommandText = statement;
                using (IDataReader reader = cmd.ExecuteReader(CommandBehavior.SchemaOnly))
                {
                    DataTable schema = reader.GetSchemaTable();
                    if (null != schema)
                    {
                        foreach (DataRow row in schema.Rows)
                        {
                            if (!row.IsNull("ColumnName"))
                            {
                                string columnName = row["ColumnName"].ToString();
                                int columnOrdinal = row.IsNull("ColumnOrdinal") ? -1 : (int)row["ColumnOrdinal"];
                                int columnSize = row.IsNull("ColumnSize") ? 0 : (int)row["ColumnSize"];
                                short numericPrecision = row.IsNull("NumericPrecision") ? (short)0 : (short)row["NumericPrecision"];
                                short numericScale = row.IsNull("NumericScale") ? (short)0 : (short)row["NumericScale"];
                                string dataType = row["DataType"].ToString();
                                bool allowDbNull = (bool)row["AllowDBNull"];

                                result.Add(columnName, new ColumnInfo
                                {
                                    DotNetType = dataType.Substring(dataType.LastIndexOf('.') + 1),
                                    Name = columnName,
                                    Nullable = allowDbNull,
                                    Ordinal = columnOrdinal,
                                    Precision = numericPrecision,
                                    Scale = numericScale,
                                    Size = columnSize
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                runner.AddError(statement, ex);
            }
            return result;
            // Oracle:
            // SELECT DISTINCT DATA_TYPE, DATA_LENGTH, DATA_PRECISION, DATA_SCALE
            // FROM USER_TAB_COLS
            // WHERE TABLE_NAME IN (SELECT DISTINCT TABLE_NAME FROM USER_TABLES WHERE TABLE_NAME LIKE 'A%')
            // ORDER BY DATA_TYPE, DATA_LENGTH, DATA_PRECISION, DATA_SCALE;
            // Finnes i en typisk Agresso-base:
            // Type     Length	Precision	Scale
            // BLOB     4000    -           -
            // CLOB     4000    -           -
            // DATE     7       -           -
            // NUMBER	22      1           0
            // NUMBER	22      3           0
            // NUMBER	22      5           0
            // NUMBER	22      9           0
            // NUMBER	22      15          0
            // NUMBER	22      20          0
            // NUMBER	22      28          3
            // NUMBER	22      30          3
            // NUMBER	22      30          8
            // NUMBER	22      -           0
            // RAW      16		-           -
            // VARCHAR2 x       -           -

            // SQL Server:
            // SELECT DISTINCT DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE
            // FROM INFORMATION_SCHEMA.COLUMNS
            // WHERE TABLE_NAME IN
            // (SELECT DISTINCT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME LIKE 'A%' AND TABLE_TYPE = 'BASE TABLE')
            // Finnes i en typisk Agresso-base:
            // DATA_TYPE        CHARACTER_MAXIMUM_LENGTH    NUMERIC_PRECISION   NUMERIC_SCALE
            // bigint           NULL                        19                  0
            // bit              NULL                        NULL                NULL
            // datetime         NULL                        NULL                NULL
            // decimal          NULL                        28                  3
            // decimal          NULL                        28                  8
            // float            NULL                        53                  NULL
            // int              NULL                        10                  0
            // smallint         NULL                        5                   0
            // tinyint          NULL                        3                   0
            // uniqueidentifier NULL                        NULL                NULL
            // varbinary        -1                          NULL                NULL
            // varchar          x                           NULL                NULL
        }

        private DataGridView MakeGridPage(string statement, int tabCounter, IDataReader reader)
        {
            DataSet ds = new DataSet();
            ds.Load(reader, LoadOption.OverwriteChanges, new[] { "A" });
            string tabLetter = TabLetter(tabCounter);
            TabPage tp = new TabPage(tabLetter);
            tp.Enter += SqlCommon.SqlForm.control_Enter;
            tp.Leave += SqlCommon.SqlForm.control_Leave;
            SqlCommon.SqlForm.tabResults.Controls.Add(tp);
            tp.ImageIndex = SqlGuiForm.IconGrid;
            tp.Name = "tp" + tabLetter;
            tp.TabIndex = tabCounter;
            int numRows = ds.Tables[0].Rows.Count;
            tp.ToolTipText = string.Format("{0} i resultatsett\r\n\r\n{1}", Util.Rowcount(numRows), statement);
            DataGridView dgv = new DataGridView
            {
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToOrderColumns = true,
                AllowUserToResizeColumns = true,
                AllowUserToResizeRows = false,
                AlternatingRowsDefaultCellStyle = { BackColor = Color.LightGoldenrodYellow },
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                ReadOnly = true,
                StandardTab = true
            };
            dgv.DataError += dgv_DataError;
            dgv.Enter += SqlCommon.SqlForm.control_Enter;
            dgv.Leave += SqlCommon.SqlForm.control_Leave;
            dgv.DataSource = ds.Tables[0];
            tp.Controls.Add(dgv);
            dgv.Visible = true;
            tp.Visible = true;
            return dgv;
        }

        private bool ShapeUpColumns(DataGridView dgv, IReadOnlyDictionary<string, ColumnInfo> columnInfo)
        {
            if (0 == dgv.Columns.Count)
            {
                return false;
            }
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (SqlCommon.Settings.BeautifyColumnNames && ConnectionManager.CurrentConnection.IsUbwDatabase)
                {
                    string originalName = column.HeaderText;
                    string fixedName = FixColumnName(originalName);
                    if (fixedName != originalName)
                    {
                        column.HeaderText = fixedName;
                    }
                }
                ColumnInfo info;
                if (columnInfo.TryGetValue(column.Name, out info))
                {
                    column.ToolTipText = info.Summary(ConnectionManager.CurrentConnection.IsUbwDatabase);
                }
            }
            return true;
        }

        private void MakeTextPage(ScriptRunner runner, int tabCounter)
        {
            string tabLetter = TabLetter(tabCounter);
            TabPage tp = new TabPage(tabLetter);
            SqlCommon.SqlForm.tabResults.Controls.Add(tp);
            tp.ImageIndex = runner.AnyError ? SqlGuiForm.IconError : SqlGuiForm.IconScript;
            tp.Name = "tp" + tabLetter;
            tp.TabIndex = tabCounter;
            TextBox tb = new TextBox
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Location = new Point(0, 0),
                Multiline = true,
                ReadOnly = true,
                Text = runner.Details,
                Visible = true
            };
            SqlCommon.SqlForm.textBoxSql.DeselectAll();
            tp.Controls.Add(tb);
            tp.ToolTipText = runner.Summary;
            tp.Visible = true;
        }

        static string TabLetter(int tabCounter)
        {
            char tabCounterCh = (char)('A' + tabCounter);
            string tabCounterStr = tabCounterCh.ToString(CultureInfo.InvariantCulture);
            return tabCounterStr;
        }

        static void dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Context.HasFlag(DataGridViewDataErrorContexts.Formatting) && e.Context.HasFlag(DataGridViewDataErrorContexts.PreferredSize))
            {
                e.ThrowException = false;
            }
        }

        private static string FixColumnName(string originalName)
        {
            StringBuilder sb = new StringBuilder();
            bool nextUpper = true;
            foreach (char ch in originalName)
            {
                if (ch == '_')
                {
                    sb.Append(' ');
                    nextUpper = true;
                }
                else
                {
                    if (char.IsLetter(ch))
                    {
                        sb.Append(nextUpper ? char.ToUpper(ch) : char.ToLower(ch));
                    }
                    else
                    {
                        sb.Append(ch);
                    }
                    nextUpper = false;
                }
            }
            return sb.ToString();
        }
    }
}
