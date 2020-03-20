using LexicalAnalyzer;
using System.Linq;
using Xunit;

namespace LibTests
{
    public class LexerTests
    {
        private enum eTokenType
        {
            StringValue,
            Number
        }

        private readonly ILexer<eTokenType> lexer;
        private readonly TokenDefinition<eTokenType>[] tokenDefinitions;

        public LexerTests()
        {
            tokenDefinitions = new[]
            {
                new TokenDefinition<eTokenType> { TokenType = eTokenType.StringValue, Pattern = "^[a-zA-Z]+" },
                new TokenDefinition<eTokenType> { TokenType = eTokenType.Number, Pattern = "^[0-9]+" }
            };

            lexer = new Lexer<eTokenType>(tokenDefinitions);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("\t")]
        [InlineData("\n")]
        public void GetTokens_ShouldReturnEmptyEnumerable_WhenTextIsEmpty(string text)
        {
            Assert.Empty(lexer.GetTokens(text));
        }

        [Theory]
        [InlineData("Hello", 1)]
        [InlineData("Hello World", 2)]
        [InlineData("Hello12", 2)]
        public void GetTokens_ShouldReturnMultipleTokens_WhenTextContainsMultipleWords(string text, int amountOfTokens)
        {
            Assert.Equal(amountOfTokens, lexer.GetTokens(text).Count());
        }

        [Theory]
        [InlineData("Hello")]
        [InlineData("Bye[]12")]
        public void GetTokens_ShouldContainStringValueToken_WhenGivenTextWithStringValue(string text)
        {
            var result = lexer.GetTokens(text);

            Assert.Contains(result, token => token.TokenType == eTokenType.StringValue);
        }

        [Theory]
        [InlineData("12")]
        [InlineData("Bye[]12")]
        public void GetTokens_ShouldContainNumberToken_WhenGivenTextWithNumber(string text)
        {
            var result = lexer.GetTokens(text);

            Assert.Contains(result, token => token.TokenType == eTokenType.Number);
        }
    }
}