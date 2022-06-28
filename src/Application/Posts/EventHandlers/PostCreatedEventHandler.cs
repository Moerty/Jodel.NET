using Jodel.NET.Domain.Events.Post;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Microsoft.Extensions.DependencyInjection.Posts.EventHandlers;

public class PostCreatedEventHandler : INotificationHandler<PostCreatedEvent>
{
    private readonly ILogger<PostCreatedEventHandler> _logger;

    public PostCreatedEventHandler(
        ILogger<PostCreatedEventHandler> logger)
    {
        _logger = logger;
    }
    
    public Task Handle(PostCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Jodel.NET Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}