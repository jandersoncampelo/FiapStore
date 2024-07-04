namespace FiapStore.Domain.Shoppers
{
    public interface IShopperRepository
    {
        Task<Shopper> GetAsync(Guid id);
        Task AddAsync(Shopper shopper);
        Task UpdateAsync(Shopper shopper);
    }
}