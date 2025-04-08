namespace Flyr.Application.DTOs
{
    public class JourneyDto
    {
        public string Origin { get; set; } = default!;
        public string Destination { get; set; } = default!;
        public double Price { get; set; }
        public List<FlightDto> Flights { get; set; } = new();
    }
}