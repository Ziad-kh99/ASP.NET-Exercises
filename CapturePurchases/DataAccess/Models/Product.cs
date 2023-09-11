namespace DataAccess.Models;

public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal ListPrice { get; set; }
    public int ModelYear { get; set; }
    public int CategoryId { get; set; }         
    public Category Category { get; set; }
}