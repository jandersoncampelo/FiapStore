using FiapStore.Application.Contracts.Products;

namespace FiapStore.Application.Contracts.Shoppers;

public interface IShopperAppService
{
    Task<ShopperDto> CreateAsync(ShopperCreateDto shopperCreateDto);
    Task<ShopperDto> UpdateAsync(long id, ShopperUpdateDto shopperUpdateDto);
    Task DeleteAsync(long id);
    Task<ShopperDto> GetByIdAsync(long id);
    Task<List<ShopperDto>> ListAsync();
}
