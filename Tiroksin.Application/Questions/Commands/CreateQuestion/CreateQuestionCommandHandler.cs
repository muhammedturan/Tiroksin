using Tiroksin.Application.Common;
using Tiroksin.Domain.Entities;
using Tiroksin.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Tiroksin.Application.Questions.Commands.CreateQuestion;

public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, Result<CreateQuestionResponse>>
{
    private readonly ApplicationDbContext _context;

    public CreateQuestionCommandHandler(ApplicationDbContext context)
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
            Difficulty = command.Difficulty,
            CreatedBy = command.CreatedBy,
            OptionsLayout = command.OptionsLayout,
            Points = 0 // Dinamik hesaplanacak
        };

        // Set parameter values directly from command if provided
        if (command.Parameters != null && command.Parameters.Any())
        {
            foreach (var param in command.Parameters)
            {
                // Map parameter keys to Question properties
                switch (param.Key)
                {
                    case "CATEGORY":
                        question.CategoryPr = param.Value;
                        break;
                    case "SUBJECT":
                        question.SubjectPr = param.Value;
                        break;
                    case "TOPIC":
                        question.TopicPr = param.Value;
                        break;
                }
            }
        }

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
