using Walks.Api.Data;
using Walks.Api.Models.Domains;

namespace Walks.Api.Repositories
{
    public interface IRegionRepository
    {
        IReadOnlyList<Region> GetAll();
       // Region Get(int id);
    }

    public class RegionRepository : IRegionRepository
    {
        private readonly WalksDbContext db;

        public RegionRepository(WalksDbContext db)
        {
            this.db = db;
        }
        public IReadOnlyList<Region> GetAll()
        {
            return db.Regions.ToList();
        }
    }
}
