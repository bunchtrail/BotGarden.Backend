using System;
using System.ComponentModel.DataAnnotations;

namespace BotGarden.Application.DTOs
{
    public class PlantCreateDto
    {
        public int? FamilyId { get; set; }
        public int? SectorId { get; set; }
        public int? GenusId { get; set; }
        
        [MaxLength(100)]
        public string? InventorNumber { get; set; }
        
        [MaxLength(100)]
        public string? Species { get; set; }
        
        [MaxLength(100)]
        public string? Variety { get; set; }
        
        [MaxLength(100)]
        public string? Form { get; set; }
        
        [MaxLength(100)]
        public string? Determined { get; set; }
        
        [MaxLength(50)]
        public string? DateOfPlanting { get; set; }
        
        [MaxLength(100)]
        public string? ProtectionStatus { get; set; }
        
        [MaxLength(100)]
        public string? FilledOut { get; set; }
        
        [MaxLength(100)]
        public string? HerbariumDuplicate { get; set; }
        
        [MaxLength(500)]
        public string? Synonyms { get; set; }
        
        [MaxLength(500)]
        public string? PlantOrigin { get; set; }
        
        [MaxLength(500)]
        public string? NaturalHabitat { get; set; }
        
        [MaxLength(1000)]
        public string? EcologyBiology { get; set; }
        
        [MaxLength(1000)]
        public string? EconomicUse { get; set; }
        
        [MaxLength(50)]
        public string? Latitude { get; set; }
        
        [MaxLength(50)]
        public string? Longitude { get; set; }
        
        [MaxLength(100)]
        public string? Originator { get; set; }
        
        [MaxLength(50)]
        public string? Date { get; set; }
        
        [MaxLength(100)]
        public string? Country { get; set; }
        
        [MaxLength(500)]
        public string? ImagePath { get; set; }
        
        public bool HerbariumPresence { get; set; }
        
        [MaxLength(1000)]
        public string? Note { get; set; }
    }
}