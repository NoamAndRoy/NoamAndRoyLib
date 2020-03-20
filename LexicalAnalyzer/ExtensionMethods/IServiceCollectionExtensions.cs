using Microsoft.Extensions.DependencyInjection;
using System;
using LexicalAnalyzer.Configs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace LexicalAnalyzer.ExtensionMethods
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddLexer<TTokenTypeEnum>(this IServiceCollection services) where TTokenTypeEnum : Enum
        {
            return services.AddTransient<ILexer<TTokenTypeEnum>, Lexer<TTokenTypeEnum>>(provider =>
            {
                var configuration = provider.GetService<IConfiguration>();
                var lexerConfig = new LexerConfig<TTokenTypeEnum>();

                configuration.GetSection("Lexer").Bind(lexerConfig);

                return new Lexer<TTokenTypeEnum>(lexerConfig.TokensDefinitions);
            });
        }
    }
}
