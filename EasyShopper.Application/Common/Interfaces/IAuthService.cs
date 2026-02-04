using EasyShopper.Application.Common.Result;
using EasyShopper.Application.Models.Users.DTOs;

namespace EasyShopper.Application.Common.Interfaces;

public interface IAuthService
{   
    Task<Result<Guid>> RegisterAsync(string name, string email, string password);

    Task<Result<LoginDto>> LoginAsync(string email, string password);
}
