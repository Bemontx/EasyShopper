using EasyShopper.Application.Common.Result;
using EasyShopper.Application.Products.DTOs;
using MediatR;

namespace EasyShopper.Application.Products.Commands;

public class UpdateProductCommand : IRequest<Result<ProductDto>>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = default!;
}
