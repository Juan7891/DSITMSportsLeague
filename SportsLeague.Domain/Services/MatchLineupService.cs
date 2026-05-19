using Microsoft.Extensions.Logging;
using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Enums;
using SportsLeague.Domain.Interfaces.Repositories;
using SportsLeague.Domain.Interfaces.Services;

namespace SportsLeague.Domain.Services;

public class MatchLineupService : IMatchLineupService
{
    private readonly IMatchLineupRepository _matchLineupRepository;
    private readonly IMatchRepository _matchRepository;
    private readonly IPlayerRepository _playerRepository;
    private readonly ILogger<MatchLineupService> _logger;

    public MatchLineupService(
       IMatchLineupRepository matchLineupRepository,
       IMatchRepository matchRepository,
       IPlayerRepository playerRepository,
       ILogger<MatchLineupService> logger)
    {
        _matchLineupRepository = matchLineupRepository;
        _matchRepository = matchRepository;
        _playerRepository = playerRepository;
        _logger = logger;
    }
    public async Task<MatchLineup> AddPlayerToLineupAsync(
          int matchId, MatchLineup matchLineup)
    {
        _logger.LogInformation(
             "Intentando agregar jugador {PlayerId} al partido {MatchId}",
              matchLineup.PlayerId, matchId);
        var match = await _matchRepository.GetByIdAsync(matchId);
        if (match == null)
        {
            throw new KeyNotFoundException(
                  "No se encontró el partido con ID {matchId}");
        }
        if (match.Status != MatchStatus.Scheduled)
        {
            throw new InvalidOperationException(
               "Solo se pueden registrar alineaciones en partidos Scheduled");
        }
        var player = await _playerRepository.GetByIdAsync(matchLineup.PlayerId);
        if (player == null)
        {
            throw new KeyNotFoundException(
               "No se encontró el jugador con ID {matchLineup.PlayerId}");
        }
        if (player.TeamId != match.HomeTeamId && player.TeamId != match.AwayTeamId)
        {
            throw new InvalidOperationException(
                 "El jugador no pertenece a ninguno de los equipos del partido");
        }
        var alreadyExists = await _matchLineupRepository
            .ExistsByMatchAndPlayerAsync(matchId, matchLineup.PlayerId);
        if (alreadyExists)
        {
            throw new InvalidOperationException(
                "El jugador ya está registrado en la alineación de este partido");
        }
        if (matchLineup.IsStarter)
        {
            var starterCount = await _matchLineupRepository
                .CountStartersByMatchAndTeamAsync(matchId, player.TeamId);
            if (starterCount >= 11)
            {
                throw new InvalidOperationException(
                   "El equipo ya tiene 11 titulares registrados en este partido");
            }
        }
        matchLineup.MatchId = matchId;
        await _matchLineupRepository.CreateAsync(matchLineup);
        _logger.LogInformation(
               "Jugador {PlayerId} agregado como {Role} al partido {MatchId}",
               matchLineup.PlayerId,
               matchLineup.IsStarter ? "titular" : "suplente",
               matchId);
        return matchLineup;
    }
    public async Task<IEnumerable<MatchLineup>> GetLineupByMatchAsync(int matchId)
    {
        var match = await _matchRepository.GetByIdAsync(matchId);
        if (match == null)
            throw new KeyNotFoundException(
                 "No se encontró el partido con ID {matchId}");
        return await _matchLineupRepository.GetByMatchAsync(matchId);
    }
    public async Task<IEnumerable<MatchLineup>> GetLineupByMatchAndTeamAsync(
       int matchId, int teamId)
    {
        var match = await _matchRepository.GetByIdAsync(matchId);
        if (match == null)
            throw new KeyNotFoundException(
               "No se encontró el partido con ID {matchId}");
        return await _matchLineupRepository.GetByMatchAndTeamAsync(matchId, teamId);
    }
    public async Task DeleteLineupEntryAsync(int matchId, int id)
    {
        var lineup = await _matchLineupRepository.GetByIdAsync(id);
        if (lineup == null || lineup.MatchId != matchId)
            throw new KeyNotFoundException(
                "No se encontró el registro de alineación con ID {id} " +
                "en el partido {matchId}");
        await _matchLineupRepository.DeleteAsync(id);
        _logger.LogInformation(
                  "Alineación {Id} eliminada del partido {MatchId}", id, matchId);
    }
}

