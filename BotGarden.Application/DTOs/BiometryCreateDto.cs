using System;
using System.ComponentModel.DataAnnotations;

namespace BotGarden.Application.DTOs
{
    /// <summary>
    /// DTO для создания новой записи биометрических измерений
    /// </summary>
    public class BiometryCreateDto
    {
        /// <summary>
        /// ID растения, к которому относится измерение
        /// </summary>
        [Required]
        public int PlantId { get; set; }

        /// <summary>
        /// Дата измерения
        /// </summary>
        [Required]
        public DateTime MeasurementDate { get; set; }

        /// <summary>
        /// Высота (в см)
        /// </summary>
        public float? Height { get; set; }

        /// <summary>
        /// Диаметр цветка (в см)
        /// </summary>
        public float? FlowerDiameter { get; set; }

        /// <summary>
        /// Тип дополнительного измерения
        /// </summary>
        [Required]
        [MaxLength(50)]
        public required string MeasurementType { get; set; }

        /// <summary>
        /// Значение дополнительного измерения
        /// </summary>
        public float? MeasurementValue { get; set; }

        /// <summary>
        /// Примечания к измерениям
        /// </summary>
        [Required]
        public required string Notes { get; set; }
    }
} 