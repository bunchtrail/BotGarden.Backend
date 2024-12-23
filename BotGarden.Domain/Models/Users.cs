using System;
using System.ComponentModel.DataAnnotations;

namespace BotGardens.Domain.Models
{
    public class Users
    {
        [Key]
        public int userId { get; set; }

        [Required]
        [EmailAddress]
        public string userEmail { get; set; }

        [Required]
        public string userHashedPass { get; set; }

        [Required]
        public string userRole { get; set; }

        public string RefreshTokenHash { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
