namespace Shared.Contracts.Requests;

public sealed class PaymentRequest
{
    [Range(1, double.MaxValue)]
    public decimal Amount { get; set; }

    [Required]
    [EmailAddress]
    public string CustomerEmail { get; set; } = string.Empty;
}