using System.ComponentModel.DataAnnotations;

namespace BotGarden.Application.DTOs
{
    public class CreateGenusDto
    {
        [Required]
        public string GenusName { get; set; }
    }
} 