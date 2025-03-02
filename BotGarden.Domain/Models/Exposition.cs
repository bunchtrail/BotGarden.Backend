using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BotGarden.Domain.Models
{
    /// <summary>
    /// Таблица экспозиций/коллекций (справочник).
    /// </summary>
    public class Exposition
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public required string ExpositionName { get; set; }

        /// <summary>
        /// Связь с BotGardenModel для хранения геометрии участка
        /// </summary>
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        public BotGardenModel? Location { get; set; }

        /// <summary>
        /// Коллекция растений, размещенных в этой экспозиции
        /// </summary>
        public required ICollection<Plant> Plants { get; set; }

        public Exposition()
        {
            // Инициализация коллекции для предотвращения null-ссылок
            Plants = new List<Plant>();
        }
    }
} 