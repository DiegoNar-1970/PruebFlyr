namespace Flyr.Application.DTOs
{
    public class FlightDto
    {
        public string Origin { get; set; } = default!;
        public string Destination { get; set; } = default!;
        public double Price { get; set; }
        public int TransportId { get; set; }
        public TransportDto? Transport { get; set; } = default!;
    }
}