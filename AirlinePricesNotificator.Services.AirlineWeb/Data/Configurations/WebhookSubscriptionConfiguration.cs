using AirlinePricesNotificator.Services.AirlineWeb.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlinePricesNotificator.Services.AirlineWeb.Data.Configurations
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
