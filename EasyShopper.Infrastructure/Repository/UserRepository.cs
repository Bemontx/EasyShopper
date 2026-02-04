using EasyShopper.Application.Common.Interfaces;
using EasyShopper.Domain.Entities;
using EasyShopper.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EasyShopper.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly EasyShopperDbContext _context;

    public UserRepository(EasyShopperDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task AddAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }
}
