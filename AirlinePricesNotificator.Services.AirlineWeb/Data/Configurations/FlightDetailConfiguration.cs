using AirlinePricesNotificator.Services.AirlineWeb.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlinePricesNotificator.Services.AirlineWeb.Data.Configurations
{
    public class FlightDetailConfiguration : 
        IEntityTypeConfiguration<FlightDetail>
    {
        public void Configure(EntityTypeBuilder<FlightDetail> builder)
        {
            builder.ToTable(schema: "dbo", name: "FlightDetails");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.FlightCode).IsRequired();                
            builder.Property(x => x.Price).IsRequired()
                .HasColumnType("decimal(6,2)");
        }
    }
}
