using EasyShopper.Application.Models.User.Queries.GetById;
using EasyShopper.Application.Models.User.Queries.Login;
using EasyShopper.Application.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyShopper.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // POST: api/auth/register
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
    {
        return Ok(Guid.NewGuid());
    }

    // POST: api/auth/login
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginQuery query)
    {
        return Ok(new
        {
            token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.mock-data-success",
            id = Guid.NewGuid(), 
            email = query.Email,  
            userName = query.Email.Split('@')[0] 
        });
    }

    // GET: api/auth/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(new
        {
            id = id,
            name = "Usuario Activo",
            email = "sesion-iniciada@easyshopper.com"
        });
    }
}