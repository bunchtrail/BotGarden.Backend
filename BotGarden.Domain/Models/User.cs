using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BotGarden.Domain.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [EmailAddress]
        public string UserEmail { get; set; } = null!;

        [Required]
        public string UserHashedPass { get; set; } = null!;

        [Required]
        public string UserRole { get; set; } = null!; // Admin, Employee, Visitor

        [Required]
        public string RefreshTokenHash { get; set; } = null!;

        public DateTime RefreshTokenExpiryTime { get; set; }

        // Новые поля
        [MaxLength(50)]
        public string? FirstName { get; set; }

        [MaxLength(50)]
        public string? LastName { get; set; }

        // Статус активности пользователя
        public bool IsActive { get; set; } = true;

        // Дата регистрации
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

        // Дата последнего входа
        public DateTime? LastLoginDate { get; set; }

        // Навигационные свойства
        // Для сотрудников - связь с добавленными/измененными растениями
        public virtual ICollection<Plant>? CreatedPlants { get; set; }
        public virtual ICollection<Plant>? ModifiedPlants { get; set; }

        // Для посетителей - избранные растения, сохраненные маршруты
        public virtual ICollection<UserFavorite>? Favorites { get; set; }
        public virtual ICollection<UserVisit>? Visits { get; set; }
        
        public User()
        {
            CreatedPlants = new List<Plant>();
            ModifiedPlants = new List<Plant>();
            Favorites = new List<UserFavorite>();
            Visits = new List<UserVisit>();
        }
    }
}
