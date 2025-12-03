using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiroksin.Application.Common.DTOs;
using Tiroksin.Application.Common.Interfaces;
using Tiroksin.Domain.Enums;

namespace Tiroksin.Application.GameSessions.Queries.GetGameSession;

public class GetGameSessionQueryHandler : IRequestHandler<GetGameSessionQuery, GetGameSessionResponse?>
{
    private readonly IApplicationDbContext _context;

    public GetGameSessionQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<GetGameSessionResponse?> Handle(GetGameSessionQuery request, CancellationToken cancellationToken)
    {
        // Get game session with players
        var gameSession = await _context.GameSessions
            .Include(gs => gs.Players)
                .ThenInclude(p => p.User)
            .Include(gs => gs.Answers)
            .FirstOrDefaultAsync(gs => gs.Id == request.SessionId, cancellationToken);

        if (gameSession == null)
        {
            return null;
        }

        // Get question IDs from game answers (questions that have been asked in this session)
        var questionIds = await _context.GameAnswers
            .Where(a => a.GameSessionId == request.SessionId)
            .Select(a => a.QuestionId)
            .Distinct()
            .ToListAsync(cancellationToken);

        // Also include current question if not in answers yet
        if (gameSession.CurrentQuestionId.HasValue && !questionIds.Contains(gameSession.CurrentQuestionId.Value))
        {
            questionIds.Add(gameSession.CurrentQuestionId.Value);
        }

        // Fetch questions with their options
        var questions = await _context.Questions
            .Include(q => q.Options)
            .Where(q => questionIds.Contains(q.Id))
            .ToListAsync(cancellationToken);

        // Order questions by when they were first asked
        var questionOrder = await _context.GameAnswers
            .Where(a => a.GameSessionId == request.SessionId)
            .GroupBy(a => a.QuestionId)
            .Select(g => new { QuestionId = g.Key, FirstAsked = g.Min(a => a.AnsweredAt) })
            .OrderBy(g => g.FirstAsked)
            .Select(g => g.QuestionId)
            .ToListAsync(cancellationToken);

        // If no answers yet but we have a current question, add it
        if (questionOrder.Count == 0 && gameSession.CurrentQuestionId.HasValue)
        {
            questionOrder.Add(gameSession.CurrentQuestionId.Value);
        }
        // If current question is not in order yet, add it at the end
        else if (gameSession.CurrentQuestionId.HasValue && !questionOrder.Contains(gameSession.CurrentQuestionId.Value))
        {
            questionOrder.Add(gameSession.CurrentQuestionId.Value);
        }

        var orderedQuestions = questionOrder
            .Select(id => questions.FirstOrDefault(q => q.Id == id))
            .Where(q => q != null)
            .ToList();

        // Get current scoreboard with isEliminated status
        var scoreboard = gameSession.Players
            .OrderByDescending(p => p.Score)
            .Select((p, index) => new PlayerScoreDto
            {
                UserId = p.UserId.ToString(),
                Username = p.User?.Username ?? "Unknown",
                Avatar = p.User?.Avatar ?? "👤",
                Score = p.Score,
                Rank = index + 1,
                IsEliminated = p.IsEliminated
            })
            .ToList();

        // Get list of eliminated players (in elimination mode)
        var finishedPlayerIds = gameSession.Players
            .Where(p => p.IsEliminated)
            .Select(p => p.UserId.ToString())
            .ToList();

        // Map questions with options (preserving the option keys from game start)
        var questionsDto = orderedQuestions.Select(q => new QuestionDto
        {
            Id = q!.Id.ToString(),
            Text = q.Text,
            ImageUrl = q.ImageUrl,
            OptionsLayout = q.OptionsLayout.ToString(),
            Options = q.Options
                .OrderBy(o => o.OptionKey)
                .Select(opt => new OptionDto
                {
                    Id = opt.Id.ToString(),
                    Text = opt.Text,
                    ImageUrl = opt.ImageUrl,
                    OptionKey = opt.OptionKey,
                    IsCorrect = opt.IsCorrect
                }).ToList()
        }).ToList();

        // Get user's answers for this session
        var userAnswers = gameSession.Answers
            .Where(a => a.UserId == request.UserId)
            .ToDictionary(a => a.QuestionId.ToString(), a => a.SelectedOptionId?.ToString());

        // Get all players' answers for review
        var allPlayersAnswers = gameSession.Answers
            .GroupBy(a => a.QuestionId.ToString())
            .ToDictionary(
                g => g.Key,
                g => g.Select(a => new GamePlayerAnswerDto
                {
                    UserId = a.UserId.ToString(),
                    Username = gameSession.Players.FirstOrDefault(p => p.UserId == a.UserId)?.User?.Username ?? "Unknown",
                    Avatar = gameSession.Players.FirstOrDefault(p => p.UserId == a.UserId)?.User?.Avatar ?? "👤",
                    SelectedOptionId = a.SelectedOptionId?.ToString(),
                    IsCorrect = a.IsCorrect,
                    TimeSpent = a.TimeSpent
                }).ToList()
            );

        // If game is finished, include results
        List<PlayerResultDto>? results = null;
        if (gameSession.Status == RoomStatus.Finished)
        {
            // Calculate ranks dynamically based on score (don't rely on stored Rank value)
            var rankedPlayers = gameSession.Players
                .OrderByDescending(p => p.Score)
                .ThenBy(p => p.IsEliminated)
                .ThenBy(p => p.EliminatedAtQuestionIndex ?? int.MaxValue)
                .ToList();

            results = rankedPlayers.Select((p, index) => new PlayerResultDto
            {
                UserId = p.UserId,
                Username = p.User?.Username ?? "Unknown",
                Avatar = p.User?.Avatar ?? "👤",
                Rank = index + 1, // Calculate rank from sorted order
                Score = p.Score,
                CorrectAnswers = p.CorrectAnswers,
                WrongAnswers = p.WrongAnswers,
                UnansweredCount = p.TimeoutCount,
                TotalTimeSpent = 0,
                AverageTimePerQuestion = 0,
                XpEarned = 0,
                NewLevel = 0,
                NewXp = 0,
                IsWinner = index == 0 && !p.IsEliminated, // First non-eliminated player is winner
                AchievementsUnlocked = new List<string>()
            }).ToList();
        }

        // Calculate remaining time (60 seconds per question)
        int? remainingTime = null;
        if (gameSession.QuestionStartedAt.HasValue && gameSession.Status == RoomStatus.InProgress)
        {
            var elapsed = (int)(DateTime.UtcNow - gameSession.QuestionStartedAt.Value).TotalSeconds;
            remainingTime = Math.Max(0, 60 - elapsed);
        }

        return new GetGameSessionResponse
        {
            GameSessionId = gameSession.Id.ToString(),
            RoomId = gameSession.RoomId.ToString(),
            Status = gameSession.Status.ToString(),
            CurrentQuestionIndex = gameSession.CurrentQuestionIndex,
            RemainingTimeSeconds = remainingTime,
            Questions = questionsDto,
            Scoreboard = scoreboard,
            UserAnswers = userAnswers,
            FinishedPlayerIds = finishedPlayerIds,
            AllPlayersAnswers = allPlayersAnswers,
            Results = results
        };
    }
}
