using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BotGarden.Domain.Models;
using BotGarden.Infrastructure.Contexts;

namespace BotGarden.Application.Services
{
    public class GenusService
    {
        private readonly BotanicGardenContext _context;

        public GenusService(BotanicGardenContext context)
        {
            _context = context;
        }

        public async Task<List<Genus>> GetAllAsync()
        {
            return await _context.Genus.ToListAsync();
        }

        public async Task AddAsync(Genus genus)
        {
            _context.Genus.Add(genus);
            await _context.SaveChangesAsync();
        }
    }
} 