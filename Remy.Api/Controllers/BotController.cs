using Microsoft.AspNetCore.Mvc;
using Remy.Api.Models.Telegram;
using Remy.Api.Services.i;

namespace Remy.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
internal class BotController : ControllerBase
{
    [HttpPost]
    public Task<IActionResult> Webhook(
        [FromBody] TelegramUpdate update,
        [FromServices] ITelegramService service,
        CancellationToken ct
    ) => service.ProcessUpdateAsync(update, Unauthorized, Ok, ct);
}
