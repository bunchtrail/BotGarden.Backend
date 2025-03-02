using System.ComponentModel.DataAnnotations;

namespace BotGarden.Application.DTOs
{
    public class PlantUpdateDto
    {
        public int Id { get; set; }
        public int? FamilyId { get; set; }
        public int? ExpositionId { get; set; }
        public int? GenusId { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string? InventoryNumber { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string? Rod { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string? Vid { get; set; }
        
        [MaxLength(50)]
        public string? Sort { get; set; }
        
        [MaxLength(50)]
        public string? Forma { get; set; }
        
        [MaxLength(50)]
        public string? DeterminedBy { get; set; }
        
        public int? YearOfPlanting { get; set; }
        
        [MaxLength(50)]
        public string? SecurityStatus { get; set; }
        
        [MaxLength(50)]
        public string? FilledBy { get; set; }
        
        public bool? HasHerbarium { get; set; }
        
        public bool? HasDuplicates { get; set; }
        
        [MaxLength(250)]
        public string? Synonyms { get; set; }
        
        [MaxLength(250)]
        public string? Origin { get; set; }
        
        [MaxLength(250)]
        public string? Areal { get; set; }
        
        [MaxLength(250)]
        public string? EcologyBiology { get; set; }
        
        [MaxLength(250)]
        public string? EconomicUse { get; set; }
        
        public double? Latitude { get; set; }
        
        public double? Longitude { get; set; }
        
        [MaxLength(250)]
        public string? Originator { get; set; }
        
        [MaxLength(250)]
        public string? YearCountry { get; set; }
        
        [MaxLength(250)]
        public string? Illustration { get; set; }
        
        public string? Notes { get; set; }
    }
}