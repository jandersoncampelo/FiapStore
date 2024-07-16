using FiapStore.Common.Entities;
using FiapStore.Domain.Products;

namespace FiapStore.Domain.Baskets;

public class BasketItem : Entity
{
    public long BasketId { get;  set; }
    public Basket Basket { get; set; }
    
    public long ProductId { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
