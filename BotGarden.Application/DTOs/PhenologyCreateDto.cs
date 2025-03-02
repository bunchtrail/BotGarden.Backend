using System;
using System.ComponentModel.DataAnnotations;

namespace BotGarden.Application.DTOs
{
    /// <summary>
    /// DTO для создания новой записи фенологических наблюдений
    /// </summary>
    public class PhenologyCreateDto
    {
        /// <summary>
        /// ID растения, к которому относится наблюдение
        /// </summary>
        [Required]
        public int PlantId { get; set; }

        /// <summary>
        /// Год наблюдений
        /// </summary>
        [Required]
        public int Year { get; set; }

        /// <summary>
        /// Дата распускания листьев
        /// </summary>
        public DateTime? LeafAppearanceDate { get; set; }
        
        /// <summary>
        /// Дата начала цветения
        /// </summary>
        public DateTime? FloweringStartDate { get; set; }
        
        /// <summary>
        /// Дата окончания цветения
        /// </summary>
        public DateTime? FloweringEndDate { get; set; }
        
        /// <summary>
        /// Дата плодоношения
        /// </summary>
        public DateTime? FruitingDate { get; set; }
        
        /// <summary>
        /// Дополнительные примечания
        /// </summary>
        [Required]
        [MaxLength(1000)]
        public required string Notes { get; set; }
    }
} 