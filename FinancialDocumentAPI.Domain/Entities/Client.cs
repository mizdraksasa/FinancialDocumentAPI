namespace FinancialDocumentAPI.Domain.Entities;

public class Client
{
    public Guid ClientId { get; set; }

    public Guid TenantId { get; set; }

    public Guid DocumentId { get; set; }

    public string ClientVAT { get; set; } = string.Empty;

    public string RegistrationNumber { get; set; } = string.Empty;
    
    public eCompanyType CompanyType { get; set; }
}
