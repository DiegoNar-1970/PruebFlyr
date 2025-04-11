using Flyr.Infrastructure.Data;
using AutoMapper;
using Flyr.Application.DTOs;
using Flyr.Domain.Entities;
using System.Text.Json;

namespace Flyr.Infrastructure.Persistence;
public class JsonDataSeeder
{
    private readonly FlyrDbContext _context;
    private readonly IMapper _mapper;

    public JsonDataSeeder(FlyrDbContext context, IMapper mapper)
    {
        //we inject the dependencies
        _context = context;
        _mapper = mapper;
    }

    public async Task SeedAsync(string jsonFilePath)
    {
        // // We check if the entity in the database is empty.
        if (_context.Transports.Any())
            return;

        //convert to json and deserialize to convert it into FlightWithTransportDto
        var jsonData = await File.ReadAllTextAsync(jsonFilePath);
        var flightDtos = JsonSerializer.Deserialize<List<FlightWithTransportDto>>(jsonData);

        if (flightDtos == null) return;

        
        var transports = flightDtos
            .Select(f => f.Transport) //sselect the Transports
            .DistinctBy(t => new { t.FlightCarrier, t.FlightNumber }) //Filter the transports and eliminate the duplicates
            .ToList(); //transforms them into a transport list
        
        Console.WriteLine(transports ); 

        //transforms transport into entity 
        var transportEntities = _mapper.Map<List<Transport>>(transports);
        await _context.Transports.AddRangeAsync(transportEntities);
        await _context.SaveChangesAsync();

        // Asignar los transportes a los vuelos
        var flights = new List<Flight>();
        foreach (var flightDto in flightDtos)
        {
            var matchingTransport = transportEntities
                .First(t => t.FlightCarrier == flightDto.Transport.FlightCarrier
                         && t.FlightNumber == flightDto.Transport.FlightNumber);

            var flight = _mapper.Map<Flight>(flightDto);
            flight.TransportId = matchingTransport.Id;

            flights.Add(flight);
        }

        await _context.Flights.AddRangeAsync(flights);
        await _context.SaveChangesAsync();
    }
}
