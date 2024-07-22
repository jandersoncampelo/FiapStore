using FiapStore.Application.Contracts.Orders.DTOs;
using FiapStore.Domain.Payments.Enums;
using FiapStore.Domain.Shoppers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiapStore.Application.Contracts.Products.DTOs
{ 
    public record OrderCreateDto(long ShopperId, EPaymentMethod PaymentMethod, IEnumerable<OrderItemDto> OrderItems);
}
