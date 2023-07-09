using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class AuthorizationHeaderMiddleware
{
    private readonly RequestDelegate _next;

    public AuthorizationHeaderMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (!context.Request.Headers.ContainsKey("Authorization"))
        {
            context.Response.StatusCode = 400; // or 401 for unauthorized requests
            await context.Response.WriteAsync("Missing Authorization header");
            return;
        }

        // Continue processing the request
        await _next(context);
    }
}
