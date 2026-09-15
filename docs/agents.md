## Project
Remy is a Telegram reminder/todo bot.

Current MVP:
- User sends a reminder request.
- Backend stores the reminder.
- At the scheduled time the bot sends a Telegram message.
- No Google Calendar or Google Tasks integration yet.

## Tech stack
- .NET 10
- ASP.NET Core Web API
- PostgreSQL
- EF Core
- Docker Compose
- Telegram Bot API

## Architecture
Follow the existing project structure.
Do not introduce new architectural layers unless necessary.

Prefer simple solutions suitable for the current MVP.

## Coding rules
- Use async APIs for I/O.
- Use CancellationToken where appropriate.
- Nullable reference types stay enabled.
- Prefer dependency injection.
- Do not add NuGet packages unless they provide substantial value.
- Do not silently change public contracts.

## Database
Use EF Core migrations for schema changes.

Do not edit generated migrations unless necessary.

## Testing
After modifying backend code:
1. Run `dotnet build`.
2. Run `dotnet test`.

Fix compilation errors before finishing.

## Working style
Before making large architectural changes, explain the proposed approach.

For small isolated tasks, implement directly.

When finished:
- summarize what changed;
- mention important design decisions;
- mention tests/build commands that were run;
- mention anything that remains unresolved.