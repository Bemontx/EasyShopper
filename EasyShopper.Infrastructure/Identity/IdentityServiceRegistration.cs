using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

namespace EasyShopper.Infrastructure.Identity;

public static class IdentityServiceRegistration
{
    public static IServiceCollection AddIdentityServices(
        this IServiceCollection services)
    {
        services.AddIdentityCore<ApplicationUser>()
            .AddRoles<IdentityRole<Guid>>();

        return services;
    }
}
