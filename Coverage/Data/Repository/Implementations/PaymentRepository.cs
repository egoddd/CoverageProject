using Coverage.Core.Models;
using Coverage.Data.Contexts;
using Coverage.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coverage.Data.Repositories.Implementations
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(CoverageDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByUserIdAsync(int userId)
        {
            return await _context.Payments.Where(p => p.UserId == userId).ToListAsync();
        }

        public async Task<decimal> GetTotalPremiumPaidAsync(int userId)
        {
            return await _context.Payments.Where(p => p.UserId == userId).SumAsync(p => p.Amount);
        }
        public async Task<IEnumerable<Payment>> GetPaymentsByPolicyIdAsync(int policyId)
        {
            return await _context.Payments.Where(p => p.PolicyId == policyId).ToListAsync();
        }

    }
}
