namespace FiapStore.Application.Contracts.Products;

public interface IProductAppService
{
    Task<ProductDto> CreateAsync(ProductCreateDto productCreateDto);
    Task<ProductDto> UpdateAsync(long id, ProductUpdateDto productUpdateDto);
    Task DeleteAsync(long id);
    Task<ProductDto> GetByIdAsync(long id);
    Task<List<ProductDto>> ListAsync();   
}
