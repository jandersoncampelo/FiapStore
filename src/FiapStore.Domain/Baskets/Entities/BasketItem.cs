using FiapStore.Common.Entities;
using FiapStore.Domain.Products;

namespace FiapStore.Domain.Baskets;

public class BasketItem : Entity
{
    public required long BasketId { get; set; }
    public required Basket Basket { get; set; }
    public required long ProductId { get; set; }
    public required Product Product { get; set; }
    public required int Quantity { get; set; }
    public required decimal Price { get; set; }
    public required decimal Total { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
