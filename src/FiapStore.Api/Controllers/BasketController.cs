using FiapStore.Application.Contracts.Basket;
using Microsoft.AspNetCore.Mvc;

namespace FiapStore.Api.Controllers
{
    [Route("api/basket")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly ILogger<BasketController> _logger;
        private readonly IBasketAppService _basketAppService;

        public BasketController(ILogger<BasketController> logger, IBasketAppService basketAppService)
        {
            _logger = logger;
            _basketAppService = basketAppService;
        }

        [HttpPost("{customerId}/items")]
        public async Task<IActionResult> AddItemAsync(long customerId, [FromBody] AddBasketItemRequest request)
        {
            await _basketAppService.AddItemAsync(customerId, request.ProductId, request.Quantity);
            return Ok();
        }

        [HttpDelete("{customerId}/items/{productId}")]
        public async Task<IActionResult> RemoveItemAsync(long customerId, long productId)
        {
            await _basketAppService.RemoveItemAsync(customerId, productId);
            return Ok();
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetBasketAsync(long customerId)
        {
            var basket = await _basketAppService.GetBasketAsync(customerId);
            return Ok(basket);
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> ClearBasketAsync(long customerId)
        {
            await _basketAppService.ClearBasketAsync(customerId);
            return Ok();
        }

        [HttpPut("{customerId}/items/{productId}")]
        public async Task<IActionResult> UpdateItemAsync(long customerId, long productId, [FromBody] UpdateBasketItemRequest request)
        {
            await _basketAppService.UpdateItemAsync(customerId, productId, request.Quantity);
            return Ok();
        }
    }
}
