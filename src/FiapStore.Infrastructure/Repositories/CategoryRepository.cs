using FiapStore.Common.Repositories;
using FiapStore.Domain.Products;
using FiapStore.Domain.Products.Repositories;
using FiapStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FiapStore.Infrastructure.Repositories;

public class CategoryRepository(FiapDbContext context) : Repository<Category>(context), ICategoryRepository
{
}
