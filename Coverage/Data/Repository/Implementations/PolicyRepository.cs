using Coverage.Core.Models;
using Coverage.Core.Enums;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coverage.Data.Contexts;
using Coverage.Data.Repositories.Interfaces;

namespace Coverage.Data.Repositories.Implementations
{
    public class PolicyRepository : GenericRepository<Policy>, IPolicyRepository
    {
        public PolicyRepository(CoverageDbContext dbContext) : base(dbContext) { }

        public async Task<Policy?> GetPolicyByIdAsync(int id)
        {
            return await _context.Policies.FindAsync(id);
        }

        public async Task<IEnumerable<Policy>> GetPoliciesByStatusAsync(PolicyStatus status)
        {
            return await _context.Policies.Where(p => p.Status == status).ToListAsync();
        }

        public async Task<bool> IsPolicyNumberExistsAsync(string policyNumber)
        {
            return await _context.Policies.AnyAsync(p => p.PolicyNumber == policyNumber);
        }

        public async Task<Policy> AddPolicyAsync(Policy policy)
        {
            if (await IsPolicyNumberExistsAsync(policy.PolicyNumber))
            {
                throw new InvalidOperationException("A policy with this number already exists.");
            }

            await _context.Policies.AddAsync(policy);
            await _context.SaveChangesAsync();
            return policy;
        }
    }
}
