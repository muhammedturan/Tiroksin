using Tiroksin.Application.Auth.Commands.Login;
using Tiroksin.Application.Auth.Commands.Register;
using Tiroksin.Application.Auth.Commands.UpdateTheme;
using Tiroksin.Application.Auth.Queries.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Tiroksin.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.Success)
            return BadRequest(new { error = result.Error });

        return Ok(result.Data);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.Success)
            return BadRequest(new { error = result.Error });

        return Ok(result.Data);
    }

    [HttpGet("users")]
    [Authorize]
    public async Task<IActionResult> GetUsers()
    {
        var query = new GetUsersQuery();
        var result = await _mediator.Send(query);

        if (!result.Success)
            return BadRequest(new { error = result.Error });

        return Ok(result.Data);
    }

    [HttpPut("theme")]
    [Authorize]
    public async Task<IActionResult> UpdateTheme([FromBody] UpdateThemeRequest request)
    {
        var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userIdClaim) || !Guid.TryParse(userIdClaim, out var userId))
            return Unauthorized(new { error = "Gecersiz kullanici" });

        var command = new UpdateThemeCommand
        {
            UserId = userId,
            Theme = request.Theme
        };

        var result = await _mediator.Send(command);

        if (!result.Success)
            return BadRequest(new { error = result.Error });

        return Ok(new { success = true });
    }
}

public class UpdateThemeRequest
{
    public string Theme { get; set; } = string.Empty;
}
