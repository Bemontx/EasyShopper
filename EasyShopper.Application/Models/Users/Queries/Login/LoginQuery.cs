using MediatR;
using EasyShopper.Application.Models.Users.DTOs;
using EasyShopper.Application.Common.Result;

namespace EasyShopper.Application.Models.User.Queries.Login;

public class LoginQuery : IRequest<Result<LoginDto>>
{
    public string Email { get; }
    public string Password { get; }

    public LoginQuery(string email, string password)
    {
        Email = email;
        Password = password;
    }
}
