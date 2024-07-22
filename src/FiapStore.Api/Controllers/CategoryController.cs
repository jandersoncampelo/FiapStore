using FiapStore.Application.Contracts.Category;
using Microsoft.AspNetCore.Mvc;

namespace FiapStore.Api.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryAppService _categoryService;

        public CategoryController(ILogger<CategoryController> logger, ICategoryAppService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _categoryService.ListAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _categoryService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryCreateDto categoryCreate)
        {
            var result = await _categoryService.CreateAsync(categoryCreate);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CategoryUpdateDto categoryUpdate)
        {
            var result = await _categoryService.UpdateAsync(id, categoryUpdate);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public Task<IActionResult> Delete(int id)
        {
            _categoryService.DeleteAsync(id);
            return Task.FromResult<IActionResult>(NoContent());
        }
    }
}
