using Moq;
using FinancialDocumentAPI.Application.Service;
using FinancialDocumentAPI.Domain.IRepositories;
using FinancialDocumentAPI.Domain.Entities;
using FinancialDocumentAPI.Domain;
using FinancialDocumentAPI.Common.Extensions;

namespace FinancialDocumentAPI.Tests.Services;

public class ValidateRequestServiceTests
{
    private Mock<IProductRepository> _mockProductRepository;
    private Mock<ITenantRepository> _mockTenantRepository;
    private Mock<IClientRepository> _mockClientRepository; 
    private ValidateRequestService _service;

    [SetUp]
    public void Setup()
    {
        _mockProductRepository = new Mock<IProductRepository>();
        _mockTenantRepository = new Mock<ITenantRepository>();
        _mockClientRepository = new Mock<IClientRepository>();
        _service = new ValidateRequestService(_mockProductRepository.Object, _mockTenantRepository.Object, _mockClientRepository.Object);
    }

    [Test]
    public async Task ValidateAsync_InvalidProduct_ReturnsFalse()
    {
        _mockProductRepository.Setup(x => x.IsProductSupportedAsync(It.IsAny<string>())).ReturnsAsync(false);
        var result = await _service.ValidateAsync("InvalidProduct", Guid.NewGuid(), Guid.NewGuid());
        Assert.IsFalse(result.IsValid);
        Assert.AreEqual("Product not supported", result.ErrorMessage);
    }

    [Test]
    public async Task ValidateAsync_ValidProductAndTenant_ReturnsTrue()
    {
        _mockProductRepository.Setup(x => x.IsProductSupportedAsync(It.IsAny<string>())).ReturnsAsync(true);
        _mockTenantRepository.Setup(x => x.IsTenantWhitelistedAsync(It.IsAny<Guid>())).ReturnsAsync(true);
        _mockClientRepository.Setup(x => x.GetClientByTenantAndDocumentAsync(It.IsAny<Guid>(), It.IsAny<Guid>()))
            .ReturnsAsync(new Client { ClientId = Guid.NewGuid(), RegistrationNumber = "Reg123", CompanyType = eCompanyType.Medium });
        _mockClientRepository.Setup(x => x.IsClientWhitelistedAsync(It.IsAny<Guid>(), It.IsAny<Guid>())).ReturnsAsync(true);
        var result = await _service.ValidateAsync("ValidProduct", Guid.NewGuid(), Guid.NewGuid());
        Assert.IsTrue(result.IsValid);
        Assert.AreEqual(string.Empty, result.ErrorMessage);
    }
    
    [Test]
    public async Task ValidateAsync_SmallCompany_ReturnsFalse()
    {
        _mockProductRepository.Setup(x => x.IsProductSupportedAsync(It.IsAny<string>())).ReturnsAsync(true);
        _mockTenantRepository.Setup(x => x.IsTenantWhitelistedAsync(It.IsAny<Guid>())).ReturnsAsync(true);
        _mockClientRepository.Setup(x => x.GetClientByTenantAndDocumentAsync(It.IsAny<Guid>(), It.IsAny<Guid>()))
            .ReturnsAsync(new Client { ClientId = Guid.NewGuid(), RegistrationNumber = "Reg456", CompanyType = eCompanyType.Small });
        _mockClientRepository.Setup(x => x.IsClientWhitelistedAsync(It.IsAny<Guid>(), It.IsAny<Guid>())).ReturnsAsync(true);
        var result = await _service.ValidateAsync("ValidProduct", Guid.NewGuid(), Guid.NewGuid());
        Assert.IsFalse(result.IsValid);
        Assert.AreEqual($"Company type is {eCompanyType.Small.DescriptionAttr()}", result.ErrorMessage);
    }
}