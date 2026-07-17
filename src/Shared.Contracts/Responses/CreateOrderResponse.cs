namespace Shared.Contracts.Responses;

public sealed record CreateOrderResponse(
    Guid OrderId,
    OrderStatus Status);