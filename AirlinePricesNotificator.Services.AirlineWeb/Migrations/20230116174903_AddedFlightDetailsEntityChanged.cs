using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlinePricesNotificator.Services.AirlineWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddedFlightDetailsEntityChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FlightCode",
                schema: "dbo",
                table: "FlightDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FlightCode",
                schema: "dbo",
                table: "FlightDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
