namespace UbwTools.Sql.Database
{
    public class NativeColumnInfo
    {
        public string Name { get; set; }
        public string DataType { get; set; }
        public int Length { get; set; }
        public int Precision { get; set; }
        public int Scale { get; set; }
        public string Default { get; set; }
        public bool Nullable { get; set; }
    }
}
