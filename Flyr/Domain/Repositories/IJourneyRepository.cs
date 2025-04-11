using Flyr.Domain.Entities;

namespace Flyr.Domain.Contracts
{

    public interface IJourneyRepository
    {
        Task<List<Journey>> GetAllJourneyAsync();
        Task <Journey?> GetByIdAsync(Guid id);
        Task AddAsync(Journey journey);
    }
}