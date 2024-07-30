using FinancialDocumentAPI.Shared.Dto;

namespace FinancialDocumentAPI.Domain.IRepositories;
public interface IFinancialDocumentRepository
{
    Task<FinancialDocumentDto> GetFinancialDocumentAsync(Guid tenantId, Guid documentId, string productCode);
}
