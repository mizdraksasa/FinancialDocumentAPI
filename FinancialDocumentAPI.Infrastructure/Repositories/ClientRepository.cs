using FinancialDocumentAPI.Domain;
using FinancialDocumentAPI.Domain.Entities;
using FinancialDocumentAPI.Domain.IRepositories;

namespace FinancialDocumentAPI.Infrastructure.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly List<Client> _clients;

    public ClientRepository()
    {
        _clients = new List<Client>
        {
            new() {
                ClientId = TryParseGuid("a3b5c3f2-5d34-4a75-b2d9-f8b75e6d62b5"),
                TenantId = TryParseGuid("d3b7f82b-d6e4-4b8a-8b1c-799d6a8f76e3"),
                DocumentId = TryParseGuid("a3b5c3f2-5d34-4a75-b2d9-f8b75e6d62b5"),
                ClientVAT = "123456789",
                RegistrationNumber = "Reg123",
                CompanyType = eCompanyType.Medium
            },
            new() {
                ClientId = TryParseGuid("b3c5d6e2-5f67-4a89-b1c2-d3e4f5e6d7c8"),
                TenantId = TryParseGuid("11111111-1111-1111-1111-111111111111"),
                DocumentId = TryParseGuid("b3c5d6e2-5f67-4a89-b1c2-d3e4f5e6d7c8"),
                ClientVAT = "987654321",
                RegistrationNumber = "Reg456",
                CompanyType = eCompanyType.Small
            }
        };
    }

    public Task<Client?> GetClientByTenantAndDocumentAsync(Guid tenantId, Guid documentId)
    {
        var client = _clients.FirstOrDefault(c => c.TenantId == tenantId && c.DocumentId == documentId);
        return Task.FromResult(client);
    }

    public Task<bool> IsClientWhitelistedAsync(Guid tenantId, Guid clientId)
    {
        var isWhitelisted = _clients.Any(c => c.ClientId == clientId);
        return Task.FromResult(_clients.Any(c => c.ClientId == clientId));
    }

    private Guid TryParseGuid(string guidString)
    {
        if (Guid.TryParse(guidString, out var guid))
            return guid;

        throw new FormatException($"Invalid GUID format: {guidString}");
    }
}
