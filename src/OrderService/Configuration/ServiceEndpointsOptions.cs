namespace OrderService.Configuration;

public sealed class ServiceEndpointsOptions
{
    public string Inventory { get; set; } = string.Empty;
    public string Payment { get; set; } = string.Empty;
    public string Notification { get; set; } = string.Empty;
}