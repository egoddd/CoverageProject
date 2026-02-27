using Coverage.Core.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coverage.Core.Models
{
    [Index(nameof(PaymentReference), IsUnique = true)]
    [Index(nameof(UserId))]
    [Index(nameof(PolicyId))]
    [Index(nameof(PaymentDate))]
    public class ProcessPaymentDTO
    {
        public int Id { get; set; } // Primary Key

        [Required]
        [MaxLength(100)]
        public string PaymentReference { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

        [Required]
        [MaxLength(50)]
        public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.Crypto; // e.g., Crypto, Bank Transfer, Credit Card

        [Required]
        [MaxLength(20)]
        public PaymentStatus Status { get; set; } = PaymentStatus.Completed; // e.g., Completed, Pending, Failed

        [MaxLength(100)]
        public string? TransactionId { get; set; } // Nullable if optional

        [MaxLength(100)]
        public string? Reference { get; set; } // Nullable if optional

        // Foreign Keys
        [Required]
        public int UserId { get; set; }

        public int? PolicyId { get; set; } // Nullable, may not always be linked to a policy

        
    }
}
