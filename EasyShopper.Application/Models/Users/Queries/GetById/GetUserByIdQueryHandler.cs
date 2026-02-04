using EasyShopper.Application.Common.Interfaces;
using EasyShopper.Application.Common.Result;
using EasyShopper.Application.Users.DTOs;
using MediatR;

namespace EasyShopper.Application.Models.User.Queries.GetById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Result<UserDto>>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<UserDto>> Handle(
        GetUserByIdQuery request,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);

        if (user == null)
        {
            return Result<UserDto>.Failure("El usuario no fue encontrado.");
        }

        var userDto = new UserDto
        {
            Id = user.Id,
            Name = user.UserName ?? string.Empty, 
            Email = user.Email ?? string.Empty
        };

        return Result<UserDto>.Success(userDto);
    }
}