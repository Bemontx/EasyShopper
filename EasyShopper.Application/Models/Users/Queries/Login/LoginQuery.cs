using MediatR;

namespace EasyShopper.Application.Models.User.Queries.Login;

public class LoginQuery : IRequest<Guid?>
{
    public string Email { get; }
    public string Password { get; }

    public LoginQuery(string email, string password)
    {
        Email = email;
        Password = password;
    }
}
