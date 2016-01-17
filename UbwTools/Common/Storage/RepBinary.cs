namespace UbwTools.Common.Storage
{
    public class RepBinary : IRepBinary
    {
        public string Name { get; private set; }
        public byte[] Value { get; private set; }

        public RepBinary(string name, byte[] value)
        {
            Name = name;
            Value = value;
        }
    }
}
