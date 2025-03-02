using NetTopologySuite.Geometries;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BotGarden.Domain.Models
{
    public class BotGardenModel
{
    [Key]
    public int LocationId { get; set; }

    public string? LocationPath { get; set; }

    public Polygon? Geometry { get; set; } 

    // Коллекция растений
    public ICollection<Plant>? Plants { get; set; }

    // Связь с экспозицией (один к одному)
    public Exposition? Exposition { get; set; }
}
}
