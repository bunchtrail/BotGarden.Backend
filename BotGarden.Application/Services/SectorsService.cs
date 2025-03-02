using BotGarden.Infrastructure.Data.Repositories;
using BotGarden.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace BotGarden.Application.Services { 
public class SectorsService
{
    private readonly IRepository<Sectors> _sectorsRepository;
    private readonly ILogger<SectorsService> _logger;

    public SectorsService(IRepository<Sectors> sectorsRepository, ILogger<SectorsService> logger)
    {
        _sectorsRepository = sectorsRepository ?? throw new ArgumentNullException(nameof(sectorsRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<IEnumerable<Sectors>> GetAllSectorsAsync()
    {
        try
        {
            _logger.LogInformation("Получение списка всех секторов");
            var sectors = await _sectorsRepository.GetAllAsync();
            return sectors ?? Enumerable.Empty<Sectors>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при получении списка секторов");
            throw;
        }
    }

    public async Task<Sectors?> GetSectorByIdAsync(int id)
    {
        if (id <= 0)
            throw new ArgumentException("ID сектора должен быть положительным числом", nameof(id));

        try
        {
            _logger.LogInformation("Получение сектора с ID: {SectorId}", id);
            return await _sectorsRepository.GetByIdAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при получении сектора с ID: {SectorId}", id);
            throw;
        }
    }

    public async Task AddSectorAsync(Sectors sector)
    {
        if (sector == null)
            throw new ArgumentNullException(nameof(sector));

        try
        {
            _logger.LogInformation("Добавление нового сектора");
            await _sectorsRepository.AddAsync(sector);
            _logger.LogInformation("Сектор успешно добавлен с ID: {SectorId}", sector.Id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при добавлении сектора");
            throw;
        }
    }

    public async Task UpdateSectorAsync(Sectors sector)
    {
        if (sector == null)
            throw new ArgumentNullException(nameof(sector));
            
        if (sector.Id <= 0)
            throw new ArgumentException("ID сектора должен быть положительным числом", nameof(sector.Id));

        try
        {
            _logger.LogInformation("Обновление сектора с ID: {SectorId}", sector.Id);
            
            var existingSector = await _sectorsRepository.GetByIdAsync(sector.Id);
            if (existingSector == null)
            {
                _logger.LogWarning("Сектор с ID: {SectorId} не найден", sector.Id);
                throw new KeyNotFoundException($"Сектор с ID {sector.Id} не найден");
            }
            
            await _sectorsRepository.UpdateAsync(sector);
            _logger.LogInformation("Сектор с ID: {SectorId} успешно обновлен", sector.Id);
        }
        catch (KeyNotFoundException)
        {
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при обновлении сектора с ID: {SectorId}", sector.Id);
            throw;
        }
    }

    public async Task DeleteSectorAsync(int id)
    {
        if (id <= 0)
            throw new ArgumentException("ID сектора должен быть положительным числом", nameof(id));

        try
        {
            _logger.LogInformation("Удаление сектора с ID: {SectorId}", id);
            
            var sector = await _sectorsRepository.GetByIdAsync(id);
            if (sector == null)
            {
                _logger.LogWarning("Сектор с ID: {SectorId} не найден", id);
                throw new KeyNotFoundException($"Сектор с ID {id} не найден");
            }
            
            await _sectorsRepository.DeleteAsync(id);
            _logger.LogInformation("Сектор с ID: {SectorId} успешно удален", id);
        }
        catch (KeyNotFoundException)
        {
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при удалении сектора с ID: {SectorId}", id);
            throw;
        }
    }
}
}
