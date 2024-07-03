using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BotGarden.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:postgis", ",,");

            migrationBuilder.CreateTable(
                name: "BotGarden",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    LocationPath = table.Column<string>(type: "text", nullable: true),
                    Geometry = table.Column<Polygon>(type: "geometry", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BotGarden", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    CollectionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CollectionName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.CollectionId);
                });

            migrationBuilder.CreateTable(
                name: "Genus",
                columns: table => new
                {
                    GenusId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    GenusName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genus", x => x.GenusId);
                });

            migrationBuilder.CreateTable(
                name: "PlantFamilies",
                columns: table => new
                {
                    FamilyId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FamilyName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantFamilies", x => x.FamilyId);
                });

            migrationBuilder.CreateTable(
                name: "Sectors",
                columns: table => new
                {
                    SectorId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    SectorName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectors", x => x.SectorId);
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    PlantId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FamilyId = table.Column<int>(type: "integer", nullable: true),
                    BiometricId = table.Column<int>(type: "integer", nullable: true),
                    SectorId = table.Column<int>(type: "integer", nullable: true),
                    GenusId = table.Column<int>(type: "integer", nullable: true),
                    InventorNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Species = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Variety = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Form = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Determined = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    YearOfObs = table.Column<string>(type: "text", nullable: true),
                    PhenophaseDate = table.Column<string>(type: "text", nullable: true),
                    Year = table.Column<string>(type: "text", nullable: true),
                    MeasurementType = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    DateOfPlanting = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ProtectionStatus = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    FilledOut = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    HerbariumDuplicate = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Synonyms = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    PlantOrigin = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    NaturalHabitat = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    EcologyBiology = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    EconomicUse = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    Originator = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Date = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Country = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    ImagePath = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    HerbariumPresence = table.Column<bool>(type: "boolean", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    BotGardenModeLocationId = table.Column<int>(type: "integer", nullable: true),
                    CollectionsCollectionId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.PlantId);
                    table.ForeignKey(
                        name: "FK_Plants_BotGarden_BotGardenModeLocationId",
                        column: x => x.BotGardenModeLocationId,
                        principalTable: "BotGarden",
                        principalColumn: "LocationId");
                    table.ForeignKey(
                        name: "FK_Plants_Collections_CollectionsCollectionId",
                        column: x => x.CollectionsCollectionId,
                        principalTable: "Collections",
                        principalColumn: "CollectionId");
                    table.ForeignKey(
                        name: "FK_Plants_Genus_GenusId",
                        column: x => x.GenusId,
                        principalTable: "Genus",
                        principalColumn: "GenusId");
                    table.ForeignKey(
                        name: "FK_Plants_PlantFamilies_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "PlantFamilies",
                        principalColumn: "FamilyId");
                    table.ForeignKey(
                        name: "FK_Plants_Sectors_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "SectorId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plants_BotGardenModeLocationId",
                table: "Plants",
                column: "BotGardenModeLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_CollectionsCollectionId",
                table: "Plants",
                column: "CollectionsCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_FamilyId",
                table: "Plants",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_GenusId",
                table: "Plants",
                column: "GenusId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_SectorId",
                table: "Plants",
                column: "SectorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "BotGarden");

            migrationBuilder.DropTable(
                name: "Collections");

            migrationBuilder.DropTable(
                name: "Genus");

            migrationBuilder.DropTable(
                name: "PlantFamilies");

            migrationBuilder.DropTable(
                name: "Sectors");
        }
    }
}
