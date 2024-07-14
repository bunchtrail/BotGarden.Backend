using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BotGarden.Domain.Models
{
    public class Plants
    {
        [Key]
        public int PlantId { get; set; }

        public int qqqq { get; set; }

        public int? FamilyId { get; set; } //

        public int? BiometricId { get; set; }

        public int? SectorId { get; set; } //

        public int? GenusId { get; set; } //

        public string? InventorNumber { get; set; } //

        public string? Species { get; set; } //

        public string? Variety { get; set; } //

        public string? Form { get; set; } //

        public string? Determined { get; set; } //
        public string? YearOfObs { get; set; }
        public string? PhenophaseDate { get; set; }
        public string? Year { get; set; }
        public string? MeasurementType { get; set; }
        public string? Value { get; set; }

        public string? DateOfPlanting { get; set; } //

        public string? ProtectionStatus { get; set; } //

        public string? FilledOut { get; set; } //

        public string? HerbariumDuplicate { get; set; } //

        public string? Synonyms { get; set; } //

        public string? PlantOrigin { get; set; } //

        public string? NaturalHabitat { get; set; } //

        public string? EcologyBiology { get; set; } //

        public string? EconomicUse { get; set; } //


        public double Latitude { get; set; }


        public double Longitude { get; set; }

        public string? Originator { get; set; } //

        public string? Date { get; set; } //

        public string? Country { get; set; } //

        public string? ImagePath { get; set; } //

        public bool HerbariumPresence { get; set; } //

        public string? Note { get; set; } //

        [Timestamp]
        public byte[]? RowVersion { get; set; }

        public PlantFamilies? Family { get; set; }
        public Sectors? Sector { get; set; }



        public Genus? Genus { get; set; }
    }
}
