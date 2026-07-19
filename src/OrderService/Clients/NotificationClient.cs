using Shared.Contracts.Requests;

namespace OrderService.Clients;

public sealed class NotificationClient : INotificationClient
{
    private readonly HttpClient _httpClient;

    public NotificationClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task SendEmailAsync(
        EmailRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "/notifications/email",
            request,
            cancellationToken);

        response.EnsureSuccessStatusCode();
    }
}