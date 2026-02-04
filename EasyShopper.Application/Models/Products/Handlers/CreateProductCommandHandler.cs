using MediatR;
using EasyShopper.Application.Common.Interfaces;
using EasyShopper.Application.Common.Result;
using EasyShopper.Application.Products.Commands;
using EasyShopper.Application.Products.DTOs;
using EasyShopper.Domain.Entities;

namespace EasyShopper.Application.Products.Handlers;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<ProductDto>>
{
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Result<ProductDto>> Handle(
        CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Price = request.Price,
            ImageUrl = request.ImageUrl
        };

        await _productRepository.AddAsync(product);

        var dto = new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            ImageUrl = product.ImageUrl
        };

        return Result<ProductDto>.Success(dto);
    }
}
