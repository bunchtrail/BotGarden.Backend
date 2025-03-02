using BotGarden.Infrastructure.Data.Repositories;
using BotGarden.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;
using BotGarden.Application.DTOs;
using System.Linq;

namespace BotGarden.Application.Services.MainFormAdd
{
    public class GenusService
    {
        private readonly IRepository<Genus> _genusRepository;
        private readonly ILogger<GenusService> _logger;

        public GenusService(IRepository<Genus> genusRepository, ILogger<GenusService> logger)
        {
            _genusRepository = genusRepository ?? throw new ArgumentNullException(nameof(genusRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<Genus>> GetAllGenusAsync()
        {
            try
            {
                _logger.LogInformation("Получение списка всех родов");
                var genuses = await _genusRepository.GetAllAsync();
                return genuses ?? Enumerable.Empty<Genus>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении списка родов");
                throw;
            }
        }

        public async Task<Genus?> GetGenusByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID рода должен быть положительным числом", nameof(id));

            try
            {
                _logger.LogInformation("Получение рода с ID: {GenusId}", id);
                return await _genusRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении рода с ID: {GenusId}", id);
                throw;
            }
        }

        public async Task<Genus> CreateGenusAsync(string genusName)
        {
            if (string.IsNullOrWhiteSpace(genusName))
                throw new ArgumentException("Название рода не может быть пустым", nameof(genusName));

            try
            {
                _logger.LogInformation("Создание нового рода с названием: {GenusName}", genusName);
                
                var newGenus = new Genus
                {
                    GenusName = genusName,
                    Plants = new List<Plant>()
                };

                await _genusRepository.AddAsync(newGenus);
                _logger.LogInformation("Род успешно создан с ID: {GenusId}", newGenus.Id);
                return newGenus;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при создании рода с названием: {GenusName}", genusName);
                throw;
            }
        }
        
        public async Task<Genus> CreateGenusAsync(CreateGenusDto genusDto)
        {
            if (genusDto == null)
                throw new ArgumentNullException(nameof(genusDto));
                
            if (string.IsNullOrWhiteSpace(genusDto.GenusName))
                throw new ArgumentException("Название рода не может быть пустым", nameof(genusDto.GenusName));

            try
            {
                _logger.LogInformation("Создание нового рода с названием: {GenusName}", genusDto.GenusName);
                
                var newGenus = new Genus
                {
                    GenusName = genusDto.GenusName,
                    Plants = new List<Plant>()
                };

                await _genusRepository.AddAsync(newGenus);
                _logger.LogInformation("Род успешно создан с ID: {GenusId}", newGenus.Id);
                return newGenus;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при создании рода с названием: {GenusName}", genusDto.GenusName);
                throw;
            }
        }
        
        public async Task DeleteGenusAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID рода должен быть положительным числом", nameof(id));

            try
            {
                _logger.LogInformation("Удаление рода с ID: {GenusId}", id);
                
                var genus = await _genusRepository.GetByIdAsync(id);
                if (genus == null)
                {
                    _logger.LogWarning("Род с ID: {GenusId} не найден", id);
                    throw new KeyNotFoundException($"Род с ID {id} не найден");
                }
                
                if (genus.Plants != null && genus.Plants.Any())
                {
                    _logger.LogWarning("Удаление рода с ID: {GenusId} невозможно, так как он содержит растения", id);
                    throw new InvalidOperationException($"Удаление рода с ID {id} невозможно, так как он содержит растения");
                }
                
                await _genusRepository.DeleteAsync(id);
                _logger.LogInformation("Род с ID: {GenusId} успешно удален", id);
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при удалении рода с ID: {GenusId}", id);
                throw;
            }
        }
    }
}
