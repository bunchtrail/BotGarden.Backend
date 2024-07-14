namespace BotGarden.Application.DTOs
{
    public class PlantUpdateDto
    {
        public int PlantId { get; set; }
        public int? FamilyId { get; set; }
        public int? BiometricId { get; set; }
        public int? SectorId { get; set; }
        public int? GenusId { get; set; }
        public string? InventorNumber { get; set; }
        public string? Species { get; set; }
        public string? Variety { get; set; }
        public string? Form { get; set; }
        public string? Determined { get; set; }
        public string? DateOfPlanting { get; set; }
        public string? ProtectionStatus { get; set; }
        public string? FilledOut { get; set; }
        public string? HerbariumDuplicate { get; set; }
        public string? Synonyms { get; set; }
        public string? PlantOrigin { get; set; }
        public string? NaturalHabitat { get; set; }
        public string? EcologyBiology { get; set; }
        public string? EconomicUse { get; set; }
        public string? Originator { get; set; }
        public string? Date { get; set; }
        public string? Country { get; set; }
        public string? ImagePath { get; set; }
        public bool? HerbariumPresence { get; set; }
        public string? Note { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
