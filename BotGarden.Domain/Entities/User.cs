﻿using System.ComponentModel.DataAnnotations;

namespace BotGardens.Domain.Entities
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
