using System;

namespace LexicalAnalyzer
{
    public class Token<TEnum> where TEnum : Enum
    {
        public TEnum TokenType { get; }
        public ReadOnlyMemory<char> Value { get; }

        internal Token(TEnum tokenType, ReadOnlyMemory<char> value)
        {
            TokenType = tokenType;
            Value = value;
        }

        public override bool Equals(object? other)
        {
            return other is Token<TEnum> otherToken &&
                   (TokenType.Equals(otherToken.TokenType) && Value.Equals(otherToken.Value));
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(TokenType, Value);
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
