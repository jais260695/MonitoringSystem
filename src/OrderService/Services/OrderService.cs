using OrderService.Clients;
using Shared.Contracts.Enums;
using Shared.Contracts.Requests;
using Shared.Contracts.Responses;

namespace OrderService.Services;

public sealed class OrderService : IOrderService
{
    private readonly IInventoryClient _inventoryClient;
    private readonly IPaymentClient _paymentClient;
    private readonly INotificationClient _notificationClient;
    private readonly ILogger<OrderService> _logger;

    public OrderService(
        IInventoryClient inventoryClient,
        IPaymentClient paymentClient,
        INotificationClient notificationClient,
        ILogger<OrderService> logger)
    {
        _inventoryClient = inventoryClient;
        _paymentClient = paymentClient;
        _notificationClient = notificationClient;
        _logger = logger;
    }

    public async Task<ApiResponse<CreateOrderResponse>> CreateOrderAsync(
        CreateOrderRequest request,
        CancellationToken cancellationToken)
    {
        var orderId = Guid.NewGuid();

        _logger.LogInformation(
            "Creating order {OrderId} for product {ProductId}",
            orderId,
            request.ProductId);

        var inventoryResult = await _inventoryClient.ReserveAsync(
            new ReserveInventoryRequest(request.ProductId, request.Quantity),
            cancellationToken);

        if (!inventoryResult.Reserved)
        {
            _logger.LogWarning(
                "Inventory reservation failed for order {OrderId}",
                orderId);

            return ApiResponse<CreateOrderResponse>.Fail(
                "inventory_failed",
                "Unable to reserve inventory");
        }

        var paymentResult = await _paymentClient.ProcessAsync(
            new PaymentRequest(request.Amount, request.CustomerEmail),
            cancellationToken);

        if (paymentResult.Status != PaymentStatus.Success)
        {
            _logger.LogWarning(
                "Payment failed for order {OrderId}",
                orderId);

            return ApiResponse<CreateOrderResponse>.Fail(
                "payment_failed",
                "Payment processing failed");
        }

        await _notificationClient.SendEmailAsync(
            new EmailRequest(
                request.CustomerEmail,
                "Order Created",
                $"Your order {orderId} has been created."),
            cancellationToken);

        _logger.LogInformation(
            "Order {OrderId} created successfully",
            orderId);

        return ApiResponse<CreateOrderResponse>.Ok(
            new CreateOrderResponse(orderId, OrderStatus.Completed));
    }
}