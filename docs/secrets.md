# Секреты приложения

Значения хранятся в локальной папке `.secrets/` в корне репозитория.
Она исключена из Git и Docker build context. Создайте её при новом клонировании
и заполните три файла без завершающего перевода строки:

| Файл | Значение | Потребители |
| --- | --- | --- |
| `Telegram__BotToken` | Токен Telegram-бота | API |
| `Telegram__WebHookSecret` | Секрет, заданный при регистрации Telegram webhook | API |
| `Postgres__Password` | Пароль пользователя PostgreSQL | API и PostgreSQL |

Права локальной папки — `700`, файлов — `644`: доступ к папке имеет только
владелец, а файлы, смонтированные Docker, может читать непривилегированный
пользователь API. Не размещайте эти файлы в общедоступной папке.

Запуск в Docker: `docker compose up --build`. Compose монтирует секреты
в `/run/secrets`; API читает их через `AddKeyPerFile`, а PostgreSQL — через
`POSTGRES_PASSWORD_FILE`. Двойное подчёркивание в имени файла задаёт вложенный
ключ конфигурации: например, `Telegram__BotToken` становится `Telegram:BotToken`.
Файловые секреты имеют приоритет над остальной конфигурацией.

При запуске API из Rider с окружением `Development` приложение читает ту же
папку `.secrets/`, а к PostgreSQL подключается через `localhost:5432`.
Базу можно запустить отдельно: `docker compose up -d remy.postgres`.
Параметр `SecretsDirectory` позволяет указать другую папку; относительный путь
отсчитывается от content root API. Значения `Postgres:Password`,
`Telegram:BotToken` и `Telegram:WebHookSecret` обязательны.

Пароль добавляется к строке подключения в памяти через
`NpgsqlConnectionStringBuilder`. В `appsettings*.json` пароля нет.
Проверка заголовка `X-Telegram-Bot-Api-Secret-Token` использует `WebHookSecret`.

После изменения секретов пересоздайте контейнеры (`docker compose up -d --force-recreate`).
`POSTGRES_PASSWORD_FILE` устанавливает пароль только при инициализации новой базы:
для существующего тома изменение файла нужно согласовать с изменением пароля
пользователя в самой PostgreSQL. При текущем переносе пароль сохранён.

Документация: [Docker Compose secrets](https://docs.docker.com/compose/how-tos/use-secrets/),
[ASP.NET Core Key-per-file](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-10.0#key-per-file-configuration-provider).
