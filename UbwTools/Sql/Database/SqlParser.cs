using System.Collections.Generic;

namespace UbwTools.Sql.Database
{
    public static class SqlParser
    {
        private enum State
        {
            Statement,
            String,
            Comment,
            LineComment
        }

        public static IEnumerable<string> Split(string statement)
        {
            List<string> result = new List<string>();

            string stmt = statement.Trim();
            int length = stmt.Length;
            State state = State.Statement;
            int start = 0;
            int pos = 0;
            while (pos < length)
            {
                char ch = stmt[pos];
                ++pos;
                switch (state)
                {
                    case State.Statement:
                        switch (ch)
                        {
                            case ';':
                                string part = stmt.Substring(start, pos - start - 1).Trim();
                                if (!string.IsNullOrWhiteSpace(part))
                                {
                                    result.Add(part);
                                }
                                start = pos;
                                break;
                            case '\'':
                                state = State.String;
                                break;
                            case '/':
                                if (pos < length)
                                {
                                    char ch2 = stmt[pos];
                                    switch (ch2)
                                    {
                                        case '/':
                                            state = State.LineComment;
                                            break;
                                        case '*':
                                            state = State.Comment;
                                            break;
                                    }
                                }
                                break;
                            case '-':
                                if ((pos < length) && (stmt[pos] == '-'))
                                {
                                    state = State.LineComment;
                                }
                                break;
                        }
                        break;
                    case State.String:
                        if (ch == '\'')
                        {
                            state = State.Statement;
                        }
                        break;
                    case State.Comment:
                        if ((ch == '*') && (pos < length) && (stmt[pos] == '/'))
                        {
                            state = State.Statement;
                        }
                        break;
                    case State.LineComment:
                        if ((ch == '\r') || (ch == '\n'))
                        {
                            state = State.Statement;
                        }
                        break;
                }
            }
            string lastPart = stmt.Substring(start, pos - start).Trim();
            if (!string.IsNullOrWhiteSpace(lastPart))
            {
                result.Add(lastPart);
            }

            return result;
        }
    }
}
