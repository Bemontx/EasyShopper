namespace EasyShopper.Application.Users.DTOs;

public class UserDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
}
