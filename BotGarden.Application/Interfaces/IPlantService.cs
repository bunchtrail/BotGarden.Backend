using BotGardens.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BotGardens.Application.Interfaces
{
    public interface IPlantService
    {
        Task<Plant> GetPlantByIdAsync(int id);
        Task<IEnumerable<Plant>> GetAllPlantsAsync();
        Task AddPlantAsync(Plant plant);
        Task UpdatePlantAsync(Plant plant);
        Task DeletePlantAsync(int id);
    }
}
