namespace Remy.Api.Models.Telegram;

internal class TelegramUpdate
{
    public required long UpdateId { get; init; }

    public TelegramMessage? Message { get; init; }

    public TelegramMessage? EditedMessage { get; init; }

    public TelegramMessage? ChannelPost { get; init; }

    public TelegramMessage? EditedChannelPost { get; init; }

    public TelegramCallbackQuery? CallbackQuery { get; init; }
}
