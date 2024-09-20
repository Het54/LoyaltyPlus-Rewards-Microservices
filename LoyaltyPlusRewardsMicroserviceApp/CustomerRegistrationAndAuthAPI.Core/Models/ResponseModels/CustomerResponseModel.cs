namespace CustomerRegistrationAndAuthAPI.Core.Models.ResponseModels;

public class CustomerResponseModel
{
    public int Id { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    public DateTime? DateOfBirth { get; set; }
    
    public string? AddressLine1 { get; set; }
    
    public string? AddressLine2 { get; set; }
    
    public string? City { get; set; }
    
    public string? State { get; set; }
    
    public int ZipCode { get; set; }
    
    public string? Country { get; set; }
   
    public string PreferredStore { get; set; }
    
    public string? PhoneNumber { get; set; }
    
    public string? MobileNumber { get; set; }
}