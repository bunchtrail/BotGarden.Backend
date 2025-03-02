using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BotGarden.Domain.Models
{
    /// <summary>
    /// Основная сущность: экземпляр растения в коллекции.
    /// </summary>
    public class Specimen
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
        [MaxLength(50)]
        public required string Rod { get; set; }

        /// <summary>
        /// Вид (не более 50 символов).
        /// </summary>
        [MaxLength(50)]
        public required string Vid { get; set; }

        /// <summary>
        /// Сорт (не более 50 символов).
        /// </summary>
        [MaxLength(50)]
        public required string Sort { get; set; }

        /// <summary>
        /// Форма (не более 50 символов).
        /// </summary>
        [MaxLength(50)]
        public required string Forma { get; set; }

        /// <summary>
        /// Связь с таблицей семейств (Family).
        /// </summary>
        [ForeignKey("Family")]
        public int? FamilyId { get; set; }
        public required Family Family { get; set; }

        /// <summary>
        /// Связь с таблицей экспозиций (Exposition) — местоположение на территории сада.
        /// </summary>
        [ForeignKey("Exposition")]
        public int? ExpositionId { get; set; }
        public required Exposition Exposition { get; set; }

        /// <summary>
        /// Синонимы (до 250 символов).
        /// </summary>
        [MaxLength(250)]
        public required string Synonyms { get; set; }

        /// <summary>
        /// Происхождение образца (до 250 символов).
        /// </summary>
        [MaxLength(250)]
        public required string Origin { get; set; }

        /// <summary>
        /// Природный ареал (до 250 символов).
        /// </summary>
        [MaxLength(250)]
        public required string Areal { get; set; }

        /// <summary>
        /// Экология и биология вида (до 250 символов).
        /// </summary>
        [MaxLength(250)]
        public required string EcologyBiology { get; set; }

        /// <summary>
        /// Хозяйственное применение (до 250 символов).
        /// </summary>
        [MaxLength(250)]
        public required string EconomicUse { get; set; }

        /// <summary>
        /// Кто определил (определил вид, сорт и т.д.) – до 50 символов.
        /// </summary>
        [MaxLength(50)]
        public required string DeterminedBy { get; set; }

        /// <summary>
        /// Год посадки (числовое поле, необязательно).
        /// </summary>
        public int? YearOfPlanting { get; set; }

        /// <summary>
        /// Охранный статус вида (до 50 символов).
        /// </summary>
        [MaxLength(50)]
        public required string SecurityStatus { get; set; }

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
        public required string Originator { get; set; }

        /// <summary>
        /// Дополнительное поле для года, страны (до 250 символов).
        /// </summary>
        [MaxLength(250)]
        public required string YearCountry { get; set; }

        /// <summary>
        /// Иллюстрация (ссылка на изображение, до 250 символов).
        /// </summary>
        [MaxLength(250)]
        public required string Illustration { get; set; }

        /// <summary>
        /// Кто заполнял информацию (до 50 символов).
        /// </summary>
        [MaxLength(50)]
        public required string FilledBy { get; set; }

        /// <summary>
        /// Примечание – текстовое поле.
        /// </summary>
        public required string Notes { get; set; }

        /// <summary>
        /// Координаты местоположения растения
        /// </summary>
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        /// <summary>
        /// Навигационные свойства на фенологию и биометрию (один Specimen - много записей).
        /// </summary>
        public required ICollection<Phenology> Phenologies { get; set; }
        public required ICollection<Biometry> Biometries { get; set; }
    }

    /// <summary>
    /// Таблица фенологических наблюдений.
    /// </summary>
    public class Phenology
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Specimen")]
        public int SpecimenId { get; set; }
        public required Specimen Specimen { get; set; }

        /// <summary>
        /// Год наблюдений.
        /// </summary>
        public int Year { get; set; }

        // Даты фенофаз
        public DateTime? LeafAppearanceDate { get; set; }      // Распускание листьев
        public DateTime? FloweringStartDate { get; set; }      // Начало цветения
        public DateTime? FloweringEndDate { get; set; }        // Конец цветения
        public DateTime? FruitingDate { get; set; }            // Завязь/плодоношение
        
        /// <summary>
        /// Дополнительные примечания.
        /// </summary>
        public required string Notes { get; set; }
    }

    /// <summary>
    /// Таблица биометрических показателей.
    /// </summary>
    public class Biometry
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Specimen")]
        public int SpecimenId { get; set; }
        public required Specimen Specimen { get; set; }

        /// <summary>
        /// Дата измерения.
        /// </summary>
        public DateTime MeasurementDate { get; set; }

        /// <summary>
        /// Высота (в см).
        /// </summary>
        public float? Height { get; set; }

        /// <summary>
        /// Диаметр цветка (в см).
        /// </summary>
        public float? FlowerDiameter { get; set; }

        /// <summary>
        /// Другие биометрические показатели.
        /// </summary>
        public required string MeasurementType { get; set; }
        public float? MeasurementValue { get; set; }

        /// <summary>
        /// Примечания к измерениям.
        /// </summary>
        public required string Notes { get; set; }
    }

    /// <summary>
    /// Таблица семейств (справочник).
    /// </summary>
    public class Family
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Название семейства (до 100 символов).
        /// </summary>
        [Required]
        [MaxLength(100)]
        public required string FamilyName { get; set; }

        public required ICollection<Specimen> Specimens { get; set; }
    }

    /// <summary>
    /// Таблица экспозиций/коллекций (справочник).
    /// </summary>
    public class Exposition
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Название экспозиции или коллекции.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        public required ICollection<Specimen> Specimens { get; set; }
    }
} 