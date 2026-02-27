using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Coverage.Core.DTOs;
using Coverage.Core.Models;
using Coverage.Data.Repositories.Interfaces;
using Coverage.Services.BusinessLogic.Interfaces;

namespace Coverage.Services.BusinessLogic.Implementation
{
    public class ClaimService : IClaimService
    {
        private readonly IClaimRepository _claimRepository;
        private readonly IMapper _mapper; // For mapping entities <-> DTOs

        public ClaimService(IClaimRepository claimRepository, IMapper mapper)
        {
            _claimRepository = claimRepository ?? throw new ArgumentNullException(nameof(claimRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ClaimDTO> GetClaimByIdAsync(int id)
        {
            var claim = await _claimRepository.GetByIdAsync(id);
            if (claim == null)
            {
                // Return null or throw exception as per your design
                throw new KeyNotFoundException($"Claim with ID {id} not found.");
            }
            return _mapper.Map<ClaimDTO>(claim);
        }

        public async Task<IEnumerable<ClaimDTO>> GetAllClaimsAsync()
        {
            var claims = await _claimRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ClaimDTO>>(claims);
        }

        public async Task<IEnumerable<ClaimDTO>> GetClaimsByUserIdAsync(int userId)
        {
            var claims = await _claimRepository.GetClaimsByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<ClaimDTO>>(claims);
        }

        public async Task<IEnumerable<ClaimDTO>> GetClaimsByPolicyIdAsync(int policyId)
        {
            var claims = await _claimRepository.GetClaimsByPolicyIdAsync(policyId);
            return _mapper.Map<IEnumerable<ClaimDTO>>(claims);
        }

        public async Task<ClaimDTO> CreateClaimAsync(CreateClaimDTO createClaimDTO)
        {
            if (createClaimDTO == null)
                throw new ArgumentNullException(nameof(createClaimDTO));

            // Convert DTO to entity
            var claimEntity = _mapper.Map<Claim>(createClaimDTO);
            claimEntity.Status = "Pending";
            claimEntity.DateFiled = DateTime.UtcNow;

            // Save to repository
            await _claimRepository.AddAsync(claimEntity);

            // Return mapped result
            return _mapper.Map<ClaimDTO>(claimEntity);
        }

        public async Task<bool> ApproveClaimAsync(int claimId)
        {
            var claim = await _claimRepository.GetByIdAsync(claimId);
            if (claim == null) return false;

            claim.Status = "Approved";
            await _claimRepository.UpdateAsync(claim);
            return true;
        }

        public async Task<bool> RejectClaimAsync(RejectClaimDTO rejectClaimDTO)
        {
            var claim = await _claimRepository.GetByIdAsync(rejectClaimDTO.ClaimId);
            if (claim == null) return false;

            claim.Status = "Rejected";
            // Optionally store reject reason in a separate property if your Claim entity supports it
            await _claimRepository.UpdateAsync(claim);
            return true;
        }
    }
}
