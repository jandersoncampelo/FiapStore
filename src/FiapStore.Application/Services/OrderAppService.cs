using AutoMapper;
using FiapStore.Application.Contracts.Orders.DTOs;
using FiapStore.Application.Contracts.Orders.Interfaces;
using FiapStore.Application.Contracts.Products.DTOs;
using FiapStore.Application.Exceptions;
using FiapStore.Domain.Customers;
using FiapStore.Domain.Orders;
using FiapStore.Domain.Payments.Entities;
using FiapStore.Domain.Products;

namespace FiapStore.Application.Services
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public OrderAppService(IOrderRepository orderRepository, IProductRepository productRepository, ICustomerRepository customerRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<OrderDto> CreateAsync(OrderCreateDto orderCreateDto)
        {
            if (orderCreateDto is null)
                throw new Exception("Error processing order");

            if (orderCreateDto.PaymentMethod == Domain.Payments.Enums.EPaymentMethod.CreditCard)
                throw new Exception("Payment refused. Please change your payment method");

            var customer = await _customerRepository.GetByIdAsync(orderCreateDto.CustomerId);

            if (customer is null)
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

            payment.ConfirmPayment(); // aprova pagamento

            var order = new Order(customer, payment, orderItems);

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
