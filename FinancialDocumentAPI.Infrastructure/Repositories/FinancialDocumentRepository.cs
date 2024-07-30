using FinancialDocumentAPI.Shared.Dto;
using FinancialDocumentAPI.Domain.IRepositories;
using FinancialDocumentAPI.Domain.Entities;
using AutoMapper;
using System.Globalization;
using FinancialDocumentAPI.Common.Constants;

namespace FinancialDocumentAPI.Infrastructure.Repositories;

public class FinancialDocumentRepository : IFinancialDocumentRepository
{
    private readonly IMapper _mapper;
    public FinancialDocumentRepository(IMapper mapper)
    {
        _mapper = mapper;
    }
    public async Task<FinancialDocumentDto> GetFinancialDocumentAsync(Guid tenantId, Guid documentId, string productCode)
    {
        var document = new FinancialDocument
        {
            AccountNumber = "95867648",
            Balance = 42331.12M,
            Currency = "EUR",
            Transactions = new List<Transaction>
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
        var documentDto = _mapper.Map<FinancialDocumentDto>(document);
        return await Task.FromResult(documentDto);
    }
    private string FormatDate(string date)
    {
        return DateTime.ParseExact(date, Constants.DateFormat, CultureInfo.InvariantCulture).ToString(Constants.DateFormat);
    }
}