using FiapStore.Common.Entities;
using FiapStore.Domain.Products;

namespace FiapStore.Domain.Orders;

public class OrderItem : Entity
{
    public  Product Product { get; set; }
    public  int Quantity { get; set; }
    public  decimal Price { get; set; }
    public  decimal Total { get; set; }
    public OrderItem()
    {
        
    }
    public OrderItem(Product product, int quantity, decimal price)
    {
        this.Product = product;
        this.Quantity = quantity;
        this.Price = price;
    }
}
