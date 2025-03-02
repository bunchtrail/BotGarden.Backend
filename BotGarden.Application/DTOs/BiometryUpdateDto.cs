using System;
using System.ComponentModel.DataAnnotations;

namespace BotGarden.Application.DTOs
{
    /// <summary>
    /// DTO для обновления существующей записи биометрических измерений
    /// </summary>
    public class BiometryUpdateDto
    {
        /// <summary>
        /// ID записи биометрии
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// ID растения, к которому относится измерение
        /// </summary>
        public int? PlantId { get; set; }

        /// <summary>
        /// Дата измерения
        /// </summary>
        public DateTime? MeasurementDate { get; set; }

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
        [MaxLength(100)]
        public string? MeasurementType { get; set; }

        /// <summary>
        /// Значение дополнительного измерения
        /// </summary>
        public float? MeasurementValue { get; set; }

        /// <summary>
        /// Примечания к измерениям
        /// </summary>
        [MaxLength(1000)]
        public string? Notes { get; set; }
    }
} 