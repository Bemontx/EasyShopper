using EasyShopper.Domain.Entities;

namespace EasyShopper.Application.Common.Interfaces;

public interface IOrderRepository
{
    Task AddAsync(Order order);
    Task<IEnumerable<Order>> GetByUserIdAsync(Guid userId);
    Task<Order?> GetByIdAsync(Guid id);
}