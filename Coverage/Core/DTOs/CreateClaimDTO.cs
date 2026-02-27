using Coverage.Core.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coverage.Core.Models
{
    [Index(nameof(ClaimNumber), IsUnique = true)]
    [Index(nameof(Status))]
    public class CreateClaimDTO
    {
        public int Id { get; set; } // Primary Key

        [Required, MaxLength(50)]
        public string ClaimNumber { get; set; } = string.Empty;

        [Required, MaxLength(20)]
        public ClaimStatus Status { get; set; } = ClaimStatus.Pending; // e.g., Pending, Approved, Rejected

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal ClaimAmount { get; set; }

        [Required, MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        public DateTime FiledDate { get; set; } = DateTime.UtcNow;

        [Required, MaxLength(500)]
        public string Reason { get; set; } = string.Empty; // Reason for filing the claim

        [MaxLength(1000)]
        public string Notes { get; set; } = string.Empty; // Additional comments during the review process

    }
}
