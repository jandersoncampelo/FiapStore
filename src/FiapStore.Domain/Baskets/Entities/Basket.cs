using FiapStore.Common.Entities;
using FiapStore.Domain.Shoppers;

namespace FiapStore.Domain.Baskets;

public class Basket : Entity
{
    public required Shopper Shopper { get; set; }
    public List<BasketItem> Items { get; set; }
    public decimal Total { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Basket()
    {
        Items = new List<BasketItem>();
    }
}
