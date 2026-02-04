using MediatR;
using EasyShopper.Application.Common.Result;
using EasyShopper.Application.Models.Users.DTOs;

namespace EasyShopper.Application.Users.Commands;

public class RegisterUserCommand : IRequest<Result<Guid>>
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}
