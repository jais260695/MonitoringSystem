using OrderService.Endpoints;
using OrderService.Extensions;
using Microsoft.AspNetCore.Http.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNameCaseInsensitive = true;
    options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new()
    {
        Title = "Order Service API",
        Version = "v1",
        Description = "API for managing orders, inventory, payments, and notifications",
        Contact = new()
        {
            Name = "Monitoring System Team",
            Email = "support@example.com"
        }
    });
});

builder.Services.AddOrderService(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Order Service API v1");
        options.RoutePrefix = "swagger";
    });
}

app.MapHealthChecks("/health");
app.MapOrderEndpoints();

app.Run();