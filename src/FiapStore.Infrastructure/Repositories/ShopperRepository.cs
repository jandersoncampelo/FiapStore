using FiapStore.Common.Repositories;
using FiapStore.Domain.Shoppers;
using FiapStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FiapStore.Infrastructure.Repositories;

public class ShopperRepository(FiapDbContext context) : Repository<Shopper>(context), IShopperRepository
{
}
