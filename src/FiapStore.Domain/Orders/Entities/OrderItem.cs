using FiapStore.Common.Entities;
using FiapStore.Domain.Products;

namespace FiapStore.Domain.Orders;

public class OrderItem : Entity
{
    public required long OrderId { get; set; }
    public required Order Order { get; set; }

    public required long ProductId { get; set; }
    public required Product Product { get; set; }

    public required int Quantity { get; set; }
    public required decimal Price { get; set; }
    public required decimal Total { get; set; }
}
