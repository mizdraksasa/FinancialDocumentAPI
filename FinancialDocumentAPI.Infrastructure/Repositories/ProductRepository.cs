using FinancialDocumentAPI.Domain.IRepositories;

namespace FinancialDocumentAPI.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly List<string> _supportedProducts = new List<string> { "ProductA", "ProductB" };
    
    public Task<bool> IsProductSupportedAsync(string productCode)
    {
        return Task.FromResult(_supportedProducts.Contains(productCode));
    }
}
