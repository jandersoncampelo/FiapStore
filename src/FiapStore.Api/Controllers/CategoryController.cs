using FiapStore.Application.Contracts.Products;
using FiapStore.Application.Contracts.Products.DTOs;
using FiapStore.Application.Contracts.Products.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FiapStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryAppService _categoryService;

        public CategoryController(ICategoryAppService categoryService)
        {
            _categoryService = categoryService;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<ActionResult<CategoryDto>> Get()
        {
            var categories = await _categoryService.ListAsync();
            return Ok(categories);
        }

        // GET api/<CategoryController>/5
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

        // POST api/<CategoryController>
        [HttpPost]
        public async Task Post([FromBody] CategoryCreateDto createDto)
        {
            await _categoryService.CreateAsync(createDto);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CategoryUpdateDto updateDto)
        {
            var result = await _categoryService.UpdateAsync(id, updateDto);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _categoryService.DeleteAsync(id);
            return Ok();
        }
    }
}
