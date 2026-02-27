using Coverage.Core.Enums;
using Coverage.Core.Models;

namespace Coverage.Services.BusinessLogic.Implementation
{
    public class TransactionCoordinatorService
    {
        private readonly ClaimService _claimService;
        private readonly PaymentService _paymentService;

        public TransactionCoordinatorService(ClaimService claimService, PaymentService paymentService)
        {
            _claimService = claimService;
            _paymentService = paymentService;
        }

        public async Task<bool> ProcessClaimAndPaymentAsync(int claimId, Payment payment)
        {
            try
            {
                var claim = await _claimService.GetClaimByIdAsync(claimId);
                if (claim == null)
                    throw new Exception($"Claim with ID {claimId} not found.");

                // Update claim
                var claimStatusString = "Pending";
                var claimStatus = Enum.Parse<ClaimStatus>(claimStatusString);
                await _claimService.UpdateClaimAsync(claim);

                // Add payment
                await _paymentService.AddPaymentAsync(payment);

                return true;
            }
            catch
            {
                throw; // Log and handle as necessary
            }
        }
    }
}
