namespace Flyr.Domain.Entities;

public class Flight
{
    public Guid Id { get; set; }

    public string Origin { get; set; } = default!;
    public string Destination { get; set; } = default!;
    public double Price { get; set; }


    public Guid TransportId { get; set; } // FK
    public Transport Transport { get; set; } = default!;

}