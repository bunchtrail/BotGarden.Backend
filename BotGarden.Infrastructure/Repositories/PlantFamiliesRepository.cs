using BotGarden.Infrastructure.Contexts;
using BotGarden.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace BotGarden.Infrastructure.Data.Repositories
{
	public class PlantFamiliesRepository : IRepository<PlantFamilies>
	{
		private readonly BotanicGardenContext _context;

		public PlantFamiliesRepository(BotanicGardenContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<PlantFamilies>> GetAllAsync()
		{
			try
			{
				if (_context.PlantFamilies == null)
					return new List<PlantFamilies>();
					
				return await _context.PlantFamilies.ToListAsync() ?? new List<PlantFamilies>();
			}
			catch (Exception ex)
			{
				// Log the exception or handle it accordingly
				throw new Exception("Failed to retrieve plant families", ex);
			}
		}

		public async Task<PlantFamilies?> GetByIdAsync(int id)
		{
			try
			{
				if (_context.PlantFamilies == null)
					return null;
					
				return await _context.PlantFamilies
									 .FirstOrDefaultAsync(f => f.FamilyId == id);
			}
			catch (Exception ex)
			{
				// Log the exception or handle it accordingly
				throw new Exception($"Failed to retrieve plant family with ID {id}", ex);
			}
		}

		public async Task AddAsync(PlantFamilies family)
		{
			if (family != null && _context.PlantFamilies != null)
			{
				_context.PlantFamilies.Add(family);
				await _context.SaveChangesAsync();
			}
		}

		public async Task UpdateAsync(PlantFamilies family)
		{
			if (family != null && _context.PlantFamilies != null)
			{
				_context.PlantFamilies.Update(family);
				await _context.SaveChangesAsync();
			}
		}

		public async Task DeleteAsync(int id)
		{
			if (_context.PlantFamilies == null)
				return;
				
			var family = await _context.PlantFamilies.FindAsync(id);
			if (family != null)
			{
				_context.PlantFamilies.Remove(family);
				await _context.SaveChangesAsync();
			}
		}
	}

}
