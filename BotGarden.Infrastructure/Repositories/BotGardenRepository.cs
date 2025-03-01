using BotGarden.Infrastructure.Contexts;
using BotGarden.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BotGarden.Infrastructure.Data.Repositories
{
    public class BotGardenRepository : IRepository<BotGardenModel>
    {
        private readonly BotanicGardenContext _context;

        public BotGardenRepository(BotanicGardenContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BotGardenModel>> GetAllAsync()
        {
            if (_context.BotGarden == null)
                return new List<BotGardenModel>();
                
            return await _context.BotGarden
                                 .Include(bg => bg.Plants)
                                 .ToListAsync();
        }

        public async Task<BotGardenModel?> GetByIdAsync(int id)
        {
            if (_context.BotGarden == null)
                return null;
                
            return await _context.BotGarden
                                 .FirstOrDefaultAsync(bg => bg.LocationId == id);
        }

        public async Task AddAsync(BotGardenModel botGarden)
        {
            if (botGarden != null && _context.BotGarden != null)
            {
                _context.BotGarden.Add(botGarden);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(BotGardenModel botGarden)
        {
            if (botGarden != null && _context.BotGarden != null)
            {
                _context.BotGarden.Update(botGarden);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            if (_context.BotGarden == null)
                return;
                
            var botGarden = await _context.BotGarden.FindAsync(id);
            if (botGarden != null)
            {
                _context.BotGarden.Remove(botGarden);
                await _context.SaveChangesAsync();
            }
        }
    }
}

