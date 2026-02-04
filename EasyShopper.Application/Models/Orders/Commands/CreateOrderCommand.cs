using EasyShopper.Application.Common.Result;
using EasyShopper.Application.Orders.DTOs;
using MediatR;

namespace EasyShopper.Application.Orders.Commands;

public class CreateOrderCommand : IRequest<Result<OrderDto>>
{
    public Guid UserId { get; set; }
    public decimal TotalAmount { get; set; }
}
