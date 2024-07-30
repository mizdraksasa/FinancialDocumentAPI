using FinancialDocumentAPI.Application.Service;
using FinancialDocumentAPI.Shared.Dto;
using FinancialDocumentAPI.Common.Extensions;
using FinancialDocumentAPI.Common.Constants;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Globalization;

namespace FinancialDocumentAPI.Tests.Services;

public class AnonymizeFinancialDocumentServicesTests
{
    private AnonymizeFinancialDocumentService _useCase;

    [SetUp]
    public void Setup()
    {
        _useCase = new AnonymizeFinancialDocumentService();
    }

    [Test]
    public async Task AnonymizeAsync_ValidInput_ReturnsAnonymizedDocument()
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
                    Date = DateTime.ParseExact("1/4/2019", Constants.DateFormat, CultureInfo.InvariantCulture).ToString(Constants.DateFormat),
                    Description = "Grocery shopping",
                    Category = "Food & Dining"
                }
            }
        };
        
        var result = await _useCase.AnonymizeAsync(document, "ProductA");
        
        Assert.That(result, Is.Not.Null);
        Assert.That(result.AccountNumber, Is.EqualTo(HashUtility.HashString("95867648")));
        
        foreach (var transaction in result.Transactions)
        {
            Assert.Multiple(() =>
            {
                Assert.That(transaction.TransactionId, Is.EqualTo("#####"));
                Assert.That(transaction.Description, Is.EqualTo("#####"));
            });
        }
    }
}