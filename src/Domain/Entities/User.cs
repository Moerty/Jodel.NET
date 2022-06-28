namespace Jodel.NET.Domain.Entities;

public class User : BaseAuditableEntity
{
    public IList<Post> Posts { get; set; }
}