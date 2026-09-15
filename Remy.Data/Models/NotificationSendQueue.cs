using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Remy.Data.Enum;

namespace Remy.Data.Models;

public class NotificationSendQueue
{
    public Guid Id { get; set; }
    
    public Guid NotificationId { get; set; }
    
    public DateTime SendAtUtc { get; set; }
    
    public NotificationSendStatusType Status { get; set; }
    
    public DateTime LastStatusUpdateUtc { get; set; }
    
    public string? Message { get; set; }

    public virtual Notification Notification { get; set; } = null!;
}


public class NotificationSendQueueConfiguration : IEntityTypeConfiguration<NotificationSendQueue>
{
    public void Configure(EntityTypeBuilder<NotificationSendQueue> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<Notification>(e => e.Notification)
            .WithMany(x => x.NotificationSendQueues)
            .HasForeignKey(e => e.NotificationId)
            .OnDelete(DeleteBehavior.Restrict);

    }
} 