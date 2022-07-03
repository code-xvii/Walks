using Microsoft.EntityFrameworkCore;
using Walks.Api.Data;
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

    public class RegionRepository : IRegionRepository
    {
        private readonly WalksDbContext db;

        public RegionRepository(WalksDbContext db)
        {
            this.db = db;
        }

        public async Task<Region> AddAsync(Region region)
        {
            await db.Regions.AddAsync(region);
            await db.SaveChangesAsync();

            return region;

        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var region = await db.Regions.FindAsync(id);
            if (region == null)
            {
                return null;
            }

            db.Regions.Remove(region);
            await db.SaveChangesAsync();
            return region;
        }

        public async Task<IReadOnlyList<Region>> GetAllAsync()
        {
            return await db.Regions.ToListAsync();
        }

        public async Task<Region?> GetAsync(Guid id)
        {
            var region = await db.Regions.FindAsync(id);
            return region;
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await db.Regions.FindAsync(id);
            if (existingRegion == null)
            {
                return null;
            }

            db.Regions.Update(region);
            await db.SaveChangesAsync();

            return region;

        }
    }
}
