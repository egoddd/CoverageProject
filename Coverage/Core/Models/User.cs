using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coverage.Core.Models
{
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(PhoneNumber))]
    [Index(nameof(CreatedAt))]
    public class User
    {
        public int Id { get; set; } // Primary Key

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;

        [MaxLength(255)]
        public string Address { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string UserRole { get; set; } = "Customer"; // e.g., Admin, Customer

        public bool IsVerified { get; set; } = false;

        [Required]
        [MaxLength(50)]
        public string Role { get; set; } = "User"; // Default value or modify as needed

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public ICollection<Policy> Policies { get; set; } = new List<Policy>();
        public ICollection<Claim> Claims { get; set; } = new List<Claim>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
