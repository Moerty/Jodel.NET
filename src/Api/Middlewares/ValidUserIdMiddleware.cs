using System.Net;
using System.Security.Claims;

namespace Jodel.NET.Api.Middlewares;

public class ValidUserIdMiddleware
{
    private readonly RequestDelegate _next;

    public ValidUserIdMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var userId = context?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userId))
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsync("missing userid");
            return;
        }

        if (!Guid.TryParse(userId, out var convertedUserId))
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsync("invalid user id");
            return;
        }
        
        // Call the next delegate/middleware in the pipeline.
        await _next(context);
    }
}
public static class ValidUserIdMiddlewareExtensions
{
    public static IApplicationBuilder CheckUserId(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ValidUserIdMiddleware>();
    }
}