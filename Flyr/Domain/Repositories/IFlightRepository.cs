using Flyr.Domain.Entities;

namespace Flyr.Domain.Contracts
{
    public interface IFlightRepository
    {
        Task<List<Flight>> GetAllAsync();
        Task<Flight?> GetByIdAsync(Guid id);
        Task AddAsync(Flight flight);
    }
}