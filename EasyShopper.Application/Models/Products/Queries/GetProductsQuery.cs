using MediatR;
using EasyShopper.Application.Products.DTOs;

namespace EasyShopper.Application.Products.Queries;

public class GetProductsQuery : IRequest<IEnumerable<ProductDto>>
{
}
