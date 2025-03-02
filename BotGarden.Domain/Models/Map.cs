using NetTopologySuite.Geometries;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BotGarden.Domain.Models
{
    /// <summary>
    /// Модель для хранения пути к изображению карты ботанического сада.
    /// Ответственность: хранение информации об изображении карты.
    /// Геометрические данные и полигоны хранятся в BotGardenModel.
    /// </summary>
    public class Map
    {
        [Key]
        public int MapImageId { get; set; }

        [Required]
        [Column("MapImagePath")]
        public string MapImagePath { get; set; } = string.Empty;
        
        /// <summary>
        /// Название карты или описание
        /// </summary>
        [MaxLength(255)]
        public string? MapDescription { get; set; }
    }
}
