using MediatR;
using EasyShopper.Application.Common.Interfaces;
using EasyShopper.Application.Orders.Commands;
using EasyShopper.Domain.Entities;

namespace EasyShopper.Application.Orders.Handlers;

public class CreateOrderCommandHandler
    : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IOrderRepository _orderRepository;

    public CreateOrderCommandHandler(
        IUserRepository userRepository,
        IOrderRepository orderRepository)
    {
        _userRepository = userRepository;
        _orderRepository = orderRepository;
    }

    public async Task<Guid> Handle(
        CreateOrderCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);

        if (user == null)
            throw new Exception("User not authenticated");

        var order = new Order(
            request.UserId,
            request.TotalAmount
        );

        await _orderRepository.AddAsync(order);

        return order.Id;
    }
}
