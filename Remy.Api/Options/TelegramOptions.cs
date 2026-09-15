namespace Remy.Api.Options;

public sealed class TelegramOptions
{
    public const string SectionName = "Telegram";
    
    public required string SecretToken { get; init; }
    public required string SecretTokenHeaderName { get; init; }
}
