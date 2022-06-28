namespace Jodel.NET.Application.Common.Interfaces;

public interface ICurrentUserService
{
    string? UserId { get; }
    double Longtitude { get; }
    double Latitude { get; }
}
