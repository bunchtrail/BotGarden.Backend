using BotGarden.Infrastructure.Contexts;
using BotGarden.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace BotGarden.Infrastructure.Data.Repositories
{
    public class PlantsRepository : IRepository<Plant>
    {
        private readonly BotanicGardenContext _context;

        public PlantsRepository(BotanicGardenContext context)
        {
            _context = context;
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Plant>> GetAllAsync()
        {
            try
            {
                if (_context.Plants == null)
                    return new List<Plant>();
                    
                return await _context.Plants
                                     .Include(p => p.Family)
                                     .Include(p => p.Exposition)
                                     .ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error in GetAllAsync: {ex.Message}");
                // Optionally handle it if specific action is needed
                throw; // re-throwing the exception to let the calling code handle it
            }
        }


        public IQueryable<Plant>? GetAll()
        {
            return _context.Plants;
        }


        public async Task<Plant?> GetByIdAsync(int id)
        {
            if (_context.Plants == null)
                return null;
                
            return await _context.Plants
                .Include(p => p.Family)
                .Include(p => p.Exposition)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Plant plant)
        {
            if (plant != null && _context.Plants != null)
            {
                _context.Plants.Add(plant);
                await _context.SaveChangesAsync();
            }
        }

	    public async Task UpdateAsync(Plant plant)
	    {
	        if (plant != null && _context.Plants != null)
	        {
		        // Проверяем, отслеживается ли уже сущность контекстом
		        if (_context.Entry(plant).State == EntityState.Detached)
		        {
			        // Если сущность не отслеживается, прикрепляем её к контексту
			        _context.Plants.Attach(plant);
		        }
		        // Устанавливаем состояние сущности как Modified, указывая, что она была изменена
		        _context.Entry(plant).State = EntityState.Modified;
		        // Сохраняем изменения в базу данных
		        await _context.SaveChangesAsync();
	        }
	    }


	    public async Task DeleteAsync(int id)
        {
            if (_context.Plants == null)
                return;
                
            var plant = await _context.Plants.FindAsync(id);
            if (plant != null)
            {
                _context.Plants.Remove(plant);
                await _context.SaveChangesAsync();
            }
        }
    }
}
