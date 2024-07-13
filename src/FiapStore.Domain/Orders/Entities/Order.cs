using FiapStore.Common.Entities;
using FiapStore.Domain.Payments;
using FiapStore.Domain.Shoppers;

namespace FiapStore.Domain.Orders;

public class Order : Entity
{
    public DateTime OrderDate { get; set; }

    public required long ShopperId { get; set; }
    public required Shopper Shopper { get; set; }

    public List<OrderItem> Items { get; set; } = null!;

    public decimal Total { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public IList<Payment> Payments { get; set; } = null!;
}
