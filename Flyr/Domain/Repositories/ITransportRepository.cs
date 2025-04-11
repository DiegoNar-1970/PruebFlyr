using Flyr.Domain.Entities;

namespace Flyr.Domain.Contracts;

public interface ITransportRepository
{
    Task<List<Transport>> GetAllAsync();
    Task<Transport?> GetByIdAsync(Guid id);
    Task AddAsync(Transport transport);
}