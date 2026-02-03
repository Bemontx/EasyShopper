using Microsoft.AspNetCore.Identity;

namespace EasyShopper.Infrastructure.Identity;

public class ApplicationUser : IdentityUser<Guid>
{
    public string Name { get; set; } = string.Empty;
}
