using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;

namespace Remy.Api.Services.i;

public interface ITelegramService
{
    Task<IActionResult> ProcessUpdateAsync(
        Update update,
        Func<IActionResult> unauthorized,
        Func<IActionResult> ok,
        CancellationToken ct);
}
