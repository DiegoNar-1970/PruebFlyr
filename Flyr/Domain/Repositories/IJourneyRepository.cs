using Flyr.Domain.Entities;

namespace Flyr.Domain.Repositories
{

    public interface IJourneyRepository
    {
        Task<List<Journey>> GetAllJourneyAsync();
        Task AddRangeAsync(List<Journey>journeys);
        
    }
}