using Coverage.Core.Models;

namespace Coverage.Services.BusinessLogic.Interfaces
{
    public interface IPaymentService
    {
        Task<Payment?> GetPaymentByIdAsync(int id);
        Task<IEnumerable<Payment>> GetPaymentsByUserIdAsync(int userId);
        Task<decimal> GetTotalPremiumPaidAsync(int userId);
        Task<Payment> RecordPaymentAsync(Payment payment);
    }
}
