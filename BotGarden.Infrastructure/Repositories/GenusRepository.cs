using BotGarden.Infrastructure.Contexts;
using BotGarden.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace BotGarden.Infrastructure.Data.Repositories
{
public class GenusRepository : IRepository<Genus>
{
	private readonly BotanicGardenContext _context;

	public GenusRepository(BotanicGardenContext context)
	{
		_context = context;
	}

	public async Task<IEnumerable<Genus>> GetAllAsync()
	{
		if (_context.Genus == null)
			return new List<Genus>();
			
		return await _context.Genus.ToListAsync() ?? new List<Genus>();
	}

	public async Task<Genus?> GetByIdAsync(int id)
	{
		if (_context.Genus == null)
			return null;
			
		return await _context.Genus.FirstOrDefaultAsync(g => g.GenusId == id);
	}

	public async Task AddAsync(Genus genus)
	{
		if (genus != null && _context.Genus != null)
		{
			_context.Genus.Add(genus);
			await _context.SaveChangesAsync();
		}
	}

	public async Task UpdateAsync(Genus genus)
	{
		if (genus != null && _context.Genus != null)
		{
			_context.Genus.Update(genus);
			await _context.SaveChangesAsync();
		}
	}

	public async Task DeleteAsync(int id)
	{
		if (_context.Genus == null)
			return;
			
		var genus = await _context.Genus.FindAsync(id);
		if (genus != null)
		{
			_context.Genus.Remove(genus);
			await _context.SaveChangesAsync();
		}
	}
}
}
    
