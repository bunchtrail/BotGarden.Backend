using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BotGarden.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLocationIdToExposition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Expositions",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expositions_LocationId",
                table: "Expositions",
                column: "LocationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Expositions_BotGarden_LocationId",
                table: "Expositions",
                column: "LocationId",
                principalTable: "BotGarden",
                principalColumn: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expositions_BotGarden_LocationId",
                table: "Expositions");

            migrationBuilder.DropIndex(
                name: "IX_Expositions_LocationId",
                table: "Expositions");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Expositions");
        }
    }
}
