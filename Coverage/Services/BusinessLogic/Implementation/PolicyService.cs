using Coverage.Core.Enums;
using Coverage.Core.Interfaces;
using Coverage.Core.Models;
using Coverage.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Coverage.Data.Repositories.Interfaces;

public class PolicyService : IPolicyService
{
    private readonly IPolicyRepository _policyRepository;

    public PolicyService(IPolicyRepository policyRepository)
    {
        _policyRepository = policyRepository ?? throw new ArgumentNullException(nameof(policyRepository));
    }

    public async Task<Policy> GetPolicyByIdAsync(int id)
    {
        var policy = await _policyRepository.GetPolicyByIdAsync(id);
        if (policy == null)
        {
            throw new KeyNotFoundException($"Policy with ID {id} not found.");
        }
        return policy;
    }

    public async Task<IEnumerable<Policy>> GetPoliciesByStatusAsync(PolicyStatus status)
    {
        return await _policyRepository.GetPoliciesByStatusAsync(status);
    }

    public async Task<Policy> CreatePolicyAsync(CreatePolicyDTO createPolicyDTO)
    {
        if (createPolicyDTO == null)
            throw new ArgumentNullException(nameof(createPolicyDTO));

        // Validate business rules
        ValidatePolicyDates(createPolicyDTO.StartDate, createPolicyDTO.EndDate);

        // Ensure policy number is unique
        if (await _policyRepository.IsPolicyNumberExistsAsync(createPolicyDTO.PolicyNumber))
        {
            throw new InvalidOperationException("A policy with this number already exists.");
        }

        // Parse the type enum
        var typeResult = ParseEnum<PolicyType>(createPolicyDTO.Type, nameof(createPolicyDTO.Type));

        // Create a new policy object
        var policy = new Policy
        {
            PolicyNumber = createPolicyDTO.PolicyNumber,
            PolicyHolderName = createPolicyDTO.PolicyHolderName,
            Type = typeResult,
            PremiumAmount = createPolicyDTO.PremiumAmount,
            CoverageAmount = createPolicyDTO.CoverageAmount,
            StartDate = createPolicyDTO.StartDate,
            EndDate = createPolicyDTO.EndDate,
            Status = createPolicyDTO.Status,
            TermsAndConditions = createPolicyDTO.TermsAndConditions ?? string.Empty,
            Description = createPolicyDTO.Description,
            UserId = createPolicyDTO.UserId
        };

        // Save the new policy
        return await _policyRepository.AddPolicyAsync(policy);
    }


    private void ValidatePolicyDates(DateTime startDate, DateTime endDate)
    {
        if (startDate >= endDate)
        {
            throw new ArgumentException("Policy start date must be earlier than the end date.");
        }
    }

    private TEnum ParseEnum<TEnum>(string value, string paramName) where TEnum : struct
    {
        if (!Enum.TryParse(value, true, out TEnum result))
        {
            throw new ArgumentException(
                $"Invalid {typeof(TEnum).Name}: {value}. Valid values are: {string.Join(", ", Enum.GetNames(typeof(TEnum)))}", paramName);
        }
        return result;
    }
}
