using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BotGarden.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDuplicateClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Biometries_Specimens_SpecimenId",
                table: "Biometries");

            migrationBuilder.DropForeignKey(
                name: "FK_Phenologies_Specimens_SpecimenId",
                table: "Phenologies");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_BotGarden_BotGardenModelId",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Collections_CollectionsCollectionId",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Genus_GenusId",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_PlantFamilies_FamilyId",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Sectors_SectorId",
                table: "Plants");

            migrationBuilder.DropTable(
                name: "Collections");

            migrationBuilder.DropTable(
                name: "PlantFamilies");

            migrationBuilder.DropTable(
                name: "Specimens");

            migrationBuilder.DropIndex(
                name: "IX_Plants_SectorId",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "DateOfPlanting",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Determined",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "FilledOut",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Form",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "HerbariumDuplicate",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "HerbariumPresence",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "InventorNumber",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "MeasurementType",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "NaturalHabitat",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "PhenophaseDate",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "PlantOrigin",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "ProtectionStatus",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Species",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Variety",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "YearOfObs",
                table: "Plants");

            migrationBuilder.RenameColumn(
                name: "SectorId",
                table: "Sectors",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SectorId",
                table: "Plants",
                newName: "YearOfPlanting");

            migrationBuilder.RenameColumn(
                name: "CollectionsCollectionId",
                table: "Plants",
                newName: "SectorsId");

            migrationBuilder.RenameColumn(
                name: "BotGardenModelId",
                table: "Plants",
                newName: "ExpositionId");

            migrationBuilder.RenameColumn(
                name: "BiometricId",
                table: "Plants",
                newName: "BotGardenModelLocationId");

            migrationBuilder.RenameColumn(
                name: "PlantId",
                table: "Plants",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Plants_CollectionsCollectionId",
                table: "Plants",
                newName: "IX_Plants_SectorsId");

            migrationBuilder.RenameIndex(
                name: "IX_Plants_BotGardenModelId",
                table: "Plants",
                newName: "IX_Plants_ExpositionId");

            migrationBuilder.RenameColumn(
                name: "SpecimenId",
                table: "Phenologies",
                newName: "PlantId");

            migrationBuilder.RenameIndex(
                name: "IX_Phenologies_SpecimenId",
                table: "Phenologies",
                newName: "IX_Phenologies_PlantId");

            migrationBuilder.RenameColumn(
                name: "GenusId",
                table: "Genus",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Expositions",
                newName: "ExpositionName");

            migrationBuilder.RenameColumn(
                name: "SpecimenId",
                table: "Biometries",
                newName: "PlantId");

            migrationBuilder.RenameIndex(
                name: "IX_Biometries_SpecimenId",
                table: "Biometries",
                newName: "IX_Biometries_PlantId");

            migrationBuilder.AlterColumn<string>(
                name: "SectorName",
                table: "Sectors",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Synonyms",
                table: "Plants",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Originator",
                table: "Plants",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "Plants",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "Plants",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<string>(
                name: "EconomicUse",
                table: "Plants",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EcologyBiology",
                table: "Plants",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Areal",
                table: "Plants",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeterminedBy",
                table: "Plants",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FilledBy",
                table: "Plants",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Forma",
                table: "Plants",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "HasDuplicates",
                table: "Plants",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasHerbarium",
                table: "Plants",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Illustration",
                table: "Plants",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InventoryNumber",
                table: "Plants",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Plants",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Origin",
                table: "Plants",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rod",
                table: "Plants",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecurityStatus",
                table: "Plants",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sort",
                table: "Plants",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Vid",
                table: "Plants",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "YearCountry",
                table: "Plants",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "GenusName",
                table: "Genus",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MeasurementType",
                table: "Biometries",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_BotGardenModelLocationId",
                table: "Plants",
                column: "BotGardenModelLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_InventoryNumber",
                table: "Plants",
                column: "InventoryNumber",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Biometries_Plants_PlantId",
                table: "Biometries",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Phenologies_Plants_PlantId",
                table: "Phenologies",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_BotGarden_BotGardenModelLocationId",
                table: "Plants",
                column: "BotGardenModelLocationId",
                principalTable: "BotGarden",
                principalColumn: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Expositions_ExpositionId",
                table: "Plants",
                column: "ExpositionId",
                principalTable: "Expositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Families_FamilyId",
                table: "Plants",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Genus_GenusId",
                table: "Plants",
                column: "GenusId",
                principalTable: "Genus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Sectors_SectorsId",
                table: "Plants",
                column: "SectorsId",
                principalTable: "Sectors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Biometries_Plants_PlantId",
                table: "Biometries");

            migrationBuilder.DropForeignKey(
                name: "FK_Phenologies_Plants_PlantId",
                table: "Phenologies");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_BotGarden_BotGardenModelLocationId",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Expositions_ExpositionId",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Families_FamilyId",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Genus_GenusId",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Sectors_SectorsId",
                table: "Plants");

            migrationBuilder.DropIndex(
                name: "IX_Plants_BotGardenModelLocationId",
                table: "Plants");

            migrationBuilder.DropIndex(
                name: "IX_Plants_InventoryNumber",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Areal",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "DeterminedBy",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "FilledBy",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Forma",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "HasDuplicates",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "HasHerbarium",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Illustration",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "InventoryNumber",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Origin",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Rod",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "SecurityStatus",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Vid",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "YearCountry",
                table: "Plants");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Sectors",
                newName: "SectorId");

            migrationBuilder.RenameColumn(
                name: "YearOfPlanting",
                table: "Plants",
                newName: "SectorId");

            migrationBuilder.RenameColumn(
                name: "SectorsId",
                table: "Plants",
                newName: "CollectionsCollectionId");

            migrationBuilder.RenameColumn(
                name: "ExpositionId",
                table: "Plants",
                newName: "BotGardenModelId");

            migrationBuilder.RenameColumn(
                name: "BotGardenModelLocationId",
                table: "Plants",
                newName: "BiometricId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Plants",
                newName: "PlantId");

            migrationBuilder.RenameIndex(
                name: "IX_Plants_SectorsId",
                table: "Plants",
                newName: "IX_Plants_CollectionsCollectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Plants_ExpositionId",
                table: "Plants",
                newName: "IX_Plants_BotGardenModelId");

            migrationBuilder.RenameColumn(
                name: "PlantId",
                table: "Phenologies",
                newName: "SpecimenId");

            migrationBuilder.RenameIndex(
                name: "IX_Phenologies_PlantId",
                table: "Phenologies",
                newName: "IX_Phenologies_SpecimenId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Genus",
                newName: "GenusId");

            migrationBuilder.RenameColumn(
                name: "ExpositionName",
                table: "Expositions",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "PlantId",
                table: "Biometries",
                newName: "SpecimenId");

            migrationBuilder.RenameIndex(
                name: "IX_Biometries_PlantId",
                table: "Biometries",
                newName: "IX_Biometries_SpecimenId");

            migrationBuilder.AlterColumn<string>(
                name: "SectorName",
                table: "Sectors",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Synonyms",
                table: "Plants",
                type: "character varying(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Originator",
                table: "Plants",
                type: "character varying(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "Plants",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "Plants",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EconomicUse",
                table: "Plants",
                type: "character varying(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "EcologyBiology",
                table: "Plants",
                type: "character varying(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Plants",
                type: "character varying(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Plants",
                type: "character varying(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DateOfPlanting",
                table: "Plants",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Determined",
                table: "Plants",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FilledOut",
                table: "Plants",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Form",
                table: "Plants",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HerbariumDuplicate",
                table: "Plants",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HerbariumPresence",
                table: "Plants",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Plants",
                type: "character varying(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InventorNumber",
                table: "Plants",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeasurementType",
                table: "Plants",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NaturalHabitat",
                table: "Plants",
                type: "character varying(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Plants",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhenophaseDate",
                table: "Plants",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlantOrigin",
                table: "Plants",
                type: "character varying(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProtectionStatus",
                table: "Plants",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Plants",
                type: "bytea",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Species",
                table: "Plants",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "Plants",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Variety",
                table: "Plants",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "Plants",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YearOfObs",
                table: "Plants",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GenusName",
                table: "Genus",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "MeasurementType",
                table: "Biometries",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

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
                name: "Specimens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ExpositionId = table.Column<int>(type: "integer", nullable: true),
                    FamilyId = table.Column<int>(type: "integer", nullable: true),
                    Areal = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    DeterminedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    EcologyBiology = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    EconomicUse = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    FilledBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Forma = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    HasDuplicates = table.Column<bool>(type: "boolean", nullable: true),
                    HasHerbarium = table.Column<bool>(type: "boolean", nullable: true),
                    Illustration = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    InventoryNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Latitude = table.Column<double>(type: "double precision", nullable: true),
                    Longitude = table.Column<double>(type: "double precision", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    Origin = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Originator = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Rod = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SecurityStatus = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Sort = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Synonyms = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Vid = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    YearCountry = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    YearOfPlanting = table.Column<int>(type: "integer", nullable: true)
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

            migrationBuilder.AddForeignKey(
                name: "FK_Biometries_Specimens_SpecimenId",
                table: "Biometries",
                column: "SpecimenId",
                principalTable: "Specimens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Phenologies_Specimens_SpecimenId",
                table: "Phenologies",
                column: "SpecimenId",
                principalTable: "Specimens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_BotGarden_BotGardenModelId",
                table: "Plants",
                column: "BotGardenModelId",
                principalTable: "BotGarden",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Collections_CollectionsCollectionId",
                table: "Plants",
                column: "CollectionsCollectionId",
                principalTable: "Collections",
                principalColumn: "CollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Genus_GenusId",
                table: "Plants",
                column: "GenusId",
                principalTable: "Genus",
                principalColumn: "GenusId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_PlantFamilies_FamilyId",
                table: "Plants",
                column: "FamilyId",
                principalTable: "PlantFamilies",
                principalColumn: "FamilyId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Sectors_SectorId",
                table: "Plants",
                column: "SectorId",
                principalTable: "Sectors",
                principalColumn: "SectorId",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
