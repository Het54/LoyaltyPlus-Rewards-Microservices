namespace TransactionHistoryAPI.Core.Models.ResponseModels;

public class TransactionResponseModel
{
    public int Id { get; set; }
    
    public int CustomerId { get; set; } 

    public int OrderId { get; set; } 

    public DateTime? TransactionDate { get; set; }

    public decimal Amount { get; set; }

    public string PaymentMethod { get; set; }

    public string Status { get; set; }
}