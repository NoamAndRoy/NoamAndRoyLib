using System;
using System.Collections.Generic;
using System.Linq;

namespace LexicalAnalyzer
{
    public class Lexer<TEnum> : ILexer<TEnum> where TEnum : Enum
    {
        private readonly TokenDefinition<TEnum>[] tokenDefinitions;

        public Lexer(TokenDefinition<TEnum>[] tokenDefinitions)
        {
            this.tokenDefinitions = tokenDefinitions;
        }

        public IEnumerable<Token<TEnum>> GetTokens(string text)
        {
            var memoryText = text.AsMemory();

            while (!memoryText.IsEmpty)
            {
                var token = FindToken(memoryText);

                if (token != null)
                {
                    yield return token;
                }

                memoryText = memoryText.Slice(token?.Value.Length ?? 1);
            }
        }

        private Token<TEnum>? FindToken(ReadOnlyMemory<char> text)
        {
            return tokenDefinitions
                .Select(tokenDefinition => tokenDefinition.Match(text))
                .FirstOrDefault(token => token != null);
        }
    }
}
