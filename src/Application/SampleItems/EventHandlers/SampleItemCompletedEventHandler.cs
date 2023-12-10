using CleanArchitecture.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.SampleItems.EventHandlers;

public class SampleItemCompletedEventHandler : INotificationHandler<SampleItemCompletedEvent>
{
    private readonly ILogger<SampleItemCompletedEventHandler> _logger;

    public SampleItemCompletedEventHandler(ILogger<SampleItemCompletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(SampleItemCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
