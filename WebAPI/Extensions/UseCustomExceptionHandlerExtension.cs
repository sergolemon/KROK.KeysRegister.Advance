using WebAPI.Middleware;

namespace WebAPI.Extensions
{
    public static class UseCustomExceptionHandlerExtension
    {
        public static void UseCustomExceptionHandler(this WebApplication application)
        {
            application.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}
