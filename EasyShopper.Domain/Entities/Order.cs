namespace EasyShopper.Domain.Entities;

public class Order
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime CreatedAt { get; set; }


    //constructores
    // EF pide un constructor vacio
    private Order() { } 

    public Order(Guid userId, decimal totalAmount)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        TotalAmount = totalAmount;
        CreatedAt = DateTime.UtcNow;
    }
}
