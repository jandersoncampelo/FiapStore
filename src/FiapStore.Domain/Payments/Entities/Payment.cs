using FiapStore.Common.Entities;
using FiapStore.Domain.Orders;

namespace FiapStore.Domain.Payments;

public class Payment : Entity
{
    public required string TransactionId { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public bool Confirmed { get; set; }

    public long OrderId { get; set; }
    public Order Order { get; set; } = null!;
}
