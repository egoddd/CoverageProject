using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coverage.Core.Models
{
    /// <summary>
    /// Represents a referral program for users to earn rewards.
    /// </summary>
    [Index(nameof(UserId))]
    [Index(nameof(ReferredEmail))]
    [Index(nameof(ReferredOn))]
    public class ReferralProgram
    {
        public int Id { get; set; } // Primary Key

        [Required]
        public int UserId { get; set; } // Referring User

        public User? User { get; set; }

        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public string ReferredEmail { get; set; } = string.Empty; // Email of the referred user

        [Required]
        public DateTime ReferredOn { get; set; } = DateTime.UtcNow; // Referral timestamp

        [Required]
        public bool IsRewarded { get; set; } = false; // Tracks if reward is granted

        [Column(TypeName = "decimal(18,2)")]
        public decimal RewardAmount { get; set; } = 0; // Amount rewarded
    }
}
