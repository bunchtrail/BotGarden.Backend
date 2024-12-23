using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BotGardens.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMapImagePathToBotGardenMode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MapImagePath",
                table: "BotGarden",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MapImagePath",
                table: "BotGarden");
        }
    }
}
