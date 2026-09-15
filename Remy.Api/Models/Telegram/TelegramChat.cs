namespace Remy.Api.Models.Telegram;

internal class TelegramChat
{
    public required long Id { get; init; }

    public required string Type { get; init; }

    public string? Title { get; init; }

    public string? Username { get; init; }

    public string? FirstName { get; init; }

    public string? LastName { get; init; }

    public bool? IsForum { get; init; }
}
