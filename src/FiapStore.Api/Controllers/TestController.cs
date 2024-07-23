using FiapStore.Application.Contracts.Category;
using FiapStore.Application.Contracts.Customers;
using FiapStore.Application.Contracts.Orders.DTOs;
using FiapStore.Application.Contracts.Orders.Interfaces;
using FiapStore.Application.Contracts.Products;
using FiapStore.Application.Contracts.Products.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FiapStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ICategoryAppService _categoryAppService;
        private readonly IProductAppService _productAppService;
        private readonly ICustomerAppService _customerAppService;
        private readonly IOrderAppService _orderAppService;
        public TestController(ICategoryAppService categoryAppService, IProductAppService productAppService,
            ICustomerAppService customerAppService, IOrderAppService orderAppService)
        {
            _categoryAppService = categoryAppService;
            _productAppService = productAppService;
            _customerAppService = customerAppService;
            _orderAppService = orderAppService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var shopper = new CustomerCreateDto("André", "Anré Pereira Fonseca", "andre@teste.com", "123456", "976757675", "Avnida.10", "São Paulo", "SP", "0101025", "Brasil");

            await _customerAppService.CreateAsync(shopper);

            var category = new CategoryCreateDto("Eletrônico", "Eletrônico");

            await _categoryAppService.CreateAsync(category);

            var product1 = new ProductCreateDto("Celular LG", "Celular LG", 1000, 100, 1);

            await _productAppService.CreateAsync(product1);

            var product2 = new ProductCreateDto("Celular Nokia", "Celular Nokia", 900, 50, 1);

            await _productAppService.CreateAsync(product2);

            var order = new OrderCreateDto(1, Domain.Payments.Enums.EPaymentMethod.Pix, new List<OrderItemDto>
            {
                new OrderItemDto(1, 3, 1000),
                new OrderItemDto (2, 3, 900),
            });

            await _orderAppService.CreateAsync(order);

            return Ok();
        }
    }
}
