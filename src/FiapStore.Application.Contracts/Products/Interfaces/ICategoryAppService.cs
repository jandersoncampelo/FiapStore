using FiapStore.Application.Contracts.Products.DTOs;

namespace FiapStore.Application.Contracts.Products.Interfaces
{
    public interface ICategoryAppService
    {
        Task<CategoryDto> CreateAsync(CategoryCreateDto categoryCreateDto);
        Task<CategoryDto> UpdateAsync(long id, CategoryUpdateDto categoryUpdateDto);
        Task DeleteAsync(long id);
        Task<CategoryDto> GetByIdAsync(long id);
        Task<List<CategoryDto>> ListAsync();
    }
}
