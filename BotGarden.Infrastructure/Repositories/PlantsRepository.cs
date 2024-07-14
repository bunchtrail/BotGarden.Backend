using BotGarden.Infrastructure.Contexts;
using BotGarden.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace BotGarden.Infrastructure.Data.Repositories
{
    public class PlantsRepository : IRepository<Plants>
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

        public async Task<IEnumerable<Plants>> GetAllAsync()
        {
            try
            {
                return await _context.Plants
                                     .Include(p => p.Family)
                                     .Include(p => p.Sector)
                                     .ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally handle it if specific action is needed
                throw; // re-throwing the exception to let the calling code handle it
            }
        }


        public IQueryable<Plants> GetAll()
        {
            return _context.Plants;
        }


        public async Task<Plants> GetByIdAsync(int id)
        {
            return await _context.Plants
                .Include(p => p.Family)
                .Include(p => p.Sector)
                .FirstOrDefaultAsync(p => p.PlantId == id);
        }

        public async Task AddAsync(Plants plant)
        {
            _context.Plants.Add(plant);
            await _context.SaveChangesAsync();
        }

	    public async Task UpdateAsync(Plants plant)
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


	    public async Task DeleteAsync(int id)
        {
            var plant = await _context.Plants.FindAsync(id);
            if (plant != null)
            {
                _context.Plants.Remove(plant);
                await _context.SaveChangesAsync();
            }
        }
    }

}
