using BotGarden.Core.Data.Contexts;
using BotGarden.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace BotGarden.Core.Data.Repositories
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
		return await _context.Genus.ToListAsync();
	}

	public async Task<Genus> GetByIdAsync(int id)
	{
		return await _context.Genus.FirstOrDefaultAsync(g => g.GenusId == id);
	}

	public async Task AddAsync(Genus genus)
	{
		_context.Genus.Add(genus);
		await _context.SaveChangesAsync();
	}

	public async Task UpdateAsync(Genus genus)
	{
		_context.Genus.Update(genus);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(int id)
	{
		var genus = await _context.Genus.FindAsync(id);
		if (genus != null)
		{
			_context.Genus.Remove(genus);
			await _context.SaveChangesAsync();
		}
	}
}
}
    
