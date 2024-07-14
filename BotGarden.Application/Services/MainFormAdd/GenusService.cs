using BotGarden.Infrastructure.Data.Repositories;
using BotGarden.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BotGarden.Application.Services.MainFormAdd
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
