using BotGarden.Infrastructure.Data.Repositories;
using BotGarden.Domain.Models;

public class CollectionsService
{
    private readonly IRepository<Collections> _collectionsRepository;

    public CollectionsService(IRepository<Collections> collectionsRepository)
    {
        _collectionsRepository = collectionsRepository;
    }

    public async Task<IEnumerable<Collections>> GetAllCollectionsAsync()
    {
        return await _collectionsRepository.GetAllAsync();
    }

    public async Task<Collections> GetCollectionByIdAsync(int id)
    {
        return await _collectionsRepository.GetByIdAsync(id);
    }

    public async Task AddCollectionAsync(Collections collection)
    {
        await _collectionsRepository.AddAsync(collection);
    }

    public async Task UpdateCollectionAsync(Collections collection)
    {
        await _collectionsRepository.UpdateAsync(collection);
    }

    public async Task DeleteCollectionAsync(int id)
    {
        await _collectionsRepository.DeleteAsync(id);
    }
}
