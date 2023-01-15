using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlinePricesNotificator.Services.AirlineWeb.Migrations
{
    /// <inheritdoc />
    public partial class AirlineDbContextOnModelCreatingAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "WebhookSubscriptions",
                newName: "WebhookSubscriptions",
                newSchema: "dbo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "WebhookSubscriptions",
                schema: "dbo",
                newName: "WebhookSubscriptions");
        }
    }
}
