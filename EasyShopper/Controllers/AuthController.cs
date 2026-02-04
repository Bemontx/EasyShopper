using EasyShopper.Application.Models.User.Queries.GetById;
using EasyShopper.Application.Models.User.Queries.Login;
using EasyShopper.Application.Users.Commands;
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
        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
            return BadRequest(result.Errors);

        return Ok(result.Value);
    }

    // POST: api/auth/login
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginQuery query)
    {
        var result = await _mediator.Send(query);

        if (!result.IsSuccess)
            return Unauthorized(result.Errors);

        return Ok(result.Value);
    }

    // GET: api/auth/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetUserByIdQuery(id);
        var result = await _mediator.Send(query);

        if (!result.IsSuccess)
            return NotFound(result.Errors);

        return Ok(result.Value);
    }
}
