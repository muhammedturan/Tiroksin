namespace Tiroksin.Application.Common.DTOs;

/// <summary>
/// Standard API response wrapper for consistent response format
/// </summary>
public class ApiResponse<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public ApiError? Error { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    public static ApiResponse<T> Ok(T data)
    {
        return new ApiResponse<T>
        {
            Success = true,
            Data = data
        };
    }

    public static ApiResponse<T> Fail(string message, string? code = null, Dictionary<string, string[]>? details = null)
    {
        return new ApiResponse<T>
        {
            Success = false,
            Error = new ApiError
            {
                Code = code ?? "ERROR",
                Message = message,
                Details = details
            }
        };
    }
}

/// <summary>
/// Non-generic version for responses without data
/// </summary>
public class ApiResponse : ApiResponse<object>
{
    public static ApiResponse Ok()
    {
        return new ApiResponse { Success = true };
    }

    public new static ApiResponse Fail(string message, string? code = null, Dictionary<string, string[]>? details = null)
    {
        return new ApiResponse
        {
            Success = false,
            Error = new ApiError
            {
                Code = code ?? "ERROR",
                Message = message,
                Details = details
            }
        };
    }
}

/// <summary>
/// Standard error object
/// </summary>
public class ApiError
{
    /// <summary>
    /// Error code for programmatic handling (e.g., "VALIDATION_ERROR", "NOT_FOUND")
    /// </summary>
    public string Code { get; set; } = "ERROR";

    /// <summary>
    /// Human-readable error message
    /// </summary>
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// Additional error details (e.g., validation errors per field)
    /// </summary>
    public Dictionary<string, string[]>? Details { get; set; }
}

/// <summary>
/// Common error codes
/// </summary>
public static class ErrorCodes
{
    // General
    public const string InternalError = "INTERNAL_ERROR";
    public const string ValidationError = "VALIDATION_ERROR";
    public const string NotFound = "NOT_FOUND";
    public const string Unauthorized = "UNAUTHORIZED";
    public const string Forbidden = "FORBIDDEN";

    // Auth
    public const string InvalidCredentials = "INVALID_CREDENTIALS";
    public const string UserExists = "USER_EXISTS";
    public const string InvalidToken = "INVALID_TOKEN";

    // Game
    public const string GameNotFound = "GAME_NOT_FOUND";
    public const string GameNotActive = "GAME_NOT_ACTIVE";
    public const string PlayerEliminated = "PLAYER_ELIMINATED";
    public const string AlreadyAnswered = "ALREADY_ANSWERED";
    public const string QuestionNotActive = "QUESTION_NOT_ACTIVE";

    // Room
    public const string RoomNotFound = "ROOM_NOT_FOUND";
    public const string RoomFull = "ROOM_FULL";
    public const string NotEnoughPlayers = "NOT_ENOUGH_PLAYERS";
    public const string NotHost = "NOT_HOST";
    public const string InsufficientQuestions = "INSUFFICIENT_QUESTIONS";
}
