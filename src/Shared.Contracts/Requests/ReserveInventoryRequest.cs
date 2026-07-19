namespace Shared.Contracts.Requests;

public sealed class ReserveInventoryRequest
{
    [Required]
    public Guid ProductId { get; set; }

    [Range(1, 100)]
    public int Quantity { get; set; }

    public ReserveInventoryRequest()
    {
    }

    public ReserveInventoryRequest(Guid productId, int quantity)
    {
        ProductId = productId;
        Quantity = quantity;
    }
}