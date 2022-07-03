using Microsoft.EntityFrameworkCore;
using Walks.Api.Data;
using Walks.Api.Models.Domains;

namespace Walks.Api.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly WalksDbContext db;

        public WalkRepository(WalksDbContext db)
        {
            this.db = db;
        }

        public async Task<Walk?> AddAsync(Walk walk)
        {
            await db.Walks.AddAsync(walk);
            await db.SaveChangesAsync();

            return walk;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var walk = await  db.Walks.FindAsync(id);
            if (walk == null)
            {
                return null;
            }

            db.Walks.Remove(walk);
            await db.SaveChangesAsync();
            return walk;
        }

        public async Task<IReadOnlyList<Walk>> GetAllAsync()
        {
            return await db.Walks.Include(w=>w.Region).Include(w=>w.WalkDifficulty).ToListAsync();
        }

        public async Task<Walk?> GetAsync(Guid id)
        {
            return await db.Walks.Include(w=>w.Region).Include(w=>w.WalkDifficulty).FirstOrDefaultAsync(w=>w.Id ==id);
           
        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            var existWalk = await db.Walks.FindAsync(id);
            if (existWalk == null)
            {
                return null;
            }

            db.Walks.Update(walk);
            await db.SaveChangesAsync();

            return walk;
        }
    }
}
