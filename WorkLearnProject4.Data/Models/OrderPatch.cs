using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WorkLearnProject4.Data.Models;

public class OrderPatch
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public Guid? CustomerId { get; set; }
    [ValidateNever] 
    public Customer? Customer { get; set; }
    public DateTime? Date { get; set; }
}