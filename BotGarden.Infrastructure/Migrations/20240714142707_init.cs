using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BotGardens.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Families",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FamilyName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Families", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LocationName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sectors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SectorName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InventoryNumber = table.Column<string>(type: "text", nullable: false),
                    Genus = table.Column<string>(type: "text", nullable: false),
                    Species = table.Column<string>(type: "text", nullable: false),
                    Variety = table.Column<string>(type: "text", nullable: false),
                    Form = table.Column<string>(type: "text", nullable: false),
                    DeterminedBy = table.Column<string>(type: "text", nullable: false),
                    PlantingYear = table.Column<string>(type: "text", nullable: false),
                    ConservationStatus = table.Column<string>(type: "text", nullable: false),
                    FilledBy = table.Column<string>(type: "text", nullable: false),
                    DuplicatesInOtherHerbaria = table.Column<string>(type: "text", nullable: false),
                    Synonyms = table.Column<string>(type: "text", nullable: false),
                    SampleOrigin = table.Column<string>(type: "text", nullable: false),
                    NaturalHabitat = table.Column<string>(type: "text", nullable: false),
                    EcologyAndBiology = table.Column<string>(type: "text", nullable: false),
                    EconomicUse = table.Column<string>(type: "text", nullable: false),
                    Originator = table.Column<string>(type: "text", nullable: false),
                    YearCountry = table.Column<string>(type: "text", nullable: false),
                    Illustration = table.Column<string>(type: "text", nullable: false),
                    FamilyID = table.Column<int>(type: "integer", nullable: false),
                    LocationID = table.Column<int>(type: "integer", nullable: false),
                    HasHerbarium = table.Column<bool>(type: "boolean", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.ID);
                    table.UniqueConstraint("AK_Plants_InventoryNumber", x => x.InventoryNumber);
                    table.ForeignKey(
                        name: "FK_Plants_Families_FamilyID",
                        column: x => x.FamilyID,
                        principalTable: "Families",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plants_Locations_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Locations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BiometricDatas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InventoryNumber = table.Column<string>(type: "text", nullable: false),
                    Indicator = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<double>(type: "double precision", nullable: false),
                    MeasurementDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BiometricDatas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BiometricDatas_Plants_InventoryNumber",
                        column: x => x.InventoryNumber,
                        principalTable: "Plants",
                        principalColumn: "InventoryNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhenologicalDatas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InventoryNumber = table.Column<string>(type: "text", nullable: false),
                    ObservationYear = table.Column<string>(type: "text", nullable: false),
                    Phenophase = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhenologicalDatas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PhenologicalDatas_Plants_InventoryNumber",
                        column: x => x.InventoryNumber,
                        principalTable: "Plants",
                        principalColumn: "InventoryNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BiometricDatas_InventoryNumber",
                table: "BiometricDatas",
                column: "InventoryNumber");

            migrationBuilder.CreateIndex(
                name: "IX_PhenologicalDatas_InventoryNumber",
                table: "PhenologicalDatas",
                column: "InventoryNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_FamilyID",
                table: "Plants",
                column: "FamilyID");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_InventoryNumber",
                table: "Plants",
                column: "InventoryNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plants_LocationID",
                table: "Plants",
                column: "LocationID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BiometricDatas");

            migrationBuilder.DropTable(
                name: "CollectionAndExhibitions");

            migrationBuilder.DropTable(
                name: "PhenologicalDatas");

            migrationBuilder.DropTable(
                name: "Sectors");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "Families");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
