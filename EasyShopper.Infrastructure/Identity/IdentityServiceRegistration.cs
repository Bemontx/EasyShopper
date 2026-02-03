using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using EasyShopper.Domain.Entities;
using EasyShopper.Infrastructure.Persistence;

namespace EasyShopper.Infrastructure.Identity;

public static class IdentityServiceRegistration
{
    public static IServiceCollection AddIdentityServices(
        this IServiceCollection services)
    {
        services.AddIdentityCore<User>(options => {
            options.Password.RequireDigit = false; 
            options.Password.RequiredLength = 6;
        })
        .AddRoles<IdentityRole<Guid>>()
        .AddEntityFrameworkStores<EasyShopperDbContext>();

        services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

        return services;
    }
}
