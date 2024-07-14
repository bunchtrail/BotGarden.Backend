namespace BotGardens.Domain.Entities
{
    public class Sector
    {
        public int ID { get; set; }
        public string SectorName { get; set; }  // Название_сектора
        public ICollection<Plant> Plants { get; set; }
    }
}
