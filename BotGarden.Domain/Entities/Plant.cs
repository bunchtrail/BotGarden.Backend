namespace BotGardens.Domain.Entities
{
    public class Plant
    {
        public int ID { get; set; }
        public string InventoryNumber { get; set; }  // Инв_номер
        public string Genus { get; set; }  // Род
        public string Species { get; set; }  // Вид
        public string Variety { get; set; }  // Сорт
        public string Form { get; set; }  // Форма
        public string DeterminedBy { get; set; }  // Определил
        public string PlantingYear { get; set; }  // Год_посадки
        public string ConservationStatus { get; set; }  // Охранный_статус_вида
        public string FilledBy { get; set; }  // Заполнял
        public string DuplicatesInOtherHerbaria { get; set; }  // Наличие_дубликатов_в_других_гербариях
        public string Synonyms { get; set; }  // Синонимы
        public string SampleOrigin { get; set; }  // Происхождение_образца
        public string NaturalHabitat { get; set; }  // Природный_ареал
        public string EcologyAndBiology { get; set; }  // Экология_и_биология_вида
        public string EconomicUse { get; set; }  // Хозяйственное_применение
        public string Originator { get; set; }  // Оригинатор
        public string YearCountry { get; set; }  // Год_страна
        public string Illustration { get; set; }  // Иллюстрация
        public int FamilyID { get; set; }  // Семейство
        public Family Family { get; set; }
        public int LocationID { get; set; }  // Местоположение_на_территории_сада
        public Location Location { get; set; }
        public int SectorID { get; set; }  // Сектор
        public Sector Sector { get; set; }
        public bool HasHerbarium { get; set; }  // Наличие_гербария
        public string Notes { get; set; }  // Примечание
        public ICollection<PhenologicalData> PhenologicalDatas { get; set; }
        public ICollection<BiometricData> BiometricDatas { get; set; }
    }
}
