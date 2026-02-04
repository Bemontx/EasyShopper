using EasyShopper.Application.Common.Interfaces;
using EasyShopper.Application.Common.Result;
using EasyShopper.Application.Models.User.Queries.Login;
using EasyShopper.Application.Models.Users.DTOs;
using MediatR;

namespace EasyShopper.Application.Users.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, Result<LoginDto>>
{
    private readonly IAuthService _authService;

    public LoginQueryHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<Result<LoginDto>> Handle(
        LoginQuery request,
        CancellationToken cancellationToken)
    {
        return await _authService.LoginAsync(request.Email, request.Password);
    }
}