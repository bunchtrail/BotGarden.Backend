using BotGarden.Infrastructure.Data.Repositories;
using BotGarden.Domain.Models;
namespace BotGarden.Application.Services.MainFormAdd
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


