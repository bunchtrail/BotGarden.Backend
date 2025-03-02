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
    public class FamilyService
    {
        private readonly IRepository<Family> _familyRepository;
        private readonly ILogger<FamilyService> _logger;

        public FamilyService(IRepository<Family> familyRepository, ILogger<FamilyService> logger)
        {
            _familyRepository = familyRepository ?? throw new ArgumentNullException(nameof(familyRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<Family>> GetAllFamiliesAsync()
        {
            try
            {
                _logger.LogInformation("Получение списка всех семейств");
                var families = await _familyRepository.GetAllAsync();
                return families ?? Enumerable.Empty<Family>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении списка семейств");
                throw;
            }
        }

        public async Task<Family> CreateFamilyAsync(string familyName)
        {
            if (string.IsNullOrWhiteSpace(familyName))
                throw new ArgumentException("Название семейства не может быть пустым", nameof(familyName));

            try
            {
                _logger.LogInformation("Создание нового семейства с названием: {FamilyName}", familyName);
                
                var newFamily = new Family
                {
                    FamilyName = familyName,
                    Plants = new List<Plant>()
                };

                await _familyRepository.AddAsync(newFamily);
                _logger.LogInformation("Семейство успешно создано с ID: {FamilyId}", newFamily.Id);
                return newFamily;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при создании семейства с названием: {FamilyName}", familyName);
                throw;
            }
        }
        
        public async Task<Family> CreateFamilyAsync(CreateFamilyDto familyDto)
        {
            if (familyDto == null)
                throw new ArgumentNullException(nameof(familyDto));
                
            if (string.IsNullOrWhiteSpace(familyDto.FamilyName))
                throw new ArgumentException("Название семейства не может быть пустым", nameof(familyDto.FamilyName));

            try
            {
                _logger.LogInformation("Создание нового семейства с названием: {FamilyName}", familyDto.FamilyName);
                
                var newFamily = new Family
                {
                    FamilyName = familyDto.FamilyName,
                    Plants = new List<Plant>()
                };

                await _familyRepository.AddAsync(newFamily);
                _logger.LogInformation("Семейство успешно создано с ID: {FamilyId}", newFamily.Id);
                return newFamily;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при создании семейства с названием: {FamilyName}", familyDto.FamilyName);
                throw;
            }
        }
    }
}


