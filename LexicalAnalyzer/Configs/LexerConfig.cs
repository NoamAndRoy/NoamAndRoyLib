using System;

namespace LexicalAnalyzer.Configs
{
    internal class LexerConfig<TEnum> where TEnum : Enum
    {
        public TokenDefinition<TEnum>[] TokensDefinitions { get; set; }
    }
}
