using Walks.Api.Models.Domains;

namespace Walks.Api.Repositories
{
    public interface IRegionRepository
    {
        Task<IReadOnlyList<Region>> GetAllAsync();
        Task<Region?> GetAsync(Guid id);
        Task<Region> AddAsync(Region region);
        Task<Region?> UpdateAsync(Guid id, Region region);

        Task<Region?> DeleteAsync(Guid id);

    }
}
