using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Backend.Services.Storage
{
    public static partial class Extensions
    {
        public static IServiceCollection AddAzureStorage(this IServiceCollection services)
        {
            using (var serviceProvider = services.BuildServiceProvider())
            {
              
                return services;
            }
        }
    }
}
