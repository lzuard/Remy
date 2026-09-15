using Microsoft.AspNetCore.Mvc;
using Remy.Api.Models.Telegram;

namespace Remy.Api.Services.i;

internal interface ITelegramService
{
    Task<IActionResult> ProcessUpdateAsync(
        TelegramUpdate update,
        Func<IActionResult> unauthorized,
        Func<IActionResult> ok,
        CancellationToken ct);
}