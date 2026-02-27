using Coverage.Core.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Coverage.Core.DTOs
{
    [Index(nameof(PolicyNumber), IsUnique = true)]
    [Index(nameof(UserId))]
    [Index(nameof(Status))]
    public class UpdatePolicyDTO
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string PolicyHolderName { get; set; } = string.Empty;

        public string PolicyNumber { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty; // e.g., Health, Auto, Property

        [StringLength(500)]
        public string? Description { get; set; }
        public string? TermsAndConditions { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue)]
        public decimal PremiumAmount { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal CoverageAmount { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public PolicyStatus Status { get; set; }
        public int UserId { get; set; }
    }
}
