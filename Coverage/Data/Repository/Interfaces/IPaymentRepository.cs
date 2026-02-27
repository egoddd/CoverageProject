using Coverage.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coverage.Data.Repositories.Interfaces
{
    public interface IPaymentRepository : IGenericRepository<Payment>
    {
        Task<IEnumerable<Payment>> GetPaymentsByUserIdAsync(int userId);
        Task<decimal> GetTotalPremiumPaidAsync(int userId);
        Task<IEnumerable<Payment>> GetPaymentsByPolicyIdAsync(int policyId);

    }
}
