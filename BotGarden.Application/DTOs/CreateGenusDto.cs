using System.ComponentModel.DataAnnotations;

namespace BotGarden.Application.DTOs
{
    public class CreateGenusDto
    {
        [Required]
        public required string GenusName { get; set; }
    }
} 