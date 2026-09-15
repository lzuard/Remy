namespace Remy.Api.Models.Telegram;

public class TelegramUser
{
    public required long Id { get; init; }

    public required bool IsBot { get; init; }

    public required string FirstName { get; init; }

    public string? LastName { get; init; }

    public string? Username { get; init; }

    public string? LanguageCode { get; init; }

    public bool? IsPremium { get; init; }
}
