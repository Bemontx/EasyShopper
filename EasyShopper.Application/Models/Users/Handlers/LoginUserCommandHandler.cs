using MediatR;
using EasyShopper.Application.Common.Interfaces;
using EasyShopper.Application.Users.Commands;

namespace EasyShopper.Application.Users.Handlers;

public class LoginUserCommandHandler
    : IRequestHandler<LoginUserCommand, Guid?>
{
    private readonly IUserRepository _userRepository;

    public LoginUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Guid?> Handle(
        LoginUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);

        if (user == null)
            return null;

        if (user.Password != request.Password)
            return null;

        return user.Id;
    }
}
