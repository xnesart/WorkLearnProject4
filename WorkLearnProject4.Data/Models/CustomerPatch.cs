namespace WorkLearnProject4.Data.Models;

public class CustomerPatch
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public DateTime? BirthDate { get; set; }
}