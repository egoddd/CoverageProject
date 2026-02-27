using Coverage.Core.Models;
using Coverage.Data.Contexts;
using Coverage.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace Coverage.Data.Repositories.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(CoverageDbContext context) : base(context) { }

        // Explicitly declare nullable return type
        public async Task<User?> GetUserByEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be null or empty.", nameof(email));

            try
            {
                return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            }
            catch (Exception ex)
            {
                // Log exception (use a logger in a real-world app)
                Console.WriteLine($"Error fetching user by email: {ex.Message}");
                throw;
            }
        }

        // Add additional method if needed
        public async Task<bool> DoesUserExistAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be null or empty.", nameof(email));

            return await _context.Users.AnyAsync(u => u.Email == email);
        }
    }
}
