using FiapStore.Common.Repositories;

namespace FiapStore.Domain.Baskets
{
    public interface IBasketRepository : IRepository<Basket>
    {
        Task<Basket> GetBasketAsync(long customerId);
    }
}
