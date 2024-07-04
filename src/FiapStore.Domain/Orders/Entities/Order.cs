using FiapStore.Domain.Shared.Entities;
using FiapStore.Domain.Shoppers;

namespace FiapStore.Domain.Orders;

public class Order : Entity
{
    public required Shopper Shopper { get; set; }
    public List<OrderItem> Items { get; set; }
    public decimal Total { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Order()
    {
        Items = new List<OrderItem>();
    }
}
