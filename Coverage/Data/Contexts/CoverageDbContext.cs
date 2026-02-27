using Coverage.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Coverage.Data.Contexts
{
    public class CoverageDbContext : DbContext
    {
        public CoverageDbContext(DbContextOptions<CoverageDbContext> options)
            : base(options)
        {
            // Debugging check
            Console.WriteLine("Connection String: " + Database.GetDbConnection().ConnectionString);
        }

        // DbSets for Core Models
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Policy> Policies { get; set; } = null!;
        public DbSet<Claim> Claims { get; set; } = null!;
        public DbSet<Payment> Payments { get; set; } = null!;
        public DbSet<BlockchainTransaction> BlockchainTransactions { get; set; } = null!;
        public DbSet<TokenizedPolicy> TokenizedPolicies { get; set; } = null!;
        public DbSet<DecentralizedPool> DecentralizedPools { get; set; } = null!;
        public DbSet<ReferralProgram> ReferralPrograms { get; set; } = null!;
        public DbSet<LoyaltyProgram> LoyaltyPrograms { get; set; } = null!;
        public DbSet<EducationalContent> EducationalContents { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure entities
            ConfigureUserEntity(modelBuilder);
            ConfigurePolicyEntity(modelBuilder);
            ConfigureClaimEntity(modelBuilder);
            ConfigurePaymentEntity(modelBuilder);
            ConfigureReferralProgramEntity(modelBuilder);
            ConfigureLoyaltyProgramEntity(modelBuilder);
            ConfigureEducationalContentEntity(modelBuilder);
            ConfigureBlockchainTransactionEntity(modelBuilder); // Corrected name

            // TokenizedPolicy and DecentralizedPool configurations
            modelBuilder.Entity<TokenizedPolicy>()
                .HasOne(tp => tp.Policy)
                .WithMany()
                .HasForeignKey(tp => tp.PolicyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DecentralizedPool>()
                .HasMany(dp => dp.Policies)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BlockchainTransaction>()
               .Property(b => b.Amount)
               .HasPrecision(18, 2);

            // Value Conversions
            modelBuilder.Entity<Policy>()
                .Property(p => p.Type)
                .HasConversion<string>();

            modelBuilder.Entity<Policy>()
                .Property(p => p.Status)
                .HasConversion<string>();

            modelBuilder.Entity<Claim>()
               .HasOne(c => c.User)
               .WithMany(u => u.Claims)
               .HasForeignKey(c => c.UserId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .Property(p => p.PaymentMethod)
                .HasConversion<string>();

            modelBuilder.Entity<Payment>()
                .Property(p => p.Status)
                .HasConversion<string>();

            modelBuilder.Entity<User>()
                .HasMany(u => u.Policies)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private static void ConfigureUserEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Policies)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

        }

        private static void ConfigurePolicyEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Policy>()
                .HasMany(p => p.Claims)
                .WithOne(c => c.Policy)
                .HasForeignKey(c => c.PolicyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Policy>()
                .Property(p => p.PremiumAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Policy>()
                .Property(p => p.CoverageAmount)
                .HasPrecision(18, 2);
        }

        private static void ConfigureClaimEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Claim>()
                 .HasOne(c => c.User)
                 .WithMany(u => u.Claims)
                 .HasForeignKey(c => c.UserId)
                 .OnDelete(DeleteBehavior.Restrict); // Avoid cascading

            modelBuilder.Entity<Claim>()
                .HasOne(c => c.Policy)
                .WithMany(p => p.Claims)
                .HasForeignKey(c => c.PolicyId)
                .OnDelete(DeleteBehavior.Restrict);

        }

        private static void ConfigurePaymentEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Policy)
                .WithMany()
                .HasForeignKey(p => p.PolicyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasPrecision(18, 2);
        }

        private static void ConfigureReferralProgramEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReferralProgram>()
                .HasOne(rp => rp.User)
                .WithMany()
                .HasForeignKey(rp => rp.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReferralProgram>()
                .Property(rp => rp.RewardAmount)
                .HasPrecision(18, 2);
        }

        private static void ConfigureLoyaltyProgramEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoyaltyProgram>()
                .HasOne(lp => lp.User)
                .WithMany()
                .HasForeignKey(lp => lp.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LoyaltyProgram>()
                .Property(lp => lp.TotalPoints)
                .HasPrecision(18, 2);
        }

        private static void ConfigureEducationalContentEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EducationalContent>()
                .Property(ec => ec.Title)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<EducationalContent>()
                .Property(ec => ec.ContentBody)
                .IsRequired();
        }

        private static void ConfigureBlockchainTransactionEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlockchainTransaction>()
                .Property(bt => bt.TransactionHash)
                .IsRequired()
                .HasMaxLength(64);

            modelBuilder.Entity<BlockchainTransaction>()
                .Property(bt => bt.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<BlockchainTransaction>()
                .Property(bt => bt.Timestamp)
                .IsRequired();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            // Additional configuration if needed
        }
    }
}
