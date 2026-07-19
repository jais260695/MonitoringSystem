using Shared.Contracts.Requests;
using Shared.Contracts.Responses;

namespace OrderService.Clients;

public interface IInventoryClient
{
    Task<InventoryResponse> ReserveAsync(
        ReserveInventoryRequest request,
        CancellationToken cancellationToken);
}