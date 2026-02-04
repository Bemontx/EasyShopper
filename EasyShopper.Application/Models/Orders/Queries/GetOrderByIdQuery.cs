using MediatR;
using EasyShopper.Application.Common.Result;
using EasyShopper.Application.Orders.DTOs;

namespace EasyShopper.Application.Orders.Queries.GetOrderById;

public class GetOrderByIdQuery : IRequest<Result<OrderDto>>
{
    public Guid Id { get; set; }

    public GetOrderByIdQuery(Guid id)
    {
        Id = id;
    }
}
