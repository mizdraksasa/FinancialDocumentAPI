using FinancialDocumentAPI.Shared.Dto;
using FinancialDocumentAPI.Application.Interfaces;
using FinancialDocumentAPI.Common.Extensions;

namespace FinancialDocumentAPI.Application.Service;

public class AnonymizeFinancialDocumentService: IAnonymizeFinancialDocumentService
{
    public Task<FinancialDocumentDto> AnonymizeAsync(FinancialDocumentDto document, string productCode)
    {
        document.AccountNumber = HashUtility.HashString(document.AccountNumber);
        foreach (var transaction in document.Transactions)
        {
            AnonymizeTransaction(transaction);
        }
        return Task.FromResult(document);
    }
    
    private void AnonymizeTransaction(TransactionDto transaction)
    {
        transaction.TransactionId = "#####";
        transaction.Description = "#####";
    }
}
