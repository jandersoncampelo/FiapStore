using FiapStore.Common.Entities;
using FiapStore.Domain.Orders;
using FiapStore.Domain.Payments.Enums;

namespace FiapStore.Domain.Payments.Entities;

public class Payment : Entity
{
    public string TransactionId { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public EPaymentMethod PaymentMethod { get; set; }
    public bool Confirmed { get; set; }

    public long OrderId { get; set; }
    public Order Order { get; set; } = null!;
    public Payment(EPaymentMethod paymentMethod, decimal amount)
    {
        this.Amount = amount;
        this.PaymentMethod = paymentMethod;
    }
    public void ConfirmPayment()
    {
        this.Confirmed = true;
        this.TransactionId = Guid.NewGuid().ToString();
    }
}
