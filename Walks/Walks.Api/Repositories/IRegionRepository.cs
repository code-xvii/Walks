using Microsoft.EntityFrameworkCore;
using Walks.Api.Data;
using Walks.Api.Models.Domains;

namespace Walks.Api.Repositories
{
    public interface IRegionRepository
    {
       Task<IReadOnlyList<Region>> GetAllAsync();
       // Region Get(int id);
    }

    public class RegionRepository : IRegionRepository
    {
        private readonly WalksDbContext db;

        public RegionRepository(WalksDbContext db)
        {
            this.db = db;
        }
        public async Task<IReadOnlyList<Region>> GetAllAsync()
        {
            return await db.Regions.ToListAsync();
        }
    }
}
