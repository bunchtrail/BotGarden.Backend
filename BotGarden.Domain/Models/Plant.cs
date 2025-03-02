using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BotGarden.Domain.Models
{
    /// <summary>
    /// Основная сущность: экземпляр растения в коллекции.
    /// </summary>
    public class Plant
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Инвентарный номер (уникальное поле, вводится вручную).
        /// </summary>
        [Required]
        [MaxLength(50)]
        public required string InventoryNumber { get; set; }

        /// <summary>
        /// Род (не более 50 символов).
        /// </summary>
        [Required]
        [MaxLength(50)]
        public required string Rod { get; set; }

        /// <summary>
        /// Связь с таблицей родов (Genus).
        /// </summary>
        [ForeignKey("Genus")]
        public int? GenusId { get; set; }
        public Genus? Genus { get; set; }

        /// <summary>
        /// Вид (не более 50 символов).
        /// </summary>
        [Required]
        [MaxLength(50)]
        public required string Vid { get; set; }

        /// <summary>
        /// Сорт (не более 50 символов).
        /// </summary>
        [MaxLength(50)]
        public string? Sort { get; set; }

        /// <summary>
        /// Форма (не более 50 символов).
        /// </summary>
        [MaxLength(50)]
        public string? Forma { get; set; }

        /// <summary>
        /// Связь с таблицей семейств (Family).
        /// </summary>
        [ForeignKey("Family")]
        public int? FamilyId { get; set; }
        public Family? Family { get; set; }

        /// <summary>
        /// Связь с пользователем, создавшим запись
        /// </summary>
        [ForeignKey("CreatedBy")]
        public int? CreatedByUserId { get; set; }
        public User? CreatedBy { get; set; }

        /// <summary>
        /// Связь с пользователем, последним изменившим запись
        /// </summary>
        [ForeignKey("ModifiedBy")]
        public int? ModifiedByUserId { get; set; }
        public User? ModifiedBy { get; set; }

        /// <summary>
        /// Дата создания записи
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Дата последнего изменения записи
        /// </summary>
        public DateTime? LastModifiedAt { get; set; }

        /// <summary>
        /// Связь с таблицей экспозиций (Exposition) — местоположение на территории сада.
        /// </summary>
        [ForeignKey("Exposition")]
        public int? ExpositionId { get; set; }
        public Exposition? Exposition { get; set; }

        /// <summary>
        /// Синонимы (до 250 символов).
        /// </summary>
        [MaxLength(250)]
        public string? Synonyms { get; set; }

        /// <summary>
        /// Происхождение образца (до 250 символов).
        /// </summary>
        [MaxLength(250)]
        public string? Origin { get; set; }

        /// <summary>
        /// Природный ареал (до 250 символов).
        /// </summary>
        [MaxLength(250)]
        public string? Areal { get; set; }

        /// <summary>
        /// Экология и биология вида (до 250 символов).
        /// </summary>
        [MaxLength(250)]
        public string? EcologyBiology { get; set; }

        /// <summary>
        /// Хозяйственное применение (до 250 символов).
        /// </summary>
        [MaxLength(250)]
        public string? EconomicUse { get; set; }

        /// <summary>
        /// Кто определил (определил вид, сорт и т.д.) – до 50 символов.
        /// </summary>
        [MaxLength(50)]
        public string? DeterminedBy { get; set; }

        /// <summary>
        /// Год посадки (числовое поле, необязательно).
        /// </summary>
        public int? YearOfPlanting { get; set; }

        /// <summary>
        /// Охранный статус вида (до 50 символов).
        /// </summary>
        [MaxLength(50)]
        public string? SecurityStatus { get; set; }

        /// <summary>
        /// Поле (логическое) «Наличие гербария».
        /// </summary>
        public bool? HasHerbarium { get; set; }

        /// <summary>
        /// Логическое поле «Наличие дубликатов в других гербариях».
        /// </summary>
        public bool? HasDuplicates { get; set; }

        /// <summary>
        /// Оригинатор (до 250 символов) – если важно для сортов.
        /// </summary>
        [MaxLength(250)]
        public string? Originator { get; set; }

        /// <summary>
        /// Дополнительное поле для года, страны (до 250 символов).
        /// </summary>
        [MaxLength(250)]
        public string? YearCountry { get; set; }

        /// <summary>
        /// Иллюстрация (ссылка на изображение, до 250 символов).
        /// </summary>
        [MaxLength(250)]
        public string? Illustration { get; set; }

        /// <summary>
        /// Кто заполнял информацию (до 50 символов).
        /// </summary>
        [MaxLength(50)]
        public string? FilledBy { get; set; }

        /// <summary>
        /// Примечание – текстовое поле.
        /// </summary>
        public string? Notes { get; set; }

        /// <summary>
        /// Координаты местоположения растения
        /// </summary>
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        /// <summary>
        /// Навигационные свойства на фенологию и биометрию (один Plant - много записей).
        /// </summary>
        public ICollection<Phenology> Phenologies { get; set; }
        public ICollection<Biometry> Biometries { get; set; }

        /// <summary>
        /// Конструктор для инициализации коллекций
        /// </summary>
        public Plant()
        {
            Phenologies = new List<Phenology>();
            Biometries = new List<Biometry>();
        }
    }
} 