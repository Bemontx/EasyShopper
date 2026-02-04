using EasyShopper.Application.Common.Result;

namespace EasyShopper.Application.Common.Interfaces;

public interface IAuthService
{
    Task<Result<Guid>> LoginAsync(string email, string password);
    Task<Result<Guid>> RegisterAsync(string name, string email, string password);
}
