using Shared.Contracts.Requests;

namespace OrderService.Clients;

public interface INotificationClient
{
    Task SendEmailAsync(
        EmailRequest request,
        CancellationToken cancellationToken);
}