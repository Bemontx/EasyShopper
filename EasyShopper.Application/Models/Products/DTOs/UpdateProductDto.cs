namespace EasyShopper.Application.Products.DTOs;

public class UpdateProductDto
{
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = default!;
}
