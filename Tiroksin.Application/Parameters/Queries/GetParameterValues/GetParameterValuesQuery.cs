using Tiroksin.Application.Common;
using MediatR;

namespace Tiroksin.Application.Parameters.Queries.GetParameterValues;

public class GetParameterValuesQuery : IRequest<Result<List<ParameterValueDto>>>
{
    public string ParameterKey { get; set; } = string.Empty; // CATEGORY, SUBJECT, TOPIC
}

public class ParameterValueDto
{
    public string Value { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int OrderNo { get; set; }
}
