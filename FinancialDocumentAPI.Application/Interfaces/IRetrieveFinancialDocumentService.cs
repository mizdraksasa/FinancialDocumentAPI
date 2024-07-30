using FinancialDocumentAPI.Shared.Dto;

namespace FinancialDocumentAPI.Application.Interfaces;

public interface IRetrieveFinancialDocumentService
{
    Task<FinancialDocumentDto> RetrieveAsync(Guid tenantId, Guid documentId, string productCode);
}
