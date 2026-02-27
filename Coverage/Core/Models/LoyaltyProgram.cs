using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coverage.Core.Models
{
    /// <summary>
    /// Represents a loyalty program for user rewards.
    /// </summary>
    [Index(nameof(UserId))]
    [Index(nameof(LastUpdated))]
    public class LoyaltyProgram
    {
        public int Id { get; set; } // Primary Key

        [Required]
        public int UserId { get; set; } // Associated User

        public User? User { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPoints { get; set; } = 0; // Accumulated loyalty points

        [MaxLength(500)]
        public string? Description { get; set; } // Optional description (e.g., tier information)

        [Required]
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow; // Tracks when points were updated
    }
}
