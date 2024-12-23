using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BotGardens.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MapImapePath",
                table: "Map",
                newName: "MapImagePath");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MapImagePath",
                table: "Map",
                newName: "MapImapePath");
        }
    }
}
