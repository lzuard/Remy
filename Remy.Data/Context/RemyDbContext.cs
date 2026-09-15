using Microsoft.EntityFrameworkCore;

namespace Remy.Data.Context;

public class RemyDbContext(DbContextOptions<RemyDbContext> options) : DbContext(options)
{
    internal const string ConnectionStringName = "Remy";
}