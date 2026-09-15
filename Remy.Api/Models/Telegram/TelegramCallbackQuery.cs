namespace Remy.Api.Models.Telegram;

internal class TelegramCallbackQuery
{
    public required string Id { get; init; }

    public required TelegramUser From { get; init; }

    public required string ChatInstance { get; init; }

    public TelegramMessage? Message { get; init; }

    public string? InlineMessageId { get; init; }

    public string? Data { get; init; }

    public string? GameShortName { get; init; }
}
