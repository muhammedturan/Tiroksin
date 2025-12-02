using Tiroksin.Application.Common;
using Tiroksin.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Tiroksin.Application.Parameters.Queries.GetParameterValues;

public class GetParameterValuesQueryHandler : IRequestHandler<GetParameterValuesQuery, Result<List<ParameterValueDto>>>
{
    private readonly IApplicationDbContext _context;

    public GetParameterValuesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<List<ParameterValueDto>>> Handle(GetParameterValuesQuery query, CancellationToken cancellationToken)
    {
        // Get parameter definition by key
        var parameterDefinition = await _context.ParameterDefinitions
            .FirstOrDefaultAsync(pd => pd.Key == query.ParameterKey, cancellationToken);

        if (parameterDefinition == null)
        {
            return Result<List<ParameterValueDto>>.Fail($"Parameter definition '{query.ParameterKey}' not found");
        }

        // Get parameter values
        var values = await _context.ParameterValues
            .Where(pv => pv.ParameterDefinitionId == parameterDefinition.Id)
            .OrderBy(pv => pv.OrderNo)
            .Select(pv => new ParameterValueDto
            {
                Value = pv.Value,
                Name = pv.Name,
                OrderNo = pv.OrderNo
            })
            .ToListAsync(cancellationToken);

        return Result<List<ParameterValueDto>>.Ok(values);
    }
}
