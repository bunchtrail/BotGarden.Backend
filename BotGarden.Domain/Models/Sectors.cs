using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace BotGarden.Domain.Models
{
    public class Sectors
    {
        [Key]
        public int SectorId { get; set; }

        [Required]
        public required string SectorName { get; set;}

        public ICollection<Plant>? Plants { get; set; }
    }
}
