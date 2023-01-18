using AirlinePricesNotificator.Services.TravelAgentWeb.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlinePricesNotificator.Services.TravelAgentWeb.Data.Configurations
{
    public class WebhookSecretConfiguration : 
        IEntityTypeConfiguration<WebhookSecret>
    {
        public void Configure(EntityTypeBuilder<WebhookSecret> builder)
        {
            builder.ToTable(schema: "dbo", name: "WebhookSecrets");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Secret).IsRequired();
            builder.Property(x => x.Publisher).IsRequired();
        }
    }
}
