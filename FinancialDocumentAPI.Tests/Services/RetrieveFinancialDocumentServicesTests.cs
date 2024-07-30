using AutoMapper;
using FinancialDocumentAPI.DependencyRegister.Mappings;
using FinancialDocumentAPI.Application.Service;
using FinancialDocumentAPI.Domain.IRepositories;
using FinancialDocumentAPI.Shared.Dto;
using System.Globalization;
using FinancialDocumentAPI.Common.Constants;
using Moq;
using NUnit.Framework;

namespace FinancialDocumentAPI.Tests.Services;
    
public class RetrieveFinancialDocumentServicesTests
{
    private Mock<IFinancialDocumentRepository> _mockFinancialDocumentRepository;
    private IMapper _mapper;
    private RetrieveFinancialDocumentService _useCase;
    [SetUp]
    public void Setup()
    {
        _mockFinancialDocumentRepository = new Mock<IFinancialDocumentRepository>();
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ApplicationMappingProfile>();
        });
        _mapper = config.CreateMapper();
        _useCase = new RetrieveFinancialDocumentService(_mockFinancialDocumentRepository.Object, _mapper);
    }
    [Test]
    public async Task RetrieveAsync_ValidInput_ReturnsDocument()
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
        _mockFinancialDocumentRepository.Setup(x => x.GetFinancialDocumentAsync(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<string>()))
            .ReturnsAsync(document);
        var result = await _useCase.RetrieveAsync(Guid.NewGuid(), Guid.NewGuid(), "ValidProduct");
        Assert.IsNotNull(result);
        Assert.AreEqual("95867648", result.AccountNumber);
    }
}