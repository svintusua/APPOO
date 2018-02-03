using System.CodeDom;
using System.Linq;
using System.Text;

namespace Core
{
    public class SymbolDictionary
    {
        private string _content = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public string Content
        {
            get => _content;
            set { _content = new string(value.Distinct().OrderBy(x => x).ToArray()); }
        }

        public int Length => Content.Length;
        public bool Contains(char ch)
        {
            return Content.IndexOf(ch) >= 0;
        }

        public bool ContainsAll(string str)
        {
            return str.All(Contains);
        }

        public int IndexOf(char c)
        {
            var index = Content.IndexOf(c);
            return index;
        }

        public string AbsentSymbols(string str)
        {
            var builder = new StringBuilder();
            foreach (var ch in str)
            {
                if (!Contains(ch))
                {
                    builder.Append(ch);
                }
            }
            return builder.ToString();
        }

        public char AtIndex(int index)
        {
            return Content[index];
        }
    }
}
