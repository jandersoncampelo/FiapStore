using FiapStore.Common.Repositories;
using FiapStore.Domain.Orders;
using FiapStore.Infrastructure.Data;

namespace FiapStore.Infrastructure.Repositories
{
    internal class OrderRepository(FiapDbContext context) : Repository<Order>(context), IOrderRepository
    {
    }
}
