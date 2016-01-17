using System.Text;

namespace UbwTools.Sql.Database
{
    public class SummaryBuilder
    {
        private readonly ColumnInfo _info;
        private readonly bool _isUbwDatabase;
        private readonly StringBuilder _sb;

        public SummaryBuilder(ColumnInfo info, bool isUbwDatabase)
        {
            _info = info;
            _isUbwDatabase = isUbwDatabase;
            _sb = new StringBuilder();
            LineWithoutLf("Kolonnenummer:", _info.Ordinal);
            FullLine("Navn:\t", _info.Name);
            FullLine("Kan være Null:\t", _info.Nullable ? "Ja" : "Nei");
        }

        public override string ToString()
        {
            return _sb.ToString();
        }

        private void Tab()
        {
            _sb.Append("\t");
        }

        private void NewLine()
        {
            _sb.Append("\r\n");
        }

        private void Append(string text)
        {
            _sb.Append(text);
        }

        private void Append(int number)
        {
            _sb.Append(number);
        }

        private void AppendNumber(int number)
        {
            Append("(");
            Append(number);
            Append(")");
        }

        private void AppendNumbers(int number1, int number2)
        {
            Append("(");
            Append(number1);
            Append(",");
            Append(number2);
            Append(")");
        }

        private void LineWithoutLf(string legend, string value)
        {
            Append(legend);
            Tab();
            Append(value);
        }

        private void LineWithoutLf(string legend, int value)
        {
            Append(legend);
            Tab();
            Append(value);
        }

        public void FullLine(string legend, string value)
        {
            NewLine();
            LineWithoutLf(legend, value);
        }

        private void AddDialectType(string dialect, string typeName)
        {
            NewLine();
            _sb.Append(dialect);
            _sb.Append(" type:");
            Tab();
            _sb.Append(typeName);
        }

        private void UbwType(string typeName)
        {
            if (_isUbwDatabase)
            {
                AddDialectType("UBW", typeName);
            }
        }

        private void UbwType(int size, params string[] typeNames)
        {
            if (_isUbwDatabase)
            {
                if (typeNames.Length > 0)
                {
                    UbwType(typeNames[0]);
                    AppendNumber(size);
                    if (typeNames.Length > 1)
                    {
                        for (int index = 1; index < typeNames.Length; ++index)
                        {
                            Append(", ");
                            Append(typeNames[index]);
                            AppendNumber(size);
                        }
                    }
                }
            }
        }

        private void SqlServerType(string typeName)
        {
            AddDialectType("SQL Server", typeName);
        }

        private void SqlServerType(int size, params string[] typeNames)
        {
            if (typeNames.Length > 0)
            {
                SqlServerType(typeNames[0]);
                AppendNumber(size);
                if (typeNames.Length > 1)
                {
                    for (int index = 1; index < typeNames.Length; ++index)
                    {
                        Append(", ");
                        Append(typeNames[index]);
                        AppendNumber(size);
                    }
                }
            }
        }

        private void SqlServerType(int precision, int scale, string typeName)
        {
            SqlServerType(typeName);
            AppendNumbers(precision, scale);
        }

        private void OracleType(string typeName)
        {
            AddDialectType("Oracle", typeName);
        }

        private void OracleType(int size, params string[] typeNames)
        {
            if (typeNames.Length > 0)
            {
                OracleType(typeNames[0]);
                AppendNumber(size);
                if (typeNames.Length > 1)
                {
                    for (int index = 1; index < typeNames.Length; ++index)
                    {
                        Append(", ");
                        Append(typeNames[index]);
                        AppendNumber(size);
                    }
                }
            }
        }

        private void OracleType(int precision, int scale, string typeName)
        {
            OracleType(typeName);
            AppendNumbers(precision, scale);
        }

        public void Boolean()
        {
            UbwType("bool");
            SqlServerType("bit");
            OracleType(1, "number");
        }

        public void Byte()
        {
            UbwType("int1");
            SqlServerType("tinyint");
        }

        public void ByteArray()
        {
            if (_info.Size == int.MaxValue)
            {
                SqlServerType("image");
            }
            else if (_info.Size > 0)
            {
                SqlServerType(_info.Size, "binary");
            }
        }

        public void DateTime()
        {
            UbwType("date, datetime");
            if (_info.Size == 3)
            {
                SqlServerType("date");
            }
            else if (_info.Size == 4)
            {
                SqlServerType("smalldatetime");
            }
            else if ((_info.Size == 8) && (_info.Precision == 23) && (_info.Scale == 3))
            {
                SqlServerType("datetime");
            }
            else if ((_info.Size >= 6) && (_info.Size <= 8) && (_info.Precision == 255))
            {
                SqlServerType(_info.Scale, "datetime2");
            }
            OracleType("date");
        }

        public void DateTimeOffset()
        {
            SqlServerType(_info.Scale, "datetimeoffset");
        }

        public void Decimal()
        {
            if ((_info.Precision > 0) && (_info.Scale > 0))
            {
                if (_info.Precision == 28)
                {
                    switch (_info.Scale)
                    {
                        case 3:
                            UbwType("money");
                            break;
                        case 8:
                            UbwType("float");
                            break;
                    }
                }
                if ((_info.Precision == 19) && (_info.Scale == 255))
                {
                    SqlServerType("money");
                }
                else
                {
                    SqlServerType(_info.Precision, _info.Scale, "decimal");
                }
                OracleType(_info.Precision + 2, _info.Scale, "number");
            }
        }

        public void Double()
        {
            SqlServerType("float");
        }

        public void Int16()
        {
            UbwType("int2");
            SqlServerType("smallint");
            OracleType(5, "number");
        }

        public void Int32()
        {
            UbwType("int");
            SqlServerType("int");
            OracleType(15, "number");
        }

        public void Int64()
        {
            UbwType("autonum, int8");
            SqlServerType("bigint");
            OracleType(20, "number");
        }

        public void SqlGeography()
        {
            SqlServerType("geography");
        }

        public void SqlGeometry()
        {
            SqlServerType("geometry");
        }

        public void SqlHierarchyId()
        {
            SqlServerType("hierarchyid");
        }

        public void String()
        {
            switch (_info.Size)
            {
                case int.MaxValue:
                    SqlServerType("varchar(MAX), nvarchar(MAX), text, xml");
                    break;
                case 1073741823:
                    SqlServerType("ntext");
                    break;
                default:
                    if (_info.Size > 0)
                    {
                        UbwType(_info.Size, "char", "vchar");
                        SqlServerType(_info.Size, "char", "nchar", "varchar", "nvarchar");
                        OracleType(_info.Size, "varchar2");
                    }
                    break;
            }
        }

        public void TinyInt()
        {
            UbwType("int1");
            SqlServerType("tinyint");
            OracleType(3, "number");
        }

        public void Uniqueidentifier()
        {
            UbwType("guid");
            SqlServerType("uniqueidentifier");
            OracleType(16, "raw");
        }
    }
}
