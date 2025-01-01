using AuthService.Application.Abstractions.Common;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AuthService.Application.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<Mapper>();

            var useCases = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.GetInterface(typeof(IRequestHandler<,>).Name) is not null);

            foreach (var useCase in useCases)
                services.AddScoped(useCase);

            return services;
        }
    }
}