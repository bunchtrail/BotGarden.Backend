namespace BotGarden.Application.DTOs
{
    public class CreateBotGardenModelDto
    {
        public required string LocationPath { get; set; }
        public required string Geometry { get; set; }
    }
}
