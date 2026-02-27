using Coverage.Core.DTOs;
using Coverage.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coverage.Services.BusinessLogic.Interfaces
{
    public interface IClaimService
    {
        /// <summary>
        /// Retrieves a claim by ID.
        /// </summary>
        /// <param name="id">Claim ID</param>
        /// <returns>A ClaimDTO or null if not found.</returns>
        Task<ClaimDTO> GetClaimByIdAsync(int id);

        /// <summary>
        /// Retrieves all claims.
        /// </summary>
        /// <returns>A list of ClaimDTOs.</returns>
        Task<IEnumerable<ClaimDTO>> GetAllClaimsAsync();

        /// <summary>
        /// Retrieves all claims submitted by a specific user.
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns>A list of ClaimDTOs.</returns>
        Task<IEnumerable<ClaimDTO>> GetClaimsByUserIdAsync(int userId);

        /// <summary>
        /// Retrieves all claims associated with a specific policy.
        /// </summary>
        /// <param name="policyId">Policy ID</param>
        /// <returns>A list of ClaimDTOs.</returns>
        Task<IEnumerable<ClaimDTO>> GetClaimsByPolicyIdAsync(int policyId);

        /// <summary>
        /// Creates a new claim.
        /// </summary>
        /// <param name="createClaimDTO">Data needed to create a claim.</param>
        /// <returns>A ClaimDTO representing the newly created claim.</returns>
        Task<ClaimDTO> CreateClaimAsync(CreateClaimDTO createClaimDTO);

        /// <summary>
        /// Approves an existing claim.
        /// </summary>
        /// <param name="claimId">Claim ID to approve.</param>
        /// <returns>True if approved successfully; otherwise false.</returns>
        Task<bool> ApproveClaimAsync(int claimId);

        /// <summary>
        /// Rejects an existing claim.
        /// </summary>
        /// <param name="rejectClaimDTO">Contains claim ID and reason for rejection.</param>
        /// <returns>True if rejected successfully; otherwise false.</returns>
        Task<bool> RejectClaimAsync(RejectClaimDTO rejectClaimDTO);
    }
}
