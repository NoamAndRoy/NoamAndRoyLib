using System;
using System.Text.RegularExpressions;

namespace LexicalAnalyzer
{
    public class TokenDefinition<TEnum> where TEnum : Enum
    {
        private Regex regex = new Regex(string.Empty);

        public TEnum TokenType { get; set; }

        public string Pattern
        {
            get => regex.ToString();
            set => regex = new Regex(value);
        }

        public Token<TEnum>? Match(ReadOnlyMemory<char> text)
        {
            var match = regex.Match(text.ToString());

            return match.Success ? new Token<TEnum>(TokenType, text.Slice(match.Index, match.Length)) : null;
        }
    }
}
