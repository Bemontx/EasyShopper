namespace EasyShopper.Application.Common.Interfaces;

public interface IAuthService
{
    Task<Guid?> LoginAsync(string email, string password);
    Task<Guid> RegisterAsync(string name, string email, string password);
}
