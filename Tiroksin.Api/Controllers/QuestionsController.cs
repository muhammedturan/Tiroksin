using Tiroksin.Application.Questions.Commands.CreateQuestion;
using Tiroksin.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;

namespace Tiroksin.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
[EnableRateLimiting("fixed")]
public class QuestionsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ApplicationDbContext _context;

    public QuestionsController(IMediator mediator, ApplicationDbContext context)
    {
        _mediator = mediator;
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var question = await _context.Questions
            .Include(q => q.Options)
            .Where(q => q.Id == id)
            .Select(q => new
            {
                q.Id,
                q.Text,
                q.ImageUrl,
                OptionsLayout = (int)q.OptionsLayout,
                ExamType = (int)q.ExamType,
                q.Category,
                q.Subject,
                q.Topic,
                Status = (int)q.Status,
                q.IsPublic,
                q.Points,
                Options = q.Options.OrderBy(o => o.OptionKey).Select(o => new
                {
                    o.Id,
                    o.OptionKey,
                    o.Text,
                    o.IsCorrect
                }).ToList()
            })
            .FirstOrDefaultAsync();

        if (question == null)
            return NotFound(new { message = "Soru bulunamadı" });

        return Ok(question);
    }

    [HttpPost]
    public async Task<IActionResult> CreateQuestion([FromBody] CreateQuestionCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.Success)
            return BadRequest(new { error = result.Error });

        return Ok(result.Data);
    }
}
