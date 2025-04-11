using AutoMapper;
using Flyr.Application.DTOs;
using Flyr.Domain.Entities;
using Flyr.Domain.Contracts;

namespace Flyr.Application.Services;

public class TransportService
{
    private readonly ITransportRepository _repository;
    private readonly IMapper _mapper;

    public TransportService(ITransportRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<TransportDto>> GetAllAsync()
    {
        var transports = await _repository.GetAllAsync();
        return _mapper.Map<List<TransportDto>>(transports);
    }

    public async Task<TransportDto?> GetByIdAsync(Guid id)
    {
        var transport = await _repository.GetByIdAsync(id);
        return transport is null ? null : _mapper.Map<TransportDto>(transport);
    }

    public async Task<String> AddAsync(TransportDto dto)
    {
        var transport = _mapper.Map<Transport>(dto);
        await _repository.AddAsync(transport);
        return "Transport added successfully.";
    }
}
