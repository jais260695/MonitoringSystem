using Shared.Contracts.Requests;
using Shared.Contracts.Responses;

namespace OrderService.Clients;

public interface IPaymentClient
{
    Task<PaymentResponse> ProcessAsync(
        PaymentRequest request,
        CancellationToken cancellationToken);
}