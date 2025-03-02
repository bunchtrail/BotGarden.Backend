using System.ComponentModel.DataAnnotations;

namespace BotGarden.Application.DTOs
{
    public class CreateGenusDto
    {
        [Required]
        [MaxLength(100)]
        public required string GenusName { get; set; }
    }
} 