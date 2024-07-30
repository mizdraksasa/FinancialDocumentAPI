using FinancialDocumentAPI.Shared.Dto;

namespace FinancialDocumentAPI.Application.Interfaces;

public interface IValidateRequestService
{
    Task<ValidationResultDto> ValidateAsync(string productCode, Guid tenantId, Guid documentId);
}
