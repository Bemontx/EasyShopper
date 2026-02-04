using Microsoft.AspNetCore.Identity;
using EasyShopper.Application.Common.Interfaces;
using EasyShopper.Application.Common.Interfaces.Authentication;
using EasyShopper.Domain.Entities;
using EasyShopper.Infrastructure.Persistence;
using EasyShopper.Infrastructure.Repositories;
using EasyShopper.Infrastructure.Services;
using EasyShopper.Infrastructure.Authentication; 
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EasyShopper.Infrastructure.DependencyInjection;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // 1. Base de Datos
        services.AddDbContext<EasyShopperDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

        // 2. Identity
        services.AddIdentity<User, IdentityRole<Guid>>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 6;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
        })
        .AddEntityFrameworkStores<EasyShopperDbContext>()
        .AddDefaultTokenProviders();

        // Mapea la sección "JwtSettings" del appsettings.json a la clase
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
                // Registra el generador de tokens
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        // 3. Registro de Repositorios
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();

        // 4. Registro de Servicios de Aplicación
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}