using NetTopologySuite.Geometries;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BotGarden.Domain.Models
{
    public class Map
    {
        [Key]
        public int MapImageId { get; set; }

        [Column("MapImagePath")]
        public string? MapImagePath { get; set; }
    }
}
