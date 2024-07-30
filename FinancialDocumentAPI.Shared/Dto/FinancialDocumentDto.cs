using System.Text.Json.Serialization;

namespace FinancialDocumentAPI.Shared.Dto;

public class FinancialDocumentDto
{
    [JsonPropertyName("account_number")]
    public string AccountNumber { get; set; } = string.Empty;

    [JsonPropertyName("balance")]
    public decimal Balance { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; } = string.Empty;
    
    [JsonPropertyName("transactions")]
    public List<TransactionDto> Transactions { get; set; } = new List<TransactionDto>();
}
