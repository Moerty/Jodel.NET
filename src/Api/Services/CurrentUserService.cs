using System.Security.Claims;

using Jodel.NET.Application.Common.Interfaces;

namespace Jodel.NET.Api.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid UserId => Guid.Parse(_httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier));
    public double Longtitude => double.Parse(_httpContextAccessor.HttpContext.Request.Headers?["Longtitude"]);
    public double Latitude => double.Parse(_httpContextAccessor.HttpContext.Request.Headers?["Latitude"]);
}
