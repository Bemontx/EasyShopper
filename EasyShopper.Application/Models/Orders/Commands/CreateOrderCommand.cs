using MediatR;

namespace EasyShopper.Application.Orders.Commands;

public class CreateOrderCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }
    public decimal TotalAmount { get; set; }
}
