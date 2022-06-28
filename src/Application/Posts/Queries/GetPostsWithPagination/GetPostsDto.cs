using Jodel.NET.Application.Common.Mappings;
using Jodel.NET.Domain.Entities;

namespace Jodel.NET.Application.Posts.Queries.GetPostsWithPagination;

public class GetPostsDto : IMapFrom<Post>
{
    public Guid Id { get; set; }
    public string Text { get; set; }
}