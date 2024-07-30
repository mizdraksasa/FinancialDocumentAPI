namespace FinancialDocumentAPI.Shared.Dto;

public class ClientDto
{
    public Guid ClientId { get; set; }

    public string ClientVAT { get; set; } = string.Empty;

    public string RegistrationNumber { get; set; } = string.Empty;
    
    public string CompanyType { get; set; } = string.Empty;
}
