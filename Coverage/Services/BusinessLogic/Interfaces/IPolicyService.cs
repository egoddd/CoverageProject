using Coverage.Core.Models;
using Coverage.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coverage.Services.BusinessLogic.Interfaces
{
    public interface IPolicyService
    {
        Task<Policy?> GetPolicyByIdAsync(int id);
        Task<IEnumerable<Policy>> GetPoliciesByStatusAsync(string status);
        Task<Policy> CreatePolicyAsync(CreatePolicyDTO createPolicyDTO);
        Task<bool> IsPolicyNumberExistsAsync(string policyNumber);
    }
}
