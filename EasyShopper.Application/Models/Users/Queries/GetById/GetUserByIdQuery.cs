using EasyShopper.Application.Common.Result;
using EasyShopper.Application.Users.DTOs;
using MediatR;

namespace EasyShopper.Application.Models.User.Queries.GetById;

public class GetUserByIdQuery : IRequest<Result<UserDto>>
{
    public Guid UserId { get; }

    public GetUserByIdQuery(Guid userId)
    {
        UserId = userId;
    }
}
