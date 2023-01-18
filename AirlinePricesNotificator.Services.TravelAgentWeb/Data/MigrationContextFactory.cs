using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AirlinePricesNotificator.Services.TravelAgentWeb.Data
{

    /// <summary>Used to create db context during migration</summary>
    public class MigrationContextFactory : IDesignTimeDbContextFactory<TravelAgentDbContext>
    {
        public TravelAgentDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TravelAgentDbContext>();

            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();

            var connectionString = config.GetConnectionString("DbConnection");
            optionsBuilder.UseSqlServer(connectionString, opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
            return new TravelAgentDbContext(optionsBuilder.Options);
        }
    }
}
