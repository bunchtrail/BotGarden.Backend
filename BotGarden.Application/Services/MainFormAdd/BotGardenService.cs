using BotGarden.Domain.Models;
using BotGarden.Infrastructure.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BotGarden.Application.Services.MainFormAdd
{
    public class BotGardenService
    {
        private readonly IRepository<BotGardenModel> _botGardenRepository;

        public BotGardenService(IRepository<BotGardenModel> botGardenRepository)
        {
            _botGardenRepository = botGardenRepository;
        }

        public async Task<IEnumerable<BotGardenModel>> GetAllBotGardensAsync()
        {
            return await _botGardenRepository.GetAllAsync();
        }
    }
}
