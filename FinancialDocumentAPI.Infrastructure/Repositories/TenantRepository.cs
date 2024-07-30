using FinancialDocumentAPI.Domain.IRepositories;

namespace FinancialDocumentAPI.Infrastructure.Repositories;

public class TenantRepository : ITenantRepository
{
    private readonly List<Guid> _whitelistedTenants = new List<Guid>
    {
        TryParseGuid("d3b7f82b-d6e4-4b8a-8b1c-799d6a8f76e3"),
        TryParseGuid("11111111-1111-1111-1111-111111111111")
    };

    public Task<bool> IsTenantWhitelistedAsync(Guid tenantId)
    {
        return Task.FromResult(_whitelistedTenants.Contains(tenantId));
    }

    private static Guid TryParseGuid(string guidString)
    {
        if (Guid.TryParse(guidString, out var guid))
        {
            return guid;
        }
        throw new FormatException($"Invalid GUID format: {guidString}");
    }
}
