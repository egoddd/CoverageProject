using Coverage.Core.DTOs;
using Coverage.Core.Models;

namespace Coverage.Core.Interfaces
{
    public interface IPolicyService
    {
        Task<Policy> CreatePolicyAsync(CreatePolicyDTO createPolicyDto);
        Task<Policy> GetPolicyByIdAsync(int id);

    }
}
