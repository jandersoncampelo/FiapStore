using FiapStore.Application.Contracts.Products;
using Microsoft.AspNetCore.Mvc;

namespace FiapStore.Api.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductAppService _productService;

        public ProductController(ILogger<ProductController> logger, IProductAppService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<List<ProductDto>> Get() => await _productService.ListAsync();

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ProductDto> Get(long id) => await _productService.GetByIdAsync(id);

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ProductDto> Post([FromBody] ProductCreateDto createDto) => await _productService.CreateAsync(createDto);

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ProductDto> Put(int id, [FromBody] ProductUpdateDto updateDto) => await _productService.UpdateAsync(id, updateDto);

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task Delete(long id) => await _productService.DeleteAsync(id);
    }
}
