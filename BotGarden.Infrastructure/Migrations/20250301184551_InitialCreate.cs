using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BotGarden.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                name: "Expositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expositions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Families",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FamilyName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Families", x => x.Id);
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
                name: "Map",
                columns: table => new
                {
                    MapImageId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    MapImagePath = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Map", x => x.MapImageId);
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
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UserEmail = table.Column<string>(type: "text", nullable: false),
                    UserHashedPass = table.Column<string>(type: "text", nullable: false),
                    UserRole = table.Column<string>(type: "text", nullable: false),
                    RefreshTokenHash = table.Column<string>(type: "text", nullable: false),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Specimens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InventoryNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Rod = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Vid = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Sort = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Forma = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    FamilyId = table.Column<int>(type: "integer", nullable: true),
                    ExpositionId = table.Column<int>(type: "integer", nullable: true),
                    Synonyms = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Origin = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Areal = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    EcologyBiology = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    EconomicUse = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    DeterminedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    YearOfPlanting = table.Column<int>(type: "integer", nullable: true),
                    SecurityStatus = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    HasHerbarium = table.Column<bool>(type: "boolean", nullable: true),
                    HasDuplicates = table.Column<bool>(type: "boolean", nullable: true),
                    Originator = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    YearCountry = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Illustration = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    FilledBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    Latitude = table.Column<double>(type: "double precision", nullable: true),
                    Longitude = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specimens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specimens_Expositions_ExpositionId",
                        column: x => x.ExpositionId,
                        principalTable: "Expositions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Specimens_Families_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Families",
                        principalColumn: "Id");
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
                    BotGardenModelId = table.Column<int>(type: "integer", nullable: true),
                    InventorNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Species = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Variety = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Form = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Determined = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    YearOfObs = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    PhenophaseDate = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Year = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    MeasurementType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Value = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
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
                    HerbariumPresence = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Note = table.Column<string>(type: "text", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CollectionsCollectionId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.PlantId);
                    table.ForeignKey(
                        name: "FK_Plants_BotGarden_BotGardenModelId",
                        column: x => x.BotGardenModelId,
                        principalTable: "BotGarden",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Plants_Collections_CollectionsCollectionId",
                        column: x => x.CollectionsCollectionId,
                        principalTable: "Collections",
                        principalColumn: "CollectionId");
                    table.ForeignKey(
                        name: "FK_Plants_Genus_GenusId",
                        column: x => x.GenusId,
                        principalTable: "Genus",
                        principalColumn: "GenusId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Plants_PlantFamilies_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "PlantFamilies",
                        principalColumn: "FamilyId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Plants_Sectors_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "SectorId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Biometries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    SpecimenId = table.Column<int>(type: "integer", nullable: false),
                    MeasurementDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: true),
                    FlowerDiameter = table.Column<float>(type: "real", nullable: true),
                    MeasurementType = table.Column<string>(type: "text", nullable: false),
                    MeasurementValue = table.Column<float>(type: "real", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biometries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Biometries_Specimens_SpecimenId",
                        column: x => x.SpecimenId,
                        principalTable: "Specimens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phenologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    SpecimenId = table.Column<int>(type: "integer", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    LeafAppearanceDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FloweringStartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FloweringEndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FruitingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phenologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phenologies_Specimens_SpecimenId",
                        column: x => x.SpecimenId,
                        principalTable: "Specimens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Biometries_SpecimenId",
                table: "Biometries",
                column: "SpecimenId");

            migrationBuilder.CreateIndex(
                name: "IX_Phenologies_SpecimenId",
                table: "Phenologies",
                column: "SpecimenId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_BotGardenModelId",
                table: "Plants",
                column: "BotGardenModelId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Specimens_ExpositionId",
                table: "Specimens",
                column: "ExpositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Specimens_FamilyId",
                table: "Specimens",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_Specimens_InventoryNumber",
                table: "Specimens",
                column: "InventoryNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Biometries");

            migrationBuilder.DropTable(
                name: "Map");

            migrationBuilder.DropTable(
                name: "Phenologies");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Specimens");

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

            migrationBuilder.DropTable(
                name: "Expositions");

            migrationBuilder.DropTable(
                name: "Families");
        }
    }
}
