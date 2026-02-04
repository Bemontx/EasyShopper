using EasyShopper.Application.Common.Interfaces;
using EasyShopper.Application.Common.Result;
using EasyShopper.Application.Users.Commands;
using EasyShopper.Domain.Entities;
using MediatR;

namespace EasyShopper.Application.Users.Handlers;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Result<Guid>>
{
    private readonly IUserRepository _userRepository;

    public RegisterUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<Guid>> Handle(
        RegisterUserCommand request,
        CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByEmailAsync(request.Email);

        if (existingUser != null)
            return Result<Guid>.Failure("User already exists");

        var user = new User(request.Name, request.Email);

        await _userRepository.AddAsync(user);

        return Result<Guid>.Success(user.Id);
    }
}