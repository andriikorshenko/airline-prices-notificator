using AirlinePricesNotificator.Services.AirlineWeb.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirlinePricesNotificator.Services.AirlineWeb.Data
{
    public class AirlineWebDbContext : DbContext
    {
        public AirlineWebDbContext(DbContextOptions<AirlineWebDbContext> options)
            : base(options) { }

        public DbSet<WebhookSubscription> WebhookSubscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AirlineWebDbContext).Assembly);

            modelBuilder.HasDefaultSchema("dbo");
        }
    }
}
