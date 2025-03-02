using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BotGarden.Domain.Models
{
    /// <summary>
    /// Таблица семейств (справочник).
    /// </summary>
    public class Family
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Название семейства (до 100 символов).
        /// </summary>
        [Required]
        [MaxLength(100)]
        public required string FamilyName { get; set; }

        public required ICollection<Plant> Plants { get; set; }
    }
} 