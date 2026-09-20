namespace Remy.Api.Options;

public sealed class TelegramOptions
{
    public const string SectionName = "Telegram";
    
    public required string BotToken { get; init; }
    public required string WebHookSecret { get; init; }
}
