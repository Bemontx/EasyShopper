using EasyShopper.Domain.Entities;

namespace EasyShopper.Application.Common.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
}
