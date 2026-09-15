using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Remy.Data.Context;

namespace Remy.Data;

public static class ServiceIndex
{
    public static T AddDataLayer<T>(this T builder) where T : IHostApplicationBuilder
    {
        
        builder.Services.AddDbContext<RemyDbContext>(options => 
            options.UseNpgsql(builder.Configuration.GetConnectionString(RemyDbContext.ConnectionStringName)));
        
        builder.Services.AddPooledDbContextFactory<RemyDbContext>(_ => {});


        return builder;
    }
}