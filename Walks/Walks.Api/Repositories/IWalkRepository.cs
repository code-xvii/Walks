using Walks.Api.Models.Domains;

namespace Walks.Api.Repositories
{
    public interface IWalkRepository
    {
        Task<IReadOnlyList<Walk>> GetAllAsync();
        Task<Walk?> GetAsync(Guid id);

        Task<Walk?> AddAsync(Walk walk);
        Task<Walk?> UpdateAsync(Guid id, Walk walk);
        Task<Walk?> DeleteAsync(Guid id);
    }
}
