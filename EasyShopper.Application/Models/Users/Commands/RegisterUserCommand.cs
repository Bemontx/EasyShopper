using MediatR;

namespace EasyShopper.Application.Users.Commands;

public class RegisterUserCommand : IRequest<Guid>
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}
