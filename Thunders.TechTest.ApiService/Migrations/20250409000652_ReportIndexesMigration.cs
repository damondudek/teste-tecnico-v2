using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Thunders.TechTest.ApiService.Migrations
{
    /// <inheritdoc />
    public partial class ReportIndexesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_City",
                table: "Tolls",
                column: "City");

            migrationBuilder.CreateIndex(
                name: "IX_TollBooth",
                table: "Tolls",
                column: "TollBooth");

            migrationBuilder.CreateIndex(
                name: "IX_UsageDateTime",
                table: "Tolls",
                column: "UsageDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_UsageDateTime_City",
                table: "Tolls",
                columns: new[] { "UsageDateTime", "City" });

            migrationBuilder.CreateIndex(
                name: "IX_UsageDateTime_TollBooth",
                table: "Tolls",
                columns: new[] { "UsageDateTime", "TollBooth" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_City",
                table: "Tolls");

            migrationBuilder.DropIndex(
                name: "IX_TollBooth",
                table: "Tolls");

            migrationBuilder.DropIndex(
                name: "IX_UsageDateTime",
                table: "Tolls");

            migrationBuilder.DropIndex(
                name: "IX_UsageDateTime_City",
                table: "Tolls");

            migrationBuilder.DropIndex(
                name: "IX_UsageDateTime_TollBooth",
                table: "Tolls");
        }
    }
}
