using EasyShopper.Application.Common.Interfaces;
using EasyShopper.Application.Common.Result;
using EasyShopper.Application.Products.Commands;
using EasyShopper.Application.Products.DTOs;
using MediatR;

namespace EasyShopper.Application.Products.Handlers;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Result<ProductDto>>
{
    private readonly IProductRepository _repository;

    public UpdateProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ProductDto>> Handle(
        UpdateProductCommand request,
        CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id);

        if (product == null)
            return Result<ProductDto>.Failure("Producto no encontrado");

        product.Update(
            request.Name,
            request.Price,
            request.ImageUrl
        );

        await _repository.UpdateAsync(product);

        return Result<ProductDto>.Success(new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            ImageUrl = product.ImageUrl
        });
    }
}
