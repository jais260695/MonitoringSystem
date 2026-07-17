namespace Shared.Contracts.Responses;

public sealed record PaymentResponse(
    PaymentStatus Status,
    string TransactionId);