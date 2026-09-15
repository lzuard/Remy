using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Remy.Data.Models;

public class User
{
    public Guid Id { get; set; }
    
    public long? TelegramId { get; set; }


    public virtual ICollection<Notification> Notifications { get; set; } = [];
}


public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
    }
}