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
        // Datos Mock 
        var mockProducts = new List<object>
    {
        new {
            Id = Guid.NewGuid(),
            Name = "Iphone 17 Pro max",
            Price = 500, 
            Quantity = 1,
            ImageUrl = "https://www.apple.com/co/iphone-17-pro/images/overview/highlights/highlights_design_endframe__flnga0hibmeu_large.jpg"
        },
        new {
            Id = Guid.NewGuid(),
            Name = "Iphone 14 Pro",
            Price = 150,
            Quantity = 1,
            ImageUrl = "https://i.blogs.es/d92636/tg_image_1817144959/650_1200.jpeg"
            },
        new {
            Id = Guid.NewGuid(),
            Name = "Iphone 11 Pro",
            Price = 150,
            Quantity = 1,
            ImageUrl = "https://www.apple.com/co/watch/images/meta/apple-watch__ywfuk5wnf1u2_og.png"
            },

        };

        return Ok(mockProducts);
    }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command) => Ok(Guid.NewGuid());

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateProductDto dto) => Ok(true);
}
