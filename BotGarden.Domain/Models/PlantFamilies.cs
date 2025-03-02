using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BotGarden.Domain.Models
{
    // Этот класс оставлен для обратной совместимости.
    // Рекомендуется использовать класс Family вместо него.
    public class PlantFamilies
    {
        [Key]
        public int FamilyId { get; set; }

        [Required]
        public string? FamilyName { get; set; }

        // Обновлено для совместимости с новой моделью Plant
        public ICollection<Plant>? Plants { get; set; }
    }
}
