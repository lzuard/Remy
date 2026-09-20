using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql;
using Remy.Data.Context;

namespace Remy.Data;

public static class ServiceIndex
{
    public static T AddDataLayer<T>(this T builder) where T : IHostApplicationBuilder
    {
        var connectionString = builder.Configuration.GetConnectionString(RemyDbContext.ConnectionStringName);
        if (string.IsNullOrWhiteSpace(connectionString))
            throw new InvalidOperationException("ConnectionStrings:Remy is required.");

        var password = builder.Configuration["Postgres:Password"];
        if (string.IsNullOrEmpty(password))
            throw new InvalidOperationException("Postgres:Password is required.");

        var database = new NpgsqlConnectionStringBuilder(connectionString)
        {
            Password = password
        };

        builder.Services.AddPooledDbContextFactory<RemyDbContext>(options =>
            options.UseNpgsql(database.ConnectionString));

        return builder;
    }
}
