using BotGarden.Domain.Models;
using BotGarden.Infrastructure.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BotGarden.Application.Services.MainFormAdd
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
