using Microsoft.Extensions.Options;
using OrderService.Clients;
using OrderService.Configuration;
using OrderService.Services;

namespace OrderService.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOrderService(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<ServiceEndpointsOptions>(
            configuration.GetSection("ServiceEndpoints"));

        services.AddScoped<IOrderService, Services.OrderService>();

        services.AddHttpClient<IInventoryClient, InventoryClient>((sp, client) =>
        {
            var options = sp.GetRequiredService<IOptions<ServiceEndpointsOptions>>().Value;
            client.BaseAddress = new Uri(options.Inventory);
        });

        services.AddHttpClient<IPaymentClient, PaymentClient>((sp, client) =>
        {
            var options = sp.GetRequiredService<IOptions<ServiceEndpointsOptions>>().Value;
            client.BaseAddress = new Uri(options.Payment);
        });

        services.AddHttpClient<INotificationClient, NotificationClient>((sp, client) =>
        {
            var options = sp.GetRequiredService<IOptions<ServiceEndpointsOptions>>().Value;
            client.BaseAddress = new Uri(options.Notification);
        });

        services.AddHealthChecks();

        return services;
    }
}