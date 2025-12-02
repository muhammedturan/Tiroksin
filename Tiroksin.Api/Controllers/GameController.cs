using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using Tiroksin.Api.Hubs;
using Tiroksin.Application.GameSessions.Commands.FinishGame;
using Tiroksin.Application.GameSessions.Commands.SubmitAnswer;
using Tiroksin.Application.GameSessions.Queries.GetGameSession;
using Tiroksin.Application.GameSessions.Queries.GetGameSessionPlayers;
using Tiroksin.Application.Rooms.Commands.StartGame;

namespace Tiroksin.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class GameController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IHubContext<GameHub> _hubContext;
    private readonly ILogger<GameController> _logger;

    public GameController(IMediator mediator, IHubContext<GameHub> hubContext, ILogger<GameController> logger)
    {
        _mediator = mediator;
        _hubContext = hubContext;
        _logger = logger;
    }

    /// <summary>
    /// Start the game (host only)
    /// </summary>
    [HttpPost("start")]
    public async Task<ActionResult<StartGameResponse>> StartGame([FromBody] StartGameRequest request)
    {
        var userId = GetUserIdFromToken();

        var command = new StartGameCommand
        {
            RoomId = request.RoomId,
            UserId = userId
        };

        var response = await _mediator.Send(command);

        if (!response.Success)
        {
            return BadRequest(response);
        }

        // Get players for the game session using Query
        var playersQuery = new GetGameSessionPlayersQuery
        {
            GameSessionId = response.GameSessionId
        };
        var gameSessionPlayers = await _mediator.Send(playersQuery);

        // Notify all players in room via SignalR that game is starting
        await _hubContext.Clients.Group(request.RoomId.ToString()).SendAsync("GameStarting", new
        {
            gameSessionId = response.GameSessionId,
            questions = response.Questions,
            players = gameSessionPlayers,
            message = "Oyun başlıyor! 🚀",
            countdown = 3
        });

        _logger.LogInformation("Game started in room: {RoomId}, notified {PlayerCount} players", request.RoomId, gameSessionPlayers.Count);

        return Ok(response);
    }

    /// <summary>
    /// Submit an answer to a question (Survival mode)
    /// </summary>
    [HttpPost("submit-answer")]
    public async Task<ActionResult<SubmitAnswerResponse>> SubmitAnswer([FromBody] SubmitAnswerRequest request)
    {
        _logger.LogDebug("SubmitAnswer endpoint hit. GameSessionId: {GameSessionId}, QuestionId: {QuestionId}", request.GameSessionId, request.QuestionId);
        var userId = GetUserIdFromToken();
        _logger.LogDebug("UserId from token: {UserId}", userId);

        var command = new SubmitAnswerCommand
        {
            GameSessionId = request.GameSessionId,
            UserId = userId,
            QuestionId = request.QuestionId,
            SelectedOptionId = request.SelectedOptionId,
            TimeSpent = request.TimeSpent
        };

        var response = await _mediator.Send(command);

        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    /// <summary>
    /// Get game session state (for recovery on refresh)
    /// </summary>
    [HttpGet("{sessionId}")]
    public async Task<ActionResult<GetGameSessionResponse>> GetGameSession(Guid sessionId)
    {
        try
        {
            var userId = GetUserIdFromToken();

            var query = new GetGameSessionQuery
            {
                SessionId = sessionId,
                UserId = userId
            };

            var response = await _mediator.Send(query);

            if (response == null)
            {
                return NotFound(new { message = "Oyun oturumu bulunamadı" });
            }

            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting game session: {SessionId}", sessionId);
            return StatusCode(500, new { message = "Oyun durumu alınırken bir hata oluştu" });
        }
    }

    /// <summary>
    /// Finish the game and get final results
    /// </summary>
    [HttpPost("finish")]
    public async Task<ActionResult<FinishGameResponse>> FinishGame([FromBody] FinishGameRequest request)
    {
        try
        {
            var command = new FinishGameCommand
            {
                GameSessionId = request.GameSessionId
            };

            var response = await _mediator.Send(command);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            // Notify all players via SignalR about game end
            await _hubContext.Clients.Group(request.RoomId.ToString()).SendAsync("GameFinished", new
            {
                results = response.Results,
                allPlayersAnswers = response.AllPlayersAnswers,
                message = response.Message
            });

            _logger.LogInformation("Game finished: {GameSessionId}", request.GameSessionId);

            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error finishing game: {GameSessionId}", request.GameSessionId);
            return StatusCode(500, new { message = "Oyun sonlandırılırken bir hata oluştu" });
        }
    }

    private Guid GetUserIdFromToken()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userIdClaim))
        {
            throw new UnauthorizedAccessException("Token'da kullanıcı bilgisi bulunamadı");
        }
        return Guid.Parse(userIdClaim);
    }
}

// DTOs (Request only - Response DTOs are in Application layer)
public record StartGameRequest
{
    public Guid RoomId { get; init; }
}

public record SubmitAnswerRequest
{
    public Guid GameSessionId { get; init; }
    public Guid QuestionId { get; init; }
    public Guid? SelectedOptionId { get; init; }
    public int TimeSpent { get; init; }
}

public record FinishGameRequest
{
    public Guid GameSessionId { get; init; }
    public Guid RoomId { get; init; }
}
