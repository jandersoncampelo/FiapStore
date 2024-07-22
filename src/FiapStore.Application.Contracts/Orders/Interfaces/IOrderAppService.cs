using FiapStore.Application.Contracts.Orders.DTOs;
using FiapStore.Application.Contracts.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiapStore.Application.Contracts.Orders.Interfaces
{
    public interface IOrderAppService
    {
        Task<OrderDto> CreateAsync(OrderCreateDto orderCreateDto);
        Task<OrderDto> GetByIdAsync(long id);
        Task<List<OrderDto>> ListAsync();
    }
}
