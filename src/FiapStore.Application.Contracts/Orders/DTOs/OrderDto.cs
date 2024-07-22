using FiapStore.Application.Contracts.Shoppers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiapStore.Application.Contracts.Orders.DTOs
{
    public class OrderDto()
    {
        public long Id { get; set; }
        public ShopperDto Shopper { get; set; }
        public IEnumerable<OrderItemDto> OrderItems { get; set; }
    }
}
