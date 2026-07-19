using Shared.Contracts.Requests;
using Shared.Contracts.Responses;

namespace OrderService.Clients;

public sealed class InventoryClient : IInventoryClient
{
    private readonly HttpClient _httpClient;

    public InventoryClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<InventoryResponse> ReserveAsync(
        ReserveInventoryRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "/inventory/reserve",
            request,
            cancellationToken);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<InventoryResponse>(cancellationToken: cancellationToken)
               ?? new InventoryResponse(false);
    }
}