using MediatR;
using EasyShopper.Application.Products.Commands;
using EasyShopper.Application.Common.Interfaces;
using EasyShopper.Application.Common.Result;
using EasyShopper.Application.Products.DTOs;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Result<ProductDto>>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Result<ProductDto>> Handle(
        UpdateProductCommand request,
        CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);

        if (product == null)
            return Result<ProductDto>.Failure("Producto no encontrado");

        product.Name = request.Name;
        product.Price = request.Price;
        product.ImageUrl = request.ImageUrl;

        await _productRepository.UpdateAsync(product);

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
