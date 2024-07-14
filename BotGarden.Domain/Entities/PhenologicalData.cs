namespace BotGardens.Domain.Entities
{
    public class PhenologicalData
    {
        public int ID { get; set; }
        public string InventoryNumber { get; set; }  // Инв_номер
        public Plant Plant { get; set; }
        public string ObservationYear { get; set; }  // Год_наблюдений
        public DateTime Phenophase { get; set; }  // Фенофаза
    }
}
