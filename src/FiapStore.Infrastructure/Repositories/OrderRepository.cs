using FiapStore.Common.Repositories;
using FiapStore.Domain.Orders;
using FiapStore.Domain.Products;
using FiapStore.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiapStore.Infrastructure.Repositories
{
    public class OrderRepository(FiapDbContext context) : Repository<Order>(context), IOrderRepository
    {
    }
}
