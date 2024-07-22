using FiapStore.Application.Contracts.Orders.DTOs;
using FiapStore.Domain.Payments.Enums;

namespace FiapStore.Application.Contracts.Products.DTOs
{
    public record OrderCreateDto(long ShopperId, EPaymentMethod PaymentMethod, IEnumerable<OrderItemDto> OrderItems);
}
