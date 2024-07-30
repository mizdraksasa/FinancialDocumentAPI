namespace FinancialDocumentAPI.Domain.Entities;

public class Transaction
{
    public string TransactionId { get; set; } = string.Empty;

    public decimal Amount { get; set; }

    public string Date { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    
    public string Category { get; set; } = string.Empty;
}
