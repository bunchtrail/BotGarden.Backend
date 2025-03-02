using BotGarden.Domain.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using BotGarden.Infrastructure.Data.Repositories;

namespace BotGarden.Applications.Services
{
    public class PlantService
    {
        private readonly IRepository<Plant> _plantRepository;

        public PlantService(IRepository<Plant> plantRepository)
        {
            _plantRepository = plantRepository;
        }





        public async Task<Plant?> GetPlantByIdAsync(int id)
        {
            return await _plantRepository.GetByIdAsync(id);
        }

	




		public async Task DeletePlantAsync(int id)
        {
            await _plantRepository.DeleteAsync(id);
        }
    }
}
