using System.ComponentModel.DataAnnotations;

namespace BotGarden.Application.DTOs
{
    public class CreateFamilyDto
    {
        [Required]
        public string FamilyName { get; set; }
    }
} 