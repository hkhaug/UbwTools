using System;
using System.Collections.Generic;
using System.Text;
using UbwTools.Common;

namespace UbwTools.Sql.Gui
{
    public class ScriptRunner
    {
        class ResultItem
        {
            public string Statement { get; private set; }
            public int RowsAffected { get; private set; }
            public Exception Ex { get; private set; }

            public ResultItem(string statement, int rowsAffected)
            {
                Statement = statement;
                RowsAffected = rowsAffected;
                Ex = null;
            }

            public ResultItem(string statement, Exception ex)
            {
                Statement = statement;
                RowsAffected = -1;
                Ex = ex;
            }
        }

        private readonly List<ResultItem> _results = new List<ResultItem>();
        private int _totalRowsAffected;
        private int _successfulStatements;
        private int _errors;
        private string _summary;
        private string _details;

        public void AddResult(string statement, int rowsAffected)
        {
            ResultItem item = new ResultItem(statement, rowsAffected);
            _results.Add(item);
            _totalRowsAffected += rowsAffected;
            ++_successfulStatements;
        }

        public void AddError(string statement, Exception exception)
        {
            if (!_results.Exists(x => (x.Statement == statement) && (x.Ex.Message == exception.Message)))
            {
                ResultItem item = new ResultItem(statement, exception);
                _results.Add(item);
                ++_errors;
            }
        }

        public bool AnythingAdded
        {
            get { return _results.Count > 0; }
        }

        public bool AnyError
        {
            get { return _errors > 0; }
        }

        public string Summary
        {
            get
            {
                if (string.IsNullOrEmpty(_summary))
                {
                    _summary = string.Format("{0} påvirket av {1}.\r\n{2} oppsto.",
                        Util.Rowcount(_totalRowsAffected),
                        Util.CountOf("uttrykk", _successfulStatements),
                        Util.CountOf("feil", _errors));
                }
                return _summary;
            }
        }

        public string Details
        {
            get
            {
                if (string.IsNullOrEmpty(_details))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(Summary);
                    foreach (ResultItem item in _results)
                    {
                        sb.AppendLine();
                        if (null == item.Ex)
                        {
                            sb.Append(Util.Rowcount(item.RowsAffected));
                            sb.AppendLine(" påvirket av:");
                            sb.AppendLine(item.Statement);
                        }
                        else
                        {
                            sb.Append("Feil oppsto: ");
                            sb.AppendLine(item.Ex.Message);
                            sb.AppendLine("Forårsaket av uttrykk:");
                            sb.AppendLine(item.Statement);
                        }
                    }
                    _details = sb.ToString();
                }
                return _details;
            }
        }
    }
}
