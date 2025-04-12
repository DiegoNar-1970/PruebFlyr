using Flyr.Application.DTOs;
public class FlightWithTransportDto
{
    public Guid Id { get; set; }

    public string Origin { get; set; } = default!;
    public string Destination { get; set; } = default!;
    public double Price { get; set; }

    public TransportDto Transport { get; set; } = default!;
}