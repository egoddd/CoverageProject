using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coverage.Core.Models
{
    [Index(nameof(PoolName))]
    [Index(nameof(BlockchainNetwork))]
    public class DecentralizedPool
    {
        public int Id { get; set; } // Primary Key
        public int UserId { get; set; }

        [Required, MaxLength(100)]
        public string PoolName { get; set; } = string.Empty;

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal TotalFunds { get; set; }

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal TotalPoolValue { get; set; }

        [Required, Range(0, int.MaxValue)]
        public int TotalParticipants { get; set; }

        [Required, MaxLength(50)]
        public string BlockchainNetwork { get; set; } = string.Empty; // e.g., Ethereum, Polygon, Pi

        // Navigation Properties
        public ICollection<Policy> Policies { get; set; } = new List<Policy>();
        public ICollection<BlockchainTransaction> Transactions { get; set; } = new List<BlockchainTransaction>();
    }
}
