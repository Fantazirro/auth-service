using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AuthService.Application.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<Mapper>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), includeInternalTypes: true);

            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            //var useCases = Assembly.GetExecutingAssembly().GetTypes()
            //    .Where(type => type.GetInterface(typeof(IRequestHandlerOld<,>).Name) is not null);

            //foreach (var useCase in useCases)
            //    services.AddScoped(useCase);

            return services;
        }
    }
}