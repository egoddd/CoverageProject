using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Coverage.Core.DTOs
{
    public class BillPaymentResponseDTO
    {
        public int Id { get; set; } // Primary Key

        [Required, MaxLength(50)]
        public string PaymentReference { get; set; } = string.Empty; // Unique identifier for the bill payment

        [Required, MaxLength(100)]
        public string BillerName { get; set; } = string.Empty; // e.g., Electricity Provider, ISP

        [Required, MaxLength(50)]
        public string BillType { get; set; } = string.Empty; // e.g., Electricity, Internet, Airtime

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required, MaxLength(3)]
        public string Currency { get; set; } = "USD"; // e.g., USD, EUR, PI

        public DateTime PaymentDate { get; set; }

        [Required, MaxLength(20)]
        public string Status { get; set; } = "Pending"; // e.g., Pending, Completed, Failed

        [Required, MaxLength(50)]
        public string PaymentMethod { get; set; } = "Crypto"; // e.g., Crypto, Bank Transfer, Credit Card
    }
}
