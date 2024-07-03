﻿
using System.ComponentModel.DataAnnotations;

namespace BotGarden.Core.Models
{
    public class Sectors
    {
        [Key]
        public int SectorId { get; set; }

        [Required]
        public string SectorName { get; set;}

        public ICollection<Plants>? Plants { get; set; }
    }
}
