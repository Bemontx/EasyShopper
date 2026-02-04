using EasyShopper.Application.Common.Interfaces;
using EasyShopper.Domain.Entities;
using EasyShopper.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EasyShopper.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly EasyShopperDbContext _context;

    public ProductRepository(EasyShopperDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
    }
}

