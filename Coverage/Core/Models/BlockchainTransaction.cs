using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coverage.Core.Models
{

    [Index(nameof(TransactionHash), IsUnique = true)]
    [Index(nameof(PolicyId))]
    [Index(nameof(ReferenceType))]
    [Index(nameof(TransactionDate))]
    public class BlockchainTransaction
    {
        public int Id { get; set; } // Primary Key

        [Required, MaxLength(256)]
        public string TransactionHash { get; set; } = string.Empty; // Blockchain transaction hash

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public DateTime TransactionDate { get; set; }

        [Required, MaxLength(50)]
        public string BlockchainNetwork { get; set; } = "Pi"; // e.g., Pi, Ethereum, Bitcoin

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        [MaxLength(50)]
        public string? ReferenceType { get; set; } // e.g., "Policy", "Claim"

        [Required]
        public int ReferenceId { get; set; } // Links to Policy or Claim by ID

        // Foreign Keys
        public int PolicyId { get; set; }

        // Navigation Properties
        public Policy Policy { get; set; } = null!;
    }
}
