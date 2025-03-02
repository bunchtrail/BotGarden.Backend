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
        /// Название экспозиции для использования в методах сервиса
        /// </summary>
        [NotMapped]
        public string? Name 
        { 
            get => ExpositionName; 
            set { if (value != null) ExpositionName = value; } 
        }

        /// <summary>
        /// Описание экспозиции
        /// </summary>
        [MaxLength(1000)]
        public string? Description { get; set; }

        /// <summary>
        /// URL изображения экспозиции
        /// </summary>
        [MaxLength(255)]
        public string? ImageUrl { get; set; }

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