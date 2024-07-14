

using System.ComponentModel.DataAnnotations;

namespace BotGardens.Domain.Models
{
    public class Users
    {
        [Key]
        public int userId { get; set; }

        public string userEmail { get; set; }

        public string userHashedPass { get; set; }

        public string userRole { get; set; }
    }
}
