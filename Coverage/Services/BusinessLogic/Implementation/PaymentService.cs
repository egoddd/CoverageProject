using Coverage.Services.BusinessLogic.Interfaces;
using Coverage.Core.Interfaces;
using Coverage.Core.Models;
using Coverage.Data.Repositories.Interfaces;
using Coverage.Core.DTOs;


namespace Coverage.Services.BusinessLogic.Implementation
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<Payment?> GetPaymentByIdAsync(int paymentId)
        {
            return await _paymentRepository.GetByIdAsync(paymentId);
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByUserIdAsync(int userId)
        {
            return await _paymentRepository.GetPaymentsByUserIdAsync(userId);
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByPolicyIdAsync(int policyId)
        {
            return await _paymentRepository.GetPaymentsByPolicyIdAsync(policyId);
        }

        public async Task AddPaymentAsync(Payment payment)
        {
            await _paymentRepository.AddAsync(payment);
        }

        public async Task UpdatePaymentAsync(Payment payment)
        {
            await _paymentRepository.UpdateAsync(payment);
        }
        public async Task<decimal> GetTotalPremiumPaidAsync(int userId)
        {
            return await _paymentRepository.GetTotalPremiumPaidAsync(userId);
        }

        public async Task<Payment> RecordPaymentAsync(Payment payment)
        {
            if (payment == null)
                throw new ArgumentNullException(nameof(payment));

            return await _paymentRepository.AddAsync(payment);
        }

    }
}
