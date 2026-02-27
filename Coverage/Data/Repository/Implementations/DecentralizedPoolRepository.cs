using Coverage.Core.Models;
using Coverage.Data.Contexts;
using Coverage.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Coverage.Data.Repositories.Implementations
{
    public class DecentralizedPoolRepository : GenericRepository<DecentralizedPool>, IDecentralizedPoolRepository
    {
        public DecentralizedPoolRepository(CoverageDbContext context) : base(context) { }

        public async Task<IEnumerable<DecentralizedPool?>> GetPoolsByUserIdAsync(int userId)
        {
            return await _context.DecentralizedPools.Where(pool => pool.UserId == userId).ToListAsync();
        }
    }
}
