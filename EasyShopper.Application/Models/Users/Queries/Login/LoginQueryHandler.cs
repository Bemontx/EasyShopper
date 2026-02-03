using MediatR;
using EasyShopper.Application.Common.Interfaces;
using Microsoft.AspNetCore.Identity;
using EasyShopper.Domain.Entities;

namespace EasyShopper.Application.Models.User.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, Guid?>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<EasyShopper.Domain.Entities.User> _passwordHasher;

    public LoginQueryHandler(IUserRepository userRepository, IPasswordHasher<EasyShopper.Domain.Entities.User> passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<Guid?> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        // 1. Buscamos al usuario solo por Email
        var user = await _userRepository.GetByEmailAsync(request.Email);

        if (user == null) return null;

        // 2. Verificamos si la contraseña es correcta
        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash!, request.Password);

        if (result == PasswordVerificationResult.Failed)
        {
            return null; // Contraseña incorrecta
        }

        return user.Id;
    }
}
