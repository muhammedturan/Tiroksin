using Tiroksin.Application.Parameters.Queries.GetParameterValues;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Tiroksin.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ParametersController : ControllerBase
{
    private readonly IMediator _mediator;

    public ParametersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{parameterKey}/values")]
    public async Task<IActionResult> GetParameterValues(string parameterKey, [FromQuery] string? parentValue = null)
    {
        var query = new GetParameterValuesQuery
        {
            ParameterKey = parameterKey.ToUpper(),
            ParentValue = parentValue
        };
        var result = await _mediator.Send(query);

        if (!result.Success)
        {
            return NotFound(result.Error);
        }

        return Ok(result.Data);
    }
}
