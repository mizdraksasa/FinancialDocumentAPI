using FinancialDocumentAPI.Shared.Dto;

namespace FinancialDocumentAPI.Application.Interfaces;

public interface IAnonymizeFinancialDocumentService
{
    Task<FinancialDocumentDto> AnonymizeAsync(FinancialDocumentDto document, string productCode);
}