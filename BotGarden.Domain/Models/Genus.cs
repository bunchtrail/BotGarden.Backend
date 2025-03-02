using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BotGarden.Domain.Models
{
	/// <summary>
	/// Таблица родов растений (справочник).
	/// </summary>
	public class Genus
	{
		[Key]
		public int Id { get; set; }

		/// <summary>
		/// Название рода (до 100 символов).
		/// </summary>
		[Required]
		[MaxLength(100)]
		public required string GenusName { get; set; }

		public required ICollection<Plant> Plants { get; set; }
	}
}