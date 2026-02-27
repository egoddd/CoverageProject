using Microsoft.AspNetCore.Mvc;
using Coverage.Services.BusinessLogic.Interfaces;
using Coverage.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class PoliciesController : ControllerBase
{
    private readonly IPolicyService _policyService;

    public PoliciesController(IPolicyService policyService)
    {
        _policyService = policyService;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<PolicyDTO>> GetPolicyById(int id)
    {
        var policy = await _policyService.GetPolicyByIdAsync(id);
        if (policy == null) return NotFound(new { Message = "Policy not found." });

        return Ok(policy);
    }

    [HttpGet("by-status/{status}")]
    public async Task<ActionResult<IEnumerable<PolicyDTO>>> GetPoliciesByStatus(string status)
    {
        var policies = await _policyService.GetPoliciesByStatusAsync(status);
        return Ok(policies);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePolicy([FromBody] CreatePolicyDTO createPolicyDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createdPolicy = await _policyService.CreatePolicyAsync(createPolicyDTO);
        return CreatedAtAction(nameof(GetPolicyById), new { id = createdPolicy.Id }, createdPolicy);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdatePolicy(int id, [FromBody] UpdatePolicyDTO updatePolicyDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updatedPolicy = await _policyService.UpdatePolicyAsync(id, updatePolicyDTO);
        if (updatedPolicy == null) return NotFound(new { Message = "Policy not found." });

        return Ok(updatedPolicy);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePolicy(int id)
    {
        var isDeleted = await _policyService.DeletePolicyAsync(id);
        if (!isDeleted) return NotFound(new { Message = "Policy not found." });

        return NoContent();
    }
}
