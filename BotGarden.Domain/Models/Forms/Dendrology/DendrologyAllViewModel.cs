using System.Collections.Generic;
using BotGarden.Domain.Models;
namespace BotGarden.Domain.Models.Forms.Dendrology
{
    public class DendrologyAllViewModel
    {
        public IEnumerable<PlantFamilies>? PlantFamilies { get; set; }
        public IEnumerable<BotGarden>? BotGardens { get; set; }
        public IEnumerable<Genus>? Genuses { get; set; }
    }
}
