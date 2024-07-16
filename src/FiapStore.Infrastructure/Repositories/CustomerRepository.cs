using FiapStore.Common.Repositories;
using FiapStore.Domain.Customers;
using FiapStore.Infrastructure.Data;

namespace FiapStore.Infrastructure.Repositories;

public class CustomerRepository(FiapDbContext context) : Repository<Customer>(context), ICustomerRepository
{
}
