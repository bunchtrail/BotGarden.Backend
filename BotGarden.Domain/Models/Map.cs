using NetTopologySuite.Geometries;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BotGarden.Domain.Models
{
    public class Map
    {
        [Key]
        public int MapImageId { get; set; }

        public string? MapImagePath { get; set; }

    }
}
