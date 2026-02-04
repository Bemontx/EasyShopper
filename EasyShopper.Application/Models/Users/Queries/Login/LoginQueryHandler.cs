using EasyShopper.Domain.Entities;
using EasyShopper.Application.Common.Interfaces;
using EasyShopper.Application.Common.Result;
using EasyShopper.Application.Models.Users.DTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EasyShopper.Application.Models.User.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, Result<LoginDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<EasyShopper.Domain.Entities.User> _passwordHasher;

    public LoginQueryHandler(
        IUserRepository userRepository,
        IPasswordHasher<EasyShopper.Domain.Entities.User> passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<Result<LoginDto>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);

        if (user == null)
        {
            return Result<LoginDto>.Failure("El usuario no existe o las credenciales son inválidas.");
        }

        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash!, request.Password);

        if (result == PasswordVerificationResult.Failed)
        {
            return Result<LoginDto>.Failure("Contraseña incorrecta.");
        }

        var loginDto = new LoginDto
        {
            Id = user.Id,
            Email = user.Email!,
            FullName = user.UserName ?? string.Empty,
            Token = ""
        };

        return Result<LoginDto>.Success(loginDto);
    }
}
