using FiapStore.Common.Repositories;
using FiapStore.Domain.Baskets;
using FiapStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FiapStore.Infrastructure.Repositories
{
    public class BasketRepository(FiapDbContext context) : Repository<Basket>(context), IBasketRepository
    {
        public async Task<Basket> GetBasketAsync(long customerId)
        {
            var query = Context.Set<Basket>().AsQueryable();

            return await query.Include(b => b.Items)
                              .ThenInclude(i => i.Product)
                              .FirstOrDefaultAsync(b => b.CustomerId == customerId);

        }
    }
}
