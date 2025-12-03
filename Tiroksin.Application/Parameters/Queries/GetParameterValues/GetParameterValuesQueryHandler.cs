using Tiroksin.Application.Common;
using Tiroksin.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Tiroksin.Application.Parameters.Queries.GetParameterValues;

public class GetParameterValuesQueryHandler : IRequestHandler<GetParameterValuesQuery, Result<ParameterValuesResponseDto>>
{
    private readonly IApplicationDbContext _context;

    public GetParameterValuesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<ParameterValuesResponseDto>> Handle(GetParameterValuesQuery query, CancellationToken cancellationToken)
    {
        // Get parameter definition by key with parent
        var parameterDefinition = await _context.ParameterDefinitions
            .Include(pd => pd.ParentDefinition)
            .FirstOrDefaultAsync(pd => pd.Key == query.ParameterKey, cancellationToken);

        if (parameterDefinition == null)
        {
            return Result<ParameterValuesResponseDto>.Fail($"Parameter definition '{query.ParameterKey}' not found");
        }

        // Build query for parameter values
        var valuesQuery = _context.ParameterValues
            .Where(pv => pv.ParameterDefinitionId == parameterDefinition.Id);

        // Filter by parent value if provided
        if (!string.IsNullOrEmpty(query.ParentValue))
        {
            // Find the parent value's ID by its value string
            var parentValueEntity = await _context.ParameterValues
                .FirstOrDefaultAsync(pv => pv.Value == query.ParentValue, cancellationToken);

            if (parentValueEntity != null)
            {
                valuesQuery = valuesQuery.Where(pv => pv.ParentValueId == parentValueEntity.Id);
            }
            else
            {
                // Parent value not found, return empty list
                valuesQuery = valuesQuery.Where(pv => false);
            }
        }
        else
        {
            // If no parent value provided, only return root values (no parent) for dependent parameters
            // or all values for root parameters
            if (parameterDefinition.ParentDefinitionId != null)
            {
                valuesQuery = valuesQuery.Where(pv => pv.ParentValueId == null);
            }
        }

        var values = await valuesQuery
            .OrderBy(pv => pv.OrderNo)
            .Select(pv => new ParameterValueDto
            {
                Value = pv.Value,
                Name = pv.Name,
                OrderNo = pv.OrderNo
            })
            .ToListAsync(cancellationToken);

        var response = new ParameterValuesResponseDto
        {
            ParameterName = parameterDefinition.Name,
            ParentParameterKey = parameterDefinition.ParentDefinition?.Key,
            Values = values
        };

        return Result<ParameterValuesResponseDto>.Ok(response);
    }
}
