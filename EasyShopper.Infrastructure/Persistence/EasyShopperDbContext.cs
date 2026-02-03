using EasyShopper.Domain.Entities;
using EasyShopper.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyShopper.Infrastructure.Persistence;

public class EasyShopperDbContext
    : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public EasyShopperDbContext(DbContextOptions<EasyShopperDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Customers => Set<User>();
    public DbSet<Order> Orders => Set<Order>();
}
