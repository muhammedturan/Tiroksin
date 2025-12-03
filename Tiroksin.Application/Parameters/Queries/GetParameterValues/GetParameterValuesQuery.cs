using Tiroksin.Application.Common;
using MediatR;

namespace Tiroksin.Application.Parameters.Queries.GetParameterValues;

public class GetParameterValuesQuery : IRequest<Result<ParameterValuesResponseDto>>
{
    public string ParameterKey { get; set; } = string.Empty; // CATEGORY, SUBJECT, TOPIC
    public string? ParentValue { get; set; } // Parent value for filtering (e.g., "tyt" to get only TYT categories)
}

public class ParameterValuesResponseDto
{
    public string ParameterName { get; set; } = string.Empty;
    public string? ParentParameterKey { get; set; }
    public List<ParameterValueDto> Values { get; set; } = new();
}

public class ParameterValueDto
{
    public string Value { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int OrderNo { get; set; }
}
