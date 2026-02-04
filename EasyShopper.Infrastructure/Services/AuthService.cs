using EasyShopper.Application.Common.Interfaces;
using EasyShopper.Application.Common.Interfaces.Authentication;
using EasyShopper.Application.Common.Result;
using EasyShopper.Application.Models.Users.DTOs;
using EasyShopper.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace EasyShopper.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthService(
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<Result<Guid>> RegisterAsync(string name, string email, string password)
    {
        var user = new User(name, email);
        var result = await _userManager.CreateAsync(user, password);

        if (!result.Succeeded)
            return Result<Guid>.Failure(string.Join(", ", result.Errors.Select(e => e.Description)));

        return Result<Guid>.Success(user.Id);
    }

    public async Task<Result<LoginDto>> LoginAsync(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null) return Result<LoginDto>.Failure("Credenciales inválidas.");

        var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
        if (!result.Succeeded) return Result<LoginDto>.Failure("Credenciales inválidas.");

        return Result<LoginDto>.Success(new LoginDto
        {
            Id = user.Id,
            Email = user.Email!,
            FullName = user.Name,
            Token = _jwtTokenGenerator.GenerateToken(user)
        });
    }
}