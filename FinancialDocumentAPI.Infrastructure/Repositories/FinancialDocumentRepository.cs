using FinancialDocumentAPI.Shared.Dto;
using FinancialDocumentAPI.Domain.IRepositories;
using System.Globalization;
using FinancialDocumentAPI.Common.Constants;

namespace FinancialDocumentAPI.Infrastructure.Repositories;

public class FinancialDocumentRepository : IFinancialDocumentRepository
{
    public Task<FinancialDocumentDto> GetFinancialDocumentAsync(Guid tenantId, Guid documentId, string productCode)
    {
        var document = new FinancialDocumentDto
        {
            AccountNumber = "95867648",
            Balance = 42331.12M,
            Currency = "EUR",
            Transactions = new List<TransactionDto>
            {
                new() {
                    TransactionId = "2913",
                    Amount = 166.95M,
                    Date = FormatDate("1/4/2015"),
                    Description = "Grocery shopping",
                    Category = "Food & Dining"
                },
                new() {
                    TransactionId = "3882",
                    Amount = 6.58M,
                    Date = FormatDate("24/4/2016"),
                    Description = "Grocery shopping",
                    Category = "Food & Dining"
                },
                new() {
                    TransactionId = "1143",
                    Amount = -241.07M,
                    Date = FormatDate("25/12/2019"),
                    Description = "Gas station purchase",
                    Category = "Utilities"
                }
            }
        };
        
        return Task.FromResult(document);
    }

    private string FormatDate(string date)
    {
        return DateTime.ParseExact(date, Constants.DateFormat, CultureInfo.InvariantCulture).ToString(Constants.DateFormat);
    }
}
