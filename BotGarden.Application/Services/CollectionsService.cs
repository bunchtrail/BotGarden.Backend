using BotGarden.Infrastructure.Data.Repositories;
using BotGarden.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BotGarden.Application.Services
{
    public class ExpositionService
    {
        private readonly IRepository<Exposition> _expositionRepository;

        public ExpositionService(IRepository<Exposition> expositionRepository)
        {
            _expositionRepository = expositionRepository;
        }

        public async Task<IEnumerable<Exposition>> GetAllExpositionsAsync()
        {
            return await _expositionRepository.GetAllAsync();
        }

        public async Task<Exposition?> GetExpositionByIdAsync(int id)
        {
            return await _expositionRepository.GetByIdAsync(id);
        }

        public async Task AddExpositionAsync(Exposition exposition)
        {
            await _expositionRepository.AddAsync(exposition);
        }

        public async Task UpdateExpositionAsync(Exposition exposition)
        {
            await _expositionRepository.UpdateAsync(exposition);
        }

        public async Task DeleteExpositionAsync(int id)
        {
            await _expositionRepository.DeleteAsync(id);
        }
    }
}
