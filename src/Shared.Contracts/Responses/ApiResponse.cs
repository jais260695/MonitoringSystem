namespace Shared.Contracts.Responses;

public sealed class ApiResponse<T>
{
    public bool Success { get; init; }

    public T? Data { get; init; }

    public ErrorResponse? Error { get; init; }

    public DateTime Timestamp { get; init; } = DateTime.UtcNow;

    public string TraceId { get; init; } = string.Empty;

    public static ApiResponse<T> Ok(T data)
    {
        return new()
        {
            Success = true,
            Data = data
        };
    }

    public static ApiResponse<T> Fail(
        string code,
        string message,
        string traceId = "")
    {
        return new()
        {
            Success = false,
            TraceId = traceId,
            Error = new ErrorResponse
            {
                Code = code,
                Message = message
            }
        };
    }
}