using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BotGardens.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MapImagePath",
                table: "BotGarden");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MapImagePath",
                table: "BotGarden",
                type: "text",
                nullable: true);
        }
    }
}
