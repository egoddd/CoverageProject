using System;
using System.Collections.Generic;
using System.Linq;
using Coverage.Core.Enums;
using Coverage.Core.Models;
using Coverage.Data.Contexts;

namespace Coverage.Data.Seeders
{
    public static class DatabaseSeeder
    {
        public static void Seed(CoverageDbContext context)
        {
            // Seed Users
            if (!context.Users.Any())
            {
                Console.WriteLine("Seeding Users...");

                var users = new List<User>
                {
                    new User { FullName = "Admin User", Email = "admin@coverage.com", Role = "Admin", PhoneNumber = "1234567890", CreatedAt = DateTime.UtcNow },
                    new User { FullName = "John Doe", Email = "johndoe@example.com", Role = "Customer", PhoneNumber = "0987654321", CreatedAt = DateTime.UtcNow }
                };
                context.Users.AddRange(users);
            }

            // Seed Policies
            if (!context.Policies.Any())
            {
                Console.WriteLine("Seeding Policies...");

                var johnDoe = context.Users.FirstOrDefault(u => u.FullName == "John Doe");
                if (johnDoe != null)
                {
                    var policies = new List<Policy>
                    {
                        new Policy
                        {
                            PolicyNumber = "POL001",
                            PolicyHolderName = "John Doe",
                            Type = PolicyType.Health,
                            PremiumAmount = 500,
                            CoverageAmount = 50000,
                            StartDate = DateTime.UtcNow,
                            EndDate = DateTime.UtcNow.AddMonths(12),
                            Status = PolicyStatus.Active,
                            TermsAndConditions = "Standard health policy terms",
                            UserId = johnDoe.Id
                        },
                        new Policy
                        {
                            PolicyNumber = "POL002",
                            PolicyHolderName = "John Doe",
                            Type = PolicyType.Auto,
                            PremiumAmount = 300,
                            CoverageAmount = 30000,
                            StartDate = DateTime.UtcNow,
                            EndDate = DateTime.UtcNow.AddMonths(6),
                            Status = PolicyStatus.Active,
                            TermsAndConditions = "Standard auto policy terms",
                            UserId = johnDoe.Id
                        }
                    };
                    context.Policies.AddRange(policies);
                }
            }

            // Seed Claims
            if (!context.Claims.Any())
            {
                Console.WriteLine("Seeding Claims...");

                var policy1 = context.Policies.FirstOrDefault(p => p.PolicyNumber == "POL001");
                var policy2 = context.Policies.FirstOrDefault(p => p.PolicyNumber == "POL002");

                if (policy1 != null && policy2 != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim
                        {
                            ClaimNumber = "CLM001",
                            Status = ClaimStatus.Pending,
                            ClaimAmount = 1000,
                            FiledDate = DateTime.UtcNow,
                            Reason = "Medical expenses",
                            Notes = "Requires further review",
                            PolicyId = policy1.Id
                        },
                        new Claim
                        {
                            ClaimNumber = "CLM002",
                            Status = ClaimStatus.Approved,
                            ClaimAmount = 500,
                            FiledDate = DateTime.UtcNow,
                            Reason = "Accident repair",
                            Notes = "Approved with deductions",
                            PolicyId = policy2.Id
                        }
                    };
                    context.Claims.AddRange(claims);
                }
            }

            // Seed Payments
            if (!context.Payments.Any())
            {
                Console.WriteLine("Seeding Payments...");

                var policy1 = context.Policies.FirstOrDefault(p => p.PolicyNumber == "POL001");
                var policy2 = context.Policies.FirstOrDefault(p => p.PolicyNumber == "POL002");

                if (policy1 != null && policy2 != null)
                {
                    var payments = new List<Payment>
                    {
                        new Payment
                        {
                            TransactionId = "TXN001",
                            Amount = 500,
                            PaymentDate = DateTime.UtcNow,
                            PaymentMethod = PaymentMethod.CreditCard,
                            Status = PaymentStatus.Successful,
                            Reference = "REF001",
                            PolicyId = policy1.Id
                        },
                        new Payment
                        {
                            TransactionId = "TXN002",
                            Amount = 300,
                            PaymentDate = DateTime.UtcNow,
                            PaymentMethod = PaymentMethod.PayPal,
                            Status = PaymentStatus.Successful,
                            Reference = "REF002",
                            PolicyId = policy2.Id
                        }
                    };
                    context.Payments.AddRange(payments);
                }
            }

            // Save all changes in one transaction
            context.SaveChanges();
        }
    }
}
