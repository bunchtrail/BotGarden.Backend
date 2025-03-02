using NetTopologySuite.Geometries;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BotGarden.Domain.Models
{
    /// <summary>
    /// Модель ботанического сада для хранения геометрических данных участков
    /// Ответственность: хранение географических/геометрических данных участков ботанического сада
    /// </summary>
    public class BotGardenModel
    {
        [Key]
        public int LocationId { get; set; }

        /// <summary>
        /// Путь к файлу с геометрическими данными участка
        /// </summary>
        public string? LocationPath { get; set; }

        /// <summary>
        /// Геометрия участка в формате NetTopologySuite.Geometries.Polygon
        /// </summary>
        public Polygon? Geometry { get; set; } 

        /// <summary>
        /// Связь с экспозицией (один к одному)
        /// </summary>
        public Exposition? Exposition { get; set; }

        public BotGardenModel()
        {
            // Инициализация для предотвращения null-ссылок
            LocationPath = string.Empty;
        }
    }
}
