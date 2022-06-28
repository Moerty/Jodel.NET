namespace Jodel.NET.Domain.Entities;

public class Post : BaseAuditableEntity
{
    public Guid UserId { get; set; }
    public string Text { get; set; }
    
    public User User { get; set; }
}