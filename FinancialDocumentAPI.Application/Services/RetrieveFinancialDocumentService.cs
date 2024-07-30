using FinancialDocumentAPI.Shared.Dto;
using FinancialDocumentAPI.Application.Interfaces;
using FinancialDocumentAPI.Domain.IRepositories;

namespace FinancialDocumentAPI.Application.Service;

public class RetrieveFinancialDocumentService : IRetrieveFinancialDocumentService
{
    private readonly IFinancialDocumentRepository _financialDocumentRepository;

    public RetrieveFinancialDocumentService(IFinancialDocumentRepository financialDocumentRepository)
    {
        _financialDocumentRepository = financialDocumentRepository;
    }
    
    public async Task<FinancialDocumentDto> RetrieveAsync(Guid tenantId, Guid documentId, string productCode)
    {
        var document = await _financialDocumentRepository.GetFinancialDocumentAsync(tenantId, documentId, productCode);
        
        return new FinancialDocumentDto
        {
            AccountNumber = document.AccountNumber,
            Balance = document.Balance,
            Currency = document.Currency,
            Transactions = document.Transactions.ConvertAll(t => new TransactionDto
            {
                TransactionId = t.TransactionId,
                Amount = t.Amount,
                Date = t.Date,
                Description = t.Description,
                Category = t.Category
            })
        };
    }
}