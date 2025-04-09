using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Thunders.TechTest.ApiService.Migrations
{
    /// <inheritdoc />
    public partial class TollAndReportChangesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CacheKey",
                table: "Reports");

            migrationBuilder.RenameColumn(
                name: "Plaza",
                table: "Tolls",
                newName: "TollBooth");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TollBooth",
                table: "Tolls",
                newName: "Plaza");

            migrationBuilder.AddColumn<string>(
                name: "CacheKey",
                table: "Reports",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
