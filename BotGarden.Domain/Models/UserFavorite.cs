using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BotGarden.Domain.Models
{
    /// <summary>
    /// Модель для хранения избранных растений пользователя
    /// </summary>
    public class UserFavorite
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Связь с пользователем
        /// </summary>
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }

        /// <summary>
        /// Связь с растением
        /// </summary>
        [ForeignKey("Plant")]
        public int PlantId { get; set; }
        public Plant? Plant { get; set; }

        /// <summary>
        /// Дата добавления в избранное
        /// </summary>
        public DateTime AddedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Личная заметка пользователя к растению
        /// </summary>
        [MaxLength(500)]
        public string? UserNote { get; set; }
    }
} 