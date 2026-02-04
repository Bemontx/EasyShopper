using MediatR;
using EasyShopper.Application.Common.Interfaces;
using EasyShopper.Application.Common.Result;
using EasyShopper.Application.Orders.DTOs;

namespace EasyShopper.Application.Orders.Queries.GetOrderById;

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Result<OrderDto>>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Result<OrderDto>> Handle(
        GetOrderByIdQuery request,
        CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.Id);

        if (order is null)
            return Result<OrderDto>.Failure("Orden no encontrada");

        var dto = new OrderDto
        {
            Id = order.Id,
            UserId = order.UserId,
            TotalAmount = order.TotalAmount,
            CreatedAt = order.CreatedAt
        };

        return Result<OrderDto>.Success(dto);
    }
}
