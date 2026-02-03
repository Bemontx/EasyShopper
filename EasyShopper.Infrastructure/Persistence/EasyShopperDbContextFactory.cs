using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EasyShopper.Infrastructure.Persistence;

public class EasyShopperDbContextFactory : IDesignTimeDbContextFactory<EasyShopperDbContext>
{
    public EasyShopperDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<EasyShopperDbContext>();

        optionsBuilder.UseSqlServer(
            configuration.GetConnectionString("DefaultConnection")
        );

        return new EasyShopperDbContext(optionsBuilder.Options);
    }
}
