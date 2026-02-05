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
                id = Guid.NewGuid(),
                name = "Venta Mayorista Premium",
                price = 5500000,
                quantity = 2,
                imageUrl = "https://cdn-icons-png.flaticon.com/512/1170/1170678.png"
            },
            new {
                id = Guid.NewGuid(),
                name = "Insumos por Volumen",
                price = 1500,
                quantity = 6000, 
                imageUrl = "https://cdn-icons-png.flaticon.com/512/2897/2897873.png"
            }
        };

        return Ok(mockProducts);
    }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command) => Ok(Guid.NewGuid());

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateProductDto dto) => Ok(true);
}
