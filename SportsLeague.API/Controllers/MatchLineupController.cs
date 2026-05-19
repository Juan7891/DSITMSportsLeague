using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SportsLeague.API.DTOs.Request;
using SportsLeague.API.DTOs.Response;
using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Interfaces.Services;

namespace SportsLeague.API.Controllers;

[ApiController]
[Route("api/match/{matchId}/lineup")]
public class MatchLineupController : ControllerBase
{
    private readonly IMatchLineupService _matchLineupService;
    private readonly IMapper _mapper;
    public MatchLineupController(
          IMatchLineupService matchLineupService,
          IMapper mapper)
    {
        _matchLineupService = matchLineupService;
        _mapper = mapper;
    }
    [HttpPost]
    public async Task<ActionResult<MatchLineupResponseDTO>> AddPlayerToLineup(
         int matchId,
         [FromBody] MatchLineupRequestDTO dto)
    {
        try
        {
            var matchLineup = _mapper.Map<MatchLineup>(dto);
            var created = await _matchLineupService
                 .AddPlayerToLineupAsync(matchId, matchLineup);
            var lineups = await _matchLineupService.GetLineupByMatchAsync(matchId);
            var createdWithDetails = lineups
                   .FirstOrDefault(ml => ml.PlayerId == dto.PlayerId);
            var responseDto = _mapper.Map<MatchLineupResponseDTO>(createdWithDetails);
            return CreatedAtAction(
                 nameof(GetLineupByMatch),
                 new { matchId },
            responseDto);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MatchLineupResponseDTO>>> GetLineupByMatch(
    int matchId)
    {
        try
        {
            var lineups = await _matchLineupService.GetLineupByMatchAsync(matchId);
            return Ok(_mapper.Map<IEnumerable<MatchLineupResponseDTO>>(lineups));
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
    [HttpGet("team/{teamId}")]
    public async Task<ActionResult<IEnumerable<MatchLineupResponseDTO>>> GetLineupByTeam(
    int matchId, int teamId)
    {
        try
        {
            var lineups = await _matchLineupService
                 .GetLineupByMatchAndTeamAsync(matchId, teamId);
            return Ok(_mapper.Map<IEnumerable<MatchLineupResponseDTO>>(lineups));
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLineupEntry(int matchId, int id)
    {
        try
        {
            await _matchLineupService.DeleteLineupEntryAsync(matchId, id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}

