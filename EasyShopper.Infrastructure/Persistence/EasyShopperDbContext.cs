using EasyShopper.Domain.Entities;
using EasyShopper.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyShopper.Infrastructure.Persistence;

public class EasyShopperDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public EasyShopperDbContext(DbContextOptions<EasyShopperDbContext> options)
        : base(options)
    {
    }
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // 1. Siempre llama al base primero para configurar Identity
        base.OnModelCreating(builder);

        // 2. Configuración para Product
        builder.Entity<Product>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Name).HasMaxLength(200).IsRequired();
            entity.Property(p => p.Price).HasPrecision(18, 2); // Importante para dinero
        });

        // 3. Configuración para Order
        builder.Entity<Order>(entity =>
        {
            entity.HasKey(o => o.Id);
            entity.Property(o => o.TotalAmount).HasPrecision(18, 2);

            // Relación: Una orden pertenece a un Usuario
            entity.HasOne<User>()
                .WithMany()
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
