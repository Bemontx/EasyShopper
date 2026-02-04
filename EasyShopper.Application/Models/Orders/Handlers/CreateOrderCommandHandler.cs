using MediatR;
using EasyShopper.Application.Common.Interfaces;
using EasyShopper.Application.Common.Result;
using EasyShopper.Application.Orders.DTOs;
using EasyShopper.Domain.Entities;

namespace EasyShopper.Application.Orders.Commands.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Result<OrderDto>>
{
    private readonly IOrderRepository _orderRepository;

    public CreateOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Result<OrderDto>> Handle(
        CreateOrderCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var order = new Order(
                request.UserId,
                request.TotalAmount
            );

            await _orderRepository.AddAsync(order);

            var dto = new OrderDto
            {
                Id = order.Id,
                UserId = order.UserId,
                TotalAmount = order.TotalAmount,
                CreatedAt = order.CreatedAt
            };

            return Result<OrderDto>.Success(dto);
        }
        catch (Exception ex)
        {
            return Result<OrderDto>.Failure($"Error al procesar la orden: {ex.Message}");
        }
    }
}
