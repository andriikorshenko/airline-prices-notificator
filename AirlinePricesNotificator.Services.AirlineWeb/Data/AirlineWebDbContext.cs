using AirlinePricesNotificator.Services.AirlineWeb.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirlinePricesNotificator.Services.AirlineWeb.Data
{
    public class AirlineWebDbContext : DbContext
    {
        public AirlineWebDbContext(DbContextOptions<AirlineWebDbContext> options)
            : base(options) { }

        public DbSet<WebhookSubscription> WebhookSubscriptions { get; set; }
    }
}
