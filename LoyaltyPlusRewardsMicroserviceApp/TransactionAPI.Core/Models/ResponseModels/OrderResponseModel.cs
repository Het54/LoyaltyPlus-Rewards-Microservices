namespace TransactionHistoryAPI.Core.Models.ResponseModels;

public class OrderResponseModel
{
    public int Id { get; set; } 
    
    public int CustomerID { get; set; }  

    public DateTime OrderDate { get; set; }

    public decimal TotalAmount { get; set; }

    public string? ShippingAddress { get; set; }

    public string? OrderStatus { get; set; }
}