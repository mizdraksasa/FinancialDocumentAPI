namespace FinancialDocumentAPI.Domain.Entities;

public class FinancialDocument
{
    public string AccountNumber { get; set; } = string.Empty;

    public decimal Balance { get; set; }

    public string Currency { get; set; } = string.Empty;
    
    public List<Transaction> Transactions { get; set; } = new List<Transaction>();
}
