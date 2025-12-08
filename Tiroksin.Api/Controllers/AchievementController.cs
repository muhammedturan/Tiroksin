using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System.Security.Claims;
using Tiroksin.Application.Common.Services;

namespace Tiroksin.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
[EnableRateLimiting("fixed")]
public class AchievementController : ControllerBase
{
    private readonly IAchievementService _achievementService;
    private readonly ILogger<AchievementController> _logger;

    public AchievementController(IAchievementService achievementService, ILogger<AchievementController> logger)
    {
        _achievementService = achievementService;
        _logger = logger;
    }

    /// <summary>
    /// Get all achievements for the current user
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<List<UserAchievementDto>>> GetMyAchievements()
    {
        try
        {
            var userId = GetUserIdFromToken();
            var achievements = await _achievementService.GetUserAchievementsAsync(userId);
            return Ok(achievements);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting user achievements");
            return StatusCode(500, new { message = "Başarılar alınırken bir hata oluştu" });
        }
    }

    /// <summary>
    /// Check and unlock any newly earned achievements
    /// </summary>
    [HttpPost("check")]
    public async Task<ActionResult<List<UnlockedAchievementDto>>> CheckAchievements()
    {
        try
        {
            var userId = GetUserIdFromToken();
            var unlockedAchievements = await _achievementService.CheckAndUnlockAchievementsAsync(userId);
            return Ok(unlockedAchievements);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error checking achievements");
            return StatusCode(500, new { message = "Başarılar kontrol edilirken bir hata oluştu" });
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
