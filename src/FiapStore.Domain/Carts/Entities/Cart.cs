using FiapStore.Common.Entities;
using FiapStore.Domain.Shoppers;

namespace FiapStore.Domain.Carts;

public class Cart : Entity
{
    public required Shopper Shopper { get; set; }
    public List<CartItem> Items { get; set; }
    public decimal Total { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Cart()
    {
        Items = new List<CartItem>();
    }
}
