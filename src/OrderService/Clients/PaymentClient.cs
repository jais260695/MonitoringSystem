using Shared.Contracts.Requests;
using Shared.Contracts.Responses;

namespace OrderService.Clients;

public sealed class PaymentClient : IPaymentClient
{
    private readonly HttpClient _httpClient;

    public PaymentClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<PaymentResponse> ProcessAsync(
        PaymentRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "/payments",
            request,
            cancellationToken);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<PaymentResponse>(cancellationToken: cancellationToken)
               ?? new PaymentResponse(Shared.Contracts.Enums.PaymentStatus.Failed, string.Empty);
    }
}