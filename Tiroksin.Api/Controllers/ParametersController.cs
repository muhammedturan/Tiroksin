using Tiroksin.Application.Parameters.Queries.GetParameterValues;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Tiroksin.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ParametersController : ControllerBase
{
    private readonly IMediator _mediator;

    public ParametersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{parameterKey}/values")]
    public async Task<IActionResult> GetParameterValues(string parameterKey)
    {
        var query = new GetParameterValuesQuery { ParameterKey = parameterKey.ToUpper() };
        var result = await _mediator.Send(query);

        if (!result.Success)
        {
            return NotFound(result.Error);
        }

        return Ok(result.Data);
    }
}
