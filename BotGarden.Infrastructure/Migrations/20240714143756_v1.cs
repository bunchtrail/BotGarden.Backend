using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BotGardens.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollectionAndExhibitions");

            migrationBuilder.AddColumn<int>(
                name: "SectorID",
                table: "Plants",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Plants_SectorID",
                table: "Plants",
                column: "SectorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Sectors_SectorID",
                table: "Plants",
                column: "SectorID",
                principalTable: "Sectors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Sectors_SectorID",
                table: "Plants");

            migrationBuilder.DropIndex(
                name: "IX_Plants_SectorID",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "SectorID",
                table: "Plants");

            migrationBuilder.CreateTable(
                name: "CollectionAndExhibitions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CollectionName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionAndExhibitions", x => x.ID);
                });
        }
    }
}
