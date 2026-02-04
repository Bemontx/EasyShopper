using EasyShopper.Application.Common.Result;
using EasyShopper.Application.Products.DTOs;
using MediatR;

namespace EasyShopper.Application.Products.Queries;

public class GetProductsQuery : IRequest<Result<IEnumerable<ProductDto>>>
{
}
