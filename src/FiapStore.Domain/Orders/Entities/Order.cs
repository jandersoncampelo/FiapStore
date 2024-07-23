using FiapStore.Common.Entities;
using FiapStore.Domain.Payments;
using FiapStore.Domain.Customers;
using System.Collections.Generic;
using System;
using FiapStore.Domain.Payments.Entities;

namespace FiapStore.Domain.Orders;

public class Order : Entity
{
    public DateTime OrderDate { get; set; }

    public long CustomerId { get; set; }
    public Customer Customer { get; set; }

    public IEnumerable<OrderItem> Items { get; set; } = null!;

    public decimal Total { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public long PaymentId { get; set; }
    public Payment Payment { get; set; }

    public IList<Payment> Payments { get; set; } = null!;
    public Order()
    {
        Items = new List<OrderItem>();
    }
    public Order(Customer customer, Payment payment, IEnumerable<OrderItem> items)
    {
        this.Total = items.Sum(x => x.Quantity * x.Price);
        this.Customer = customer;
        this.Payment = payment;
        this.Items = items;

        this.CreatedAt = DateTime.Now;
        this.UpdatedAt = DateTime.Now;
    }
}
