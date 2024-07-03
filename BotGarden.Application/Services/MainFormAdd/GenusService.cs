using BotGarden.Core.Data.Repositories;
using BotGarden.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BotGarden.Applications.Services
{
    public class GenusService
    {
        private readonly IRepository<Genus> _genusRepository;

        public GenusService(IRepository<Genus> genusRepository)
        {
            _genusRepository = genusRepository;
        }

        public async Task<IEnumerable<Genus>> GetAllGenusAsync()
        {
            return await _genusRepository.GetAllAsync();
        }
    }
}
