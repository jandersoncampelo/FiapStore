using FiapStore.Common.Repositories;
using FiapStore.Domain.Products;
using FiapStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FiapStore.Infrastructure.Repositories;

public class ProductRepository(FiapDbContext context) : Repository<Product>(context), IProductRepository
{
}
