using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BotGardens.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removeqqq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "qqqq",
                table: "Plants");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "qqqq",
                table: "Plants",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
