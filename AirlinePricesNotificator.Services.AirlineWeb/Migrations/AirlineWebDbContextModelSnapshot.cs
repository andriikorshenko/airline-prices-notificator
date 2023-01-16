﻿// <auto-generated />
using AirlinePricesNotificator.Services.AirlineWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AirlinePricesNotificator.Services.AirlineWeb.Migrations
{
    [DbContext(typeof(AirlineWebDbContext))]
    partial class AirlineWebDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AirlinePricesNotificator.Services.AirlineWeb.Data.Entities.FlightDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FlightCode")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("Id");

                    b.ToTable("FlightDetails", "dbo");
                });

            modelBuilder.Entity("AirlinePricesNotificator.Services.AirlineWeb.Data.Entities.WebhookSubscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Secret")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebhookPublisher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebhookType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebhookUri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WebhookSubscriptions", "dbo");
                });
#pragma warning restore 612, 618
        }
    }
}
