using System.Text.Json;
using Remy.Api.Options;
using Remy.Api.Services;
using Remy.Api.Services.i;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
});
builder.Services.AddOpenApi();


builder.Services.AddOptions<TelegramOptions>()
    .Bind(builder.Configuration.GetSection(TelegramOptions.SectionName));


builder.Services.AddScoped<ITelegramService, TelegramService>();

builder.Services.Configure<TelegramOptions>(builder.Configuration.GetSection(TelegramOptions.SectionName));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}



app.MapControllers();
app.UseHttpsRedirection();


app.Run();
