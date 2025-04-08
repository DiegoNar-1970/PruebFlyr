namespace Flyr.Domain.Entities;

public class Journey
{
    public int Id { get; set; }
    public string Origin { get; set; } = default!;
    public string Destination { get; set; } = default!;
    public double Price { get; set; }

    public List<Flight> Flights { get; set; } = new();
}