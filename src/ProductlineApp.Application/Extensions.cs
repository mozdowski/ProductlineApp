using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ProductlineApp.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
