using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BotGarden.Domain.Models
{
    /// <summary>
    /// Модель для хранения информации о посещениях пользователей
    /// </summary>
    public class UserVisit
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
        /// Дата начала посещения
        /// </summary>
        public DateTime VisitStartDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Дата окончания посещения
        /// </summary>
        public DateTime? VisitEndDate { get; set; }

        /// <summary>
        /// Прошел ли полный маршрут
        /// </summary>
        public bool CompletedFullRoute { get; set; } = false;

        /// <summary>
        /// Количество просмотренных растений
        /// </summary>
        public int ViewedPlantsCount { get; set; } = 0;

        /// <summary>
        /// Список посещенных экспозиций, хранится в формате JSON
        /// </summary>
        public string? VisitedExpositions { get; set; }

        /// <summary>
        /// Отзыв о посещении
        /// </summary>
        [MaxLength(1000)]
        public string? Feedback { get; set; }

        /// <summary>
        /// Оценка посещения (1-5)
        /// </summary>
        public int? Rating { get; set; }
    }
} 