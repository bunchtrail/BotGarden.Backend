using BotGarden.Core.Data.Repositories;
using BotGarden.Core.Models;
namespace BotGarden.Applications.Services
{

    public class PlantFamilyService
    {
        private readonly IRepository<PlantFamilies> _plantFamilyRepository;

        public PlantFamilyService(IRepository<PlantFamilies> plantFamilyRepository)
        {
            _plantFamilyRepository = plantFamilyRepository;
        }

        public async Task<IEnumerable<PlantFamilies>> GetAllPlantFamiliesAsync()
        {
            var families = await _plantFamilyRepository.GetAllAsync();
            return families ?? [];
        }

    }
}


