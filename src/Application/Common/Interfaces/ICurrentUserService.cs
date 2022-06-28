namespace Jodel.NET.Application.Common.Interfaces;

public interface ICurrentUserService
{
    Guid UserId { get; }
    double Longtitude { get; }
    double Latitude { get; }
}
