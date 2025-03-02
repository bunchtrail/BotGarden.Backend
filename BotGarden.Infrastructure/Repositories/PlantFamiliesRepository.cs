using BotGarden.Infrastructure.Contexts;
using BotGarden.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace BotGarden.Infrastructure.Data.Repositories
{
	public class FamilyRepository : IRepository<Family>
	{
		private readonly BotanicGardenContext _context;

		public FamilyRepository(BotanicGardenContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Family>> GetAllAsync()
		{
			try
			{
				if (_context.Families == null)
					return new List<Family>();
					
				return await _context.Families.ToListAsync() ?? new List<Family>();
			}
			catch (Exception ex)
			{
				// Логирование ошибки
				Console.WriteLine($"Ошибка при получении списка семейств: {ex.Message}");
				return new List<Family>();
			}
		}

		public async Task<Family?> GetByIdAsync(int id)
		{
			try
			{
				if (_context.Families == null)
					return null;
					
				return await _context.Families
					.FirstOrDefaultAsync(f => f.Id == id);
			}
			catch (Exception ex)
			{
				// Логирование ошибки
				Console.WriteLine($"Ошибка при получении семейства по ID: {ex.Message}");
				return null;
			}
		}

		public async Task AddAsync(Family family)
		{
			if (family != null && _context.Families != null)
			{
				_context.Families.Add(family);
				await _context.SaveChangesAsync();
			}
		}

		public async Task UpdateAsync(Family family)
		{
			if (family != null && _context.Families != null)
			{
				_context.Families.Update(family);
				await _context.SaveChangesAsync();
			}
		}

		public async Task DeleteAsync(int id)
		{
			try
			{
				if (_context.Families == null)
					return;
					
				var family = await _context.Families.FindAsync(id);
				if (family != null)
				{
					_context.Families.Remove(family);
					await _context.SaveChangesAsync();
				}
			}
			catch (Exception ex)
			{
				// Логирование ошибки
				Console.WriteLine($"Ошибка при удалении семейства: {ex.Message}");
			}
		}
	}
}
