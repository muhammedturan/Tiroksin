using System.Net;
using System.Text.Json;
using Tiroksin.Application.Common.DTOs;

namespace Tiroksin.Api.Middleware;

public class GlobalExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;
    private readonly IHostEnvironment _env;

    public GlobalExceptionHandlerMiddleware(
        RequestDelegate next,
        ILogger<GlobalExceptionHandlerMiddleware> logger,
        IHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _env = env;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        _logger.LogError(exception, "An unhandled exception occurred: {Message}", exception.Message);

        var response = context.Response;
        response.ContentType = "application/json";

        string errorCode;
        string errorMessage;
        Dictionary<string, string[]>? details = null;

        switch (exception)
        {
            case FluentValidation.ValidationException fluentValidationEx:
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                errorCode = ErrorCodes.ValidationError;
                errorMessage = "Doğrulama hatası";
                details = fluentValidationEx.Errors
                    .GroupBy(e => e.PropertyName)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Select(e => e.ErrorMessage).ToArray()
                    );
                break;

            case ValidationException validationEx:
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                errorCode = ErrorCodes.ValidationError;
                errorMessage = validationEx.Message;
                details = validationEx.Errors;
                break;

            case NotFoundException notFoundEx:
                response.StatusCode = (int)HttpStatusCode.NotFound;
                errorCode = ErrorCodes.NotFound;
                errorMessage = notFoundEx.Message;
                break;

            case UnauthorizedAccessException:
                response.StatusCode = (int)HttpStatusCode.Unauthorized;
                errorCode = ErrorCodes.Unauthorized;
                errorMessage = "Yetkisiz erişim";
                break;

            case ForbiddenException:
                response.StatusCode = (int)HttpStatusCode.Forbidden;
                errorCode = ErrorCodes.Forbidden;
                errorMessage = "Bu işlem için yetkiniz yok";
                break;

            case BusinessException businessEx:
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                errorCode = "BUSINESS_ERROR";
                errorMessage = businessEx.Message;
                break;

            default:
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                errorCode = ErrorCodes.InternalError;
                errorMessage = _env.IsDevelopment()
                    ? exception.Message
                    : "Bir hata oluştu. Lütfen daha sonra tekrar deneyin.";

                if (_env.IsDevelopment())
                {
                    details = new Dictionary<string, string[]>
                    {
                        { "stackTrace", new[] { exception.StackTrace ?? "" } }
                    };
                }
                break;
        }

        var apiResponse = ApiResponse.Fail(errorMessage, errorCode, details);

        var jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        var result = JsonSerializer.Serialize(apiResponse, jsonOptions);
        await response.WriteAsync(result);
    }
}

public class ErrorResponse
{
    public string Message { get; set; } = string.Empty;
    public string? StackTrace { get; set; }
    public Dictionary<string, string[]>? Errors { get; set; }
}

// Custom Exceptions
public class ValidationException : Exception
{
    public Dictionary<string, string[]> Errors { get; }

    public ValidationException(string message) : base(message)
    {
        Errors = new Dictionary<string, string[]>();
    }

    public ValidationException(Dictionary<string, string[]> errors)
        : base("Bir veya daha fazla doğrulama hatası oluştu")
    {
        Errors = errors;
    }
}

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message) { }
    public NotFoundException(string name, object key)
        : base($"'{name}' ({key}) bulunamadı") { }
}

public class ForbiddenException : Exception
{
    public ForbiddenException(string message = "Bu işlem için yetkiniz yok") : base(message) { }
}

public class BusinessException : Exception
{
    public BusinessException(string message) : base(message) { }
}

// Extension method
public static class GlobalExceptionHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
    {
        return app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
    }
}
