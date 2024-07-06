using FiapStore.Common.Entities;
using FiapStore.Domain.Products;

namespace FiapStore.Domain.Orders;

public class OrderItem : Entity
{
    public required Product Product { get; set; }
    public required int Quantity { get; set; }
    public required decimal Price { get; set; }
    public required decimal Total { get; set; }
}
