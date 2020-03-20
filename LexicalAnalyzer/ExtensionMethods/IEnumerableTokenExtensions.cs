using System;
using System.Collections.Generic;
using System.Linq;

namespace LexicalAnalyzer.ExtensionMethods
{
    public static class IEnumerableTokenExtensions
    {
        public static IEnumerable<ReadOnlyMemory<char>> GetValuesByTokenTypes<TEnum>(this IEnumerable<Token<TEnum>> tokens, params TEnum[] tokenTypes) where TEnum : Enum
        {
            return tokens.Where(t => tokenTypes.Contains(t.TokenType)).Select(t => t.Value);
        }
    }
}