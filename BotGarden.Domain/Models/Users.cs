using System;
using System.ComponentModel.DataAnnotations;

namespace BotGardens.Domain.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [EmailAddress]
        public string UserEmail { get; set; } = null!;

        [Required]
        public string UserHashedPass { get; set; } = null!;

        [Required]
        public string UserRole { get; set; } = null!;

        [Required]
        public string RefreshTokenHash { get; set; } = null!;

        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
