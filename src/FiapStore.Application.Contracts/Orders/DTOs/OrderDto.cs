using FiapStore.Application.Contracts.Customers;

namespace FiapStore.Application.Contracts.Orders.DTOs
{
    public class OrderDto()
    {
        public long Id { get; set; }
        public CustomerDto Customer { get; set; }
        public IEnumerable<OrderItemDto> OrderItems { get; set; }
    }
}
