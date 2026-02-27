using Microsoft.AspNetCore.Mvc;
using Coverage.Services.BusinessLogic.Interfaces;
using Coverage.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using Coverage.Core.Models;

[Route("api/[controller]")]
[ApiController]
public class ClaimsController : ControllerBase
{
    private readonly IClaimService _claimService;

    public ClaimsController(IClaimService claimService)
    {
        _claimService = claimService;
    }

    /// <summary>
    /// Gets a claim by ID.
    /// </summary>
    /// <param name="id">Claim ID</param>
    /// <returns>Claim data or 404 if not found</returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ClaimDTO>> GetClaimById(int id)
    {
        var claim = await _claimService.GetClaimByIdAsync(id);
        if (claim == null) return NotFound(new { Message = "Claim not found." });
        return Ok(claim);
    }

    /// <summary>
    /// Retrieves all claims for a given user.
    /// </summary>
    /// <param name="userId">User ID</param>
    /// <returns>List of claims</returns>
    [HttpGet("user/{userId:int}")]
    public async Task<ActionResult<IEnumerable<ClaimDTO>>> GetUserClaims(int userId)
    {
        var claims = await _claimService.GetClaimsByUserIdAsync(userId);
        return Ok(claims);
    }

    /// <summary>
    /// Retrieves all claims for a given policy.
    /// </summary>
    /// <param name="policyId">Policy ID</param>
    /// <returns>List of claims</returns>
    [HttpGet("policy/{policyId:int}")]
    public async Task<ActionResult<IEnumerable<ClaimDTO>>> GetPolicyClaims(int policyId)
    {
        var claims = await _claimService.GetClaimsByPolicyIdAsync(policyId);
        return Ok(claims);
    }

    /// <summary>
    /// Submits a new claim.
    /// </summary>
    /// <param name="createClaimDTO">Claim data</param>
    /// <returns>Created claim</returns>
    [HttpPost]
    public async Task<IActionResult> CreateClaim([FromBody] CreateClaimDTO createClaimDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createdClaim = await _claimService.CreateClaimAsync(createClaimDTO);
        return CreatedAtAction(nameof(GetClaimById), new { id = createdClaim.Id }, createdClaim);
    }

    /// <summary>
    /// Approves an existing claim.
    /// </summary>
    /// <param name="id">Claim ID</param>
    /// <returns>200 if successful, 404 if not found</returns>
    [HttpPut("{id:int}/approve")]
    public async Task<IActionResult> ApproveClaim(int id)
    {
        var isApproved = await _claimService.ApproveClaimAsync(id);
        if (!isApproved) return NotFound(new { Message = "Claim not found or already processed." });
        return Ok(new { Message = "Claim approved successfully." });
    }

    /// <summary>
    /// Rejects an existing claim.
    /// </summary>
    /// <param name="id">Claim ID</param>
    /// <param name="rejectClaimDTO">DTO containing reason for rejection</param>
    /// <returns>200 if successful, 404 if not found</returns>
    [HttpPut("{id:int}/reject")]
    public async Task<IActionResult> RejectClaim(int id, [FromBody] RejectClaimDTO rejectClaimDTO)
    {
        // If you store the claim ID in RejectClaimDTO, you can set it here:
        rejectClaimDTO.ClaimId = id;

        var isRejected = await _claimService.RejectClaimAsync(rejectClaimDTO);
        if (!isRejected) return NotFound(new { Message = "Claim not found or already processed." });
        return Ok(new { Message = "Claim rejected successfully." });
    }
}
