using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BotGarden.Domain.Models;
using BotGarden.Infrastructure.Contexts;

namespace BotGarden.Application.Services
{
    public class PlantFamilyService
    {
        private readonly BotanicGardenContext _context;

        public PlantFamilyService(BotanicGardenContext context)
        {
            _context = context;
        }

        public async Task<List<PlantFamilies>> GetAllAsync()
        {
            return await _context.PlantFamilies.ToListAsync();
        }

        public async Task AddAsync(PlantFamilies plantFamily)
        {
            _context.PlantFamilies.Add(plantFamily);
            await _context.SaveChangesAsync();
        }
    }
} 