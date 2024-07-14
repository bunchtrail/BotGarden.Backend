using BotGarden.Infrastructure.Contexts;
using BotGarden.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BotGarden.Infrastructure.Data.Repositories
{
    public class BotGardenRepository : IRepository<BotGardenMode>
    {
        private readonly BotanicGardenContext _context;

        public BotGardenRepository(BotanicGardenContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BotGardenMode>> GetAllAsync()
        {
            return await _context.BotGarden
                                 .Include(bg => bg.Plants)
                                 .ToListAsync();
        }

        public async Task<BotGardenMode> GetByIdAsync(int id)
        {
            return await _context.BotGarden
                                 .FirstOrDefaultAsync(bg => bg.LocationId == id);
        }

        public async Task AddAsync(BotGardenMode botGarden)
        {
            _context.BotGarden.Add(botGarden);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BotGardenMode botGarden)
        {
            _context.BotGarden.Update(botGarden);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var botGarden = await _context.BotGarden.FindAsync(id);
            if (botGarden != null)
            {
                _context.BotGarden.Remove(botGarden);
                await _context.SaveChangesAsync();
            }
        }
    }
}

