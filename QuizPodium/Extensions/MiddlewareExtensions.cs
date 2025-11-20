using WebApi.Middlewares;

namespace WebApi.Extensions;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseAppMiddlewares(this IApplicationBuilder app)
    {
        app.UseFileServer();

        app.UseCustomExceptionHandler();
        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        return app;
    }
}
