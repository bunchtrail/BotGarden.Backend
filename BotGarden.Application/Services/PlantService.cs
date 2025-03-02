using BotGarden.Domain.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using BotGarden.Infrastructure.Data.Repositories;
using Microsoft.Extensions.Logging;
using System;
using BotGarden.Application.DTOs;
using System.Linq;

namespace BotGarden.Application.Services
{
    public class PlantService
    {
        private readonly IRepository<Plant> _plantRepository;
        private readonly ILogger<PlantService> _logger;

        public PlantService(IRepository<Plant> plantRepository, ILogger<PlantService> logger)
        {
            _plantRepository = plantRepository ?? throw new ArgumentNullException(nameof(plantRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<Plant>> GetAllPlantsAsync()
        {
            try
            {
                _logger.LogInformation("Получение списка всех растений");
                return await _plantRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении списка растений");
                throw;
            }
        }

        public async Task<Plant?> GetPlantByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID растения должен быть положительным числом", nameof(id));

            try
            {
                _logger.LogInformation("Получение растения с ID: {PlantId}", id);
                return await _plantRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении растения с ID: {PlantId}", id);
                throw;
            }
        }

        public async Task<Plant> CreatePlantAsync(PlantCreateDto plantDto)
        {
            if (plantDto == null)
                throw new ArgumentNullException(nameof(plantDto));

            try
            {
                _logger.LogInformation("Создание нового растения с инвентарным номером: {InventoryNumber}", plantDto.InventoryNumber);
                
                var plant = new Plant
                {
                    FamilyId = plantDto.FamilyId,
                    ExpositionId = plantDto.ExpositionId,
                    GenusId = plantDto.GenusId,
                    InventoryNumber = plantDto.InventoryNumber,
                    Rod = plantDto.Rod,
                    Vid = plantDto.Vid,
                    Sort = plantDto.Sort,
                    Forma = plantDto.Forma,
                    DeterminedBy = plantDto.DeterminedBy,
                    YearOfPlanting = plantDto.YearOfPlanting,
                    SecurityStatus = plantDto.SecurityStatus,
                    FilledBy = plantDto.FilledBy,
                    HasHerbarium = plantDto.HasHerbarium,
                    HasDuplicates = plantDto.HasDuplicates,
                    Synonyms = plantDto.Synonyms,
                    Origin = plantDto.Origin,
                    Areal = plantDto.Areal,
                    EcologyBiology = plantDto.EcologyBiology,
                    EconomicUse = plantDto.EconomicUse,
                    Latitude = plantDto.Latitude,
                    Longitude = plantDto.Longitude,
                    Originator = plantDto.Originator,
                    YearCountry = plantDto.YearCountry,
                    Illustration = plantDto.Illustration,
                    Notes = plantDto.Notes
                };

                await _plantRepository.AddAsync(plant);
                _logger.LogInformation("Растение успешно создано с ID: {PlantId}", plant.Id);
                return plant;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при создании растения");
                throw;
            }
        }

        public async Task UpdatePlantAsync(PlantUpdateDto plantDto)
        {
            if (plantDto == null)
                throw new ArgumentNullException(nameof(plantDto));
            
            if (plantDto.Id <= 0)
                throw new ArgumentException("ID растения должен быть положительным числом", nameof(plantDto.Id));

            try
            {
                _logger.LogInformation("Обновление растения с ID: {PlantId}", plantDto.Id);
                
                var plant = await _plantRepository.GetByIdAsync(plantDto.Id);
                if (plant == null)
                {
                    _logger.LogWarning("Растение с ID: {PlantId} не найдено", plantDto.Id);
                    throw new KeyNotFoundException($"Растение с ID {plantDto.Id} не найдено");
                }

                // Обновляем свойства
                plant.FamilyId = plantDto.FamilyId;
                plant.ExpositionId = plantDto.ExpositionId;
                plant.GenusId = plantDto.GenusId;
                plant.InventoryNumber = plantDto.InventoryNumber;
                plant.Rod = plantDto.Rod;
                plant.Vid = plantDto.Vid;
                plant.Sort = plantDto.Sort;
                plant.Forma = plantDto.Forma;
                plant.DeterminedBy = plantDto.DeterminedBy;
                plant.YearOfPlanting = plantDto.YearOfPlanting;
                plant.SecurityStatus = plantDto.SecurityStatus;
                plant.FilledBy = plantDto.FilledBy;
                plant.HasHerbarium = plantDto.HasHerbarium;
                plant.HasDuplicates = plantDto.HasDuplicates;
                plant.Synonyms = plantDto.Synonyms;
                plant.Origin = plantDto.Origin;
                plant.Areal = plantDto.Areal;
                plant.EcologyBiology = plantDto.EcologyBiology;
                plant.EconomicUse = plantDto.EconomicUse;
                plant.Latitude = plantDto.Latitude;
                plant.Longitude = plantDto.Longitude;
                plant.Originator = plantDto.Originator;
                plant.YearCountry = plantDto.YearCountry;
                plant.Illustration = plantDto.Illustration;
                plant.Notes = plantDto.Notes;

                await _plantRepository.UpdateAsync(plant);
                _logger.LogInformation("Растение с ID: {PlantId} успешно обновлено", plantDto.Id);
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при обновлении растения с ID: {PlantId}", plantDto.Id);
                throw;
            }
        }

        public async Task DeletePlantAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID растения должен быть положительным числом", nameof(id));

            try
            {
                _logger.LogInformation("Удаление растения с ID: {PlantId}", id);
                
                var plant = await _plantRepository.GetByIdAsync(id);
                if (plant == null)
                {
                    _logger.LogWarning("Растение с ID: {PlantId} не найдено", id);
                    throw new KeyNotFoundException($"Растение с ID {id} не найдено");
                }
                
                await _plantRepository.DeleteAsync(id);
                _logger.LogInformation("Растение с ID: {PlantId} успешно удалено", id);
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при удалении растения с ID: {PlantId}", id);
                throw;
            }
        }
    }
}
