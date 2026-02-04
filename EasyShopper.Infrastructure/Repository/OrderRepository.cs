using EasyShopper.Application.Common.Interfaces;
using EasyShopper.Domain.Entities;
using EasyShopper.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EasyShopper.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly EasyShopperDbContext _context;

    public OrderRepository(EasyShopperDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Order>> GetByUserIdAsync(Guid userId)
    {
        return await _context.Orders
            .Where(o => o.UserId == userId)
            .ToListAsync();
    }
}