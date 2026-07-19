using OrderService.Services;
using Shared.Contracts.Requests;
using Shared.Contracts.Responses;

namespace OrderService.Endpoints;

public static class OrderEndpoints
{
    public static IEndpointRouteBuilder MapOrderEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/orders", async (
            CreateOrderRequest request,
            IOrderService orderService,
            CancellationToken cancellationToken) =>
        {
            var result = await orderService.CreateOrderAsync(request, cancellationToken);
            return Results.Ok(result);
        })
        .WithName("CreateOrder")
        .WithDescription("Creates a new order with inventory reservation, payment processing, and notification")
        .Produces<ApiResponse<CreateOrderResponse>>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status500InternalServerError)
        .WithTags("Orders");

        return app;
    }
}
