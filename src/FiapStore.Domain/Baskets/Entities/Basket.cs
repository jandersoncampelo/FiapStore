using FiapStore.Common.Entities;
using FiapStore.Domain.Customers;

namespace FiapStore.Domain.Baskets;

public class Basket : Entity
{
    public long CustomerId { get; set; }
    public Customer Customer { get; set; }

    public List<BasketItem> Items { get; set; } = [];

    public decimal Total { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
