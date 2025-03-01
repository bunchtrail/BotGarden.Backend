using System.ComponentModel.DataAnnotations;

namespace BotGarden.Application.DTOs
{
    public class CreateFamilyDto
    {
        [Required]
        public required string FamilyName { get; set; }
    }
} 