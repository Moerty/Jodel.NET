using AutoMapper;
using AutoMapper.QueryableExtensions;
using Jodel.NET.Application.Common.Interfaces;
using Jodel.NET.Application.Common.Mappings;
using Jodel.NET.Application.Common.Models;
using MediatR;

namespace Jodel.NET.Application.Posts.Queries.GetPostsWithPagination;

public record GetPostsWithPaginationQuery : IRequest<PaginatedList<GetPostsDto>>
{
    public bool FromUser { get; init; } = false;
    
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class
    GetPostsWithPaginationQueryHandler : IRequestHandler<GetPostsWithPaginationQuery, PaginatedList<GetPostsDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _userService;

    public GetPostsWithPaginationQueryHandler(
        IApplicationDbContext context,
        IMapper mapper,
        ICurrentUserService userService)
    {
        _context = context;
        _mapper = mapper;
        _userService = userService;
    }
    
    public async Task<PaginatedList<GetPostsDto>> Handle(GetPostsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Posts.AsQueryable();

        query = query.OrderByDescending(o => o.Created);

        if (request.FromUser)
            query = query.Where(u => u.UserId == _userService.UserId);
        
        return await query
            .ProjectTo<GetPostsDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}