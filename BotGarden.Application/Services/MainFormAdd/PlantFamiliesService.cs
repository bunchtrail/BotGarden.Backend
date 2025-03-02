using BotGarden.Infrastructure.Data.Repositories;
using BotGarden.Domain.Models;
namespace BotGarden.Application.Services.MainFormAdd
{

    public class FamilyService
    {
        private readonly IRepository<Family> _familyRepository;

        public FamilyService(IRepository<Family> familyRepository)
        {
            _familyRepository = familyRepository;
        }

        public async Task<IEnumerable<Family>> GetAllFamiliesAsync()
        {
            var families = await _familyRepository.GetAllAsync();
            return families ?? [];
        }

        public async Task<Family> CreateFamilyAsync(string familyName)
        {
            var newFamily = new Family
            {
                FamilyName = familyName,
                Plants = new List<Plant>()
            };

            await _familyRepository.AddAsync(newFamily);
            return newFamily;
        }
    }
}


