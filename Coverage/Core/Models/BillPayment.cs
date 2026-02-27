using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coverage.Core.Models
{
    [Index(nameof(PaymentReference), IsUnique = true)]
    [Index(nameof(PaymentDate))]
    [Index(nameof(UserId))]
    [Index(nameof(Status))]
    public class BillPayment
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

        // Foreign Keys
        public int UserId { get; set; } // User making the payment
        public int? BlockchainTransactionId { get; set; } // Optional, for crypto payments

        // Navigation Properties
        public User User { get; set; } = null!;
        public BlockchainTransaction? BlockchainTransaction { get; set; } // Link to the blockchain transaction, if any
    }
}
