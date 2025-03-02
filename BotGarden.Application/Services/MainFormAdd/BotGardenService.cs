using BotGarden.Domain.Models;
using BotGarden.Infrastructure.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;
using BotGarden.Application.DTOs;
using System.Linq;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;

namespace BotGarden.Application.Services.MainFormAdd
{
    public class BotGardenService
    {
        private readonly IRepository<BotGardenModel> _botGardenRepository;
        private readonly ILogger<BotGardenService> _logger;

        public BotGardenService(IRepository<BotGardenModel> botGardenRepository, ILogger<BotGardenService> logger)
        {
            _botGardenRepository = botGardenRepository ?? throw new ArgumentNullException(nameof(botGardenRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<BotGardenModel>> GetAllBotGardensAsync()
        {
            try
            {
                _logger.LogInformation("Получение списка всех моделей ботанического сада");
                var botGardenModels = await _botGardenRepository.GetAllAsync();
                return botGardenModels ?? Enumerable.Empty<BotGardenModel>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении списка моделей ботанического сада");
                throw;
            }
        }
        
        public async Task<BotGardenModel?> GetBotGardenByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID модели ботанического сада должен быть положительным числом", nameof(id));

            try
            {
                _logger.LogInformation("Получение модели ботанического сада с ID: {BotGardenId}", id);
                return await _botGardenRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении модели ботанического сада с ID: {BotGardenId}", id);
                throw;
            }
        }
        
        public async Task<BotGardenModel> CreateBotGardenModelAsync(CreateBotGardenModelDto modelDto)
        {
            if (modelDto == null)
                throw new ArgumentNullException(nameof(modelDto));

            try
            {
                _logger.LogInformation("Создание новой модели ботанического сада");
                
                // Преобразование WKT-строки в объект Polygon
                Polygon? geometry = null;
                if (!string.IsNullOrEmpty(modelDto.Geometry))
                {
                    var reader = new WKTReader();
                    geometry = reader.Read(modelDto.Geometry) as Polygon;
                }
                
                var exposition = new Exposition
                {
                    ExpositionName = modelDto.Name ?? "Новая экспозиция",
                    Description = modelDto.Description,
                    ImageUrl = modelDto.ImageUrl,
                    Plants = new List<Plant>()
                };
                
                var botGardenModel = new BotGardenModel
                {
                    LocationPath = modelDto.LocationPath,
                    Geometry = geometry,
                    Exposition = exposition
                };

                await _botGardenRepository.AddAsync(botGardenModel);
                _logger.LogInformation("Модель ботанического сада успешно создана с ID: {BotGardenId}", botGardenModel.LocationId);
                return botGardenModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при создании модели ботанического сада");
                throw;
            }
        }
        
        public async Task UpdateBotGardenModelAsync(BotGardenModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
                
            if (model.LocationId <= 0)
                throw new ArgumentException("ID модели ботанического сада должен быть положительным числом", nameof(model.LocationId));

            try
            {
                _logger.LogInformation("Обновление модели ботанического сада с ID: {BotGardenId}", model.LocationId);
                
                var existingModel = await _botGardenRepository.GetByIdAsync(model.LocationId);
                if (existingModel == null)
                {
                    _logger.LogWarning("Модель ботанического сада с ID: {BotGardenId} не найдена", model.LocationId);
                    throw new KeyNotFoundException($"Модель ботанического сада с ID {model.LocationId} не найдена");
                }
                
                await _botGardenRepository.UpdateAsync(model);
                _logger.LogInformation("Модель ботанического сада с ID: {BotGardenId} успешно обновлена", model.LocationId);
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при обновлении модели ботанического сада с ID: {BotGardenId}", model.LocationId);
                throw;
            }
        }
        
        public async Task DeleteBotGardenModelAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID модели ботанического сада должен быть положительным числом", nameof(id));

            try
            {
                _logger.LogInformation("Удаление модели ботанического сада с ID: {BotGardenId}", id);
                
                var model = await _botGardenRepository.GetByIdAsync(id);
                if (model == null)
                {
                    _logger.LogWarning("Модель ботанического сада с ID: {BotGardenId} не найдена", id);
                    throw new KeyNotFoundException($"Модель ботанического сада с ID {id} не найдена");
                }
                
                await _botGardenRepository.DeleteAsync(id);
                _logger.LogInformation("Модель ботанического сада с ID: {BotGardenId} успешно удалена", id);
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при удалении модели ботанического сада с ID: {BotGardenId}", id);
                throw;
            }
        }
    }
}
