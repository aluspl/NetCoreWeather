using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Backend.Services.Swagger
{
    public static class Extensions
    {
        public static IServiceCollection AddSwaggerDocs(this IServiceCollection services)
        {
            using (var serviceProvider = services.BuildServiceProvider())
            {
                var configuration = serviceProvider.GetService<IConfiguration>();

                return services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info { Title = "Weather", Version = "v1" });                  
                });
            }
        }

        public static IApplicationBuilder UseSwaggerDocs(this IApplicationBuilder builder)
        {        

            builder.UseStaticFiles()
                .UseSwagger(c => c.RouteTemplate = "swagger/{documentName}/swagger.json");

            return builder.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint($"/swagger/v1/swagger.json", "Weather");
                    c.RoutePrefix = "swagger";
                });
        }
    }
}
