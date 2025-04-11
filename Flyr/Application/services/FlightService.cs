using AutoMapper;
using Flyr.Application.DTOs;
using Flyr.Domain.Entities;
using Flyr.Domain.Contracts;

namespace Flyr.Application.Services;

public class FlightService
{
    private readonly IFlightRepository _repository;
    private readonly IMapper _mapper;

    public FlightService(IFlightRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<FlightDto>> GetAllAsync()
    {
        var Transports  = await _repository.GetAllAsync();
        return _mapper.Map<List<FlightDto>>(Transports);
    }

    public async Task<FlightDto?> GetByIdAsync(Guid id)
    {
        var Transport = await _repository.GetByIdAsync(id);
        return Transport is null ? null : _mapper.Map<FlightDto>(Transport);
    }

    public async Task AddAsync(FlightDto dto)
    {
        var Transport = _mapper.Map<Flight>(dto);
        await _repository.AddAsync(Transport);
    }
}
