namespace WorkLearnProject4.Data.Models;

public class Order
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Customer Customer { get; set; }
    public DateTime Date { get; set; }
}