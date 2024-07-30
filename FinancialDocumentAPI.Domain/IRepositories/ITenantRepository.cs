namespace FinancialDocumentAPI.Domain.IRepositories;

public interface ITenantRepository
{
    Task<bool> IsTenantWhitelistedAsync(Guid tenantId);
}