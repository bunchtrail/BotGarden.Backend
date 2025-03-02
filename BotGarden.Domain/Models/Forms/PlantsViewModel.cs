using BotGarden.Domain.Models;

namespace BotGarden.Domain.Models.Forms
{
	public class PlantsViewModel
	{
		public IEnumerable<Plant>? Plants { get; set; }
		public IEnumerable<Exposition>? Collections { get; set; }
	}
}
