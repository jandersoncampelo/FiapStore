using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiapStore.Application.Contracts.Orders.DTOs
{
    public record OrderItemDto(long ProductId, int Quantity, decimal Price);
}
