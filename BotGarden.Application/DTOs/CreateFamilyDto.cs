using System.ComponentModel.DataAnnotations;

namespace BotGarden.Application.DTOs
{
    public class CreateFamilyDto
    {
        [Required]
        [MaxLength(100)]
        public required string FamilyName { get; set; }
    }
} 