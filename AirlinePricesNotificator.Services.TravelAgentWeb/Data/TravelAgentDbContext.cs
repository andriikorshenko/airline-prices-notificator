using AirlinePricesNotificator.Services.TravelAgentWeb.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirlinePricesNotificator.Services.TravelAgentWeb.Data
{
    public class TravelAgentDbContext : DbContext
    {
        public TravelAgentDbContext(DbContextOptions<TravelAgentDbContext> options)
            : base(options) { }

        public DbSet<WebhookSecret> WebhookSecrets { get; set; }
    }
}
