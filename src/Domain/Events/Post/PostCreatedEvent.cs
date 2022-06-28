namespace Jodel.NET.Domain.Events.Post;

public class PostCreatedEvent : BaseEvent
{
    public Entities.Post Item { get; }

    public PostCreatedEvent(
        Domain.Entities.Post item)
    {
        Item = item;
    }
}