using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Mvc;
using Remy.Api.Services.i;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Remy.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class BotController(ITelegramBotClient botClient) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Webhook(
        [FromBody] Update update,
        [FromServices] ITelegramService service,
        CancellationToken ct)
    {
        var result = await service.ProcessUpdateAsync(update, Unauthorized, Ok, ct);

        // Временный ответ для проверки бота. Основная обработка выше сохранена.
        if (result is OkResult && update.Message is { } message)
        {
            await botClient.SendMessage(
                chatId: message.Chat.Id,
                text: "принял",
                replyParameters: new ReplyParameters
                {
                    MessageId = message.Id,
                    AllowSendingWithoutReply = true
                },
                messageThreadId: message.MessageThreadId,
                cancellationToken: ct);
        }

        return result;
    }

    [HttpGet]
    public IActionResult Ping()
    {
        return Ok(DateTime.Now);
    }
}
