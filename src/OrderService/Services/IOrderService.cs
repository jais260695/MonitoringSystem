using Shared.Contracts.Requests;
using Shared.Contracts.Responses;

public interface IOrderService
{
    Task<ApiResponse> CreateOrderAsync(CreateOrderRequest request);
}