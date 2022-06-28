using Jodel.NET.Application.Common.Interfaces;
using Jodel.NET.Domain.Entities;
using MediatR;

namespace Jodel.NET.Application.Posts.Commands.CreatePost;

public record CreatePostCommand : IRequest<bool>
{
    public string Text { get; set; }
}

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _userService;

    public CreatePostCommandHandler(
        IApplicationDbContext context,
        ICurrentUserService userService)
    {
        _context = context;
        _userService = userService;
    }
    
    public async Task<bool> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var entity = new Post {
            Text = request.Text,
            UserId = _userService.UserId
        };
        
        // entity.AddDomainEvent(new TodoItemCreatedEvent(entity));
        await _context.Posts
            .AddAsync(entity, cancellationToken)
            .ConfigureAwait(false);

        return await _context
            .SaveChangesAsync(cancellationToken)
            .ConfigureAwait(false) > 0;
    }
}