using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Remy.Data.Enum;
using Remy.Data.Services.i;

namespace Remy.Data.Models;

public class Notification
{
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }
    
    public required string Message { get; set; }
    
    public NotificationSendType SendType { get; set; }



    public virtual User User { get; set; } = null!;

    public virtual ICollection<NotificationSendQueue> NotificationSendQueues { get; set; } = [];
}


public class NotificationConfiguration(ICryptoService cryptoService) : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Message)
            .HasConversion<byte[]>(
                convertToProviderExpression: str => cryptoService.Encrypt(str),
                convertFromProviderExpression: cipher => cryptoService.Decrypt(cipher)
            );

        builder.HasOne<User>(e => e.User)
            .WithMany(x => x.Notifications)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}