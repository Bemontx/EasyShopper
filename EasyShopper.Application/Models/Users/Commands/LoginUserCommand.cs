using EasyShopper.Application.Common.Result;
using MediatR;

namespace EasyShopper.Application.Users.Commands;

public class LoginUserCommand : IRequest<Result<Guid>>
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}
