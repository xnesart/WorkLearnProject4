namespace WorkLearnProject4.Data.Models;

public class CurrentWeather
{
    public Guid Id { get; set; }
    public string Status { get; set; }
    public double Temp { get; set; }
    public double MinTemp { get; set; }
    public double MaxTemp { get; set; }
    public DateTime Date { get; set; }
}