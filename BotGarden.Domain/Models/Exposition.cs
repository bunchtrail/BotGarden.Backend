using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BotGarden.Domain.Models
{
    /// <summary>
    /// Таблица экспозиций/коллекций (справочник).
    /// </summary>
    public class Exposition
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Название экспозиции (до 100 символов).
        /// </summary>
        [Required]
        [MaxLength(100)]
        public required string ExpositionName { get; set; }

        public required ICollection<Plant> Plants { get; set; }
    }
} 