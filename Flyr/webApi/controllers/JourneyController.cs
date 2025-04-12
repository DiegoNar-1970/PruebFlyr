using Flyr.Application.DTOs;
using Flyr.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Flyr.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JourneyController : ControllerBase
{
    private readonly JourneyService _journeyService;

    public JourneyController(JourneyService journeyService)
    {
        _journeyService = journeyService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var journeys = await _journeyService.GetAllJourneyAsync();
        return Ok(journeys);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var journey = await _journeyService.GetByIdAsync(id);
        if (journey is null) return NotFound();
        return Ok(journey);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] JourneyDto dto)
    {
        await _journeyService.AddAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = dto.id }, dto);
    }
}
