using Coverage.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coverage.Data.Repositories.Interfaces
{
    public interface IClaimRepository : IGenericRepository<Claim>
    {
        Task<IEnumerable<Claim>> GetClaimsByUserIdAsync(int userId);
        Task<IEnumerable<Claim>> GetClaimsByPolicyIdAsync(int policyId);
    }
}
