using AutoMapper;
using FiapStore.Application.Contracts.Orders.DTOs;
using FiapStore.Application.Contracts.Orders.Interfaces;
using FiapStore.Application.Contracts.Products;
using FiapStore.Application.Contracts.Products.DTOs;
using FiapStore.Application.Exceptions;
using FiapStore.Domain.Orders;
using FiapStore.Domain.Payments.Entities;
using FiapStore.Domain.Products;
using FiapStore.Domain.Shoppers;
using FiapStore.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiapStore.Application.Services
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IShopperRepository _shopperRepository;
        private readonly IMapper _mapper;

        public OrderAppService(IOrderRepository orderRepository, IProductRepository productRepository, IShopperRepository shopperRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _shopperRepository = shopperRepository;
            _mapper = mapper;
        }
        public async Task<OrderDto> CreateAsync(OrderCreateDto orderCreateDto)
        {
            if (orderCreateDto is null)
                throw new Exception("Error processing order");

            if (orderCreateDto.PaymentMethod == Domain.Payments.Enums.EPaymentMethod.CreditCard)
                throw new Exception("Payment refused. Please change your payment method");

            var shopper = await _shopperRepository.GetByIdAsync(orderCreateDto.ShopperId);

            if (shopper is null)
                throw new Exception("Error processing order");

            #region Valida se os produtos do pedido possuem estoque
            var orderItems = new List<OrderItem>();

            foreach (var item in orderCreateDto.OrderItems)
            {
                var stockItem = await _productRepository.GetByIdAsync(item.ProductId);

                if (stockItem.Stock < item.Quantity)
                    throw new Exception("Product out of stock");

                orderItems.Add(new OrderItem(stockItem, item.Quantity, item.Price));
            }
            #endregion Valida se os produtos do pedido possuem estoque

            var payment = new Payment(orderCreateDto.PaymentMethod, orderCreateDto.OrderItems.Sum(x => x.Quantity * x.Price));

            var order = new Order(shopper, payment, orderItems);

            await _orderRepository.AddAsync(order);

            #region Atualiza estoque dos itens            
            foreach (var item in orderCreateDto.OrderItems)
            {
                var stockItem = await _productRepository.GetByIdAsync(item.ProductId);

                stockItem.SubtractQuantityFromStock(item.Quantity);

                await _productRepository.UpdateAsync(stockItem);
            }
            #endregion Atualiza estoque dos itens

            return _mapper.Map<OrderDto>(order);
        }
        public async Task<OrderDto> GetByIdAsync(long id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                throw new EntityNotFoundException(typeof(Order), id);
            }

            return _mapper.Map<OrderDto>(order);
        }
        public async Task<List<OrderDto>> ListAsync()
        {
            var orders = await _orderRepository.ListAsync();
            return _mapper.Map<List<OrderDto>>(orders);
        }
    }
}
