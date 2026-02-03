using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;

namespace EasyShopper.Application.DependencyInjection;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
        );

        return services;
    }
}
