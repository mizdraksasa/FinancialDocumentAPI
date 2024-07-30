namespace FinancialDocumentAPI.Shared.Dto;

public class ValidationResultDto
{
    public bool IsValid { get; set; }
    public string ErrorMessage { get; set; } = string.Empty;
    public ClientDto Client { get; set; } = new ClientDto();
}
