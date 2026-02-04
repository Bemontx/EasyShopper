using MediatR;
using EasyShopper.Application.Common.Interfaces;
using EasyShopper.Application.Common.Result;
using EasyShopper.Application.Products.DTOs;
using EasyShopper.Application.Products.Queries;

namespace EasyShopper.Application.Products.Handlers;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, Result<IEnumerable<ProductDto>>>
{
    private readonly IProductRepository _productRepository;

    public GetProductsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Result<IEnumerable<ProductDto>>> Handle(
        GetProductsQuery request,
        CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllAsync();

        if (!products.Any())
            return Result<IEnumerable<ProductDto>>
                .Failure("No hay productos disponibles");

        var dtoList = products.Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            ImageUrl = p.ImageUrl
        });

        return Result<IEnumerable<ProductDto>>.Success(dtoList);
    }
}
