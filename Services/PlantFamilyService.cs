using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BotGarden.Domain.Models;
using BotGarden.Infrastructure.Contexts;

namespace BotGarden.Application.Services
{
    public class FamilyService
    {
        private readonly BotanicGardenContext _context;

        public FamilyService(BotanicGardenContext context)
        {
            _context = context;
        }

        public async Task<List<Family>> GetAllAsync()
        {
            return await _context.Families.ToListAsync();
        }

        public async Task AddAsync(Family family)
        {
            _context.Families.Add(family);
            await _context.SaveChangesAsync();
        }
    }
} 