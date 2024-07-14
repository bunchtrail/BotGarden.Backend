﻿
using System.ComponentModel.DataAnnotations;

namespace BotGarden.Domain.Models
{
    public class Collections
    {
        [Key]
        public int CollectionId { get; set; }


        public string? CollectionName { get; set; }


        public ICollection<Plants>? Plants { get; set; }
    }
}
