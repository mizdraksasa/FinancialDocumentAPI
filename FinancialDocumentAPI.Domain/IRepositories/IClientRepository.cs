using FinancialDocumentAPI.Domain.Entities;

namespace FinancialDocumentAPI.Domain.IRepositories;

public interface IClientRepository
{
    Task<Client?> GetClientByTenantAndDocumentAsync(Guid tenantId, Guid documentId);
    
    Task<bool> IsClientWhitelistedAsync(Guid clientId);
}
