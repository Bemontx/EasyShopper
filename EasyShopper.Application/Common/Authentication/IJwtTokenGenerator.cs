using EasyShopper.Domain.Entities;

namespace EasyShopper.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}