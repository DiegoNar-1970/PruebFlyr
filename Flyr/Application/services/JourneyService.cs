using AutoMapper;
using Flyr.Application.DTOs;
using Flyr.Domain.Entities;
using Flyr.Domain.Contracts;

namespace Flyr.Application.Services;

public class JourneyService
{
    private readonly IJourneyRepository _repository;
    private readonly IMapper _mapper;

    public JourneyService(IJourneyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<JourneyDto>> GetAllJourneyAsync()
    {
        var journeys = await _repository.GetAllJourneyAsync();
        return _mapper.Map<List<JourneyDto>>(journeys);
    }

    public async Task<JourneyDto?> GetByIdAsync(Guid id)
    {
        var journey = await _repository.GetByIdAsync(id);
        return journey is null ? null : _mapper.Map<JourneyDto>(journey);
    }

    public async Task AddAsync(JourneyDto dto)
    {
        var journey = _mapper.Map<Journey>(dto);
        await _repository.AddAsync (journey);
    }
}
