namespace FiapStore.Application.Contracts.Basket;

public interface IBasketAppService
{
    Task AddItemAsync(long customerId, long productId, int quantity);
    Task RemoveItemAsync(long customerId, long productId);
    Task UpdateItemAsync(long customerId, long productId, int quantity);
    Task ClearBasketAsync(long customerId);
    Task<BasketDto> GetBasketAsync(long customerId);
}
