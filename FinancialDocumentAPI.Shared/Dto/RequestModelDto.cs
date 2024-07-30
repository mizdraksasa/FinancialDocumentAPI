namespace FinancialDocumentAPI.Shared.Dto;

public class RequestModelDto
{
    public string ProductCode { get; set; } = string.Empty;

    public Guid TenantId { get; set; }
    
    public Guid DocumentId { get; set; }
}