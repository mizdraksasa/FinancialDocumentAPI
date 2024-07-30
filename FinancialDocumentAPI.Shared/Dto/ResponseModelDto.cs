namespace FinancialDocumentAPI.Shared.Dto;

public class ResponseModelDto
{
    public FinancialDocumentDto Data { get; set; } = new FinancialDocumentDto();
    public CompanyInfoDto Company { get; set; } = new CompanyInfoDto();
}