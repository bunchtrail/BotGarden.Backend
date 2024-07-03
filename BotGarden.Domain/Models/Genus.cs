using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BotGarden.Core.Models
{
	public class Genus
	{
		[Key]
		public int GenusId { get; set; }

		public string? GenusName { get; set; }

		
		public ICollection<Plants>? Plants { get; set; }
	}
}