using FinancialDocumentAPI.Shared.Dto;
using FinancialDocumentAPI.Application.Interfaces;

namespace FinancialDocumentAPI.Application.Service;

public class AnonymizeFinancialDocumentService: IAnonymizeFinancialDocumentService
{
    public Task<FinancialDocumentDto> AnonymizeAsync(FinancialDocumentDto document, string productCode)
    {
        document.AccountNumber = "d3sg4sxos23zxvhads";
        foreach (var transaction in document.Transactions)
        {
            transaction.TransactionId = "#####";
            transaction.Description = "#####";
        }
        return Task.FromResult(document);
    }
}
