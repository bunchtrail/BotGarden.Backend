namespace BotGardens.Domain.Entities
{
    public class BiometricData
    {
        public int ID { get; set; }
        public string InventoryNumber { get; set; }  // Инв_номер
        public Plant Plant { get; set; }
        public string Indicator { get; set; }  // Показатель
        public double Value { get; set; }  // Значение
        public DateTime MeasurementDate { get; set; }  // Дата_измерения
    }
}
