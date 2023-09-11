namespace DataAccess.Models;

public class OrderItem
{
    public int ItemId { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int quantity { get; set; }
    public decimal ListPrice { get; set; }
}