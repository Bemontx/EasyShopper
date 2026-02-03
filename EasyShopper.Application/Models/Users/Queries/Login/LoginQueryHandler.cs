using MediatR;
using EasyShopper.Application.Common.Interfaces;

namespace EasyShopper.Application.Models.User.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, Guid?>
{
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Guid?> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository
            .GetByEmailAndPasswordAsync(request.Email, request.Password);

        return user?.Id;
    }
}
