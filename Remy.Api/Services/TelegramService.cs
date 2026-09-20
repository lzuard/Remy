using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Remy.Api.Options;
using Remy.Api.Services.i;
using Telegram.Bot.Types;

namespace Remy.Api.Services;

internal class TelegramService(
    IOptions<TelegramOptions> optionsInternal,
    ILogger<TelegramService> logger,
    IHttpContextAccessor httpContextAccessor
) : ITelegramService
{
    private readonly TelegramOptions _options = optionsInternal.Value;

    private const string SecretTokenHeaderName =
        "X-Telegram-Bot-Api-Secret-Token";

    public async Task<IActionResult> ProcessUpdateAsync(
        Update update,
        Func<IActionResult> unauthorized,
        Func<IActionResult> ok,
        CancellationToken ct)
    {
        var secretToken = _options.WebHookSecret;
        var request = httpContextAccessor.HttpContext?.Request ??
                      throw new Exception("Could not get Request");

        var isInvalid =
            !request.Headers.TryGetValue(SecretTokenHeaderName, out var suppliedToken) ||
            suppliedToken.Count != 1 ||
            !CryptographicOperations.FixedTimeEquals(
                Encoding.UTF8.GetBytes(secretToken),
                Encoding.UTF8.GetBytes(suppliedToken[0] ?? string.Empty));


        logger.LogInformation("Received Telegram update {UpdateId}", update.Id);

        return isInvalid? unauthorized() : ok();
    }
}
