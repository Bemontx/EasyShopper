using EasyShopper.Application.Users.DTOs;
using MediatR;

namespace EasyShopper.Application.Models.User.Queries.GetById;

public class GetUserByIdQuery : IRequest<UserDto?>
{
    public Guid UserId { get; }

    public GetUserByIdQuery(Guid userId)
    {
        UserId = userId;
    }
}
