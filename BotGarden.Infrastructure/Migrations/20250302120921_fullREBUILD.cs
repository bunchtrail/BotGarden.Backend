using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BotGarden.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fullREBUILD : Migration
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
                name: "Genera",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    GenusName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genera", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Maps",
                columns: table => new
                {
                    MapImageId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    MapImagePath = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MapDescription = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maps", x => x.MapImageId);
                });

            migrationBuilder.CreateTable(
                name: "Sectors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    SectorName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectors", x => x.Id);
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
                name: "Expositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ExpositionName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    LocationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expositions_BotGarden_LocationId",
                        column: x => x.LocationId,
                        principalTable: "BotGarden",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InventoryNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Rod = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    GenusId = table.Column<int>(type: "integer", nullable: true),
                    Vid = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Sort = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Forma = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    FamilyId = table.Column<int>(type: "integer", nullable: true),
                    ExpositionId = table.Column<int>(type: "integer", nullable: true),
                    Synonyms = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Origin = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Areal = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    EcologyBiology = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    EconomicUse = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    DeterminedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    YearOfPlanting = table.Column<int>(type: "integer", nullable: true),
                    SecurityStatus = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    HasHerbarium = table.Column<bool>(type: "boolean", nullable: true),
                    HasDuplicates = table.Column<bool>(type: "boolean", nullable: true),
                    Originator = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    YearCountry = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Illustration = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    FilledBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Latitude = table.Column<double>(type: "double precision", nullable: true),
                    Longitude = table.Column<double>(type: "double precision", nullable: true),
                    SectorsId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plants_Expositions_ExpositionId",
                        column: x => x.ExpositionId,
                        principalTable: "Expositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Plants_Families_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Families",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Plants_Genera_GenusId",
                        column: x => x.GenusId,
                        principalTable: "Genera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Plants_Sectors_SectorsId",
                        column: x => x.SectorsId,
                        principalTable: "Sectors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Biometries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    PlantId = table.Column<int>(type: "integer", nullable: false),
                    MeasurementDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: true),
                    FlowerDiameter = table.Column<float>(type: "real", nullable: true),
                    MeasurementType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    MeasurementValue = table.Column<float>(type: "real", nullable: true),
                    Notes = table.Column<string>(type: "text", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biometries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Biometries_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phenologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    PlantId = table.Column<int>(type: "integer", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    LeafAppearanceDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FloweringStartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FloweringEndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FruitingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Notes = table.Column<string>(type: "text", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phenologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phenologies_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Biometries_PlantId",
                table: "Biometries",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Expositions_LocationId",
                table: "Expositions",
                column: "LocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Phenologies_PlantId",
                table: "Phenologies",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_ExpositionId",
                table: "Plants",
                column: "ExpositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_FamilyId",
                table: "Plants",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_GenusId",
                table: "Plants",
                column: "GenusId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_InventoryNumber",
                table: "Plants",
                column: "InventoryNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plants_SectorsId",
                table: "Plants",
                column: "SectorsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Biometries");

            migrationBuilder.DropTable(
                name: "Maps");

            migrationBuilder.DropTable(
                name: "Phenologies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "Expositions");

            migrationBuilder.DropTable(
                name: "Families");

            migrationBuilder.DropTable(
                name: "Genera");

            migrationBuilder.DropTable(
                name: "Sectors");

            migrationBuilder.DropTable(
                name: "BotGarden");
        }
    }
}
