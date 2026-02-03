using MediatR;
using EasyShopper.Application.Common.Interfaces;
using EasyShopper.Application.Users.Commands;
using Microsoft.AspNetCore.Identity;
using EasyShopper.Domain.Entities;

namespace EasyShopper.Application.Users.Handlers;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Guid?>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<EasyShopper.Domain.Entities.User> _passwordHasher;

    public LoginUserCommandHandler(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<Guid?> Handle(
        LoginUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);

        if (user == null)
            return null;

        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash!, request.Password);

        if (result == PasswordVerificationResult.Failed)
            return null;

        return user.Id;
    }
}
