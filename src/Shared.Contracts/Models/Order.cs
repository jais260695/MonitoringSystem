using Shared.Contracts.Enums;

namespace Shared.Contracts.Models;

public sealed class Order
{
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal Amount { get; set; }

    public string CustomerEmail { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public OrderStatus Status { get; set; }
}