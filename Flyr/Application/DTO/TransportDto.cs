namespace Flyr.Application.DTOs
{
    public class TransportDto
    {
        public Guid Id { get; set; }
        public string FlightCarrier { get; set; } = default!;
        public string FlightNumber { get; set; } = default!;
    }
}