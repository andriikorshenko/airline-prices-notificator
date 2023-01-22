using AirlinePriceNotificator.Services.SendAgent.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlinePricesNotificator.Services.SendAgent.Data.Configurations
{
    public class WebhookSubscriptionConfiguration : 
        IEntityTypeConfiguration<WebhookSubscription>
    {
        public void Configure(EntityTypeBuilder<WebhookSubscription> builder)
        {
            builder.ToTable(schema: "dbo", name: "WebhookSubscriptions");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.WebhookUri).IsRequired();
            builder.Property(x => x.Secret).IsRequired();
            builder.Property(x => x.WebhookType).IsRequired();
            builder.Property(x => x.WebhookPublisher).IsRequired();
        }
    }
}
