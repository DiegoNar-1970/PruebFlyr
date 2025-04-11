using Flyr.Domain.Entities;
using Flyr.Domain.Contracts;
using Flyr.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Flyr.Infrastructure.Repositories;

public class TransportRepository : ITransportRepository
{
    private readonly FlyrDbContext _context;

    public TransportRepository(FlyrDbContext context)
    {
        _context = context;
    }

    public async Task<List<Transport>> GetAllAsync()
    {
        return await _context.Transports.ToListAsync();
    }

    public async Task<Transport?> GetByIdAsync(Guid id)
    {
        return await _context.Transports.FindAsync(id);
    }

    public async Task AddAsync(Transport transport)
    {
        _context.Transports.Add(transport);
        await _context.SaveChangesAsync();
    }
}
