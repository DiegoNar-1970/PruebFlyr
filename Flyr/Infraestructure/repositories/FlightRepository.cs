using Flyr.Domain.Entities;
using Flyr.Domain.Contracts;
using Flyr.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Flyr.Infrastructure.Repositories;

public class FlightRepository : IFlightRepository
{
    private readonly FlyrDbContext _context;

    public FlightRepository(FlyrDbContext context)
    {
        _context = context;
    }

    public async Task<List<Flight>> GetAllAsync()
    {
        return await _context.Flights
            .Include(f => f.Transport)
            .ToListAsync();
    }

    public async Task<Flight?> GetByIdAsync(Guid id)
    {
        return await _context.Flights
            .Include(f => f.Transport)
            .FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task AddAsync(Flight flight)
    {
        _context.Flights.Add(flight);
        await _context.SaveChangesAsync();
    }
}
