using Microsoft.EntityFrameworkCore;
using Walks.Api.Data;
using Walks.Api.Models.Domains;

namespace Walks.Api.Repositories
{
    public interface IWalkDifficultyRepository
    {
        Task<IReadOnlyList<WalkDifficulty>> GetAllAsync();
        Task<WalkDifficulty?> GetAsync(Guid id);

        Task<WalkDifficulty?> AddAsync(WalkDifficulty walkDifficulty);
        Task<WalkDifficulty?> UpdateAsync(Guid id, WalkDifficulty walkDifficulty);
        Task<WalkDifficulty?> DeleteAsync(Guid id);
    }

    public class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        private readonly WalksDbContext db;

        public WalkDifficultyRepository(WalksDbContext db)
        {
            this.db = db;
        }
        public async Task<WalkDifficulty?> AddAsync(WalkDifficulty walkDifficulty)
        {
            await db.WalkDifficulties.AddAsync(walkDifficulty);
            await db.SaveChangesAsync();

            return walkDifficulty;
        }

        public async Task<WalkDifficulty?> DeleteAsync(Guid id)
        {
            var walkDifficulty = await db.WalkDifficulties.FindAsync(id);
            if (walkDifficulty == null)
            {
                return null;
            }

            db.WalkDifficulties.Remove(walkDifficulty);
            await db.SaveChangesAsync();
            return walkDifficulty;
        }

        public async Task<IReadOnlyList<WalkDifficulty>> GetAllAsync()
        {

            return await db.WalkDifficulties.ToListAsync();
        }

        public async Task<WalkDifficulty?> GetAsync(Guid id)
        {
            return await db.WalkDifficulties.FindAsync(id);

        }

        public async Task<WalkDifficulty?> UpdateAsync(Guid id, WalkDifficulty walkDifficulty)
        {
            var existWalkDifficulty = await db.WalkDifficulties.FindAsync(id);
            if (existWalkDifficulty == null)
            {
                return null;
            }

            db.WalkDifficulties.Update(walkDifficulty);
            await db.SaveChangesAsync();

            return walkDifficulty;
        }
    }
}
