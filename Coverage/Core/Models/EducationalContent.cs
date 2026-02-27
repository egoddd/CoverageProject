using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace Coverage.Core.Models
{
    /// <summary>
    /// Represents educational content related to insurance and blockchain.
    /// </summary>  
    [Index(nameof(Title))]
    [Index(nameof(PublishedOn))]
    public class EducationalContent
    {
        public int Id { get; set; } // Primary Key

        [Required, MaxLength(200)]
        public string Title { get; set; } = string.Empty; // Content title

        [Required]
        public string ContentBody { get; set; } = string.Empty; // Detailed content

        [Required, MaxLength(100)]
        public string Category { get; set; } = string.Empty; // Category (e.g., "Insurance", "Blockchain")

        [Required]
        public DateTime PublishedOn { get; set; } = DateTime.UtcNow; // Publish date

        [MaxLength(100)]
        public string? Author { get; set; } // Author or contributor
    }
}
