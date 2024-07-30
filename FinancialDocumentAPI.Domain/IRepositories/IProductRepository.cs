namespace FinancialDocumentAPI.Domain.IRepositories;

public interface IProductRepository
{
    Task<bool> IsProductSupportedAsync(string productCode);
}
