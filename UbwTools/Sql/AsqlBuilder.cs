using System.Text;

namespace UbwTools.Sql
{
    public class AsqlBuilder
    {
        private const int IndentSize = 4;
        private int _indentLevel;
        private readonly StringBuilder _sb = new StringBuilder();

        public void IncIndent()
        {
            ++_indentLevel;
        }

        public void DecIndent()
        {
            if (0 < _indentLevel)
            {
                --_indentLevel;
            }
        }

        private void Indent()
        {
            if (0 < _indentLevel)
            {
                Write(new string(' ', _indentLevel * IndentSize));
            }
        }

        public void SlashLine(string line = null)
        {
            if (null != line)
            {
                Indent();
                WriteLine(line);
            }
            Indent();
            WriteLine("/");
        }

        public void IndentWrite(string text)
        {
            Indent();
            Write(text);
        }

        public void Write(string text)
        {
            _sb.Append(text);
        }

        public void IndentWriteLine(string text)
        {
            Indent();
            WriteLine(text);
        }

        public void WriteLine(string text)
        {
            _sb.AppendLine(text);
        }

        public override string ToString()
        {
            return _sb.ToString();
        }
    }
}
