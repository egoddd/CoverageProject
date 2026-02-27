using Coverage.Core.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coverage.Core.Models
{
    [Index(nameof(PolicyNumber), IsUnique = true)]
    [Index(nameof(UserId))]
    [Index(nameof(Status))]
    public class Policy
    {
        public int Id { get; set; } // Primary Key

        [Required]
        [MaxLength(100)]
        public string PolicyNumber { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        public string PolicyHolderName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public PolicyType Type { get; set; } = PolicyType.Health; // e.g., Health, Auto, Property

        [Column(TypeName = "decimal(18,2)")]
        public decimal PremiumAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal CoverageAmount { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [MaxLength(20)]
        public PolicyStatus Status { get; set; } = PolicyStatus.Active; // e.g., Active, Expired, Canceled

        [Required]
        [MaxLength(1000)] // Allows up to 1000 characters; adjust as needed
        public string TermsAndConditions { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        // Foreign Keys
        [Required]
        public int UserId { get; set; }

        [ForeignKey("DecentralizedPool")]
        public int? DecentralizedPoolId { get; set; }

        // Navigation Properties
        public User User { get; set; } = null!;
        public ICollection<Claim> Claims { get; set; } = new List<Claim>();
        public ICollection<BlockchainTransaction> BlockchainTransactions { get; set; } = new List<BlockchainTransaction>();
    }
}
