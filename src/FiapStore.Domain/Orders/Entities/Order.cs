using FiapStore.Common.Entities;
using FiapStore.Domain.Payments.Entities;
using FiapStore.Domain.Payments.Enums;
using FiapStore.Domain.Shoppers;

namespace FiapStore.Domain.Orders;

public class Order : Entity
{
    public Shopper Shopper { get; set; }
    public IEnumerable<OrderItem> Items { get; set; }
    public decimal Total { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public long PaymentId { get; set; }
    public Payment Payment { get; set; }

    public Order()
    {
        Items = new List<OrderItem>();
    }
    public Order(Shopper shopper, Payment payment, IEnumerable<OrderItem> items)
    {
        this.Total = items.Sum(x => x.Quantity * x.Price);
        this.Shopper = shopper;
        this.Payment = payment;
        this.Items = items;

        this.CreatedAt = DateTime.Now;
        this.UpdatedAt = DateTime.Now;
    }
}
