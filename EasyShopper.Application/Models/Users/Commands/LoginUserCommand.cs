using MediatR;

namespace EasyShopper.Application.Users.Commands;

public class LoginUserCommand : IRequest<Guid?>
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}
