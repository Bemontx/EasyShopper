using MediatR;
using EasyShopper.Application.Common.Result;
using EasyShopper.Application.Products.DTOs;

namespace EasyShopper.Application.Products.Commands;

public class CreateProductCommand : IRequest<Result<ProductDto>>
{
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = default!;
}
