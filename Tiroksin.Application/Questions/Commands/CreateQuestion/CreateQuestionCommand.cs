using Tiroksin.Application.Common;
using Tiroksin.Domain.Enums;
using MediatR;

namespace Tiroksin.Application.Questions.Commands.CreateQuestion;

public class CreateQuestionCommand : IRequest<Result<CreateQuestionResponse>>
{
    public string Text { get; set; } = string.Empty;
    public ExamType ExamType { get; set; }
    public Guid CreatedBy { get; set; }
    public OptionsLayout OptionsLayout { get; set; } = OptionsLayout.Vertical;
    public List<QuestionOptionDto> Options { get; set; } = new List<QuestionOptionDto>();

    // Category parameters - stored directly on Question entity
    public string? Category { get; set; }
    public string? Subject { get; set; }
    public string? Topic { get; set; }

    // Optional: Additional parameters for future use
    public Dictionary<string, string>? Parameters { get; set; }
}

public class QuestionOptionDto
{
    public string Text { get; set; } = string.Empty;
    public bool IsCorrect { get; set; } = false;
}

public class CreateQuestionResponse
{
    public Guid Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public int Points { get; set; }
}
