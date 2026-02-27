using Coverage.Core.Enums;
using Coverage.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coverage.Data.Repositories.Interfaces
{
    public interface IPolicyRepository : IGenericRepository<Policy>
    {
        /// <summary>
        /// Retrieves a policy by its unique identifier.
        /// </summary>
        /// <param name="id">The policy ID.</param>
        /// <returns>A Policy object or null if not found.</returns>
        Task<Policy?> GetPolicyByIdAsync(int id);

        /// <summary>
        /// Retrieves all policies with the specified status.
        /// </summary>
        /// <param name="status">The status of the policies to retrieve.</param>
        /// <returns>A collection of policies with the given status.</returns>
        Task<IEnumerable<Policy>> GetPoliciesByStatusAsync(PolicyStatus status);

        /// <summary>
        /// Checks if a policy with the given policy number exists.
        /// </summary>
        /// <param name="policyNumber">The policy number to check.</param>
        /// <returns>True if the policy number exists, otherwise false.</returns>
        Task<bool> IsPolicyNumberExistsAsync(string policyNumber);

        /// <summary>
        /// Adds a new policy to the database.
        /// </summary>
        /// <param name="policy">The policy to add.</param>
        /// <returns>The added Policy object.</returns>
        Task<Policy> AddPolicyAsync(Policy policy);
    }
}
