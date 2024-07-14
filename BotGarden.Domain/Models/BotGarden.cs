using NetTopologySuite.Geometries;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BotGarden.Domain.Models
{
    public class BotGarden
    {
        [Key]
        public int LocationId { get; set; }

        public string? LocationPath { get; set; }

        public Polygon? Geometry { get; set; } 

        public ICollection<Plants>? Plants { get; set; }
    }
}
