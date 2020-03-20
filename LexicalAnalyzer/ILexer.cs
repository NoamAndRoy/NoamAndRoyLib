using System;
using System.Collections.Generic;

namespace LexicalAnalyzer
{
    public interface ILexer<TEnum> where TEnum : Enum
    {
        IEnumerable<Token<TEnum>> GetTokens(string text);
    }
}
