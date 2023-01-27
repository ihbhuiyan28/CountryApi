namespace CountryApi.Models;

public class Country
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Capital { get; set; }
    public string? Region { get; set; }
    public double Area { get; set; }
    public long Population { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
}
