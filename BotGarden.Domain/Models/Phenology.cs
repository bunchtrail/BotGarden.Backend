using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BotGarden.Domain.Models
{
    /// <summary>
    /// Таблица фенологических наблюдений.
    /// </summary>
    public class Phenology
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Plant")]
        public int PlantId { get; set; }
        public required Plant Plant { get; set; }

        /// <summary>
        /// Год наблюдений.
        /// </summary>
        public int Year { get; set; }

        // Даты фенофаз
        public DateTime? LeafAppearanceDate { get; set; }      // Распускание листьев
        public DateTime? FloweringStartDate { get; set; }      // Начало цветения
        public DateTime? FloweringEndDate { get; set; }        // Конец цветения
        public DateTime? FruitingDate { get; set; }            // Завязь/плодоношение
        
        /// <summary>
        /// Дополнительные примечания.
        /// </summary>
        public required string Notes { get; set; }
    }
} 