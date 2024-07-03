using BotGarden.Core.Models;
using BotGarden.Core.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BotGarden.Applications.Services
{
    public class BotGardenService
    {
        private readonly IRepository<BotGardenMode> _botGardenRepository;

        public BotGardenService(IRepository<BotGardenMode> botGardenRepository)
        {
            _botGardenRepository = botGardenRepository;
        }

        public async Task<IEnumerable<BotGardenMode>> GetAllBotGardensAsync()
        {
            return await _botGardenRepository.GetAllAsync();
        }
    }
}
