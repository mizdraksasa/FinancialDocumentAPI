using FinancialDocumentAPI.Shared.Dto;
using FinancialDocumentAPI.Application.Interfaces;
using FinancialDocumentAPI.Domain.IRepositories;
using FinancialDocumentAPI.Domain;
using FinancialDocumentAPI.Common.Extensions;

namespace FinancialDocumentAPI.Application.Service;

public class ValidateRequestService : IValidateRequestService
{
    private readonly IProductRepository _productRepository;
    private readonly ITenantRepository _tenantRepository;
    private readonly IClientRepository _clientRepository;

    public ValidateRequestService(IProductRepository productRepository, ITenantRepository tenantRepository, IClientRepository clientRepository)
    {
        _productRepository = productRepository;
        _tenantRepository = tenantRepository;
        _clientRepository = clientRepository;
    }

    public async Task<ValidationResultDto> ValidateAsync(string productCode, Guid tenantId, Guid documentId)
    {
        if (!await _productRepository.IsProductSupportedAsync(productCode))
            return CreateInvalidResult("Product not supported");

        if (!await _tenantRepository.IsTenantWhitelistedAsync(tenantId))
            return CreateInvalidResult("Tenant not whitelisted");

        var client = await _clientRepository.GetClientByTenantAndDocumentAsync(tenantId, documentId);
        
        if (client == null || !await _clientRepository.IsClientWhitelistedAsync(tenantId, client.ClientId))
            return CreateInvalidResult("Client not whitelisted");

        if (client.CompanyType == eCompanyType.Small)
            return CreateInvalidResult($"Company type is {eCompanyType.Small.DescriptionAttr()}");
            
        return new ValidationResultDto
        {
            IsValid = true,
            Client = new ClientDto
            {
                ClientId = client.ClientId,
                ClientVAT = client.ClientVAT,
                RegistrationNumber = client.RegistrationNumber,
                CompanyType = client.CompanyType.DescriptionAttr()
            }
        };
    }
    
    private ValidationResultDto CreateInvalidResult(string errorMessage)
    {
        return new ValidationResultDto { IsValid = false, ErrorMessage = errorMessage };
    }
}