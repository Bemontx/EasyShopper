using EasyShopper.Application.Common.Interfaces;
using EasyShopper.Application.Common.Result;
using EasyShopper.Application.Users.Commands;
using EasyShopper.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EasyShopper.Application.Users.Handlers;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Result<Guid>>
{
    private readonly UserManager<User> _userManager;

    public RegisterUserCommandHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Result<Guid>> Handle(
        RegisterUserCommand request,
        CancellationToken cancellationToken)
    {
        var existingUser = await _userManager.FindByEmailAsync(request.Email);

        if (existingUser != null)
            return Result<Guid>.Failure("User already exists");

        var user = new User(request.Name, request.Email);

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            var error = result.Errors.FirstOrDefault()?.Description ?? "Error al crear usuario";
            return Result<Guid>.Failure(error);
        }

        return Result<Guid>.Success(user.Id);
    }
}