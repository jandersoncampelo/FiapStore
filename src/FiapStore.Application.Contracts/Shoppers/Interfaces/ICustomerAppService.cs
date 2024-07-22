using FiapStore.Application.Contracts.Products;

namespace FiapStore.Application.Contracts.Customers;

public interface ICustomerAppService
{
    Task<CustomerDto> CreateAsync(CustomerCreateDto shopperCreateDto);
    Task<CustomerDto> UpdateAsync(long id, CustomerUpdateDto shopperUpdateDto);
    Task DeleteAsync(long id);
    Task<CustomerDto> GetByIdAsync(long id);
    Task<List<CustomerDto>> ListAsync();
}
