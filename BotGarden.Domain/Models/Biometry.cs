using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BotGarden.Domain.Models
{
    /// <summary>
    /// Таблица биометрических показателей.
    /// </summary>
    public class Biometry
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Plant")]
        public int PlantId { get; set; }
        public required Plant Plant { get; set; }

        /// <summary>
        /// Дата измерения.
        /// </summary>
        public DateTime MeasurementDate { get; set; }

        /// <summary>
        /// Высота (в см).
        /// </summary>
        public float? Height { get; set; }

        /// <summary>
        /// Диаметр цветка (в см).
        /// </summary>
        public float? FlowerDiameter { get; set; }

        /// <summary>
        /// Другие биометрические показатели.
        /// </summary>
        [MaxLength(100)]
        public required string MeasurementType { get; set; }
        public float? MeasurementValue { get; set; }

        /// <summary>
        /// Примечания к измерениям.
        /// </summary>
        [MaxLength(1000)]
        public required string Notes { get; set; }
    }
} 