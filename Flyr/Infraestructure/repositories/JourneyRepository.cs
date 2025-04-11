using Flyr.Domain.Entities;
using Flyr.Domain.Contracts;
using Flyr.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Flyr.Infrastructure.Repositories
{
    public class JourneyRepository : IJourneyRepository
    {
        private readonly FlyrDbContext _context;

        public JourneyRepository(FlyrDbContext context)
        {
            _context = context;
        }

        public async Task<List<Journey>> GetAllJourneyAsync()
        {
            return await _context.Journeys
                .Include(j => j.Flights)
                .ThenInclude(f => f.Transport)
                .ToListAsync();
        }

        public async Task<Journey?> GetByIdAsync(Guid id){
            return await _context.Journeys
                   .Include(f => f.Flights)
                   .ThenInclude(f => f.Transport)
                   .FirstOrDefaultAsync(j => j.Id == id);
        }

        public async Task AddAsync(Journey journey)
        {
            _context.Journeys.Add(journey);
            await _context.SaveChangesAsync();
        }
    }
}