using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using AutoMapper;
namespace resto.application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}


