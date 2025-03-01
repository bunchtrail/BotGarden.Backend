using System.ComponentModel.DataAnnotations;

namespace BotGarden.Domain.Models
{
    public class Sectors
    {
        [Key]
        public int SectorId { get; set; }

        [Required]
        public required string SectorName { get; set;}

        public ICollection<Plants>? Plants { get; set; }
    }
}
