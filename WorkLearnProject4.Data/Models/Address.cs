using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WorkLearnProject4.Data.Models;

public class Address
{
    public Guid Id { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    [ValidateNever] 
    public Customer Customer { get; set; }
    public Guid CustomerId { get; set; }
}