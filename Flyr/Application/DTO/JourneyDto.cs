namespace Flyr.Application.DTOs
{
    public class JourneyDto
    {
        public Guid id { get; set; }
        public string Origin { get; set; } = default!;
        public string Destination { get; set; } = default!;
        public double Price { get; set; }
        public string Type { get; set; } = default!;
        public List<FlightDto> Flights { get; set; } = new();
    }
}