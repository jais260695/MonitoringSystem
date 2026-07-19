using Shared.Contracts.Requests;
using Shared.Contracts.Responses;

namespace OrderService.Services;

public interface IOrderService
{
    Task<ApiResponse<CreateOrderResponse>> CreateOrderAsync(
        CreateOrderRequest request,
        CancellationToken cancellationToken);
}