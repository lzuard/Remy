namespace Remy.Api.Models.Telegram;

internal class TelegramMessage
{
    public required long MessageId { get; init; }

    public required long Date { get; init; }

    public required TelegramChat Chat { get; init; }

    public TelegramUser? From { get; init; }

    public TelegramChat? SenderChat { get; init; }

    public string? Text { get; init; }

    public string? Caption { get; init; }

    public long? MessageThreadId { get; init; }

    public TelegramMessage? ReplyToMessage { get; init; }

    public long? EditDate { get; init; }
}
