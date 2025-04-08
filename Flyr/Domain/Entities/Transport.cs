namespace Flyr.Domain.Entities;

public class Transport
{
    public Guid Id { get; set;}
    public string FlightCarrier { get; set; } = default!;
    public string FlightNumber { get; set; } = default!;
}