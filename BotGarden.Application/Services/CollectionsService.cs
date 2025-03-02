using BotGarden.Infrastructure.Data.Repositories;
using BotGarden.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace BotGarden.Application.Services
{
    public class ExpositionService
    {
        private readonly IRepository<Exposition> _expositionRepository;
        private readonly ILogger<ExpositionService> _logger;

        public ExpositionService(IRepository<Exposition> expositionRepository, ILogger<ExpositionService> logger)
        {
            _expositionRepository = expositionRepository ?? throw new ArgumentNullException(nameof(expositionRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<Exposition>> GetAllExpositionsAsync()
        {
            try
            {
                _logger.LogInformation("Получение списка всех экспозиций");
                var expositions = await _expositionRepository.GetAllAsync();
                return expositions ?? Enumerable.Empty<Exposition>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении списка экспозиций");
                throw;
            }
        }

        public async Task<Exposition?> GetExpositionByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID экспозиции должен быть положительным числом", nameof(id));

            try
            {
                _logger.LogInformation("Получение экспозиции с ID: {ExpositionId}", id);
                return await _expositionRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении экспозиции с ID: {ExpositionId}", id);
                throw;
            }
        }

        public async Task AddExpositionAsync(Exposition exposition)
        {
            if (exposition == null)
                throw new ArgumentNullException(nameof(exposition));

            try
            {
                _logger.LogInformation("Добавление новой экспозиции");
                await _expositionRepository.AddAsync(exposition);
                _logger.LogInformation("Экспозиция успешно добавлена с ID: {ExpositionId}", exposition.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при добавлении экспозиции");
                throw;
            }
        }

        public async Task UpdateExpositionAsync(Exposition exposition)
        {
            if (exposition == null)
                throw new ArgumentNullException(nameof(exposition));
                
            if (exposition.Id <= 0)
                throw new ArgumentException("ID экспозиции должен быть положительным числом", nameof(exposition.Id));

            try
            {
                _logger.LogInformation("Обновление экспозиции с ID: {ExpositionId}", exposition.Id);
                
                var existingExposition = await _expositionRepository.GetByIdAsync(exposition.Id);
                if (existingExposition == null)
                {
                    _logger.LogWarning("Экспозиция с ID: {ExpositionId} не найдена", exposition.Id);
                    throw new KeyNotFoundException($"Экспозиция с ID {exposition.Id} не найдена");
                }
                
                await _expositionRepository.UpdateAsync(exposition);
                _logger.LogInformation("Экспозиция с ID: {ExpositionId} успешно обновлена", exposition.Id);
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при обновлении экспозиции с ID: {ExpositionId}", exposition.Id);
                throw;
            }
        }

        public async Task DeleteExpositionAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID экспозиции должен быть положительным числом", nameof(id));

            try
            {
                _logger.LogInformation("Удаление экспозиции с ID: {ExpositionId}", id);
                
                var exposition = await _expositionRepository.GetByIdAsync(id);
                if (exposition == null)
                {
                    _logger.LogWarning("Экспозиция с ID: {ExpositionId} не найдена", id);
                    throw new KeyNotFoundException($"Экспозиция с ID {id} не найдена");
                }
                
                await _expositionRepository.DeleteAsync(id);
                _logger.LogInformation("Экспозиция с ID: {ExpositionId} успешно удалена", id);
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при удалении экспозиции с ID: {ExpositionId}", id);
                throw;
            }
        }
    }
}
