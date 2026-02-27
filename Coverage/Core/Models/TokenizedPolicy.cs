using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coverage.Core.Models
{
    [Index(nameof(TokenId), IsUnique = true)]
    [Index(nameof(PolicyId))]
    public class TokenizedPolicy
    {
        public int Id { get; set; } // Primary Key

        [Required]
        public int PolicyId { get; set; } // Foreign Key to Policy

        [Required]
        [MaxLength(100)]
        public string TokenId { get; set; } = string.Empty; // Blockchain token identifier

        [Required]
        [Column(TypeName = "decimal(18,8)")]
        public decimal FractionalValue { get; set; } // For fractional ownership

        [Required]
        public DateTime TokenizationDate { get; set; } = DateTime.UtcNow; // Default to current UTC time

        // Navigation Property
        public Policy Policy { get; set; } = null!;
    }
}
