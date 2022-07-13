using System.Threading;
using System.Threading.Tasks;
using DoDo.Open.Sdk.Services;
using Microsoft.Extensions.Hosting;

namespace DoDo.Open.Client;

public class HostedService : IHostedService
{
    private readonly IOpenEventService _openEventService;
    private readonly IHostApplicationLifetime _applicationLifetime;

    public HostedService(IOpenEventService openEventService, IHostApplicationLifetime applicationLifetime)
    {
        _openEventService = openEventService;
        _applicationLifetime = applicationLifetime;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _applicationLifetime.ApplicationStarted.Register(StartReceiveEvents);
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _openEventService.StopReceiveAsync().GetAwaiter().GetResult();

        return Task.CompletedTask;
    }

    private void StartReceiveEvents()
    {
        _openEventService.ReceiveAsync().GetAwaiter().GetResult();
    }
}
