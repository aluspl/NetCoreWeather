using Microsoft.AspNetCore.Builder;

namespace Backend.Services.Common 
{
    public static class Extensions 
    {
           public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder builder)
            => builder.UseMiddleware<ErrorHandlerMiddleware>();
    }
}