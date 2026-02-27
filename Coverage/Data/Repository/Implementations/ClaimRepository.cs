using Coverage.Core.Models;
using Coverage.Data.Contexts;
using Coverage.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coverage.Data.Repositories.Implementations
{
    public class ClaimRepository : GenericRepository<Claim>, IClaimRepository
    {
        public ClaimRepository(CoverageDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Claim>> GetClaimsByUserIdAsync(int userId)
        {
            return await _context.Claims.Where(c => c.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<Claim>> GetClaimsByPolicyIdAsync(int policyId)
        {
            return await _context.Claims.Where(c => c.PolicyId == policyId).ToListAsync();
        }
    }
}
