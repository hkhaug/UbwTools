namespace UbwTools.Sql.Database
{
    public class ColumnInfo
    {
        public string DotNetType { get; set; }
        public string Name { get; set; }
        public bool Nullable { get; set; }
        public int Ordinal { get; set; }
        public int Precision { get; set; }
        public int Scale { get; set; }
        public int Size { get; set; }

        private string _summary;

        public string Summary(bool isUbwDatabase)
        {
            if (null == _summary)
            {
                SummaryBuilder sb = new SummaryBuilder(this, isUbwDatabase);
                if (!string.IsNullOrEmpty(DotNetType))
                {
                    sb.FullLine(".Net type:", DotNetType);
                    switch (DotNetType)
                    {
                        case "Boolean":
                            sb.Boolean();
                            break;
                        case "Byte":
                            sb.Byte();
                            break;
                        case "Byte[]":
                            sb.ByteArray();
                            break;
                        case "DateTime":
                            sb.DateTime();
                            break;
                        case "DateTimeOffset":
                            sb.DateTimeOffset();
                            break;
                        case "Decimal":
                            sb.Decimal();
                            break;
                        case "Double":
                            sb.Double();
                            break;
                        case "Int16":
                            sb.Int16();
                            break;
                        case "Int32":
                            sb.Int32();
                            break;
                        case "Int64":
                            sb.Int64();
                            break;
                        case "SqlGeography":
                            sb.SqlGeography();
                            break;
                        case "SqlGeometry":
                            sb.SqlGeometry();
                            break;
                        case "SqlHierarchyId":
                            sb.SqlHierarchyId();
                            break;
                        case "String":
                            sb.String();
                            break;
                        case "Tinyint":
                            sb.TinyInt();
                            break;
                        case "Uniqueidentifier":
                            sb.Uniqueidentifier();
                            break;
                    }
                }
                _summary = sb.ToString();
            }
            return _summary;
        }
    }
}
