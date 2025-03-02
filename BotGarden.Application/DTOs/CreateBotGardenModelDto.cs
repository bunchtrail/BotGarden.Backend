using System.ComponentModel.DataAnnotations;

namespace BotGarden.Application.DTOs
{
    public class CreateBotGardenModelDto
    {
        [Required]
        public required string LocationPath { get; set; }

        /// <summary>
        /// Строковое представление геометрии участка в формате WKT (Well-Known Text).
        /// Будет преобразовано в NetTopologySuite.Geometries.Polygon при обработке.
        /// </summary>
        [Required]
        public required string Geometry { get; set; }
    }
}
