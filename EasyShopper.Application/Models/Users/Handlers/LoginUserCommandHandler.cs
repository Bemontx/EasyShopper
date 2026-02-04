using MediatR;
using EasyShopper.Application.Common.Interfaces;
using EasyShopper.Application.Users.Commands;
using EasyShopper.Application.Common.Result;
using Microsoft.AspNetCore.Identity;
using EasyShopper.Domain.Entities;

namespace EasyShopper.Application.Users.Handlers;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Result<Guid>>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<User> _passwordHasher;

    public LoginUserCommandHandler(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<Result<Guid>> Handle(
        LoginUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);

        if (user == null)
            return Result<Guid>.Failure("Usuario o contraseña incorrectos.");

        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash!, request.Password);

        if (result == PasswordVerificationResult.Failed)
            return Result<Guid>.Failure("Usuario o contraseña incorrectos.");

        return Result<Guid>.Success(user.Id);
    }
}
