using FiapStore.Common.Repositories;
using FiapStore.Domain.Products;
using FiapStore.Infrastructure.Data;

namespace FiapStore.Infrastructure.Repositories;

public class CategoryRepository(FiapDbContext context) : Repository<Category>(context), ICategoryRepository
{
}
