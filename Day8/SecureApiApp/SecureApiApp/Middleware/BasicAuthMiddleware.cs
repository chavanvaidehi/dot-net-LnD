using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.Text;

public class BasicAuthMiddleware
{
    private readonly RequestDelegate _next;
    private const string USERNAME = "admin";
    private const string PASSWORD = "1234";

    public BasicAuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();

        if (authHeader != null && AuthenticationHeaderValue.TryParse(authHeader, out var headerValue))
        {
            var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(headerValue.Parameter ?? ""))
                              .Split(':', 2);

            if (credentials.Length == 2 && credentials[0] == USERNAME && credentials[1] == PASSWORD)
            {
                await _next(context);
                return;
            }
        }

        context.Response.StatusCode = 401;
        context.Response.Headers["WWW-Authenticate"] = "Basic";
        await context.Response.WriteAsync("Unauthorized");
    }
}
