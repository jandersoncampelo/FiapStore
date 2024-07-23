using FiapStore.Application.Contracts.Orders.DTOs;
using FiapStore.Application.Contracts.Orders.Interfaces;
using FiapStore.Application.Contracts.Products;
using FiapStore.Application.Contracts.Products.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FiapStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderAppService _orderAppService;
        public OrderController(IOrderAppService orderAppService)
        {
            _orderAppService = orderAppService;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public async Task<ActionResult<OrderDto>> Get()
        {
            var orders = await _orderAppService.ListAsync();
            return Ok(orders);
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _orderAppService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task Post([FromBody] OrderCreateDto createDto)
        {
            await _orderAppService.CreateAsync(createDto);
        }
    }
}
