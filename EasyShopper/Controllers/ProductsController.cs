using EasyShopper.Application.Products.Commands;
using EasyShopper.Application.Products.DTOs;
using EasyShopper.Application.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyShopper.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetProductsQuery());

        if (!result.IsSuccess)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
    Guid id,
    UpdateProductDto dto)
    {
        var command = new UpdateProductCommand
        {
            Id = id,
            Name = dto.Name,
            Price = dto.Price,
            ImageUrl = dto.ImageUrl
        };

        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }


}
