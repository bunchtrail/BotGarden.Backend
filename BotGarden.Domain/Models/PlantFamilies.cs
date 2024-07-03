
using System.ComponentModel.DataAnnotations;

namespace BotGarden.Core.Models
{
    public class PlantFamilies
    {
        [Key]
        public int FamilyId { get; set; }

        [Required]
        public string? FamilyName { get; set; }

        public ICollection<Plants>? Plants { get; set; }
    }
}
