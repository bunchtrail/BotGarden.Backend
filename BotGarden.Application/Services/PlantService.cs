using BotGarden.Core.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using BotGarden.Core.Data.Repositories;

namespace NewBotanicG.Services
{
    public class PlantService
    {
        private readonly IRepository<Plants> _plantRepository;

        public PlantService(IRepository<Plants> plantRepository)
        {
            _plantRepository = plantRepository;
        }





        public async Task<Plants> GetPlantByIdAsync(int id)
        {
            return await _plantRepository.GetByIdAsync(id);
        }

	




		public async Task DeletePlantAsync(int id)
        {
            await _plantRepository.DeleteAsync(id);
        }
    }
}
