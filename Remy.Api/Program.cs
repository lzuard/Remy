using System.Text.Json;
using Microsoft.Extensions.Options;
using Remy.Api.Options;
using Remy.Api.Services;
using Remy.Api.Services.i;
using Remy.Data;
using Telegram.Bot;

var builder = WebApplication.CreateBuilder(args);

var secretsDirectory = builder.Configuration["SecretsDirectory"] ?? "/run/secrets";
builder.Configuration.AddKeyPerFile(
    Path.GetFullPath(secretsDirectory, builder.Environment.ContentRootPath),
    optional: true);

builder.AddDataLayer();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
});
builder.Services.AddOpenApi();


builder.Services.AddOptions<TelegramOptions>()
    .Bind(builder.Configuration.GetSection(TelegramOptions.SectionName))
    .Validate(options => !string.IsNullOrWhiteSpace(options.BotToken), "Telegram:BotToken is required.")
    .Validate(options => !string.IsNullOrWhiteSpace(options.WebHookSecret), "Telegram:WebHookSecret is required.")
    .ValidateOnStart();

builder.Services.AddHttpContextAccessor();

builder.Services.AddSingleton<ITelegramBotClient>(services =>
    new TelegramBotClient(services.GetRequiredService<IOptions<TelegramOptions>>().Value.BotToken));

builder.Services.AddScoped<ITelegramService, TelegramService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}



app.MapControllers();
app.UseHttpsRedirection();


app.Run();
