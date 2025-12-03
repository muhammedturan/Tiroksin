using Tiroksin.Application.Common;
using Tiroksin.Application.Common.Interfaces;
using Tiroksin.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Tiroksin.Application.Questions.Commands.CreateQuestion;

public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, Result<CreateQuestionResponse>>
{
    private readonly IApplicationDbContext _context;

    public CreateQuestionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<CreateQuestionResponse>> Handle(CreateQuestionCommand command, CancellationToken cancellationToken)
    {
        // Soru oluştur
        var question = new Question
        {
            Text = command.Text,
            ExamType = command.ExamType,
            CreatedBy = command.CreatedBy,
            OptionsLayout = command.OptionsLayout,
            Points = 0, // Dinamik hesaplanacak
            Category = command.Category,
            Subject = command.Subject,
            Topic = command.Topic
        };

        _context.Questions.Add(question);

        // Şıkları ekle
        foreach (var optionDto in command.Options)
        {
            var option = new QuestionOption
            {
                QuestionId = question.Id,
                Text = optionDto.Text,
                IsCorrect = optionDto.IsCorrect
            };

            _context.QuestionOptions.Add(option);
        }

        await _context.SaveChangesAsync(cancellationToken);

        var response = new CreateQuestionResponse
        {
            Id = question.Id,
            Text = question.Text,
            Points = question.Points
        };

        return Result<CreateQuestionResponse>.Ok(response);
    }
}
