namespace Shared.Contracts.Responses;

public sealed class ErrorResponse
{
    public string Code { get; init; } = string.Empty;

    public string Message { get; init; } = string.Empty;

    public IDictionary<string, string[]>? ValidationErrors { get; init; }
}