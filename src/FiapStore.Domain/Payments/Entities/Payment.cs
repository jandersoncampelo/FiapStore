using FiapStore.Common.Entities;
using FiapStore.Domain.Orders;
using FiapStore.Domain.Payments.Enums;
using FiapStore.Domain.Shoppers;

namespace FiapStore.Domain.Payments.Entities;

public class Payment : Entity
{
    public long OrderId { get; set; }
    public Order Order { get; set; }
    public EPaymentMethod PaymentMethod { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public decimal TotalPrice { get; set; }

    public Payment(EPaymentMethod paymentMethod, decimal totalPrice)
    {
        this.PaymentMethod = paymentMethod;
        this.TotalPrice = totalPrice;

        this.CreatedAt = DateTime.Now;
        this.UpdatedAt = DateTime.Now;
    }
}
