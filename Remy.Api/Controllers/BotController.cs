using Microsoft.AspNetCore.Mvc;
using Remy.Api.Services.i;
using Telegram.Bot.Types;

namespace Remy.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
internal class BotController : ControllerBase
{
    [HttpPost]
    public Task<IActionResult> Webhook(
        [FromBody] Update update,
        [FromServices] ITelegramService service,
        CancellationToken ct
    ) => service.ProcessUpdateAsync(update, Unauthorized, Ok, ct);
}
