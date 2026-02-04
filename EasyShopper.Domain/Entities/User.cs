using Microsoft.AspNetCore.Identity;

namespace EasyShopper.Domain.Entities;

public class User : IdentityUser<Guid>
{
    public string Name { get; set; } = default!;
    public DateTime CreatedAt { get; set; }

    // EF pide un constructor vacio
    private User() { }

    public User(string name, string email)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        UserName = email;
        CreatedAt = DateTime.UtcNow;
        NormalizedEmail = email.ToUpper();
        NormalizedUserName = email.ToUpper();
        CreatedAt = DateTime.UtcNow;
    }
}