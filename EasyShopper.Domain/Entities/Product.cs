namespace EasyShopper.Domain.Entities;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = default!;

    // Constructor vacío para EF
    private Product() { }

    public Product(string name, decimal price, string imageUrl)
    {
        Id = Guid.NewGuid();
        Name = name;
        Price = price;
        ImageUrl = imageUrl;
    }

    public void Update(string name, decimal price, string imageUrl)
    {
        Name = name;
        Price = price;
        ImageUrl = imageUrl;
    }
}
