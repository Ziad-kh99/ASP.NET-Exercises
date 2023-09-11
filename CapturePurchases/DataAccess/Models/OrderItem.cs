namespace DataAccess.Models;

public class OrderItem
{
    public int ItemId { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal ListPrice { get; set; }

    public Order Order { get; set; }
    public Product Product { get; set; }
} 