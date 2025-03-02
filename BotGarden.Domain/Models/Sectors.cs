using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace BotGarden.Domain.Models
{
    /// <summary>
    /// Таблица секторов ботанического сада (справочник).
    /// </summary>
    public class Sectors
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Название сектора (до 100 символов).
        /// </summary>
        [Required]
        [MaxLength(100)]
        public required string SectorName { get; set;}

        public required ICollection<Plant> Plants { get; set; }
    }
}
