using BotGarden.Core.Data.Repositories;
using BotGarden.Core.Models;

public class SectorsService
{
    private readonly IRepository<Sectors> _sectorsRepository;

    public SectorsService(IRepository<Sectors> sectorsRepository)
    {
        _sectorsRepository = sectorsRepository;
    }

    public async Task<IEnumerable<Sectors>> GetAllSectorsAsync()
    {
        return await _sectorsRepository.GetAllAsync();
    }

    public async Task<Sectors> GetSectorByIdAsync(int id)
    {
        return await _sectorsRepository.GetByIdAsync(id);
    }

    public async Task AddSectorAsync(Sectors sector)
    {
        await _sectorsRepository.AddAsync(sector);
    }

    public async Task UpdateSectorAsync(Sectors sector)
    {
        await _sectorsRepository.UpdateAsync(sector);
    }

    public async Task DeleteSectorAsync(int id)
    {
        await _sectorsRepository.DeleteAsync(id);
    }
}
