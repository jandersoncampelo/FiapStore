using FiapStore.Common.Repositories;
using FiapStore.Domain.Baskets;
using FiapStore.Infrastructure.Data;

namespace FiapStore.Infrastructure.Repositories
{
    public class BasketRepository(FiapDbContext context) : Repository<Basket>(context), IBasketRepository
    {
    }
}
