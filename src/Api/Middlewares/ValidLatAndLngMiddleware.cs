using System.Net;

namespace Jodel.NET.Api.Middlewares;

public class ValidLatAndLngMiddleware
{
    private readonly RequestDelegate _next;

    public ValidLatAndLngMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // check for headers
        var latitudeString = context.Request.Headers["Latitude"];
        var longtitudeString = context.Request.Headers["Longtitude"];
        if (string.IsNullOrEmpty(latitudeString) || string.IsNullOrEmpty(longtitudeString))
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsync("missing latitude or longitude");
            return;
        }

        // check for valid doubles
        var isLatitudeValidDouble = double.TryParse(latitudeString, out var latitude);
        var isLontitudeValidDouble = double.TryParse(longtitudeString, out var longititude);
        if (!isLatitudeValidDouble || isLontitudeValidDouble)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsync("latitude or longtitude invalid");
            return;
        }

        // check valid latitude
        if (latitude is < -90 or > 90)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsync("latitude invalid");
            return;
        }

        // check valid longtitude
        if (longititude is < -180 or > 180)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsync("longtitude invalid");
            return;
        }

        // Call the next delegate/middleware in the pipeline.
        await _next(context);
    }
}

public static class ValidLatAndLngMiddlewareExtensions
{
    public static IApplicationBuilder UseLongLatMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ValidLatAndLngMiddleware>();
    }
}