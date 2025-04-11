namespace Flyr.Domain.Entities;

public class Journey
{
    public Guid Id { get; set; }
    public string Origin { get; set; } = default!;
    public string Destination { get; set; } = default!;
    public double Price { get; set; }
    public FlightType Type { get; set; }
    public List<Flight> Flights { get; set; } = new();
}