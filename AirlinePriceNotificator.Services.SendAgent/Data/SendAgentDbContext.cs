using AirlinePriceNotificator.Services.SendAgent.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AirlinePricesNotificator.Services.SendAgent.Data
{
    public class SendAgentDbContext : DbContext
    {
        public SendAgentDbContext(DbContextOptions<SendAgentDbContext> options)
            : base(options) { }

        public DbSet<WebhookSubscription> WebhookSubscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SendAgentDbContext).Assembly);

            modelBuilder.HasDefaultSchema("dbo");
        }
    }
}
